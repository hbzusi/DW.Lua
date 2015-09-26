using System.Collections.Generic;

namespace LuaParser.Syntax
{
    public class StatementBlock : Statement
    {
        public StatementBlock()
        {
            Statements = new List<Statement>();
        }

        public IList<Statement> Statements { get; }

        public override IEnumerable<Unit> Children => Statements;
    }
}