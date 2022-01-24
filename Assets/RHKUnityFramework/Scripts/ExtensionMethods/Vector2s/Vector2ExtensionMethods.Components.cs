using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace RHKUnityFramework.Scripts.ExtensionMethods.Vector2s
{
    public static partial class Vector2ExtensionMethods 
    {
        public static Vector2 XX(this Vector3 v)
        {
            return new Vector2(v.x,v.x);
        }
        public static Vector2 XY(this Vector3 v)
        {
            return new Vector2(v.x,v.y);
        }
        public static Vector2 XZ(this Vector3 v)
        {
            return new Vector2(v.x,v.z);
        }
        
        public static Vector2 YX(this Vector3 v)
        {
            return new Vector2(v.y,v.x);
        }
        public static Vector2 YY(this Vector3 v)
        {
            return new Vector2(v.y,v.y);
        }
        public static Vector2 YZ(this Vector3 v)
        {
            return new Vector2(v.y,v.z);
        }
        
        public static Vector2 ZX(this Vector3 v)
        {
            return new Vector2(v.z,v.x);
        }
        public static Vector2 ZY(this Vector3 v)
        {
            return new Vector2(v.z,v.y);
        }
        public static Vector2 ZZ(this Vector3 v)
        {
            return new Vector2(v.z,v.z);
        }
    }
}
