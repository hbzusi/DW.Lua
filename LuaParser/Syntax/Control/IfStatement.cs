using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax.Control
{
    public class IfStatement : Statement, IEquatable<IfStatement>
    {
        public IfStatement([NotNull] LuaExpression condition, [NotNull] StatementBlock ifBlock,
            [CanBeNull] StatementBlock elseBlock = null)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            if (ifBlock == null) throw new ArgumentNullException(nameof(ifBlock));
            Condition = condition;
            IfBlock = ifBlock;
            ElseBlock = elseBlock;
        }

        public override IEnumerable<Unit> Children { get; }

        [NotNull]
        public LuaExpression Condition { get; }

        [NotNull]
        public StatementBlock IfBlock { get; }

        [CanBeNull]
        public StatementBlock ElseBlock { get; }

        public bool Equals(IfStatement other)
        {
            return Condition.Equals(other.Condition) && IfBlock.Equals(other.IfBlock) &&
                   Equals(ElseBlock, other.ElseBlock);
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