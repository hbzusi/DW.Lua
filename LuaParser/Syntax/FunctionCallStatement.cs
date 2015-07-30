using System.Collections.Generic;

namespace LuaParser.Syntax
{
    class FunctionCallStatement : Statement {
        public override IEnumerable<Unit> Children
        {
            get { return new Unit[0]; }
        }
    }
}