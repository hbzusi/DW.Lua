using DW.Lua.Extensions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class BracketedExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftBracket);
            reader.Advance();
            var expression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedToken(LuaToken.RightBracket);
            reader.Advance();
            return new BracketedExpression(expression);
        }
    }
}