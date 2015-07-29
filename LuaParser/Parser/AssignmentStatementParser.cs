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

        public override Statement Parse(TokenEnumerator reader)
        {
            bool local = false;
            var variablesStringBuilder = new StringBuilder();
            var expressionsStringBuilder = new StringBuilder();
            if (_initialToken == "local")
                local = true;
            else
                variablesStringBuilder.Append(_initialToken);

            while (reader.Current != EqualsSign)
                variablesStringBuilder.Append(reader.GetAndAdvance());

            while (reader.Current != Semicolon && reader.Current != "\n")
            {
                expressionsStringBuilder.Append(reader.GetAndAdvance());
            }
            var variables = variablesStringBuilder.ToString().Split(',');
            var expressions = expressionsStringBuilder.ToString().Split(',');

            return new Assignment
            {
                Local = local,
                Variables = variables.Select(s => new Variable {Name = s}).ToList()
            };
        }

        private const string EqualsSign = "=";

        private const string Semicolon = ";";
    }

    internal class EndOfFileException : Exception
    {
    }
}