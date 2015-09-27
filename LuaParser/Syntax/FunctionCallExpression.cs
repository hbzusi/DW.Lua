using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.Lua.Extensions;
using JetBrains.Annotations;

namespace DW.Lua.Syntax
{
    internal class FunctionCallExpression : LuaExpression, IEquatable<FunctionCallExpression>
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new NotImplementedException(); }
        }

        public string FunctionName { get; set; }
        public IList<LuaExpression> Parameters { get; set; }

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
            throw new NotImplementedException();
        }
    }
}