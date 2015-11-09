using System;
using DW.Lua.Extensions;

namespace DW.Lua.Syntax
{
    public class Variable : IEquatable<Variable>
    {
        public Variable(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public bool Equals(Variable other)
        {
            return other?.Name == Name;
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}