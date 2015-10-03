using System.Linq;
using static System.Char;
using static System.Double;

namespace DW.Lua.Syntax
{
    public static class LuaToken
    {
        public static string Comma = ",";
        public static string Colon = ":";

        public static string EqualsSign = "=";

        public static string Semicolon = ";";
        public static string LeftBracket => "(";
        public static string RightBracket => ")";
        public static string LeftCurlyBrace => "{";
        public static string RightCurlyBrace => "}";

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
            return new[] {"+", "-", "*", "/", "=="}.Contains(token);
        }

        public static bool IsBooleanConstant(string token)
        {
            return token == "true" || token == "false";
        }

        public const string SingleCharTokensString = "{}()[]+-/*=\n,:";
        public static readonly string NonTokenCharsString = "\t\r ";
    }
}
