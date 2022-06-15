using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace RHKUnityFramework.TestExample.PlayMode
{
    public class PlayModeTests : MonoBehaviour
    {
        [SetUp]
        public void SetupTestScene()
        {
            // load scene, initialize services, etc.
        }
        
        /// <summary>
        /// Note this must be a coroutine and have the UnityTest attribute. Otherwise it will not work properly.
        /// </summary>
        [UnityTest]
        public IEnumerator Test()
        {
            yield return null;
            GameObject g = new GameObject();
            g.AddComponent<Image>();
            Assert.IsTrue(g.GetComponent<Image>());
        }
    }
}
