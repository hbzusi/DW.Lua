using System.Collections.Generic;

namespace DW.Lua.Misc
{
    public interface INextAwareEnumerator<out T> : IEnumerator<T>
    {
        T Next { get; }
        bool HasNext { get; }
    }
}