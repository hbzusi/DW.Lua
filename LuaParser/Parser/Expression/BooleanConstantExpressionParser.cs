using System;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var expression = new ConstantExpression(new Value { BooleanValue = Boolean.Parse(reader.Current.Value) });
            reader.MoveNext();
            return expression;
        }
    }
}