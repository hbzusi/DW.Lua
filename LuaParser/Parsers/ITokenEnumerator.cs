namespace DW.Lua.Parsers
{
    public interface ITokenEnumerator
    {
        string Previous { get; }
        string Next { get; }
        string Current { get; }
        bool Finished { get; }
        void MoveNext();
        string GetAndMoveNext();
    }
}