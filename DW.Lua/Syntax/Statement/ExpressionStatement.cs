using System;
using System.Collections.Generic;

using DW.Lua.Extensions;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Syntax.Statement
{
    public class FunctionCallStatement : LuaStatement, IEquatable<FunctionCallStatement>
    {
        private readonly FunctionCallExpression _expression;

        public FunctionCallStatement(FunctionCallExpression expression)
        {
            _expression = expression;
        }

        public FunctionCallExpression Expression => _expression;

        public override IEnumerable<Unit> Children => new LuaExpression[] { Expression };

        public bool Equals(FunctionCallStatement other)
        {
            return other != null && 
                   Expression.Equals(other.Expression);
        }

        public override string ToString()
        {
            return Expression.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Expression.GetHashCode();
                return hash;
            }
        }
    }
}