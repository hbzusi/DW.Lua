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
            return Char.IsLetter(token[0]) && token.Skip(1).All(Char.IsLetterOrDigit);
        }

        public static bool IsBinaryOperation(string token)
        {
            return new[] {"+", "-", "*", "/"}.Contains(token);
        }
    }
}
