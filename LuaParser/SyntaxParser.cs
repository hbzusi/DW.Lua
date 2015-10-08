using System.Collections.Generic;
using System.IO;
using DW.Lua.Extensions;
using DW.Lua.Parsers;
using DW.Lua.Parsers.Expression;
using DW.Lua.Parsers.Statement;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;

namespace DW.Lua
{
    public static class SyntaxParser
    {
        public static StatementBlock Parse(string s)
        {
            var statements = new List<LuaStatement>();
            var reader = new StringReader(s);
            var rootScope = new Scope();
            var context = new ParserContext(rootScope);
            ITokenEnumerator tokenEnumerator = Tokenizer.Parse(reader);

            while (tokenEnumerator.HasNext)
            {
                var statement = ReadStatement(tokenEnumerator, context);
                statements.Add(statement);
            }

            return new StatementBlock(statements);
        }

        public static LuaStatement ReadStatement(ITokenEnumerator reader, IParserContext context)
        {
            while (string.IsNullOrEmpty(reader.Current) || reader.Current == "\n")
                reader.MoveNext();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(reader);
            return statementParser.Parse(reader, context);
        }


        public static LuaExpression ReadExpression(ITokenEnumerator reader, IParserContext context)
        {
            var expressionDiscriminator = new ExpressionParserDiscriminator();
            var expressionParser = expressionDiscriminator.Identify(reader);
            var expression = expressionParser.Parse(reader, context);

            if (LuaToken.IsBinaryOperation(reader.Current))
            {
                var operation = reader.GetAndMoveNext();
                var rightSideExpression = ReadExpression(reader,context);
                expression = new BinaryExpression(expression,rightSideExpression,operation);
            }

            return expression;
        }
    }
}
