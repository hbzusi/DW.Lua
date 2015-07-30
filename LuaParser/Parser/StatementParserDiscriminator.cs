using System;
using System.IO;
using LuaParser.Syntax;

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

    internal class UnknownTokenException : Exception
    {
        public UnknownTokenException(string message) : base(message)
        {

        }
    }

    internal abstract class StatementParser
    {
        public abstract Statement Parse(TokenEnumerator reader);
    }
}