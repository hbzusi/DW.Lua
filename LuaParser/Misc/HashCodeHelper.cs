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
            return objects.Where(o => o != null).Select(obj => obj.GetHashCode()).Aggregate(seed, Combine);
        }

        private static int Combine(int hash1, int hash2)
        {
            unchecked
            {
                return 17*hash1 + 19*hash2;
            }
        }
    }
}