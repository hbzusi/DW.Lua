using DW.Lua.Exceptions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class ExpressionParserDiscriminator
    {
        public ExpressionParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == Token.LeftBracket)
                return new BracketedExpressionParser();
            if (Token.IsIdentifier(reader.Current) && reader.Next == Token.LeftBracket)
                return new FunctionCallExpressionParser();
            if (Token.IsIdentifier(reader.Current) && Token.IsBinaryOperation(reader.Next))
                return new BinaryOperationExpressionParser();
            if (Token.IsBooleanConstant(reader.Current))
                return new BooleanConstantExpressionParser();
            if (Token.IsIdentifier(reader.Current))
                return new SingleVariableExpressionParser();
            if (Token.IsNumericConstant(reader.Current))
                return new NumericConstantExpressionParser();
            if (reader.Current == Token.LeftCurlyBrace)
                return new TableInitializerExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }
}