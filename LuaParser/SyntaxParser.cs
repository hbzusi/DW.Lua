using System.IO;
using LuaParser.Extensions;
using LuaParser.Parser;
using LuaParser.Syntax;

namespace LuaParser
{
    public static class SyntaxParser
    {
        public static Block Parse(string s)
        {
            var rootBlock = new Block();
            var reader = new StringReader(s);

            while (reader.Peek() != -1)
            {
                var statement = ReadStatement(reader);
                rootBlock.Statements.Add(statement);
            }

            return rootBlock;
        }

        private static Statement ReadStatement(TextReader reader)
        {
            reader.SkipWhitespace();
            var word = reader.ReadWord();
            if (string.IsNullOrEmpty(word))
                return new EmptyStatement();
            var statementDiscriminator = new StatementParserDiscriminator();
            var statementParser = statementDiscriminator.Identify(word);
            return statementParser.Parse(reader);
        }
    }
}
