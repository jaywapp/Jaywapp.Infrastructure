using System.Collections.Generic;
using System.Linq;

namespace Jaywapp.Infrastructure.Helpers
{
/// <summary>
/// 유틸리티 메서드를 제공합니다.
/// </summary>
    public static class HashSetHelper
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> targets)
        {
            foreach (var target in targets.ToList())
                hashSet.Add(target);
        }

        public static void RemoveRange<T>(this HashSet<T> hashSet, IEnumerable<T> targets)
        {
            foreach (var target in targets.ToList())
                hashSet.Remove(target);
        }
    }
}
