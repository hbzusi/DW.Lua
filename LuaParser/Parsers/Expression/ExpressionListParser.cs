using System.Collections.Generic;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class ExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(ITokenEnumerator reader, IParserContext context)
        {
            var expressions = new List<LuaExpression>();
            do
            {
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
            } while (reader.Next == Token.Comma);
            return expressions;
        }
    }
}