using System.Collections.Generic;
using LuaParser.Syntax;

namespace LuaParser.Control
{
    class BreakStatement : Statement
    {
        public override IEnumerable<Unit> Children
        {
            get { return new Unit[0]; }
        }
    }
}