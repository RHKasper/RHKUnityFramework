using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector2s
{
    public static partial class Vector2ExtensionMethods 
    {
        /// <summary>
        /// Multiplies two Vector2s component-wise by two floats.
        /// </summary>
        public static Vector2 Multiply(this Vector2 v, float x, float y)
        {
            return new Vector2(v.x * x, v.y * y);
        }

        /// <summary>
        /// Multiplies two Vector2s component-wise.
        /// </summary>
        public static Vector2 Multiply(this Vector2 v, Vector2 v2)
        {
            return new Vector2(v.x * v2.x, v.y * v2.y);
        }
        
        /// <summary>
        /// Finds greatest components value in a Vector2.
        /// </summary>
        public static float Max(this Vector2 v)
        {
            return Mathf.Max(v.x, v.y);
        }
        
        /// <summary>
        /// Finds smallest components value in a Vector2.
        /// </summary>
        public static float Min(this Vector2 v)
        {
            return Mathf.Min(v.x, v.y);
        }

    }
}
