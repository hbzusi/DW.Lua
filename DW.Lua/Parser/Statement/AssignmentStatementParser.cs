using System.Collections.Generic;
using System.Linq;

using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Parser.Expression;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class AssignmentStatementParser : IStatementParser
    {
        private readonly bool _local;

        public AssignmentStatementParser(bool local)
        {
            _local = local;
        }

        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var variables = ReadDeclarations(reader);
            foreach (var variable in variables)
            {
                if (!context.CurrentScope.DefinedVariables.ContainsKey(variable.Name))
                    context.CurrentScope.AddVariable(variable);
            }

            if (reader.Current.Value != LuaToken.EqualsSign)
            {
                var nil = new ConstantExpression(LuaValue.Nil);
                return new Assignment(variables, Enumerable.Repeat(nil, variables.Count), _local);
            }

            reader.MoveNext();

            var assignedExpressionParser = new ExpressionListParser();
            var expressions = assignedExpressionParser.Parse(reader, context);

            return new Assignment(variables, expressions, _local);
        }

        private IList<Variable> ReadDeclarations(INextAwareEnumerator<Token> reader)
        {
            var result = new List<Variable>();
            while (reader.HasNext && reader.Next.Value != null)
            {
                var variable = new Variable(reader.Current.Value);
                result.Add(variable);
                reader.MoveNext();
                reader.VerifyExpectedToken(LuaToken.Comma, LuaToken.EqualsSign, LuaToken.Semicolon, LuaToken.Dot, "\n");
                if (reader.Current.Value == LuaToken.Dot)
                {
                    result[result.Count - 1] =
                        new Variable($"{variable.Name}.{reader.GetAndMoveNext()}");
                }

                if (reader.Current.Value != LuaToken.Comma)
                    break;
                reader.MoveNext();
            }
            return result;
        }
    }
}