using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class BracketedExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(Token.LeftBracket);
            reader.Advance();
            var expression = SyntaxParser.ReadExpression(reader);
            reader.VerifyExpectedToken(Token.RightBracket);
            reader.Advance();
            return new BracketedExpression(expression);
        }
    }
}