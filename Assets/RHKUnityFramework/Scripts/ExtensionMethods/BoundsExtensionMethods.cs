using System.Collections.Generic;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class BoundsExtensionMethods
    {
        /// <summary>
        /// Create bounding box that encapsulates all given colliders. 
        /// </summary>
        public static Bounds MakeBoundingBox(this Collider[] colliders)
        {
            Bounds bounds = colliders[0].bounds;
            foreach (Collider c in colliders)
            {
                bounds.Encapsulate(c.bounds);
            }

            return bounds;
        }
        
        
        /// <summary>
        /// Makes a bounding box encapsulating all the renderers passed in
        /// </summary>
        public static Bounds MakeBoundingBox(this Renderer[] renderers, Bounds defaultValue = new Bounds())
        {
            if (renderers.Length == 0)
            {
                return defaultValue;
            }

            //We start with one of the existing bounds to ensure no unnecessary space in the bounds
            Bounds bounds = new Bounds(renderers[0].bounds.center, renderers[0].bounds.size);
            foreach (Renderer r in renderers)
            {
                bounds.Encapsulate(r.bounds);
            }

            return bounds;
        }

        /// <summary>
        /// Returns true if any points are within the bounds.
        /// </summary>
        public static bool ContainsAnyPoint(this Bounds boundsToCheck, IEnumerable<Vector3> points)
        {
            foreach (Vector3 point in points)
            {
                if (boundsToCheck.Contains(point))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Find world-space positions of the bounding box's eight corners.
        /// </summary>
        public static List<Vector3> GetBoundsCorners(this Bounds bounds, Vector3 worldPosition, Quaternion worldRotation)
        {
            Vector3 boundPoint1 = bounds.min;
            Vector3 boundPoint2 = bounds.max;
            Vector3 boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
            Vector3 boundPoint4 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint1.z);
            Vector3 boundPoint5 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
            Vector3 boundPoint6 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint2.z);
            Vector3 boundPoint7 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint2.z);
            Vector3 boundPoint8 = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint1.z);
            
            
            var retVal =  new List<Vector3>
            {
                boundPoint1, boundPoint2, boundPoint3, boundPoint4,
                boundPoint5, boundPoint6, boundPoint7, boundPoint8,
            };

            for (int i = 0; i < retVal.Count; i++)
                retVal[i] = worldPosition + worldRotation * retVal[i];

            return retVal;
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

        /// <summary>
        /// Find world-space positions of the center of each of the bounding box's
        /// six faces.
        /// </summary>
        public static List<Vector3> GetBoundsFaceCenters(this Bounds bounds, Vector3 boundsWorldSpacePosition)
        {
            List<Vector3> points = new List<Vector3>()
            {
                boundsWorldSpacePosition + new Vector3(bounds.extents.x, 0, 0),
                boundsWorldSpacePosition + new Vector3(-bounds.extents.x, 0, 0),
                boundsWorldSpacePosition + new Vector3(0, bounds.extents.y, 0),
                boundsWorldSpacePosition + new Vector3(0, -bounds.extents.y, 0),
                boundsWorldSpacePosition + new Vector3(0, 0, bounds.extents.z),
                boundsWorldSpacePosition + new Vector3(0, 0, -bounds.extents.z),
            };
            return points;
        }
    }
}
