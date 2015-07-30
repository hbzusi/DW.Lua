using System.Collections.Generic;

namespace LuaParser.Syntax
{
    public abstract class Unit
    {
        public abstract IEnumerable<Unit> Children { get; }
    }
}