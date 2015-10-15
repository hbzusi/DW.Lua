using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
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
        public abstract LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context);
    }
}