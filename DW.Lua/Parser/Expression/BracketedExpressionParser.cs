using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class BracketedExpressionParser : IExpressionParser
    {
        public virtual LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftBracket);
            reader.MoveNext();
            var expression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedToken(LuaToken.RightBracket);
            reader.MoveNext();
            return new BracketedExpression(expression);
        }
    }
}