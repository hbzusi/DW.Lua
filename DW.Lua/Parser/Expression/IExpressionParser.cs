using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
{
    /// <summary>
    ///     Base class for Lua expression parsers
    /// </summary>
    public interface IExpressionParser
    {
        /// <summary>
        ///     Parses an expression from reader
        ///     Advances the TokenEnumerator one past last expression token
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context);
    }
}