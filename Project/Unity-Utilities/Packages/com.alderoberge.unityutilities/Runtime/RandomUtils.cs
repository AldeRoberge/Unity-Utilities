using System;
using System.Collections.Generic;
using System.Linq;

namespace AldeRoberge.UnityUtilities
{
    public static class RandomUtils
    {
        private static readonly Random RandomProvider = new Random();

        private static int GetRandomInRange(int i, int arrayLength)
        {
            return RandomProvider.Next(i, arrayLength);
        }

        public static T Random<T>(this List<T> list)
        {
            return list[GetRandomInRange(0, list.Count)];
        }

        public static T Random<T>(this T[] array)
        {
            return array[GetRandomInRange(0, array.Length)];
        }

        public static T GetRandomElement<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                return default;
            }

            var enumerable = list.ToList();

            if (!enumerable.Any())
                return default;

            return enumerable.ElementAt(RandomProvider.Next(enumerable.Count));
        }
    }
}