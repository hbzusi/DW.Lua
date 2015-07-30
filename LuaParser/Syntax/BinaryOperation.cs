using System.Collections.Generic;

namespace LuaParser.Syntax
{
    class BinaryOperation : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}