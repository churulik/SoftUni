using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LinqEnxtension
{
    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var element in collection)
            {
                if (!predicate(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection,
            Func<TSource, TSelector> selector) where TSelector : IComparable<TSelector>
        {
            var list = collection.ToArray();
            var max = selector(list[0]);
            for (int i = 0; i < list.Length - 1; i++)
            {
                var num = selector(list[i + 1]);
                if (max.CompareTo(num) < 0)
                {
                    max = num;
                }
            }
            return max;
        }
    }
}