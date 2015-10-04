using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Expression
{
    internal class FunctionCallExpression : LuaExpression, IEquatable<FunctionCallExpression>
    {

        public FunctionCallExpression(string name, IEnumerable<LuaExpression> parameters)
        {
            FunctionName = name;
            Parameters = parameters.ToList();
        }

        public override IEnumerable<Unit> Children => Parameters;

        public string FunctionName { get; }
        public IList<LuaExpression> Parameters { get; }

        public bool Equals([CanBeNull] FunctionCallExpression other)
        {
            return other != null && FunctionName == other.FunctionName && Parameters.SequenceEqual(other.Parameters);
        }

        public override string ToString()
        {
            return
                new StringBuilder().Append(FunctionName)
                    .Append("(")
                    .Append(String.Join(",", Parameters))
                    .Append(")")
                    .ToString();
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(FunctionName.GetHashCode(), Parameters);
        }
    }
}