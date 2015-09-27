using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax
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