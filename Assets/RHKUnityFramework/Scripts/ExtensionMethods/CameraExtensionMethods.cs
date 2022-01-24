using RHKUnityFramework.Scripts.ExtensionMethods.Vector3s;
using UnityEngine;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class CameraExtensionMethods
    {

        public static float GetCameraDistanceToSeeWholeBounds(this Camera camera, Bounds bounds, Vector3 viewFromDirection, float fudgeFactor = 1.2f)
        {
            viewFromDirection = viewFromDirection.normalized;
            Transform camTransform = camera.transform;

            Vector3 initialPos = camTransform.position;
            Quaternion initialRot = camTransform.rotation;
            
            //Place the camera outside the object, looking at it.
            camTransform.position = bounds.center + viewFromDirection * bounds.size.magnitude;
            camTransform.LookAt(bounds.center);
            
            //measure how much of the viewport it takes up then use that to determine how much closer or further it should be.
            Rect initialViewport = camera.ViewportRectFromBounds(bounds);
            float initialDistance = (camTransform.position - bounds.center).magnitude;
            float finalDistance = fudgeFactor * initialDistance * Mathf.Max(initialViewport.height, initialViewport.width);

            camTransform.SetPositionAndRotation(initialPos, initialRot);

            finalDistance = Mathf.Max(bounds.extents.Max() * fudgeFactor, finalDistance);
            
            return finalDistance;
        }
        
        /// <summary>
        /// This method moves the camera object to see the entirety of bounds.
        /// </summary>
        public static void MoveCameraToSeeWholeBounds(this Camera camera, Bounds bounds, Vector3 viewFromDirection, float fudgeFactor = 1.2f)
        {
            viewFromDirection = viewFromDirection.normalized;
            float distanceToSeeWholeBounds = GetCameraDistanceToSeeWholeBounds(camera, bounds, viewFromDirection, fudgeFactor);
            Transform camTransform = camera.transform;
            
            //reposition camera based on calculated viewport size
            camTransform.position = bounds.center + distanceToSeeWholeBounds * viewFromDirection;
            camTransform.LookAt(bounds.center);
        }

        public static Vector2 WorldVectorToScreenVector(this Camera camera, Vector3 start, Vector3 end)
        {
            return camera.WorldToScreenPoint(end) - camera.WorldToScreenPoint(start);
        }
    
        /// <summary>
        /// Calculates the world-space position of the top-right and bottom-left corners of the viewport at the given distance.
        /// </summary>
        public static void GetViewportCornersInWorldSpace(this Camera camera, float distance, out Vector3 topRight, out Vector3 bottomLeft)
        {
            Vector3 v3ViewPort = new Vector3(0,0,distance);
            bottomLeft = camera.ViewportToWorldPoint(v3ViewPort);
            v3ViewPort.Set(1,1,distance);
            topRight = camera.ViewportToWorldPoint(v3ViewPort);
        }
        
        public static Texture2D RenderCameraToTexture2D(this Camera c)
        {
            return c.RenderCameraToTexture2D(c.targetTexture.width, c.targetTexture.height);
        }

        public static Texture2D RenderCameraToTexture2D(this Camera c, int width, int height)
        {
            //store camera's initial target and switch to the created RT
            RenderTexture initialRt = c.targetTexture;
            RenderTexture rt = new RenderTexture(width, height, 1);
            c.targetTexture = rt;
            
            // Render and convert to Texture2D
            c.Render();
            Texture2D texture2D = rt.ToTexture2D();
            
            // Restore initial camera target
            c.targetTexture = initialRt;
            return texture2D;
        }

        public static Texture2D ToTexture2D(this RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
            var oldRT = RenderTexture.active;
            RenderTexture.active = rTex;

            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            RenderTexture.active = oldRT;
            return tex;
        }
        
        public static void SaveTextureAsPNG(this Texture2D texture, string fullPath)
        {
            if (fullPath.EndsWith(".png") == false)
                fullPath += ".png";

            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(fullPath, bytes);
            Debug.Log(bytes.Length/1024  + "Kb was saved as: " + fullPath);
        }
        
        //========== Private Methods ==================================================================================
        public static Rect ViewportRectFromBounds(this Camera camera, Bounds worldBounds)
        {
            Bounds b = worldBounds;
            var extentPoints = new Vector2[]
            {
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f)
            };
 
            Vector2 min = extentPoints[0];
            Vector2 max = extentPoints[0];
            foreach (Vector2 v in extentPoints)
            {
                min = Vector2.Min(min, v);
                max = Vector2.Max(max, v);
            }
            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
    }
}
