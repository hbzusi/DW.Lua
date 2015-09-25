using LuaParser.Exceptions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class FunctionCallExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            var name = reader.Current;
            reader.Advance();
            if (reader.Current != "(")
                throw new UnexpectedTokenException(reader.Current);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression
            {
                FunctionName = name,
                Parameters = parametersParser.Parse(reader)
            };
            if (reader.Current != ")")
                throw new UnexpectedTokenException(reader.Current);
            return expression;
        }
    }
}