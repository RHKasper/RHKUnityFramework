using System;
using System.Globalization;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class DoubleExtensionMethods
    {
        /// <summary>
        /// Remaps a number between from1 and to1 to the corresponding number between from2 and to2
        /// </summary>
        public static double Remap (this double value, double inMin, double inMax, double outMin, double outMax) {
            return (value - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
        }
        
        /// <summary>
        /// Determines the equality of two doubles up to a specified precision
        /// </summary>
        /// <returns>True if the difference between f and f1 is less than precision</returns>
        public static bool RoughlyEquals(this double f, double f1, double precision = Single.Epsilon)
        {
            return Math.Abs(f1 - f) < Math.Abs(precision);
        }

        /// <summary>
        /// Returns -1, 0, or 1 depending on the sign of the given double.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static double Sign(this double f)
        {
            if (f == 0)
                return 0;
            if (f > 0)
                return 1;
            else
                return -1;
        }
        
        /// <summary>
        /// Convert double to rounded number as a string.
        /// </summary>
        /// <param name="f">Raw double value.</param>
        /// <param name="digitsAfterDecimalPoint">Precision of rounded value.</param>
        public static string ToRoundedString(this double f, int digitsAfterDecimalPoint)
        {
            return Math.Round(f, digitsAfterDecimalPoint).ToString(CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// Converts any angle to the corresponding angle between 0 and 360
        /// </summary>
        public static double ReduceAngleTo0To360(this double f)
        {
            while (f < 0)
                f += 360;
            while (f > 360)
                f -= 360;
            return f % 360;
        }
    }
}