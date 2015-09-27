using System.Collections.Generic;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class ExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(ITokenEnumerator reader)
        {
            var expressions = new List<LuaExpression>();
            do
            {
                expressions.Add(SyntaxParser.ReadExpression(reader));
            } while (reader.Next == Token.Comma);
            return expressions;
        }
    }
}