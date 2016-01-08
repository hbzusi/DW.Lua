using System;
using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Syntax
{
    public class TableIndexExpression : LuaExpression, IEquatable<TableIndexExpression>
    {
        public TableIndexExpression(Variable tableVariable, LuaExpression indexExpression)
        {
            TableVariable = tableVariable;
            IndexExpression = indexExpression;
        }

        public Variable TableVariable { get; }

        public LuaExpression IndexExpression { get; }

        public override IEnumerable<Unit> Children
        {
            get { yield return IndexExpression; }
        }

        public bool Equals(TableIndexExpression other)
        {
            return other != null && Equals(TableVariable, other.TableVariable) &&
                   Equals(IndexExpression, other.IndexExpression);
        }

        public override string ToString()
        {
            return $"{TableVariable}[{IndexExpression}]";
        }

        public override bool Equals(object other)
        {
            return other is TableIndexExpression && Equals((TableIndexExpression) other);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(8637, TableVariable, IndexExpression);
        }
    }
}