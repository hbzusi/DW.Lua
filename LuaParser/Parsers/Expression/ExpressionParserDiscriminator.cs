using System;
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
            if (Token.IsBooleanConstant(reader.Current))
                return new BooleanConstantExpressionParser();
            if (Token.IsIdentifier(reader.Current))
                return new SingleVariableExpressionParser();
            if (Token.IsNumericConstant(reader.Current))
                return new NumericConstantExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }

    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            reader.Advance();
            return new ConstantExpression(new Value() {BooleanValue = Boolean.Parse(reader.Previous) });
        }
    }
}