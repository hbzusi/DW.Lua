using System;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
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