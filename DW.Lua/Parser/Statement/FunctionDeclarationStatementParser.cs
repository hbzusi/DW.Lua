using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal class FunctionDeclarationStatementParser : StatementParser
    {
        private readonly bool _local;

        public FunctionDeclarationStatementParser(bool local)
        {
            _local = local;
        }

        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Function);
            if (reader.Next.Value == LuaToken.Colon)
            {
                reader.MoveNext();
                reader.MoveNext();
            }
            var functionName = reader.GetAndMoveNext();
            reader.VerifyExpectedToken(LuaToken.LeftBracket);

            var argumentNames = new List<string>();
            while (reader.Current.Value != LuaToken.RightBracket)
            {
                reader.MoveNext();
                argumentNames.Add(reader.Current.Value);
                reader.MoveNext();
                reader.VerifyExpectedToken(LuaToken.Comma, LuaToken.RightBracket);
            }
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightBracket);
            var statementsParser = new StatementBlockParser(Keywords.End);
            var body = statementsParser.ParseBlock(reader, context);

            return new FunctionDeclarationStatement(functionName.Value,argumentNames,body);
        }
    }
}