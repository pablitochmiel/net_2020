using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class FilterExtension
    {
        public static IEnumerable<int> Even(this IEnumerable<int>? list)
        {
            if (list is null) return new List<int>();
            var enumerable = list.ToList();
            return enumerable.Where(i => i % 2 == 0);
        }

        public static IEnumerable<int> Odd(this IEnumerable<int>? list)
        {
            if (list is null) return new List<int>();
            var enumerable = list.ToList();
            return enumerable.Where(i => i % 2 == 1);
        }

        public static IEnumerable<int> Only(this IEnumerable<int>? list, int a)
        {
            var res = new List<int>();
            if (list is null) return res;
            var enumerable = list.ToList();
            for (var i = 0; i < a; i++)
            {
                res.Add(enumerable.ElementAt(i));
            }
            return res;
        }
    }
}