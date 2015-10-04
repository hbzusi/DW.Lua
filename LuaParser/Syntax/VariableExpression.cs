using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax
{
    public class VariableExpression : LuaExpression
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

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}