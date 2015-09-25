using System.Collections.Generic;

namespace LuaParser.Syntax.Control
{
    class BreakStatement : Statement
    {
        public override IEnumerable<Unit> Children
        {
            get { return new Unit[0]; }
        }
    }
}