using System.Collections.Generic;
using System.Linq;

namespace DW.Lua.Misc
{
    public static class HashCodeHelper
    {
        public static int CombineHashCodes(int seed, params object[] objects)
            => CombineHashCodes(seed, objects.AsEnumerable());

        public static int CombineHashCodes(int seed, IEnumerable<object> objects)
        {
            var hash = seed;
            foreach (var o in objects)
            {
                unchecked
                {
                    hash = 17*hash + 19*o.GetHashCode();
                }
            }
            return hash;
        }
    }
}