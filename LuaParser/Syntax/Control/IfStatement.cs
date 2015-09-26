using System.Collections.Generic;

namespace LuaParser.Syntax.Control
{
    class IfStatement : Statement
    {
        public IfStatement(Expression condition, StatementBlock ifBlock, StatementBlock elseBlock)
        {
            Condition = condition;
            IfBlock = ifBlock;
            ElseBlock = elseBlock;
        }

        public override IEnumerable<Unit> Children { get; }
        public Expression Condition { get; private set; }
        public StatementBlock IfBlock { get; private set; }
        public StatementBlock ElseBlock { get; private set; }
    }
}
