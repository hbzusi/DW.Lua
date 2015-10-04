using System;
using System.Collections.Generic;
using System.Text;
using DW.Lua.Extensions;

namespace DW.Lua.Syntax
{
    public class DoEndBlock : LuaStatement, IEquatable<DoEndBlock>
    {
        public StatementBlock Body { get; }

        public DoEndBlock(StatementBlock body)
        {
            Body = body;
        }

        public override IEnumerable<Unit> Children { get { yield return Body; } }

        public bool Equals(DoEndBlock other)
        {
            return other != null && Equals(Body, other.Body);
        }

        public override string ToString()
        {
            return new StringBuilder().AppendLine("do").AppendLine(Body.ToString()).AppendLine("end").ToString();
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return Body.GetHashCode();
        }
    }
}