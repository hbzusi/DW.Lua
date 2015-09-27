using System;
using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;

namespace DW.Lua.Syntax
{
    public class StatementBlock : LuaStatement, IEquatable<StatementBlock>
    {
        private readonly List<LuaStatement> _statements;

        public StatementBlock(params LuaStatement[] statements) : this(statements.AsEnumerable()) { }

        public StatementBlock(IEnumerable<LuaStatement> statements)
        {
            _statements = statements.ToList();
        }

        public IList<LuaStatement> Statements => _statements.AsReadOnly();

        public override IEnumerable<Unit> Children => Statements;

        public bool Equals(StatementBlock other)
        {
            return other != null && Statements.SequenceEqual(other.Statements);
        }

        public override string ToString()
        {
            return String.Join("\n", _statements);
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