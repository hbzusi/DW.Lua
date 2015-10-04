using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class SingleVariableExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var variableName = reader.Current;
            var visibleVariables = context.CurrentScope.GetVisibleVariables();
            Variable variable;
            if (!visibleVariables.ContainsKey(variableName))
            {
                context.AddError("Undefined variable: " + variableName);
                variable = new Variable(variableName);
            }
            else variable = visibleVariables[variableName];
            reader.Advance();
            return new VariableExpression(variable);
        }
    }
}