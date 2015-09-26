using LuaParser.Exceptions;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class FunctionCallExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            var name = reader.Current;
            reader.Advance();
            reader.VerifyExpectedToken(Token.LeftBracket);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression
            {
                FunctionName = name,
                Parameters = parametersParser.Parse(reader)
            };
            reader.VerifyExpectedToken(Token.RightBracket);
            return expression;
        }
    }
}