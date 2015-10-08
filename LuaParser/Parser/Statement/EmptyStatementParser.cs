using DW.Lua.Exceptions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parsers.Statement
{
    internal class EmptyStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            var token = reader.GetAndMoveNext();
            if (string.IsNullOrWhiteSpace(token) || token == LuaToken.Semicolon)
                return new EmptyStatement();
            throw new UnexpectedTokenException(token);
        }
    }
}