using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LuaParser.Parsers
{
    public class ParserContext : IParserContext
    {
        public List<string> Errors { get; } = new List<string>();

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public IScope CurrentScope { get; private set; }

        public IScope RootScope { get; }

        public ParserContext([NotNull] IScope rootScope)
        {
            if (rootScope == null) throw new ArgumentNullException(nameof(rootScope));
            RootScope = rootScope;
            CurrentScope = RootScope;
        }

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