using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class MovementTests
    {
        [Test]
        public void Move_Forward(){
            Assert.AreEqual(1, new Movement().CalculatePosition(1,1,1).z,0.1f);
        }
        [Test]
        public void Rotate_Forward(){
            Assert.AreEqual(1, new Movement().CalculateRotation(1,1,1).y,0.1f);
        }
    }
}