using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class FunctionCallExpressionParser : IExpressionParser
    {
        public virtual LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var name = reader.Current.Value;
            reader.MoveNext();
            reader.VerifyExpectedToken(LuaToken.LeftBracket);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression(name, parametersParser.Parse(reader, context).ToList());
            reader.VerifyExpectedToken(LuaToken.RightBracket);
            return expression;
        }
    }
}