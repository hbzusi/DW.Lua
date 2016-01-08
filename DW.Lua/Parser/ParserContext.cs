using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace DW.Lua.Parser
{
    public class ParserContext : IParserContext
    {
        public ParserContext([NotNull] IScope rootScope)
        {
            if (rootScope == null) throw new ArgumentNullException(nameof(rootScope));
            RootScope = rootScope;
            CurrentScope = RootScope;
        }

        public List<string> Errors { get; } = new List<string>();

        public IScope RootScope { get; }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public IScope CurrentScope { get; private set; }

        public IScope AcquireScope()
        {
            var scope = new Scope(CurrentScope);
            CurrentScope = scope;
            return scope;
        }

        public void ReleaseScope(IScope scope)
        {
            if (scope != CurrentScope)
                throw new InvalidOperationException("Cannot release not acquired scope");
            CurrentScope = scope.Parent;
        }
    }
}