using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parsers.Statement
{
    internal class FunctionDeclarationStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keyword.Function);
            if (reader.Next == LuaToken.Colon)
            {
                reader.MoveNext();
                reader.MoveNext();
            }
            var functionName = reader.GetAndMoveNext();
            reader.VerifyExpectedToken(LuaToken.LeftBracket);

            var argumentNames = new List<string>();
            while (reader.Current != LuaToken.RightBracket)
            {
                reader.MoveNext();
                argumentNames.Add(reader.Current);
                reader.MoveNext();
                reader.VerifyExpectedToken(LuaToken.Comma, LuaToken.RightBracket);
            }
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightBracket);
            var statementsParser = new StatementBlockParser();
            var body = statementsParser.ParseBlock(reader, context);
            reader.VerifyExpectedTokenAndMoveNext(Keyword.End);

            return new FunctionDeclarationStatement(functionName,argumentNames,body);
        }
    }
}