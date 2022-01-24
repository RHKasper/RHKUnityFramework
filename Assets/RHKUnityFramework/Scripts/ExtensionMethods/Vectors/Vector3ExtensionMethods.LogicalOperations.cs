using System;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vectors
{
    public static partial class Vector3ExtensionMethods
    {
        /// <summary>
        /// Finds lowest component value in a Vector3.
        /// </summary>
        public static float Min(this Vector3 v)
        {
            return Mathf.Min(v.x, v.y, v.z);
        }

        /// <summary>
        /// Finds greatest component value in a Vector3.
        /// </summary>
        public static float Max(this Vector3 v)
        {
            return Mathf.Max(v.x, v.y, v.z);
        }

        
        /// <summary>
        /// Finds the max between v1 and v2 in each component
        /// </summary>
        public static Vector3 Max(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
        }
        
                
        /// <summary>
        /// Converts each component of a Vector3 to its absolute value.
        /// </summary>
        public static Vector3 Abs(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        
        /// <summary>
        /// Rounds each component of a Vector3 to a given number of decimal places
        /// </summary>
        public static Vector3 Round(this Vector3 v, int decimals)
        {
            return new Vector3((float) Math.Round(v.x, decimals), (float) Math.Round(v.y, decimals), (float) Math.Round(v.z, decimals));
        }


        public static bool RoughlyEquals(this Vector3 v, Vector3 other, float tolerance = Single.Epsilon)
        {
            return v.x.RoughlyEquals(other.x, tolerance) && 
                   v.y.RoughlyEquals(other.y, tolerance) &&
                   v.z.RoughlyEquals(other.z, tolerance);
        }
    }
}
