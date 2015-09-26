using System;
using System.Collections.Generic;
using System.Linq;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class StatementBlock : Statement, IEquatable<StatementBlock>
    {
        private readonly List<Statement> _statements;

        public StatementBlock(params Statement[] statements) : this(statements.AsEnumerable()) { }

        public StatementBlock(IEnumerable<Statement> statements)
        {
            _statements = statements.ToList();
        }

        public IList<Statement> Statements => _statements.AsReadOnly();

        public override IEnumerable<Unit> Children => Statements;

        public bool Equals(StatementBlock other)
        {
            return other != null && Statements.SequenceEqual(other.Statements);
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            foreach (var statement in Statements)
            {
                unchecked
                {
                    hashCode += statement.GetHashCode();
                }
            }
            return hashCode;
        }
    }
}