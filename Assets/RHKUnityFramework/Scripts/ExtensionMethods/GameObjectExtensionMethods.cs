using System.Collections.Generic;
using System.Linq;
using RHKUnityFramework.Scripts.Types;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static partial class GameObjectExtensionMethods
    {
        /// <summary>
        /// Recursively set all of a GameObject's children to active.
        /// </summary>
        /// <param name="obj">Root object</param>
        /// <param name="value">Modifies root object's active state</param>
        public static void SetAllChildrenActive(this GameObject obj, bool value)
        {
            obj.SetActive(value);
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                obj.transform.GetChild(i).gameObject.SetAllChildrenActive(true);
            }
        }

        /// <summary>
        /// Call SetActive() on a collection of objects with a given value
        /// </summary>
        public static void SetActiveAll(this IEnumerable<GameObject> objs, bool value)
        {
	        foreach (GameObject o in objs) o.SetActive(value);
        }
        
        
        /// <summary>
        /// Get the Scene Hierarchy path of a GameObject
        /// </summary>
        public static string GetPath(this GameObject gameObject)
        {
            return gameObject.transform.GetPath();
        }

        /// <summary>
        /// Set layer of GameObject and all of its children. Includes inactive
        /// children.
        /// </summary>
        public static void SetLayerRecursively(this GameObject objectToSet, int layer)
        {
            foreach (Transform transform in objectToSet.GetComponentsInChildren<Transform>(true))
                transform.gameObject.layer = layer;
        }
        

       

        /// <summary>
        /// Convert collection of GameObjects to list of TransformDatas.
        /// </summary>
        public static List<TransformData> GetTransformData(this IEnumerable<GameObject> gameObjects)
        {
            return gameObjects.Select(g => new TransformData(g.transform)).ToList();
        }

       

        /// <summary>
        /// Scales the target around an arbitrary point by scaleFactor.
        /// This is relative scaling, meaning using  scale Factor of Vector3.one
        /// will not change anything and new Vector3(0.5f,0.5f,0.5f) will reduce
        /// the object size by half.
        /// The pivot is assumed to be the position in the space of the target.
        /// Scaling is applied to localScale of target.
        /// </summary>
        /// <param name="target">The object to scale.</param>
        /// <param name="pivot">The point to scale around in space of target.</param>
        /// <param name="scaleFactor">The factor with which the current localScale of the target will be multiplied with.</param>
        public static void ScaleAroundRelative(this GameObject target, Vector3 pivot, Vector3 scaleFactor)
        {
            // pivot
            var pivotDelta = target.transform.localPosition - pivot;
            pivotDelta.Scale(scaleFactor);
            target.transform.localPosition = pivot + pivotDelta;

            // scale
            var finalScale = target.transform.localScale;
            finalScale.Scale(scaleFactor);
            target.transform.localScale = finalScale;
        }

        /// <summary>
        /// Scales the target around an arbitrary pivot.
        /// This is absolute scaling, meaning using for example a scale factor of
        /// Vector3.one will set the localScale of target to x=1, y=1 and z=1.
        /// The pivot is assumed to be the position in the space of the target.
        /// Scaling is applied to localScale of target.
        /// </summary>
        /// <param name="target">The object to scale.</param>
        /// <param name="pivot">The point to scale around in the space of target.</param>
        /// <param name="scaleFactor">The new localScale the target object will have after scaling.</param>
        public static void ScaleAround(this GameObject target, Vector3 pivot, Vector3 newScale)
        {
            // pivot
            Vector3 pivotDelta = target.transform.localPosition - pivot; // diff from object pivot to desired pivot/origin
            Vector3 scaleFactor = new Vector3(
                newScale.x / target.transform.localScale.x,
                newScale.y / target.transform.localScale.y,
                newScale.z / target.transform.localScale.z );
            pivotDelta.Scale(scaleFactor);
            target.transform.localPosition = pivot + pivotDelta;

            //scale
            target.transform.localScale = newScale;
        }
        
        /// <summary>
        /// Create bounding box that encapsulates all colliders on this GameObject and its children
        /// </summary>
        public static Bounds MakeBoundingBoxForObjectColliders(this GameObject rootObject, bool includeInactive = false)
        {
            Collider[] colliders = rootObject.GetComponentsInChildren<Collider>(includeInactive);
            if (colliders.Length == 0)
            {
                return new Bounds(rootObject.transform.position, Vector3.zero);
            }
    
            return colliders.MakeBoundingBox();
        }
        
        /// <summary>
        /// Makes a bounding box that encapsulates every renderer on the "rootObject" and all of its children.
        /// </summary>
        public static Bounds MakeBoundingBoxForObjectRenderers(this GameObject rootObject, bool includeInactive = false)
        {
            Renderer[] renderers = rootObject.GetComponentsInChildren<Renderer>(includeInactive);
            return renderers.MakeBoundingBox();
        }
    }
}
