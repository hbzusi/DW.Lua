using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Statement
{
    internal class ReturnStatement : LuaStatement
    {
        public ReturnStatement(LuaExpression returnedExpression)
        {
            ReturnedExpression = returnedExpression;
        }

        public LuaExpression ReturnedExpression { get; }

        public override IEnumerable<Unit> Children
        {
            get { yield return ReturnedExpression; }
        }

        public override string ToString()
        {
            return "return " + ReturnedExpression;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is ReturnStatement other) && ReturnedExpression.Equals(other.ReturnedExpression);
        }

        public override int GetHashCode()
        {
            return ReturnedExpression.GetHashCode();
        }
    }
}