using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DamageTest
    {
        
        [Test]
        public void FallDamage()
        {
            PlayerStatus stats = new PlayerStatus();
            stats.Health = 3;

            stats.damage();

            Assert.AreEqual(expected: 2, stats.Health);

           
        }

        
       
    }
}
