using LuaParser.Extensions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class WhileStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndAdvance(Keyword.While);
            var conditionExpression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedTokenAndAdvance(Keyword.Do);
            var blockParser = new StatementBlockParser(Keyword.End);
            var bodyBlock = blockParser.ParseBlock(reader, context);
            return new WhileStatement(conditionExpression, bodyBlock);
        }
    }
}