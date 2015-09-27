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
            Contents = expression;
        }

        public override IEnumerable<Unit> Children => new[] {Contents};

        public bool Equals(BracketedExpression other)
        {
            return Contents?.Equals(other.Contents) ?? false;
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return Contents?.GetHashCode() ?? 0;
        }

        public LuaExpression Contents { get; }
    }
}