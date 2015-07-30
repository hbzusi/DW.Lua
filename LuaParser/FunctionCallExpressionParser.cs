using System.Collections;
using System.Collections.Generic;
using LuaParser.Parser;
using LuaParser.Syntax;

namespace LuaParser
{
    public class FunctionCallExpressionParser : ExpressionParser
    {
        public override Expression Parse(TokenEnumerator reader)
        {
            var name = reader.Current;
            reader.Advance();
            if (reader.Current != "(")
                throw new UnexpectedTokenException(reader.Current);

            var parametersParser = new ExpressionListParser();

            var expression = new FunctionCallExpression
            {
                FunctionName = name,
                Parameters = parametersParser.Parse(reader)
            };
            if (reader.Current != ")")
                throw new UnexpectedTokenException(reader.Current);
            return expression;
        }
    }

    public class ExpressionListParser
    {
        public IList<Expression> Parse(TokenEnumerator reader)
        {
            throw new System.NotImplementedException();
        }
    }
}