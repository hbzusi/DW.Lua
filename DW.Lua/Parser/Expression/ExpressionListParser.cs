using System.Collections.Generic;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
{
    public class ExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var expressions = new List<LuaExpression>();
            do
            {
                if (reader.Current.Value == LuaToken.RightBracket)
                    break;
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
            } while (reader.Current.Value == LuaToken.Comma && reader.MoveNext());
            return expressions;
        }
    }
}