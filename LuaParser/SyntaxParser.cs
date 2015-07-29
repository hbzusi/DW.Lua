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

        private static Statement ReadStatement(TokenEnumerator tokenEnumerator)
        {
            var token = tokenEnumerator.Current;
            if (string.IsNullOrEmpty(token)) 
                return new EmptyStatement();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(token);
            return statementParser.Parse(tokenEnumerator);
        }
    }
}
