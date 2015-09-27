using System.Diagnostics;
using System.IO;
using LuaParser;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Code
{
    [TestFixture]
    public class RealLifeCodeTests
    {
        private string GetFixtureCode(string name)
        {
            var assembly = GetType().Assembly;
            var resourceName = "LuaParserUnitTests.Fixtures."+name;
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (StreamReader reader = new StreamReader(stream))
                    result = reader.ReadToEnd();
            }
            return result;
        }

        [Test]
        public void ShouldParseFixtureCode()
        {
            SyntaxParser.Parse(GetFixtureCode("Hamming.lua"));
        }
    }
}
