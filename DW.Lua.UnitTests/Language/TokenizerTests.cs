using System.Collections.Generic;
using System.IO;
using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Language
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
        [TestCase("---[[ Comment\ntest", ExpectedResult = new[] { "-[[ Comment","test" })]
        [TestCase("--[[ Comment\ntest\n--]] test", ExpectedResult = new[] { " Comment\ntest\n--", "test" })]
        public string[] ShouldParse(string code)
        {
            var reader = Tokenizer.Parse(new StringReader(code));
            return reader.Enumerate().Select(t => t.Value).ToArray();
        }
    }
}