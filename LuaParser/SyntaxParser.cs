using System.IO;
using LuaParser.Extensions;
using LuaParser.Parser;
using LuaParser.Syntax;

namespace LuaParser
{
    public static class SyntaxParser
    {
        public static StatementBlock Parse(string s)
        {
            var rootBlock = new StatementBlock();
            var reader = new StringReader(s);
            var tokenEnumerator = Tokenizer.Parse(reader);

            while (!tokenEnumerator.Finished)
            {
                var statement = ReadStatement(tokenEnumerator);
                rootBlock.Statements.Add(statement);
            }

            return rootBlock;
        }

        private static Statement ReadStatement(TokenEnumerator reader)
        {
            var token = reader.Current;
            if (string.IsNullOrEmpty(token)) 
                return new EmptyStatement();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(reader);
            return statementParser.Parse(reader);
        }


        public static Expression ReadExpression(TokenEnumerator reader)
        {
            var expressionDiscriminator = new ExpressionParserDiscriminator();
            var expressionParser = expressionDiscriminator.Identify(reader);
            return expressionParser.Parse(reader);
        }
    }
}
