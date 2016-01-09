using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class StringConstantExpression : LuaExpression, IEquatable<StringConstantExpression>
    {
        private readonly string _value;

        public StringConstantExpression(string value)
        {
            _value = value;
        }

        public override IEnumerable<Unit> Children
        {
            get { yield break; }
        }

        public bool Equals(StringConstantExpression other)
        {
            return other != null && string.Equals(_value, other._value);
        }

        public override string ToString()
        {
            if (_value.Contains("\n"))
                return $"[[{_value}]]";
            else
                return $"\"{_value}\"";
        }

        public override bool Equals(object obj)
        {
            return obj is StringConstantExpression && Equals((StringConstantExpression) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}