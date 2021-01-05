using System.Collections.Generic;

using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class FunctionDeclarationStatementParser : IStatementParser
    {
        private readonly bool _local;

        public FunctionDeclarationStatementParser(bool local)
        {
            _local = local;
        }

        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Function);
            if (reader.Next.Value == LuaToken.Colon)
            {
                reader.MoveNext();
                reader.MoveNext();
            }
            var functionName = reader.GetAndMoveNext().Value;
            reader.VerifyExpectedToken(LuaToken.LeftBracket, LuaToken.Dot);
            while (reader.Current.Value == LuaToken.Dot
                    && reader.MoveNext()
                    && LuaToken.IsIdentifier(reader.Current.Value))
            {
                var name = reader.GetAndMoveNext().Value;
                functionName = $"{functionName}.{name}";
            }

            var argumentNames = new List<string>();
            reader.MoveNext();
            while (reader.Current.Value != LuaToken.RightBracket)
            {
                argumentNames.Add(reader.Current.Value);
                reader.MoveNext();
                reader.VerifyExpectedToken(LuaToken.Comma, LuaToken.RightBracket);
                if (reader.Current.Value == LuaToken.RightBracket)
                    break;
                reader.MoveNext();
            }
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightBracket);
            var scope = context.AcquireScope();
            argumentNames.ForEach(a => scope.AddVariable(new Variable(a)));
            var statementsParser = new StatementBlockParser(Keywords.End);
            var body = statementsParser.ParseBlock(reader, context);
            context.ReleaseScope(scope);
            return new FunctionDeclarationStatement(functionName, argumentNames, body);
        }
    }
}