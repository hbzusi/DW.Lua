using LuaParser.Syntax;

namespace LuaParserUnitTests
{
    internal static class Constants
    {
        public static Value True => new Value {BooleanValue = true};
        public static Value False => new Value {BooleanValue = false};
        public static Value One => new Value {NumericValue = 1};
        public static Value Two => new Value { NumericValue = 2 };
    }
}