using DW.Lua.Syntax;

namespace DW.Lua.UnitTests
{
    internal static class Constants
    {
        public static LuaValue True => new LuaValue {BooleanValue = true};
        public static LuaValue False => new LuaValue {BooleanValue = false};
        public static LuaValue One => new LuaValue {NumericValue = 1};
        public static LuaValue Two => new LuaValue { NumericValue = 2 };
    }
}