namespace LuaParser.Parsers.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(ITokenEnumerator reader)
        {
            switch (reader.Current)
            {
                case "if":
                    return new IfStatementParser();
                case "while":
                    return new WhileStatementParser();
            }
            return new AssignmentStatementParser();
        }
    }
}