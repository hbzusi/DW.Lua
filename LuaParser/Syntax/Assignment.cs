using System;
using System.Collections.Generic;
using System.Linq;
using LuaParser.Extensions;

namespace LuaParser.Syntax
{
    public class Assignment : Statement, IEquatable<Assignment>
    {
        private readonly List<Variable> _variables;
        private readonly List<LuaExpression> _expressions;

        public Assignment(IEnumerable<Variable> variables, IEnumerable<LuaExpression> expressions, bool local)
        {
            _variables = variables.ToList();
            _expressions = expressions.ToList();
            Local = local;
        }

        public IList<Variable> Variables => _variables.AsReadOnly();

        public IList<LuaExpression> Expressions => _expressions;

        public bool Local { get; }

        public override IEnumerable<Unit> Children => (Expressions ?? new LuaExpression[0]);

        public bool Equals(Assignment other)
        {
            return other != null && Local.Equals(other.Local) && Variables.SequenceEqual(other.Variables) &&
                   Expressions.SequenceEqual(other.Expressions);
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Variables.Aggregate(29, (current, variable) => current*19 + variable.GetHashCode());
                hash = Expressions.Aggregate(hash, (current, expression) => current*17 + expression.GetHashCode());
                hash += Local.GetHashCode();
                return hash;
            }
        }
    }
}