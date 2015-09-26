using System.IO;
using LuaParser.Extensions;
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
            var rootBlock = new StatementBlock();
            var reader = new StringReader(s);
            ITokenEnumerator tokenEnumerator = Tokenizer.Parse(reader);

            while (!tokenEnumerator.Finished)
            {
                var statement = ReadStatement(tokenEnumerator);
                rootBlock.Statements.Add(statement);
            }

            return rootBlock;
        }

        public static Statement ReadStatement(ITokenEnumerator reader)
        {
            var token = reader.Current;
            if (string.IsNullOrEmpty(token)) 
                return new EmptyStatement();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(reader);
            return statementParser.Parse(reader);
        }


        public static Expression ReadExpression(ITokenEnumerator reader)
        {
            var expressionDiscriminator = new ExpressionParserDiscriminator();
            var expressionParser = expressionDiscriminator.Identify(reader);
            return expressionParser.Parse(reader);
        }
    }
}
