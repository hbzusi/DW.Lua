using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class VariableExpression : LuaExpression, IEquatable<VariableExpression>
    {
        private readonly Variable _variable;

        public VariableExpression(Variable variable)
        {
            _variable = variable;
        }

        public override IEnumerable<Unit> Children
        {
            get { yield break; }
        }

        public bool Equals(VariableExpression other)
        {
            return other != null && Equals(_variable, other._variable);
        }

        public override string ToString()
        {
            return _variable.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is VariableExpression && Equals((VariableExpression) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}