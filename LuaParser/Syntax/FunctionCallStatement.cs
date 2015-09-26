using System.Collections.Generic;

namespace LuaParser.Syntax
{
    class FunctionCallStatement : Statement {
        public override IEnumerable<Unit> Children => new Unit[0];
    }
}