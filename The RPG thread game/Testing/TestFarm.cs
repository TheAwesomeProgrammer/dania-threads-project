using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.Utillity;

namespace Testing
{
    [TestClass]
    public class TestFarm
    {
        private int TestTimerID = 5;
        private int WaitingFarmers = 13;

        private Action<Thread> StartNJoinThread = thread =>
        {
            thread.Start();
            thread.Join();
        };
        

        [TestMethod]
        public void TestEnteringOfFarm()
        {
            Farm Farm = new Farm();
            FarmResourceManager.Instance.Resource = 0;
            Thread Thread = new Thread(() => FarmThread(Farm));

            StartNJoinThread(Thread);

            Assert.AreEqual(FarmResourceManager.Instance.Resource, Farm.ResourcePerFarmer);
        }

        [TestMethod]
        public void TestSemaphoreWaitingWithXAntalFarmers()
        {
            Farm Farm = new Farm();
            FarmResourceManager.Instance.Resource = 0;
            Thread[] Threads = new Thread[Farm.MaxFarmerCount + WaitingFarmers];
            

            for (int ThreadNumber = 0; ThreadNumber < Threads.Length; ThreadNumber++)
            {
                StartNJoinThread(new Thread(() => FarmThread(Farm)));
            }

            Assert.AreEqual(FarmResourceManager.Instance.Resource,Threads.Length * Farm.ResourcePerFarmer);
        }

        private void FarmThread(Farm farm)
        {
            farm.Enter();
        }
    }
}
