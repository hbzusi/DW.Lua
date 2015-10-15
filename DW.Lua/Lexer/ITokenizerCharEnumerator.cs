using DW.Lua.Misc;

namespace DW.Lua.Lexer
{
    public interface ITokenizerCharEnumerator : INextAwareEnumerator<char>
    {
        TokenPosition Position { get; }
    }
}