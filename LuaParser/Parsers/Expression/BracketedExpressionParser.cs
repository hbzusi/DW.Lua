using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class BracketedExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftBracket);
            reader.MoveNext();
            var expression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedToken(LuaToken.RightBracket);
            reader.MoveNext();
            return new BracketedExpression(expression);
        }
    }
}