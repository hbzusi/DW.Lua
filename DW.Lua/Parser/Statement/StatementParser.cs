using DW.Lua.Lexer;
using DW.Lua.Misc;
using JetBrains.Annotations;

namespace DW.Lua.Parser.Statement
{
    /// <summary>
    /// Base class for statement parsers
    /// </summary>
    internal abstract class StatementParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract Syntax.LuaStatement Parse([NotNull]INextAwareEnumerator<Token> reader, [NotNull]IParserContext context);
    }
}