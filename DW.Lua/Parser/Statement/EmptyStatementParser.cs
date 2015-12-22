using DW.Lua.Exceptions;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal class EmptyStatementParser : IStatementParser
    {
        public virtual LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var token = reader.GetAndMoveNext();
            if (string.IsNullOrWhiteSpace(token.Value) || token.Value == LuaToken.Semicolon)
                return new EmptyStatement();
            throw new UnexpectedTokenException(token);
        }
    }
}