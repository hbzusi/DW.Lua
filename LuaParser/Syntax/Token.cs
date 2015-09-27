using System.Linq;

namespace DW.Lua.Syntax
{
    public static class Token
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
            return char.IsLetter(token[0]) && token.Skip(1).All(char.IsLetterOrDigit);
        }

        public static bool IsNumericConstant(string token)
        {
            double dummy;
            return double.TryParse(token, out dummy);
        }

        public static bool IsBinaryOperation(string token)
        {
            return new[] {"+", "-", "*", "/", "=="}.Contains(token);
        }

        public static bool IsBooleanConstant(string token)
        {
            return token == "true" || token == "false";
        }
    }
}
