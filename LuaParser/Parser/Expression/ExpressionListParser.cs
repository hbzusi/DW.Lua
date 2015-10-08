using System.Collections.Generic;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
{
    public class ExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(ITokenEnumerator reader, IParserContext context)
        {
            var expressions = new List<LuaExpression>();
            do
            {
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
            } while (reader.Current.Value == LuaToken.Comma && reader.MoveNext());
            return expressions;
        }
    }
}