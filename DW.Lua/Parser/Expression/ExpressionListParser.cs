using System.Collections.Generic;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Expression
{
    public class ExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(INextAwareEnumerator<Token> reader, IParserContext context)
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