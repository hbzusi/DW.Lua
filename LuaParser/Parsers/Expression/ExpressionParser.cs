using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    /// <summary>
    /// Base class for Lua expression parsers
    /// </summary>
    public abstract class ExpressionParser
    {
        /// <summary>
        /// Parses an expression from reader
        /// Advances the TokenEnumerator one past last expression token
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract LuaExpression Parse(ITokenEnumerator reader, IParserContext context);
    }
}