using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaParser.Extensions;

namespace LuaParser.Syntax.Control
{
    public class WhileStatement : Statement, IEquatable<WhileStatement>
    {
        public Expression Condition { get; }
        public StatementBlock Body { get; }

        public WhileStatement(Expression condition, StatementBlock body)
        {
            Condition = condition;
            Body = body;
        }

        public override IEnumerable<Unit> Children { get; }

        public bool Equals(WhileStatement other)
        {
            return other != null && Equals(Condition, other.Condition) && Equals(Body, other.Body);
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
