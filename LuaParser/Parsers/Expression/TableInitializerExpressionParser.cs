using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class TableInitializerExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            reader.VerifyExpectedToken(Token.LeftCurlyBrace);
            reader.Advance();
            var expressions = new List<Syntax.Expression>();
            while (reader.Current != Token.RightCurlyBrace)
            {
                expressions.Add(SyntaxParser.ReadExpression(reader));
                reader.VerifyExpectedToken(Token.RightCurlyBrace, Token.Colon);
            }
            reader.VerifyExpectedToken(Token.RightCurlyBrace);
            reader.Advance();
            return new TableInitializerExpression(expressions);
        }
    }
}