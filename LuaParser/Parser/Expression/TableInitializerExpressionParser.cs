using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class TableInitializerExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftCurlyBrace);
            reader.MoveNext();
            var expressions = new List<LuaExpression>();
            while (reader.Current.Value != LuaToken.RightCurlyBrace)
            {
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
                reader.VerifyExpectedToken(LuaToken.RightCurlyBrace, LuaToken.Comma);
            }
            reader.VerifyExpectedToken(LuaToken.RightCurlyBrace);
            reader.MoveNext();
            return new TableInitializerExpression(expressions);
        }
    }
}