using DW.Lua.Misc;

namespace DW.Lua.Lexer
{
    public interface ITokenizerCharEnumerator : INextAwareEnumerator<char>
    {
        int TextPosition { get; }
        int Line { get; }
        int Column { get; }
    }
}