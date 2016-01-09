using System.Collections.Generic;
using DW.Lua.Syntax;
using JetBrains.Annotations;

namespace DW.Lua.Parser
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