using System;
using System.Collections.Generic;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Control
{
    public class IfStatement : LuaStatement, IEquatable<IfStatement>
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

        public override IEnumerable<Unit> Children
        {
            get
            {
                yield return Condition;
                yield return IfBlock;
                if (ElseBlock != null)
                    yield return ElseBlock;
            }
        }

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("if ").Append(Condition).AppendLine(" then ");
            sb.AppendLine(IfBlock.ToString());
            if (ElseBlock != null)
                sb.AppendLine("else").AppendLine(ElseBlock.ToString());
            sb.Append(" end");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(97621, Condition, IfBlock, ElseBlock);
        }
    }
}