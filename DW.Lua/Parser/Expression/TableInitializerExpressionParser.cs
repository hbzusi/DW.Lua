using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public sealed class TableInitializerExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftCurlyBrace);
            reader.MoveNext();
            var expressions = Enumerable.Empty<LuaExpression>();
            if (reader.Current.Value != LuaToken.RightCurlyBrace)
            {
                var parser = new TableFieldInitializerExpressionListParser();
                expressions = parser.Parse(reader, context);
                reader.VerifyExpectedToken(LuaToken.RightCurlyBrace);
                reader.MoveNext();
            }
            else
                reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightCurlyBrace);
            return new TableInitializerExpression(expressions);
        }
    }
}