using System.Collections.Generic;
using System.IO;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Parser;
using DW.Lua.Parser.Expression;
using DW.Lua.Parser.Statement;
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
            var enumerator = Tokenizer.Parse(reader);

            while (enumerator.HasNext && enumerator.MoveNext())
            {
                var statement = ReadStatement(enumerator, context);
                statements.Add(statement);
            }

            return new StatementBlock(statements);
        }

        public static LuaStatement ReadStatement(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            while (string.IsNullOrEmpty(reader.Current.Value)
                   || reader.Current.Value == "\n"
                   || reader.Current.Type == TokenType.Comment)
                reader.MoveNext();

            var statementParser = StatementParserDiscriminator.Identify(reader);
            return statementParser.Parse(reader, context);
        }


        public static LuaExpression ReadExpression(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var expressionParser = ExpressionParserDiscriminator.Identify(reader);
            var expression = expressionParser.Parse(reader, context);

            if (LuaToken.IsBinaryOperation(reader.Current.Value))
            {
                var operation = reader.GetAndMoveNext();
                var rightSideExpression = ReadExpression(reader, context);
                expression = new BinaryExpression(expression, rightSideExpression, operation.Value);
            }

            return expression;
        }


        public static bool CurrentTokenIsTableIndexer(INextAwareEnumerator<Token> reader)
        {
            return reader.Current.Type == TokenType.Identifier && reader.HasNext &&
                   reader.Next.Type == TokenType.TableIndexer;
        }
    }
}