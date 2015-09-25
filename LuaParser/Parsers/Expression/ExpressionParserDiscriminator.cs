using LuaParser.Exceptions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class ExpressionParserDiscriminator
    {
        public ExpressionParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == "(")
                return new BracketedExpressionParser();
            if (Token.IsIdentifier(reader.Current) && reader.Next == "(")
                return new FunctionCallExpressionParser();
            if (Token.IsIdentifier(reader.Current) && Token.IsBinaryOperation(reader.Next))
                return new BinaryOperationExpressionParser();
            if (Token.IsIdentifier(reader.Current))
                return new SingleVariableExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }
}