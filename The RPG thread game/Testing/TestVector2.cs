using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_RPG_thread_game;

namespace Testing
{
    [TestClass]
    public class TestVector2
    {
        [TestMethod]
        public void TestDistanceCheck()
        {
            Vector2 StartVector = new Vector2(0,0);
            Vector2 EndVector2 = new Vector2(1, 0);
            
            Assert.AreEqual(Math.Sqrt(1), StartVector.DistanceToVector(EndVector2));
        }
    }
}
