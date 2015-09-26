using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class BracketedExpression : Syntax.Expression, IEquatable<BracketedExpression>
    {
        public BracketedExpression([NotNull] Syntax.Expression expression)
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

        public Syntax.Expression Contents { get; }
    }
}