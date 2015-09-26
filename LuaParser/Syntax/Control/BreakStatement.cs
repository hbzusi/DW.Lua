using System.Collections.Generic;

namespace LuaParser.Syntax.Control
{
    class BreakStatement : Statement
    {
        public override IEnumerable<Unit> Children => new Unit[0];
    }
}