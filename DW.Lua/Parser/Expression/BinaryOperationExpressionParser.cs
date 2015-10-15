using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class BinaryOperationExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var leftExpression = SyntaxParser.ReadExpression(reader,context);
            var operation = reader.Current.Value;
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.BinaryOperations);
            var rightExpression = SyntaxParser.ReadExpression(reader, context);
            return new BinaryExpression(leftExpression,rightExpression, operation);
        }
    }
}