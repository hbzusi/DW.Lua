using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace LuaParser.Extensions
{
    public static class EquatableExtensions
    {
        public static bool CheckEquality<T>([NotNull] this IEquatable<T> caller, [CanBeNull] object other)
        {
            if (caller == null) throw new ArgumentNullException(nameof(caller));
            return ReferenceEquals(caller, other) || (other?.GetType() == typeof (T) && caller.Equals((T) other));
        }
    }
}
