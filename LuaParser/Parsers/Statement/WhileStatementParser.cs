using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class WhileStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader)
        {
            reader.VerifyExpectedTokenAndAdvance(Keyword.While);
            var conditionExpression = SyntaxParser.ReadExpression(reader);
            reader.VerifyExpectedTokenAndAdvance(Keyword.Do);
            var blockParser = new StatementBlockParser(Keyword.End);
            var bodyBlock = blockParser.ParseBlock(reader);
            return new WhileStatement(conditionExpression, bodyBlock);
        }
    }
}