using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == Keyword.If)
                return new IfStatementParser();
            if (reader.Current == Keyword.While)
                return new WhileStatementParser();
            if (reader.Current == Token.Semicolon)
                return new EmptyStatementParser();
            if (reader.Current == Keyword.Do)
                return new DoEndBlockStatementParser();
            return new AssignmentStatementParser();
        }
    }
}