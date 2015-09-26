using LuaParser.Exceptions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class EmptyStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader)
        {
            var token = reader.GetAndAdvance();
            if (string.IsNullOrWhiteSpace(token) || token == Token.Semicolon)
                return new EmptyStatement();
            throw new UnexpectedTokenException(token);
        }
    }
}