using LuaParser.Parser;
using LuaParser.Syntax;

namespace LuaParser
{
    public abstract class ExpressionParser
    {
        public abstract Expression Parse(TokenEnumerator reader);
    }
}