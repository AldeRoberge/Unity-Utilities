using System;
using System.Collections.Generic;

namespace AldeRoberge.UnityUtilities
{
    public static class RateLimiter
    {
        private static readonly Dictionary<string, List<DateTime>> RateLimitDictionary = new();

        public static bool IsRateLimited(string key, int maxRequests, TimeSpan timeSpan)
        {
            // If the key is not in the dictionary, add it.
            if (!RateLimitDictionary.ContainsKey(key))
            {
                RateLimitDictionary.Add(key, new List<DateTime>());
            }

            // Get the list of requests for the key.
            var requests = RateLimitDictionary[key];

            // If the list is empty, add the current time to the list.
            if (requests.Count == 0)
            {
                requests.Add(DateTime.Now);
                return false;
            }

            // If the list is not empty, check if the current time is greater than the time span.
            if (DateTime.Now - requests[0] > timeSpan)
            {
                // If the current time is greater than the time span, remove the first item in the list.
                requests.RemoveAt(0);
            }

            // If the list is not full, add the current time to the list.
            if (requests.Count < maxRequests)
            {
                requests.Add(DateTime.Now);
                return false;
            }

            // If the list is full, return true.
            return true;
        }
    }
}