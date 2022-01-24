using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector3Ints
{
    public static partial class Vector3IntExtensionMethods
    {
        
        /// <summary>
        /// Multiplies Vector3Int and Vector3 component-wise. Functionally
        /// equivalent to Vector3.Scale.
        /// </summary>
        public static Vector3 Multiply(this Vector3Int v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies two Vector3Ints component-wise. Functionally equivalent to
        /// Vector3Int.Scale.
        /// </summary>
        public static Vector3Int Multiply(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and floors each value.
        /// </summary>
        public static Vector3Int DivideAndFloor(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and ceils each value.
        /// </summary>
        public static Vector3Int DivideAndCeil(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(
                Mathf.CeilToInt((float) v1.x / v2.x),
                Mathf.CeilToInt((float) v1.y / v2.y), 
                Mathf.CeilToInt((float) v1.z / v2.z));
            
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and rounds each value.
        /// </summary>
        public static Vector3Int DivideAndRound(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(
                Mathf.RoundToInt((float) v1.x / v2.x),
                Mathf.RoundToInt((float) v1.y / v2.y), 
                Mathf.RoundToInt((float) v1.z / v2.z));
            
            return retval;
        }
    }
}