using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class TableInitializerExpression : Expression, IEquatable<TableInitializerExpression>
    {
        [NotNull] private readonly List<Expression> _expressions;

        public TableInitializerExpression([NotNull] IEnumerable<Expression> expressions)
        {
            if (expressions == null) throw new ArgumentNullException(nameof(expressions));
            _expressions = new List<Expression>(expressions);
        }

        public TableInitializerExpression(params Expression[] expressions) : this(expressions.AsEnumerable())
        {
        }

        public IEnumerable<Expression> Expressions => _expressions.AsReadOnly();

        public override IEnumerable<Unit> Children { get; }

        public bool Equals(TableInitializerExpression other)
        {
            return other != null && Expressions.SequenceEqual(other.Expressions);
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