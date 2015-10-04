using System.Collections.Generic;

namespace DW.Lua.Syntax.Expression
{
    public class StringConstantExpression : LuaExpression
    {
        private readonly string _value;

        public StringConstantExpression(string value)
        {
            _value = value;
        }

        public override IEnumerable<Unit> Children { get { yield break; } }
        public override string ToString()
        {
            return "[[" + _value + "]]";
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