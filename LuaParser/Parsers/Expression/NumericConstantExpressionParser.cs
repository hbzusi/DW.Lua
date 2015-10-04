using System;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class NumericConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var constantValue = Double.Parse(reader.Current);
            reader.Advance();
            return new ConstantExpression(new Value {NumericValue = constantValue});
        }
    }
}