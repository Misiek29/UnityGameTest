using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Stats
    {
        
        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
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
        public IEnumerator DistanceTest()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            Transform Platform = GameObject.Find("platform_03 2(Clone)").transform;

            var distance = playerObject.GetComponent<PlayerStatus>().distance;

            playerObject.transform.position = new Vector3(Platform.transform.position.x, Platform.transform.position.y + 1, Platform.transform.position.z);

            yield return new WaitForSeconds(3f);

            var distance2 = playerObject.GetComponent<PlayerStatus>().distance;

            Assert.Greater(distance2, distance);
        }

        [UnityTest]
        public IEnumerator HealthTest()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            GameObject startPoint = GameObject.Find("Startpoint");

            var health = playerObject.GetComponent<PlayerStatus>().Health;
            Vector3 position = new Vector3(40, 10, 50);

            playerObject.transform.position = Vector3.Lerp(startPoint.transform.position, position,10f);

            yield return new WaitForSeconds(4f);

            Assert.Less(playerObject.GetComponent<PlayerStatus>().Health, health);
        }
    }
}
