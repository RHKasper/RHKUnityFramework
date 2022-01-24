using System.Collections.Generic;
using System.Linq;
using RHKUnityFramework.Scripts.Types;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static partial class TransformExtensionMethods
    {
        /// <summary>
        /// Destroy all children of a Transform.
        /// </summary>
        /// <param name="obj">Root Transform</param>
        /// <param name="destroyImmediate">Use Destroy or DestroyImmediate</param>
        public static void DestroyAllChildren(this Transform obj, bool destroyImmediate = false)
        {
            int numChildren = obj.childCount;
            for (int i = numChildren - 1; i >= 0; i--)
            {
                if(destroyImmediate)
                    Object.DestroyImmediate(obj.GetChild(i).gameObject);
                else
                    Object.Destroy(obj.GetChild(i).gameObject);
            }
        }
        
        
        /// <summary>
        /// Get the Scene Hierarchy path of a Transform
        /// </summary>
        public static string GetPath(this Transform current) {
            if (current.parent == null)
                return "/" + current.name;
            return current.parent.GetPath() + "/" + current.name;
        }
        
        /// <summary>
        /// Recursively set the layer of a GameObject and all its children, passing its transform
        /// </summary>
        public static void SetLayerRecursively(this Transform transform, int layer)
        {
            transform.gameObject.SetLayerRecursively(layer);
        }
        
        /// <summary>
        /// Calculate the average position of the given transforms either in local space or world space
        /// </summary>
        public static Vector3 GetAveragePosition(this IEnumerable<Transform> transforms, bool localSpace = true)
        {
            Vector3 sum = Vector3.zero;
            int num = 0;

            foreach (Transform transform in transforms)
            {
                sum += localSpace ? transform.localPosition : transform.position;
                num++;
            }

            return sum / num;
        }
        
        /// <summary>
        /// Reset Transform's local scale, rotation and position to defaults.
        /// </summary>
        public static void Reset(this Transform t)
        {
            t.localScale = Vector3.one;
            t.localRotation = Quaternion.identity;
            t.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Set Transform's local scale, rotation and position to match given
        /// TransformData.
        /// </summary>
        public static void SetLocal(this Transform t, TransformData transformData)
        {
            t.localScale = transformData.scale;
            t.localRotation = transformData.rotation;
            t.localPosition = transformData.position;
        }

        /// <summary>
        /// Find all children of a Transform. Does not include given Transform.
        /// </summary>
        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }

            return children;
        }
        
        /// <summary>
        /// Convert collection of Transforms to list of TransformDatas.
        /// </summary>
        public static List<TransformData> GetTransformData(this IEnumerable<Transform> transforms)
        {
            return transforms.Select(t => new TransformData(t)).ToList();
        }
        
        
        #region LookAway Methods
        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Vector3 point)
        {
            t.LookAt(2 * t.position - point);
        }


        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Transform target)
        {
            t.LookAt(2 * t.position - target.position);
        }

        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Vector3 point, Vector3 worldUp)
        {
            t.LookAt(2 * t.position - point, worldUp);
        }

        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Transform target, Vector3 worldUp)
        {
            t.LookAt(2 * t.position - target.position, worldUp);
        }
        #endregion
        
        /// <summary>
        /// Create bounding box that encapsulates all colliders on this Transform and its children. 
        /// </summary>
        public static Bounds MakeBoundingBoxForObjectColliders(this Transform rootObject, bool includeInactive = false)
        {
            return rootObject.gameObject.MakeBoundingBoxForObjectColliders(includeInactive);
        }
        
        /// <summary>
        /// Makes a bounding box that encapsulates every renderer on the "rootObject" and all of its children.
        /// </summary>
        public static Bounds MakeBoundingBoxForObjectRenderers(this Transform rootObject, bool includeInactive = false)
        {
            return rootObject.gameObject.MakeBoundingBoxForObjectRenderers(includeInactive);
        }
    }
}