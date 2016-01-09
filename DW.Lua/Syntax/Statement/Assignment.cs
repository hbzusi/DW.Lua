using System;
using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;

namespace DW.Lua.Syntax.Statement
{
    public class Assignment : LuaStatement, IEquatable<Assignment>
    {
        private readonly List<LuaExpression> _expressions;
        private readonly List<IAssignmentTarget> _targets;

        public Assignment(IEnumerable<IAssignmentTarget> targets, IEnumerable<LuaExpression> expressions, bool local)
        {
            _targets = targets.ToList();
            _expressions = expressions.ToList();
            Local = local;
        }

        public Assignment(IAssignmentTarget target, LuaExpression expression, bool local)
        {
            _targets = new List<IAssignmentTarget> {target};
            _expressions = new List<LuaExpression> {expression};
            Local = local;
        }

        public IList<IAssignmentTarget> Targets => _targets.AsReadOnly();

        public IList<LuaExpression> Expressions => _expressions;

        public bool Local { get; }

        public override IEnumerable<Unit> Children => Expressions ?? new LuaExpression[0];

        public bool Equals(Assignment other)
        {
            return other != null && Local.Equals(other.Local) && Targets.SequenceEqual(other.Targets) &&
                   Expressions.SequenceEqual(other.Expressions);
        }

        public override string ToString()
        {
            return string.Join(",", Targets) + "=" + string.Join(",", Expressions);
        }

        public override bool Equals(object obj)
        {
            return this.CheckEquality(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Targets.Aggregate(29, (current, variable) => current*19 + variable.GetHashCode());
                hash = Expressions.Aggregate(hash, (current, expression) => current*17 + expression.GetHashCode());
                hash += Local.GetHashCode();
                return hash;
            }
        }
    }
}