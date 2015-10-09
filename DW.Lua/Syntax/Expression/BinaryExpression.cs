using System;
using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class BinaryExpression : LuaExpression
    {
        private readonly LuaExpression _leftExpression;
        private readonly LuaExpression _rightExpression;

        public BinaryExpression(LuaExpression leftExpression, LuaExpression rightExpression, string operation)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
        }

        public override IEnumerable<Unit> Children
        {
            get
            {
                yield return _leftExpression;
                yield return _rightExpression;
            }
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