using System;
using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Syntax.Expression
{
    public class TableIndexExpression : LuaExpression, IEquatable<TableIndexExpression>, IAssignmentTarget
    {
        public TableIndexExpression(Variable tableVariable, LuaExpression indexExpression) : this(new VariableExpression(tableVariable), indexExpression)
        {
        }
        public TableIndexExpression(LuaExpression tableExpression, LuaExpression indexExpression)
        {
            this.TableExpression = tableExpression;
            this.IndexExpression = indexExpression;
        }

        public LuaExpression TableExpression { get; }

        public LuaExpression IndexExpression { get; }

        public override IEnumerable<Unit> Children
        {
            get { yield return IndexExpression; }
        }

        public bool Equals(TableIndexExpression other)
        {
            return other != null && Equals(TableExpression, other.TableExpression) &&
                   Equals(IndexExpression, other.IndexExpression);
        }

        public override string ToString()
        {
            return $"{TableExpression}[{IndexExpression}]";
        }

        public override bool Equals(object other)
        {
            return other is TableIndexExpression && Equals((TableIndexExpression) other);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(8637, TableExpression, IndexExpression);
        }
    }
}