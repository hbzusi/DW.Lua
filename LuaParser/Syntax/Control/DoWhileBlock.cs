using System.Collections.Generic;
using System.Linq;

namespace LuaParser.Syntax.Control
{
    internal class DoWhileBlock : Statement
    {
        public Expression Condition { get; set; }
        public StatementBlock StatementBlock { get; set; }

        public override IEnumerable<Unit> Children
        {
            get { return new Unit[] {Condition}.Concat(StatementBlock.Statements); }
        }
    }
}