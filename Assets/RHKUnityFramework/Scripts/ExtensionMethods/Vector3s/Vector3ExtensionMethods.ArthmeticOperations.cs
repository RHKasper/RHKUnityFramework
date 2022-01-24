using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector3s
{
    public static partial class Vector3ExtensionMethods
    {
        /// <summary>
        /// Multiplies Vector3 and Vector3Int component-wise.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, Vector3Int v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies two Vector3s component-wise.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies Vector3 by three floats component-wise.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, float x, float y, float z)
        {
            Vector3 retval = new Vector3(v1.x * x, v1.y * y, v1.z * z);
            return retval;
        }

        /// <summary>
        /// Divides Vector3 by three floats component-wise.
        /// </summary>
        public static Vector3 Divide(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            return retval;
        }
        
        /// <summary>
        /// Sums components of a Vector3.
        /// </summary>
        public static float Sum(this Vector3 v)
        {
            return v.x + v.y + v.z;
        }
    }
}
