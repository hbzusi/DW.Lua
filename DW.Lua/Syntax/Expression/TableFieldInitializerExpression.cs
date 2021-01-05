using System;
using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Syntax.Expression
{
    public class TableFieldInitializerExpression : LuaExpression, IEquatable<TableFieldInitializerExpression>, IAssignmentTarget
    {
        public TableFieldInitializerExpression(Variable tableVariable, LuaExpression indexExpression, LuaExpression valueExpression)
        {
            TableVariable = tableVariable;
            IndexExpression = indexExpression;
            ValueExpression = valueExpression;
        }

        public Variable TableVariable { get; }

        public LuaExpression IndexExpression { get; }

        public LuaExpression ValueExpression { get; }

        public override IEnumerable<Unit> Children
        {
            get 
            { 
                yield return IndexExpression;
                yield return ValueExpression;
            }
        }

        public bool Equals(TableFieldInitializerExpression other)
        {
            return other != null && Equals(TableVariable, other.TableVariable) &&
                   Equals(IndexExpression, other.IndexExpression) &&
                   Equals(ValueExpression, other.ValueExpression);
        }

        public override string ToString()
        {
            return $"{TableVariable}[{IndexExpression}] = {ValueExpression}";
        }

        public override bool Equals(object other)
        {
            return other is TableFieldInitializerExpression && Equals((TableFieldInitializerExpression) other);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(8637, TableVariable, IndexExpression, ValueExpression);
        }
    }
}