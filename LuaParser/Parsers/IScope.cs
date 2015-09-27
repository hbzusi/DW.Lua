using System.Collections.Generic;
using JetBrains.Annotations;
using LuaParser.Syntax;

namespace LuaParser.Parsers
{
    public interface IScope
    {
        [CanBeNull]
        IScope Parent { get; }
        IDictionary<string, Variable> DefinedVariables { get; }
        IDictionary<string, Variable> GetVisibleVariables();
        void AddVariable(Variable variable);
    }
}
