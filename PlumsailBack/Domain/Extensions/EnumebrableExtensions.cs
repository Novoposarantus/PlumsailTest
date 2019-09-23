using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class EnumebrableExtensions
    {
        public static Dictionary<T, List<K>> ToListDictionary<T, K>(this IEnumerable<K> enumerable, Func<K, T> selector)
        {
            var dictionary = new Dictionary<T, List<K>>();
            foreach (var item in enumerable)
            {
                var key = selector(item);
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item);
                    continue;
                }

                dictionary.Add(key, new List<K>() {item});
            }

            return dictionary;
        }
    }
}
