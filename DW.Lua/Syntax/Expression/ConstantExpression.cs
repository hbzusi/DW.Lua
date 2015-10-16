using System;
using System.Collections.Generic;
using DW.Lua.Extensions;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Expression
{
    public class ConstantExpression : LuaExpression, IEquatable<ConstantExpression>
    {
        public LuaValue Value { get; }

        public ConstantExpression(LuaValue value)
        {
            Value = value;
        }

        public override IEnumerable<Unit> Children => new Unit[0];

        public bool Equals([CanBeNull] ConstantExpression other)
        {
            return Value.Equals(other?.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
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