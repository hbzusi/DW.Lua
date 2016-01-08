using System;
using System.Collections.Generic;
using System.Text;

namespace DW.Lua.Syntax.Statement
{
    internal class ForStatement : LuaStatement
    {
        public ForStatement(IEnumerable<LuaExpression> conditions, StatementBlock body)
        {
            Conditions = conditions;
            Body = body;
        }

        public IEnumerable<LuaExpression> Conditions { get; }
        public StatementBlock Body { get; }

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
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}