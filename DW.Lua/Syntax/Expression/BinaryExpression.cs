using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class BinaryExpression : LuaExpression, IEquatable<BinaryExpression>
    {
        public BinaryExpression(LuaExpression leftExpression, LuaExpression rightExpression, string operation)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            this.Operation = operation;
        }

        public override IEnumerable<Unit> Children
        {
            get
            {
                yield return LeftExpression;
                yield return RightExpression;
            }
        }

        public string Operation { get; }

        public LuaExpression LeftExpression { get; }

        public LuaExpression RightExpression { get; }

        public override string ToString()
        {
            return $"{LeftExpression} {Operation} {RightExpression}";
        }

        public bool Equals(BinaryExpression other)
        {
            return ReferenceEquals(this, other)
                || this.Operation == other.Operation
                && this.LeftExpression.Equals(other.LeftExpression)
                && this.RightExpression.Equals(other.RightExpression);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is BinaryExpression b && Equals(b);
        }

        public override int GetHashCode()
        {
            return this.Operation.GetHashCode() ^ this.LeftExpression.GetHashCode() ^ this.RightExpression.GetHashCode();
        }
    }
}