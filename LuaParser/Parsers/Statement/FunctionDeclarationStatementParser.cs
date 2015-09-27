using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class FunctionDeclarationStatementParser : StatementParser
    {
        public override Syntax.LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndAdvance(Keyword.Function);
            if (reader.Next == Token.Colon)
            {
                reader.Advance();
                reader.Advance();
            }
            var functionName = reader.GetAndAdvance();
            reader.VerifyExpectedToken(Token.LeftBracket);

            var argumentNames = new List<string>();
            while (reader.Current != Token.RightBracket)
            {
                reader.Advance();
                argumentNames.Add(reader.Current);
                reader.Advance();
                reader.VerifyExpectedToken(Token.Comma, Token.RightBracket);
            }
            reader.VerifyExpectedTokenAndAdvance(Token.RightBracket);
            var statements = new List<Syntax.LuaStatement>();
            while (reader.Current != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader));
            reader.VerifyExpectedToken(Keyword.End);

            return new FunctionDeclarationStatement(functionName,argumentNames,new StatementBlock(statements));
        }
    }
}