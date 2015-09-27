using System;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.Advance();
            return new ConstantExpression(new Value {BooleanValue = Boolean.Parse(reader.Previous) });
        }
    }
}