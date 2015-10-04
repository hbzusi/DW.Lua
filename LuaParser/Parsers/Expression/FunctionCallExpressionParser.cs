using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class FunctionCallExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var name = reader.Current;
            reader.Advance();
            reader.VerifyExpectedToken(LuaToken.LeftBracket);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression(name, parametersParser.Parse(reader, context).ToList());
            reader.VerifyExpectedToken(LuaToken.RightBracket);
            return expression;
        }
    }
}