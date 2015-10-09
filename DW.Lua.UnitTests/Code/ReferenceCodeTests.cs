using System;
using System.IO;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Code
{
    [TestFixture]
    public class ReferenceCodeTests
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
        [TestCase("Factorial.lua")]
        [TestCase("Hamming.lua")]
        [TestCase("HexDump.lua")]
        [TestCase("MarkovChain.lua")]
        public void Parse(string fixtureName)
        {
            SyntaxParser.Parse(GetFixtureCode(fixtureName));
        }
    }
}
