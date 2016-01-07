using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public sealed class StringConstantExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.DoubleQuote, LuaToken.DoubleLeftSquareBracket);
            var builder = new StringBuilder();
            while (reader.HasNext && reader.Current.Value != LuaToken.DoubleQuote &&
                   reader.Current.Value != LuaToken.DoubleRightSquareBracket)
                builder.Append(reader.GetAndMoveNext());
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.DoubleQuote, LuaToken.DoubleRightSquareBracket);

            return new StringConstantExpression(builder.ToString());
        }
    }
}