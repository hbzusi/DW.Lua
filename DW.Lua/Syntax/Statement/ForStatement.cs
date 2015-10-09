using System.Collections.Generic;
using System.Text;

namespace DW.Lua.Syntax.Statement
{
    internal class ForStatement : LuaStatement
    {
        public IEnumerable<LuaExpression> Conditions { get; }
        public StatementBlock Body { get; }

        public ForStatement(IEnumerable<LuaExpression> conditions, StatementBlock body)
        {
            Conditions = conditions;
            Body = body;
        }

        public override IEnumerable<Unit> Children
        {
            get
            {
                foreach (var condition in Conditions)
                    yield return condition;
                yield return Body;
            }
        }
        public override string ToString()
        {
            return new StringBuilder()
                .Append("for ").Append(string.Join(", ", Conditions)).AppendLine(" do")
                .AppendLine(Body.ToString())
                .AppendLine("end")
                .ToString();
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}