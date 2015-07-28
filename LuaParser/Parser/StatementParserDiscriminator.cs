using System;
using System.IO;
using LuaParser.Syntax;

namespace LuaParser.Parser
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(string word)
        {
            switch (word)
            {
                case "if":
                    return new IfStatementParser();
                case "while":
                    return new WhileStatementParser();
            }
            return new AssignmentStatementParser(word);
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
        public abstract Statement Parse(TextReader reader);
    }
}