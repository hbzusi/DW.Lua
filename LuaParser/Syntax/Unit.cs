using System.Collections.Generic;
using JetBrains.Annotations;

namespace LuaParser.Syntax
{
    public abstract class Unit
    {
        [NotNull]
        public abstract IEnumerable<Unit> Children { get; }
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}