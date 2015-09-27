using System;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class NumericConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var constantValue = Double.Parse(reader.Current);
            return new ConstantExpression(new Value {NumericValue = constantValue});
        }
    }
}