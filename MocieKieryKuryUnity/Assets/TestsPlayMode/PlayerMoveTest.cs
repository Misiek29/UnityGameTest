using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMoveTest
    {
        public game game;
       
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
        public IEnumerator StartPosition()
        {
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));

            GameObject playerChicken = GameObject.Find("Chicken");
            GameObject startPoint = GameObject.Find("Startpoint");

            
            var startPosition = startPoint.transform.position;
          

            yield return new WaitForSeconds(1f);
            var playerPosition = playerChicken.transform.position;

            Assert.AreEqual(playerPosition, startPosition);
        }


        [UnityTest]
        public IEnumerator offTheMap()
        {
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));

            GameObject playerChicken = GameObject.Find("Chicken");
            GameObject startPoint = GameObject.Find("Startpoint");

            var startPosition = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z);
            Vector3 position = new Vector3(-50, 100, 100);

            playerChicken.transform.position = Vector3.Lerp(startPoint.transform.position, position, 10f);


            yield return new WaitForSeconds(7f);

            var playerPosition = new Vector3 (playerChicken.transform.position.x-0.4f, playerChicken.transform.position.y, playerChicken.transform.position.z);


            Assert.AreEqual((int)playerPosition.x, (int)startPosition.x);
            Assert.AreEqual((int)playerPosition.y, (int)startPosition.y);
            Assert.AreEqual((int)playerPosition.z, (int)startPosition.z);
        }






    }
}
