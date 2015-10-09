using System.Collections.Generic;

namespace DW.Lua.Syntax.Statement
{
    internal class ReturnStatement : LuaStatement
    {
        public LuaExpression ReturnedExpression { get; }

        public ReturnStatement(LuaExpression returnedExpression)
        {
            ReturnedExpression = returnedExpression;
        }

        public override IEnumerable<Unit> Children { get { yield return ReturnedExpression; } }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}