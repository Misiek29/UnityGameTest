using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlatformTest
    {
        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));

            // game = gameGameObject.GetComponent<game>();
        }

        [TearDown]
        public void Teardown()
        {
            GameObject[] gameObjectsList = GameObject.FindObjectsOfType<GameObject>();

            for (int i = 0; i < gameObjectsList.Length; i++)
            {
                GameObject gameObject = gameObjectsList[i];
                MonoBehaviour.DestroyImmediate(gameObject);

            }
        }


        [UnityTest]
        public IEnumerator FallPlatformTest()
        {
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));

            Transform fallPlatform = GameObject.Find("fall(Clone)").transform;
   
           
            var fallPlatformPosition = fallPlatform.position.y;

           
           Debug.Log(fallPlatformPosition);

            yield return new WaitForSeconds(5f);


            Assert.Greater(fallPlatformPosition, 0);
        }

        [UnityTest]
        public IEnumerator FallPlatformTestPlayer()
        {
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));

            Transform fallPlatform = GameObject.Find("fall(Clone)").transform;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");


            var fallPlatformPosition = fallPlatform.position.y;
            playerObject.transform.position = new Vector3 (fallPlatform.transform.position.x, fallPlatform.transform.position.y+10, fallPlatform.transform.position.z);

            Debug.Log(fallPlatformPosition);

            yield return new WaitForSeconds(3f);


            Assert.Less(playerObject.transform.position.y, 0);
        }
    }
}
