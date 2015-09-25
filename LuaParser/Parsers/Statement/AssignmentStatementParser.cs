using System.Collections.Generic;
using LuaParser.Exceptions;
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
            if (reader.Current != Token.EqualsSign)
                throw new UnexpectedTokenException(reader.Current, Token.EqualsSign);
            reader.Advance();
            var expressions = ReadExpressions(reader);

            return new Assignment
            {
                Local = local,
                Variables = variables,
                Expressions = expressions
            };
        }

        private IList<Syntax.Expression> ReadExpressions(ITokenEnumerator reader)
        {
            var result = new List<Syntax.Expression>();
            while (reader.Current != null)
            {
                var expression = SyntaxParser.ReadExpression(reader);
                result.Add(expression);
                if (reader.Next == null)
                    break;
                reader.Advance();
                if (reader.Current != "\n" && reader.Current != Token.Colon && reader.Current != Token.Semicolon)
                    throw new UnexpectedTokenException(reader.Current);
                if (reader.Current == "\n" || reader.Current == Token.Semicolon)
                    break;
                reader.Advance();
            }
            return result;
        }

        private IList<Variable> ReadDeclarations(ITokenEnumerator reader)
        {
            var result = new List<Variable>();
            while (reader.Next != null)
            {
                var variable = new Variable {Name = reader.Current};
                result.Add(variable);
                reader.Advance();
                if (reader.Current != Token.Colon && reader.Current != Token.EqualsSign)
                    throw new UnexpectedTokenException(reader.Current);
                if (reader.Current == Token.EqualsSign)
                    break;
                reader.Advance();
            }
            return result;
        }
    }
}