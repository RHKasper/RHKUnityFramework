using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vectors
{
    public static class Vector2ExtensionMethods 
    {
        public static Vector2 Multiply(this Vector2 v, float x, float y)
        {
            return new Vector2(v.x * x, v.y * y);
        }

        public static Vector2 Multiply(this Vector2 v, Vector2 v2)
        {
            return new Vector2(v.x * v2.x, v.y * v2.y);
        }
    }
}
