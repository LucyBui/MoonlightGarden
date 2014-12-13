using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Platform.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonlightGarden.Framework.Utils
{
    public static class Extension
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Length == 0;
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        public static TSource Weakest<TSource>(this IEnumerable<TSource> list, Func<TSource, int> selector)
        {
            TSource candidate = default(TSource);
            foreach (TSource item in list)
            {
                if (candidate == null)
                {
                    candidate = item;
                }
                else
                {
                    if (selector(item) < selector(candidate))
                    {
                        candidate = item;
                    }
                }
            }
            return candidate;
        }
    }
}