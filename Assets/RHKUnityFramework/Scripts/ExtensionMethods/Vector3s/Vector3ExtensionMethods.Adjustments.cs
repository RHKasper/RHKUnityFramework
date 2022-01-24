using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector3s
{
    public static partial class Vector3ExtensionMethods
    {
        /// <summary>
        /// Converts a Vector3 to a Vector3Int. Functionally equivalent to
        /// Vector3Int.FloorToInt.
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector3 v)
        {
            return new Vector3Int((int)v.x,(int)v.y,(int)v.z);
        }
        
        /// <summary>
        /// Clamps each component of vector v between the corresponding components of min and max.
        /// </summary>
        public static Vector3 Clamp(this Vector3 v, Vector3 min, Vector3 max)
        {
            float x = Mathf.Clamp(v.x, min.x, max.x);
            float y = Mathf.Clamp(v.y, min.y, max.y);
            float z = Mathf.Clamp(v.z, min.z, max.z);
            
            return new Vector3(x, y, z);
        }
        
        /// <summary>
        /// returns a vector where any non-zero component is set to 1 and zero remains 0
        /// </summary>
        public static Vector3 Digitize(this Vector3 v)
        {
            if (v.x != 0)
                v.x = 1;
            if (v.y != 0)
                v.y = 1;
            if (v.z != 0)
                v.z = 1;

            return v;
        }
        
        public static Vector3 RemoveInfinities(this Vector3 v, float valueToUseInstead)
        {
            if (float.IsInfinity(v.x))
                v.x = valueToUseInstead;
            if (float.IsInfinity(v.y))
                v.y = valueToUseInstead;
            if (float.IsInfinity(v.z))
                v.z = valueToUseInstead;

            return v;
        }
        
        /// <summary>
        /// Create a vector where each component has the absolute value of v's largest component
        /// </summary>
        public static Vector3 MakeUniformToMax(this Vector3 v)
        {
            float maxAbs = v.MaxAbsValue();
            
            v.x = maxAbs;
            v.y = maxAbs;
            v.z = maxAbs;

            return v;
        }
    }
}
