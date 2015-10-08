using System;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.MoveNext();
            return new ConstantExpression(new Value {BooleanValue = Boolean.Parse(reader.Previous) });
        }
    }
}