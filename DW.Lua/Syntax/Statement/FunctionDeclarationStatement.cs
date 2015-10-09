using System;
using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;
using JetBrains.Annotations;

namespace DW.Lua.Syntax.Statement
{
    public class FunctionDeclarationStatement : LuaStatement, IEquatable<FunctionDeclarationStatement>
    {
        private readonly List<string> _argumentNames;

        [NotNull]
        public string FunctionName { get; }

        [NotNull]
        public IList<string> ArgumentNames => _argumentNames.AsReadOnly();

        [NotNull]
        public StatementBlock FunctionBody { get; }

        public FunctionDeclarationStatement([NotNull] string functionName, [NotNull] IEnumerable<string> argumentNames,
            [NotNull] StatementBlock functionBody)
        {
            if (functionName == null) throw new ArgumentNullException(nameof(functionName));
            if (argumentNames == null) throw new ArgumentNullException(nameof(argumentNames));
            if (functionBody == null) throw new ArgumentNullException(nameof(functionBody));
            FunctionName = functionName;
            _argumentNames = argumentNames.ToList();
            FunctionBody = functionBody;
        }

        public override IEnumerable<Unit> Children { get { yield return FunctionBody; } }

        public bool Equals([CanBeNull] FunctionDeclarationStatement other)
        {
            return other != null && other.FunctionName == FunctionName &&
                   ArgumentNames.SequenceEqual(other.ArgumentNames) && Equals(other.FunctionBody, FunctionBody);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}