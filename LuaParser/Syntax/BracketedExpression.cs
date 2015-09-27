using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class BracketedExpression : LuaExpression, IEquatable<BracketedExpression>
    {
        public BracketedExpression([NotNull] LuaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Expression = expression;
        }

        public override IEnumerable<Unit> Children => new[] {Expression};

        public bool Equals(BracketedExpression other)
        {
            return Expression?.Equals(other.Expression) ?? false;
        }

        public override string ToString()
        {
            return $"('{Expression}')";
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return Expression?.GetHashCode() ?? 0;
        }

        public LuaExpression Expression { get; }
    }
}