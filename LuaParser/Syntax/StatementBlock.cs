using System.Collections.Generic;

namespace LuaParser.Syntax
{
    public class StatementBlock : Statement
    {
        public StatementBlock()
        {
            Statements = new List<Statement>();
        }

        public IList<Statement> Statements { get; private set; }

        public override IEnumerable<Unit> Children
        {
            get { return Statements; }
        }
    }
}