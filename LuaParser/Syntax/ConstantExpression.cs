using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class ConstantExpression : LuaExpression, IEquatable<ConstantExpression>
    {
        public Value Value { get; }

        public ConstantExpression(Value value)
        {
            Value = value;
        }

        public override IEnumerable<Unit> Children => new Unit[0];

        public bool Equals([CanBeNull] ConstantExpression other)
        {
            return Value.Equals(other?.Value);
        }

        public override bool Equals([CanBeNull] object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}