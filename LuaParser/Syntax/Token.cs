using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaParser.Syntax
{
    public static class Token
    {
        public const string Colon = ",";

        public const string EqualsSign = "=";

        public const string Semicolon = ";";

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
            return new[] {"+", "-", "*", "/"}.Contains(token);
        }
    }
}
