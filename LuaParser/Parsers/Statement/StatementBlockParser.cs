using System.Collections.Generic;
using System.Linq;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class StatementBlockParser : StatementParser
    {
        private readonly HashSet<string> _terminatingTokens;

        public StatementBlockParser(params string[] terminatingTokens)
            : this(Enumerable.AsEnumerable(terminatingTokens))
        {
        }

        public StatementBlockParser(IEnumerable<string> terminatingTokens)
        {
            _terminatingTokens = new HashSet<string>(terminatingTokens);
        }

        public override Syntax.LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            return ParseBlock(reader);
        }

        public StatementBlock ParseBlock(ITokenEnumerator reader)
        {
            var statements = new List<Syntax.LuaStatement>();
            while (!_terminatingTokens.Contains(reader.Current))
                statements.Add(SyntaxParser.ReadStatement(reader));
            reader.VerifyExpectedToken(_terminatingTokens);
            return new StatementBlock(statements);
        }
    }
}