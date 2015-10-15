using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class SingleVariableExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var variableName = reader.Current.Value;
            var visibleVariables = context.CurrentScope.GetVisibleVariables();
            Variable variable;
            if (!visibleVariables.ContainsKey(variableName))
            {
                context.AddError("Undefined variable: " + variableName);
                variable = new Variable(variableName);
            }
            else variable = visibleVariables[variableName];
            reader.MoveNext();
            return new VariableExpression(variable);
        }
    }
}