using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_RPG_thread_game;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;
using The_RPG_thread_game.Utillity;

namespace Testing
{
    [TestClass]
    public class TestFarm
    {
        private int WaitingFarmers = 13;

        private Action<Thread> StartNJoinThread = thread =>
        {
            thread.Start();
            thread.Join();
        };
        

        [TestMethod]
        public void TestEnteringOfFarm()
        {
            Farm Farm = new Farm(new Vector2(0,0));
            ResourceManager.Instance.Meat = 0;
            Thread Thread = new Thread(() => FarmThread(Farm));

            StartNJoinThread(Thread);

            Assert.AreEqual(ResourceManager.Instance.Meat, Farm.MeatPerFarmer);
        }

        [TestMethod]
        public void TestSemaphoreWaitingWithXAntalFarmers()
        {
            Farm Farm = new Farm(new Vector2(0, 0));
            ResourceManager.Instance.Meat = 0;
            Thread[] Threads = new Thread[Farm.MaxFarmerCount + WaitingFarmers];
            

            for (int ThreadNumber = 0; ThreadNumber < Threads.Length; ThreadNumber++)
            {
                StartNJoinThread(new Thread(() => FarmThread(Farm)));
            }

            Assert.AreEqual(ResourceManager.Instance.Meat,Threads.Length * Farm.MeatPerFarmer);
        }

        private void FarmThread(Farm farm)
        {
            //farm.Enter();
        }
    }
}
