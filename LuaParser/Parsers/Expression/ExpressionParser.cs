namespace LuaParser.Parsers.Expression
{
    public abstract class ExpressionParser
    {
        public abstract Syntax.Expression Parse(ITokenEnumerator reader, IParserContext context);
    }
}