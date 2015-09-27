using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class FunctionCallExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var name = reader.Current;
            reader.Advance();
            reader.VerifyExpectedToken(Token.LeftBracket);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression
            {
                FunctionName = name,
                Parameters = parametersParser.Parse(reader, context).ToList()
            };
            reader.VerifyExpectedToken(Token.RightBracket);
            return expression;
        }
    }
}