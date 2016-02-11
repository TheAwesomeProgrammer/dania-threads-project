using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_RPG_thread_game;
using The_RPG_thread_game.Utillity;
using System.Diagnostics;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;

namespace Testing
{
    [TestClass]
    public class TestWorker
    {
        private const float TimeOutThreeshold = 5000;
        private const int TimeOutID = 1;
        private const int Framerate = 60;
        private DateTime StartTime;
        private DateTime EndTime;

        [TestMethod]
        public void TestWorkerMovingBetweenStructures()
        {
            Structure StartStructure = new Farm(new Vector2(20, 20));
            Structure EndStructure = new Farm(new Vector2(10, 10));
            GameObject Worker = new Farmer(new Vector2(0, 0), StartStructure, EndStructure);
            Worker = new ThreadUpdating(Worker);
            Counter Counter = Counter.Instance;

            Counter.StartCounter(TimeOutID);
            while (true)
            {
                if (Counter.GetTimeGone(1) > TimeOutThreeshold ||
                    StartStructure.HasEntered && EndStructure.HasEntered)
                {
                    break;
                }
                WorkerThread(Worker);
                Thread.Sleep(1000 / Framerate);
            }

            Assert.AreEqual(true, StartStructure.HasEntered && EndStructure.HasEntered);
        }

        private void WorkerThread(GameObject worker)
        {
            double DeltaTime = (EndTime - StartTime).TotalMilliseconds/1000;
            Time.Instance.AddTime(DeltaTime);
            StartTime = DateTime.Now;
            
            worker.Update(DeltaTime);

            EndTime = DateTime.Now;

        }


    }
}
