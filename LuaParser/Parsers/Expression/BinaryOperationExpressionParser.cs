using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class BinaryOperationExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            var leftExpression = SyntaxParser.ReadExpression(reader,context);
            var operation = reader.Current;
            reader.VerifyExpectedTokenAndAdvance(LuaToken.BinaryOperations);
            var rightExpression = SyntaxParser.ReadExpression(reader, context);
            return new BinaryExpression(leftExpression,rightExpression, operation);
        }
    }
}