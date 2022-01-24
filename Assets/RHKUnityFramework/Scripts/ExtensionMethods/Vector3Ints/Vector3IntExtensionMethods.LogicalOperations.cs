using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector3Ints
{
    public static partial class Vector3IntExtensionMethods
    {
        /// <summary>
        /// Finds the max between v1 and v2 in each component
        /// </summary>
        public static Vector3Int Max(this Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
        }
    }
}