using System.Collections.Generic;
using System.IO;
using LuaParser.Parsers;
using LuaParser.Parsers.Expression;
using LuaParser.Parsers.Statement;
using LuaParser.Syntax;

namespace LuaParser
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

            while (!tokenEnumerator.Finished)
            {
                var statement = ReadStatement(tokenEnumerator, context);
                statements.Add(statement);
            }

            return new StatementBlock(statements);
        }

        public static LuaStatement ReadStatement(ITokenEnumerator reader, IParserContext context)
        {
            while (string.IsNullOrEmpty(reader.Current) || reader.Current == "\n")
                reader.Advance();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(reader);
            return statementParser.Parse(reader, context);
        }


        public static LuaExpression ReadExpression(ITokenEnumerator reader, IParserContext context)
        {
            var expressionDiscriminator = new ExpressionParserDiscriminator();
            var expressionParser = expressionDiscriminator.Identify(reader);
            return expressionParser.Parse(reader, context);
        }
    }
}
