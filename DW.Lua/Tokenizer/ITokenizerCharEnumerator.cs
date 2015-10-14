using DW.Lua.Misc;

namespace DW.Lua.Tokenizer
{
    public interface ITokenizerCharEnumerator : INextAwareEnumerator<char>
    {
        int TextPosition { get; }
        int Line { get; }
        int Column { get; }
    }
}