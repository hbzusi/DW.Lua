using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == "if")
                return new IfStatementParser();
            if (reader.Current == "while")
                return new WhileStatementParser();
            if (reader.Current == Token.Semicolon)
                return new EmptyStatementParser();
            return new AssignmentStatementParser();
        }
    }
}