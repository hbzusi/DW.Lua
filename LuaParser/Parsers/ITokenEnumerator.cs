using DW.Lua.Misc;

namespace DW.Lua.Parsers
{
    public interface ITokenEnumerator : INextAwareEnumerator<string>
    {
        string Previous { get; }
        bool Finished { get; }
        string GetAndMoveNext();
    }
}