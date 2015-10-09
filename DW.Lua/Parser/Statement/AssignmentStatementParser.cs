using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Parser.Expression;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal class AssignmentStatementParser : StatementParser
    {
        private readonly bool _local;

        public AssignmentStatementParser(bool local)
        {
            _local = local;
        }

        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var variables = ReadDeclarations(reader);
            foreach (var variable in variables)
                context.CurrentScope.AddVariable(variable);
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.EqualsSign);
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
                reader.VerifyExpectedToken(LuaToken.Comma,LuaToken.EqualsSign);
                if (reader.Current.Value == LuaToken.EqualsSign)
                    break;
                reader.MoveNext();
            }
            return result;
        }
    }
}