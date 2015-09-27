using System.Collections.Generic;
using LuaParser.Exceptions;
using LuaParser.Extensions;
using LuaParser.Parsers.Expression;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class AssignmentStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader)
        {
            bool local = false;
            if (reader.Current == "local")
            {
                local = true;
                reader.Advance();
            }

            var variables = ReadDeclarations(reader);
            reader.VerifyExpectedTokenAndAdvance(Token.EqualsSign);
            var assignedExpressionParser = new ExpressionListParser();
            var expressions = assignedExpressionParser.Parse(reader);

            return new Assignment(variables, expressions, local);
        }

        private IList<Variable> ReadDeclarations(ITokenEnumerator reader)
        {
            var result = new List<Variable>();
            while (reader.Next != null)
            {
                var variable = new Variable(reader.Current);
                result.Add(variable);
                reader.Advance();
                reader.VerifyExpectedToken(Token.Comma,Token.EqualsSign);
                if (reader.Current == Token.EqualsSign)
                    break;
                reader.Advance();
            }
            return result;
        }
    }
}