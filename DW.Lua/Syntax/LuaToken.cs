using System.Collections.Generic;
using System.Linq;
using static System.Char;
using static System.Double;

namespace DW.Lua.Syntax
{
    public static class LuaToken
    {
        public const string Comma = ",";
        public const string Colon = ":";

        public const string EqualsSign = "=";

        public const string Semicolon = ";";
        public const string LeftBracket = "(";
        public const string RightBracket = ")";
        public const string LeftSquareBracket = "[";
        public const string RightSquareBracket = "]";
        public const string LeftCurlyBrace = "{";
        public const string RightCurlyBrace = "}";

        public const string DoubleQuote = "\"";

        public const string Dot = ".";

        public const string DoubleLeftSquareBracket = "[[";
        public const string DoubleRightSquareBracket = "]]";

        public const string SingleCharTokensString = "{}()[]+-/*=\n,:&|\".";
        public static readonly string NonTokenCharsString = "\t\r ";

        public static readonly string[] TokenBigrams =
        {
            "==",
            "~=",
            "&&",
            "||",
            ".."
        };

        public static readonly string[] BinaryOperations = {"+", "-", "*", "/", "=="};

        public static bool IsIdentifier(string token)
        {
            return IsLetter(token[0]) && token.Skip(1).All(IsLetterOrDigit);
        }

        public static bool IsNumericConstant(string token)
        {
            double dummy;
            return TryParse(token, out dummy);
        }

        public static bool IsBinaryOperation(string token)
        {
            return BinaryOperations.Contains(token);
        }

        public static bool IsBooleanConstant(string token)
        {
            return token == "true" || token == "false";
        }
    }
}