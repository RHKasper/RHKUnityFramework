using System;
using System.Globalization;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class FloatExtensionMethods
    {
        /// <summary>
        /// Remaps a number between from1 and to1 to the corresponding number between from2 and to2
        /// </summary>
        public static float Remap (this float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        
        /// <summary>
        /// Determines the equality of two floats up to a specified precision
        /// </summary>
        /// <returns>True if the difference between f and f1 is less than precision</returns>
        public static bool RoughlyEquals(this float f, float f1, float precision = Single.Epsilon)
        {
            return Mathf.Abs(f1 - f) < Mathf.Abs(precision);
        }

        /// <summary>
        /// Returns -1, 0, or 1 depending on the sign of the given float.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Sign(this float f)
        {
            if (f == 0)
                return 0;
            if (f > 0)
                return 1;
            else
                return -1;
        }
        
        /// <summary>
        /// Convert float to rounded number as a string.
        /// </summary>
        /// <param name="f">Raw float value.</param>
        /// <param name="digitsAfterDecimalPoint">Precision of rounded value.</param>
        public static string ToRoundedString(this float f, int digitsAfterDecimalPoint)
        {
            return Math.Round(f, digitsAfterDecimalPoint).ToString(CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// Converts any angle to the corresponding angle between 0 and 360
        /// </summary>
        public static float ReduceAngleTo0To360(this float f)
        {
            while (f < 0)
                f += 360;
            while (f > 360)
                f -= 360;
            return f % 360;
        }
        
        /// <summary>
        /// Clamps <paramref name="value"/> so its absolute value is no less than absMin and no more than absMax
        /// </summary>
        /// <param name="value">The value being clamped.</param>
        /// <param name="absMin">The minimum absolute value (must be no less than 0)</param>
        /// <param name="absMax">The maximum absolute value (must be no less than <paramref name="absMin"/>)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static float ClampAbs(this float value, float absMin, float absMax)
        {
            if (absMax < 0 || absMin < 0)
                throw new ArgumentException("absMin and absMax must not be negative numbers. Min: " + absMin + "; Max: " + absMax);
            if(absMin > absMax)
                throw new ArgumentException("absMin must be less than absMax. Min: " + absMin + "; Max: " + absMax);

            float sign = Mathf.Sign(value);
            float abs  = Mathf.Abs(value);

            float clampedAbs = Mathf.Clamp(abs, absMin, absMax);
            return sign * clampedAbs;
        }

        /// <summary>
        /// Clamp a float between 0 and 1
        /// </summary>
        public static float Clamp01(this float f)
        {
            return Mathf.Clamp01(f);
        }
    }
}