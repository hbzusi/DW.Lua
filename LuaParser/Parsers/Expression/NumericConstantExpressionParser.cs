using System;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class NumericConstantExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            var constantValue = Double.Parse(reader.Current);
            return new NumericConstantExpression(constantValue);
        }
    }
}