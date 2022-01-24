using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class VisualDebugExtensionMethods
    {
        public static void DrawPointAndRotationInEditorGizmos(this Vector3 point, Quaternion rotation, float lineLen = 1)
        {
            Debug.DrawRay(point, rotation * Vector3.up * lineLen, Color.green);
            Debug.DrawRay(point, rotation * Vector3.down * lineLen, Color.white);
            Debug.DrawRay(point, rotation * Vector3.right * lineLen, Color.red);
            Debug.DrawRay(point, rotation * Vector3.left * lineLen, Color.white);
            Debug.DrawRay(point, rotation * Vector3.forward * lineLen, Color.blue);
            Debug.DrawRay(point, rotation * Vector3.back * lineLen, Color.white);
        }
        
        public static void DrawBounds(this Bounds bounds, Transform localTo, Color lineColor = default)
        {
            bounds.DrawBounds(localTo.position, localTo.rotation, lineColor);
        }
        
        public static void DrawBounds(this Bounds bounds, Vector3 worldPosition = default, Quaternion worldRotation = default, Color lineColor = default)
        {
            if(lineColor == default)
                lineColor = Color.green;
            
            if(worldRotation == default)
                worldRotation = Quaternion.identity;

            var boundPoints = bounds.GetBoundsCorners(worldPosition, worldRotation);
            
            // rectangular cuboid
            // top of rectangular cuboid (6-2-8-4)
            Debug.DrawLine(boundPoints[5], boundPoints[1], lineColor);
            Debug.DrawLine(boundPoints[1], boundPoints[7], lineColor);
            Debug.DrawLine(boundPoints[7], boundPoints[3], lineColor);
            Debug.DrawLine(boundPoints[3], boundPoints[5], lineColor);
            
            // bottom of rectangular cuboid (3-7-5-1)
            Debug.DrawLine(boundPoints[2], boundPoints[6], lineColor);
            Debug.DrawLine(boundPoints[6], boundPoints[4], lineColor);
            Debug.DrawLine(boundPoints[4], boundPoints[0], lineColor);
            Debug.DrawLine(boundPoints[0], boundPoints[2], lineColor);
            
            // legs (6-3, 2-7, 8-5, 4-1)
            Debug.DrawLine(boundPoints[5], boundPoints[2], lineColor);
            Debug.DrawLine(boundPoints[1], boundPoints[6], lineColor);
            Debug.DrawLine(boundPoints[7], boundPoints[4], lineColor);
            Debug.DrawLine(boundPoints[3], boundPoints[0], lineColor);
        }
    }
}