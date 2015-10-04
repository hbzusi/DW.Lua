using System;
using System.IO;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Code
{
    [TestFixture]
    public class RealLifeCodeTests
    {
        private string GetFixtureCode(string name)
        {
            var assembly = GetType().Assembly;
            var resourceName = "DW.Lua.UnitTests.Fixtures."+name;
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                    using (StreamReader reader = new StreamReader(stream))
                        result = reader.ReadToEnd();
                else
                {
                    throw new InvalidOperationException("Could not load resource stream for " + name);
                }
            }
            return result;
        }

        [Test]
        public void ShouldParseHammingAlgorithmCode()
        {
            SyntaxParser.Parse(GetFixtureCode("Hamming.lua"));
        }
    }
}
