using System;
using System.Collections.Generic;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class DoEndBlock : LuaStatement, IEquatable<DoEndBlock>
    {
        public StatementBlock StatementBlock { get; }

        public DoEndBlock(StatementBlock statementBlock)
        {
            StatementBlock = statementBlock;
        }

        public override IEnumerable<Unit> Children { get; }

        public bool Equals(DoEndBlock other)
        {
            return other != null && Equals(StatementBlock, other.StatementBlock);
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return StatementBlock.GetHashCode();
        }
    }
}