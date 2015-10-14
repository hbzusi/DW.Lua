using System.Collections.Generic;
using System.IO;
using System.Linq;
using DW.Lua.Extensions;
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
        public string[] ShouldParse(string code)
        {
            var reader = Tokenizer.Tokenizer.Parse(new StringReader(code));
            return reader.Enumerate().Select(t => t.Value).ToArray();
        }
    }
}