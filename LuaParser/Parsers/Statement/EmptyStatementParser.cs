using LuaParser.Exceptions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class EmptyStatementParser : StatementParser
    {
        public override Syntax.LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            var token = reader.GetAndAdvance();
            if (string.IsNullOrWhiteSpace(token) || token == Token.Semicolon)
                return new EmptyStatement();
            throw new UnexpectedTokenException(token);
        }
    }
}