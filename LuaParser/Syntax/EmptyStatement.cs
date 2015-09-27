using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class EmptyStatement : LuaStatement, IEquatable<EmptyStatement>
    {
        public override IEnumerable<Unit> Children => new Unit[0];

        public bool Equals([CanBeNull] EmptyStatement other)
        {
            return other != null;
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}