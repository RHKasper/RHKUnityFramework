using System;
using System.Collections.Generic;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector3s
{
    public static partial class Vector3ExtensionMethods
    {
        #region Min and Max

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
        /// Returns the greatest non-zero value. Returns 0 if all values equal 0
        /// </summary>
        public static float MaxIgnoreZeroes(this Vector3 v)
        {
            float max = 0;
            if (max == 0 || v.x > max && v.x != 0)
                max = v.x;
            if (max == 0 || v.y > max && v.y != 0)
                max = v.y;
            if (max == 0 || v.z > max && v.z != 0)
                max = v.z;

            return max;
        }
        
        
        /// <summary>
        /// Returns the least non-zero value. Returns 0 if all values equal 0
        /// </summary>
        public static float MinIgnoreZeroes(this Vector3 v)
        {
            float min = 0;
            if (min == 0 || v.x < min && v.x != 0)
                min = v.x;
            if (min == 0 || v.y < min && v.y != 0)
                min = v.y;
            if (min == 0 || v.z < min && v.z != 0)
                min = v.z;

            return min;
        }

        #endregion
        
        /// <summary>
        /// Finds component with the greatest absolute value.
        /// </summary>
        /// <returns>Signed value that's furthest from zero.</returns>
        public static float MaxAbsValue(this Vector3 v)
        {
            float max = v.Max();
            float min = v.Min();

            return Mathf.Abs(max) > Mathf.Abs(min) ? max : min;
        }
                
        /// <summary>
        /// Converts each component of a Vector3 to its absolute value.
        /// </summary>
        public static Vector3 Abs(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }


        /// <summary>
        /// Creates new vector from the average of each component from a list
        /// of Vector3s. 
        /// </summary>
        public static Vector3 Average(this List<Vector3> vector3s)
        {
            Vector3 sum = Vector3.zero;

            foreach (Vector3 vector3 in vector3s)
            {
                sum += vector3;
            }

            int numVectors = vector3s.Count;

            sum = new Vector3(sum.x / numVectors, sum.y / numVectors, sum.z / numVectors);

            return sum;
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
        

        /// <summary>
        /// Finds greatest component value in a Vector3. Functionally
        /// equivalent to Max.
        /// </summary>
        public static float GreatestDimension(this Vector3 vector)
        {
            if (vector.x > vector.y && vector.x > vector.z)
                return vector.x;
            //At this point we know x is not the greatest, so it must be y or z
            return vector.y > vector.z ? vector.y : vector.z;
        }
        
        
        public static Vector3 Sign(this Vector3 v)
        {
            return new Vector3(Mathf.Sign(v.x), Mathf.Sign(v.y), Mathf.Sign(v.z));
        }

        /// <summary>
        /// Determines if all components are approximately equal.
        /// </summary>
        public static bool IsUniform(this Vector3 v)
        {
            return Math.Abs(v.x - v.y) < .01f && Math.Abs(v.y - v.z) < .01f;
        }
    }
}
