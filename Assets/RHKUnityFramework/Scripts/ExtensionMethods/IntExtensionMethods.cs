using System.Collections.Generic;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static partial class IntExtensionMethods
    {
        /// <summary>
        /// Finds the lowest-value integer in list that's greater than the
        /// given value. 
        /// </summary>
        /// <returns>Integer value or null.</returns>
        public static int? GetClosestHigher(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d > value && (best.HasValue == false || d < best.Value))
                    best = d;
            }

            return best;
        }
        
        /// <summary>
        /// Finds the highest-value integer in list that's lower than the
        /// given value. 
        /// </summary>
        /// <returns>Integer value or null.</returns>
        public static int? GetClosestLower(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d < value && (best.HasValue == false || d > best.Value))
                    best = d;
            }

            return best;
        }
        
        /// <summary>
        /// Converts given integer to a string and prepends a "0" if the value
        /// is less than 10 and non-negative.
        /// </summary>
        public static string AsAtLeast2Digits(this int i)
        {
            if (i is >= 0 and < 10)
            {
                return "0" + i;
            }
            else
            {
                return i.ToString();
            }
        }

        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }
        
        public static bool IsOdd(this int i)
        {
            return i % 2 == 1;
        }
    }
}