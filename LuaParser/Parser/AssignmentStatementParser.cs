using System;
using System.IO;
using System.Linq;
using System.Text;
using LuaParser.Syntax;

namespace LuaParser.Parser
{
    internal class AssignmentStatementParser : StatementParser
    {
        private readonly string _initialToken;

        public AssignmentStatementParser(string initialToken)
        {
            this._initialToken = initialToken;
        }

        public override Statement Parse(TextReader reader)
        {
            bool local = false;
            var variablesStringBuilder = new StringBuilder();
            var expressionsStringBuilder = new StringBuilder();
            if (_initialToken == "local")
                local = true;
            else
                variablesStringBuilder.Append(_initialToken);

            for (int next; (next = reader.Read()) != EqualsSignCode;)
            {
                if (next == -1)
                    throw new EndOfFileException();
                variablesStringBuilder.Append((char)next);
            }

            for (int next; (next = reader.Read()) >= 0; )
            {
                if (next == '\n' || next == SemicolonCode)
                    break;
                expressionsStringBuilder.Append((char)next);
            }
            var variables = variablesStringBuilder.ToString().Split(',');
            var expressions = expressionsStringBuilder.ToString().Split(',');

            return new Assignment
            {
                Local = local,
                Variables = variables.Select(s => new Variable {Name = s}).ToList()
            };
        }

        private const int EqualsSignCode = '=';
        private const int SemicolonCode = ';';
    }

    internal class EndOfFileException : Exception
    {
    }
}