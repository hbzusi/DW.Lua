using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Statement
{
    /// <summary>
    ///     Base class for statement parsers
    /// </summary>
    internal interface IStatementParser
    {
        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context);
    }
}