using System.Collections.Generic;
using System.IO;
using DW.Lua.Parsers;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers
{
    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        [TestCase("(a)", ExpectedResult = new[] {"(", "a", ")"})]
        [TestCase("a,b", ExpectedResult = new[] {"a", ",", "b"})]
        [TestCase("a=b", ExpectedResult = new[] {"a", "=", "b"})]
        [TestCase("a = b", ExpectedResult = new[] {"a", "=", "b"})]
        [TestCase("a > b < c", ExpectedResult = new[] { "a", ">", "b", "<", "c" })]
        [TestCase("a == b", ExpectedResult = new[] {"a", "==", "b"})]
        [TestCase("a&&b", ExpectedResult = new[] { "a", "&&", "b" })]
        [TestCase("a && b", ExpectedResult = new[] { "a", "&&", "b" })]
        [TestCase("a ~= b", ExpectedResult = new[] { "a", "~=", "b" })]
        [TestCase("a =! b", ExpectedResult = new[] { "a", "=", "!", "b" })]
        [TestCase("local a={}", ExpectedResult = new[] {"local", "a", "=", "{", "}"})]
        public string[] ShouldParse(string code)
        {
            var reader = Tokenizer.Parse(new StringReader(code));
            var tokens = new List<string>();
            while (!reader.Finished)
                tokens.Add(reader.GetAndMoveNext());
            return tokens.ToArray();
        }
    }
}