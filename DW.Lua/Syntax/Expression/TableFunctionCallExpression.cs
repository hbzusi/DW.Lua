using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Expression
{
    public class TableFunctionCallExpression : LuaExpression, IEquatable<TableFunctionCallExpression>
    {
        public TableFunctionCallExpression(Variable table, LuaExpression index, IEnumerable<LuaExpression> parameters)
        {
            Table = table;
            Index = index;
            Parameters = parameters.ToList();
        }

        public LuaExpression Index { get; }

        public Variable Table { get; }

        public TableFunctionCallExpression(Variable table, LuaExpression index, params LuaExpression[] parameters)
            : this(table, index, parameters.AsEnumerable())
        {
        }

        public override IEnumerable<Unit> Children => Parameters;
        
        public IList<LuaExpression> Parameters { get; }

        public bool Equals([CanBeNull] TableFunctionCallExpression other)
        {
            return other != null && Equals(Table,other.Table) && Equals(Index,other.Index) && Parameters.SequenceEqual(other.Parameters);
        }

        public override string ToString()
        {
            return $"{Table}[{Index}]({string.Join(",", Parameters)})";
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(Table.GetHashCode(), Parameters);
        }
    }
}