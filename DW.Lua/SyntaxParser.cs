using System.Collections.Generic;
using System.IO;
using DW.Lua.Extensions;
using DW.Lua.Language;
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
            return Parse(new StringReader(s));
        }

        public static StatementBlock Parse(TextReader reader)
        { 
            var statements = new List<LuaStatement>();
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
            while (string.IsNullOrEmpty(reader.Current.Value)
                   || reader.Current.Value == "\n"
                   || reader.Current.Type == TokenType.Comment)
                reader.MoveNext();

            if (reader.Current.Value == Keywords.Not)
            {
                reader.MoveNext();
                return new BinaryExpression(ReadExpression(reader, context), new ConstantExpression(LuaValue.False), "==");
            }

            var expressionParser = ExpressionParserDiscriminator.Identify(reader, context);
            var expression = expressionParser.Parse(reader, context);

            while (reader.Current.Value == LuaToken.Dot && reader.HasNext
                && LuaToken.IsIdentifier(reader.Next.Value))
            {
                reader.MoveNext();

                if (reader.Next.Value == LuaToken.LeftBracket)
                {
                    var name = reader.GetAndMoveNext();
                    reader.MoveNext();
                    var args = new ExpressionListParser().Parse(reader, context);
                    reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightBracket);
                    expression = new FunctionCallExpression($"{expression}.{name.Value}", args);
                }
                else
                {
                    var indexerExpression = reader.GetAndMoveNext();
                    expression = new TableIndexExpression(expression, new StringConstantExpression(indexerExpression.Value));
                }
            }

            if (reader.Current.Value == LuaToken.LeftSquareBracket)
            {
                reader.MoveNext();
                var indexerExpression = SyntaxParser.ReadExpression(reader, context);
                reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightSquareBracket);
                expression = new TableIndexExpression(expression, indexerExpression);
            }

            if (reader.Current.Value == LuaToken.Colon && reader.HasNext
                && LuaToken.IsIdentifier(reader.Next.Value))
            {
                reader.MoveNext();
                var name = reader.GetAndMoveNext();
                reader.VerifyExpectedTokenAndMoveNext(LuaToken.LeftBracket);
                var args = new ExpressionListParser().Parse(reader, context);
                reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightBracket);
                expression = new FunctionCallExpression(name.Value, args.Prepend(expression));
            }
            
            while (LuaToken.IsBinaryOperation(reader.Current.Value))
            {
                var operation = reader.GetAndMoveNext();
                var rightSideExpression = ReadExpression(reader, context);
                expression = new BinaryExpression(expression, rightSideExpression, operation.Value);

                if (!string.IsNullOrEmpty(reader.Current.Value)
                   && reader.Current.Value != "\n"
                   && reader.Current.Type != TokenType.Comment)
                {
                    break;
                }

                while (reader.HasNext && (string.IsNullOrEmpty(reader.Next.Value)
                   || reader.Next.Value == "\n"
                   || reader.Next.Type == TokenType.Comment))
                    reader.MoveNext();

                if (!LuaToken.IsBinaryOperation(reader.Next.Value))
                {
                    break;
                }

                reader.MoveNext();
            }

            return expression;
        }
    }
}