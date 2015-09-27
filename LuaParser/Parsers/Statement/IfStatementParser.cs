using LuaParser.Extensions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class IfStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            StatementBlock elseBlock = null;
            reader.VerifyExpectedTokenAndAdvance(Keyword.If);
            var conditionExpression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedTokenAndAdvance(Keyword.Then);

            var ifBlockParser = new StatementBlockParser(Keyword.End, Keyword.Else);
            var ifBlock = ifBlockParser.ParseBlock(reader, context);

            if (reader.Previous == Keyword.Else)
            {
                var elseBlockParser = new StatementBlockParser(Keyword.End);
                elseBlock = elseBlockParser.ParseBlock(reader, context);
            }
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}