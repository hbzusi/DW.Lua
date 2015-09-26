using System.Collections.Generic;

namespace LuaParser.Syntax
{
    public class Assignment : Statement
    {
        public IList<Variable> Variables { get; set; }
        public IList<Expression> Expressions { get; set; }
        public bool Local { get; set; }

        public override IEnumerable<Unit> Children => (Expressions ?? new Expression[0]);
    }
}