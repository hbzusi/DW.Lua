using System.Collections.Generic;

namespace LuaParser.Syntax
{
    class UnaryOperation : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}