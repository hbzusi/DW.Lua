using System.IO;
using LuaParser;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Code
{
    [TestFixture]
    public class RealLifeCodeTests
    {
        [Test]
        public void ShouldParseFixtureCode()
        {
            var assembly = GetType().Assembly;
            var resourceName = "LuaParserUnitTests.Fixtures.Hamming.lua";
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
                result = reader.ReadToEnd();

            SyntaxParser.Parse(result);
        }
    }
}
