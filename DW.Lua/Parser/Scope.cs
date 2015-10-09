using System.Collections.Generic;
using DW.Lua.Syntax;

namespace DW.Lua.Parser
{
    class Scope : IScope
    {
        private readonly Dictionary<string,Variable> _definedVariables = new Dictionary<string, Variable>();

        public Scope(IScope parent = null)
        {
            Parent = parent;
        }

        public IScope Parent { get; }

        public IDictionary<string, Variable> DefinedVariables => _definedVariables;

        public IDictionary<string, Variable> GetVisibleVariables()
        {
            var visibleVariables = Parent?.GetVisibleVariables() ?? new Dictionary<string, Variable>();
            foreach (var kvp in _definedVariables)
                if (visibleVariables.ContainsKey(kvp.Key))
                    visibleVariables[kvp.Key] = kvp.Value;
                else
                    visibleVariables.Add(kvp);
            return visibleVariables;
        }

        public void AddVariable(Variable variable)
        {
            _definedVariables.Add(variable.Name, variable);
        }
    }
}