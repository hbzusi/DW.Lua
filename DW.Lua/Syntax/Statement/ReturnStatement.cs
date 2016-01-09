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