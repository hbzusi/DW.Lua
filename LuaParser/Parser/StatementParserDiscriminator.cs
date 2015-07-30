using System.IO;

namespace LuaParser.Parser
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(TokenEnumerator reader)
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