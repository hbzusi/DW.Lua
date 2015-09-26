using System;
using System.Collections.Generic;

namespace LuaParser.Syntax
{
    public abstract class Unit
    {
        public abstract IEnumerable<Unit> Children { get; }
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}