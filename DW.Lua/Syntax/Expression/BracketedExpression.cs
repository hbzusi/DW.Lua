using System;
using System.Collections.Generic;
using DW.Lua.Extensions;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Expression
{
    public class BracketedExpression : LuaExpression, IEquatable<BracketedExpression>
    {
        public BracketedExpression([NotNull] LuaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            ContainedExpression = expression;
        }

        public override IEnumerable<Unit> Children => new[] {ContainedExpression};

        public bool Equals(BracketedExpression other)
        {
            return ContainedExpression?.Equals(other.ContainedExpression) ?? false;
        }

        public override string ToString()
        {
            return $"('{ContainedExpression}')";
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return ContainedExpression?.GetHashCode() ?? 0;
        }

        public LuaExpression ContainedExpression { get; }
    }
}