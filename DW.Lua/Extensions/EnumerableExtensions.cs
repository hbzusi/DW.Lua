using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Extensions
{
    public static class EnumerableExtensions
    {
        public static INextAwareEnumerator<T> GetNextAwareEnumerator<T>(this IEnumerable<T> source)
        {
            return new NextAwareEnumerator<T>(source.GetEnumerator());
        }

        public static IEnumerable<T> Enumerate<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T first)
        {
            yield return first;
            if (source is null)
            {
                yield break;
            }

            foreach (var next in source)
            {
                yield return next;
            }
        }
    }
}