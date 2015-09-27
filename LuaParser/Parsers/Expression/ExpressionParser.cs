using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public abstract class ExpressionParser
    {
        public abstract LuaExpression Parse(ITokenEnumerator reader, IParserContext context);
    }
}