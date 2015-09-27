using System;
using System.Collections.Generic;
using System.Linq;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class SingleVariableExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var variableName = reader.Current;
            var visibleVariables = context.CurrentScope.GetVisibleVariables();
            if (!visibleVariables.ContainsKey(variableName))
                context.AddError("Undefined variable: "+ variableName);
            return new VariableExpression();
        }
    }

    public class VariableExpression : LuaExpression
    {
        public override IEnumerable<Unit> Children { get; }
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}