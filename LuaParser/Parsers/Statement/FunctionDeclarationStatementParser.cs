using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Statement
{
    internal class FunctionDeclarationStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndAdvance(Keyword.Function);
            if (reader.Next == LuaToken.Colon)
            {
                reader.Advance();
                reader.Advance();
            }
            var functionName = reader.GetAndAdvance();
            reader.VerifyExpectedToken(LuaToken.LeftBracket);

            var argumentNames = new List<string>();
            while (reader.Current != LuaToken.RightBracket)
            {
                reader.Advance();
                argumentNames.Add(reader.Current);
                reader.Advance();
                reader.VerifyExpectedToken(LuaToken.Comma, LuaToken.RightBracket);
            }
            reader.VerifyExpectedTokenAndAdvance(LuaToken.RightBracket);
            var statements = new List<LuaStatement>();
            while (reader.Current != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader, context));
            reader.VerifyExpectedTokenAndAdvance(Keyword.End);

            return new FunctionDeclarationStatement(functionName,argumentNames,new StatementBlock(statements));
        }
    }
}