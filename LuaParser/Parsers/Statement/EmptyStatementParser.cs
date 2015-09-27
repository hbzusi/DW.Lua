using DW.Lua.Exceptions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Statement
{
    internal class EmptyStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            var token = reader.GetAndAdvance();
            if (string.IsNullOrWhiteSpace(token) || token == Token.Semicolon)
                return new EmptyStatement();
            throw new UnexpectedTokenException(token);
        }
    }
}