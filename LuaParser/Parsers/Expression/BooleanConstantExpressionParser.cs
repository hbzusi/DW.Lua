using System;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            reader.Advance();
            return new ConstantExpression(new Value() {BooleanValue = Boolean.Parse(reader.Previous) });
        }
    }
}