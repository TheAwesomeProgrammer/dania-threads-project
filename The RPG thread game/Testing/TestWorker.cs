using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_RPG_thread_game;
using The_RPG_thread_game.Utillity;
using System.Diagnostics;

namespace Testing
{
    [TestClass]
    public class TestWorker
    {
        private float TimeOutThreeshold = 5000;
        private int TimeOutID = 1;
        private int Framerate = 60;

        [TestMethod]
        public void TestWorkerMovingBetweenStructures()
        {
            Structure StartStructure = new BigTownhall(new Vector2(20, 20), @"Resources\apple.png", 1);
            Structure EndStructure = new BigTownhall(new Vector2(10, 10), @"Resources\apple.png", 1);
            Worker Worker = new Farmer(new Vector2(0, 0), @"Resources\apple.png", 1, StartStructure, EndStructure);
            DateTimeTimer Timer = DateTimeTimer.Instance;

            Timer.StartTimer(GetHashCode());
            Timer.StartTimer(TimeOutID);
            while (true)
            {
                if (Timer.GetTimeGone(1).TotalMilliseconds > TimeOutThreeshold ||
                    StartStructure.HasEntered && EndStructure.HasEntered)
                {
                    break;
                }
                WorkerThread(Worker,Timer);
                Thread.Sleep(1000 / Framerate);
            }

            Assert.AreEqual(true, StartStructure.HasEntered && EndStructure.HasEntered);
        }

        private void WorkerThread(Worker worker,DateTimeTimer timer)
        {
            float DeltaTime = (float)(timer.GetTimeGone(GetHashCode()).TotalMilliseconds / 1000);
            worker.Update(DeltaTime);

            timer.StartTimer(GetHashCode());

        }


    }
}
