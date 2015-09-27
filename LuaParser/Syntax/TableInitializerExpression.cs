using System;
using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;
using JetBrains.Annotations;

namespace DW.Lua.Syntax
{
    public class TableInitializerExpression : LuaExpression, IEquatable<TableInitializerExpression>
    {
        [NotNull] private readonly List<LuaExpression> _expressions;

        public TableInitializerExpression([NotNull] IEnumerable<LuaExpression> expressions)
        {
            if (expressions == null) throw new ArgumentNullException(nameof(expressions));
            _expressions = new List<LuaExpression>(expressions);
        }

        public TableInitializerExpression(params LuaExpression[] expressions) : this(expressions.AsEnumerable())
        {
        }

        public IEnumerable<LuaExpression> Expressions => _expressions.AsReadOnly();

        public override IEnumerable<Unit> Children { get; }

        public bool Equals(TableInitializerExpression other)
        {
            return other != null && Expressions.SequenceEqual(other.Expressions);
        }

        public override string ToString()
        {
            return $"{{{string.Join(",", Expressions)}}}";
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return Expressions.GetHashCode();
        }
    }
}