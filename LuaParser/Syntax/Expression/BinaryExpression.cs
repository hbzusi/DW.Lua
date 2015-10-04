using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class BinaryExpression : LuaExpression
    {
        public BinaryExpression(LuaExpression leftExpression, LuaExpression rightExpression, string operation)
        {
        }

        public override IEnumerable<Unit> Children { get; }
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