using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Farm_Semphore_
{
    public class Farm
    {
        public int StartFarmerCount = 5;
        public int MaxFarmerCount = 5;
        public int MeatPerFarmer = 5;

        public int FarmingTimeInMilliSecounds = 1;

        private Semaphore SemaphoreLock;

        public Farm()
        {
            SemaphoreLock = new Semaphore(StartFarmerCount, MaxFarmerCount);
        }

        public void Enter()
        {
            SemaphoreLock.WaitOne(-1);
            Thread.Sleep(FarmingTimeInMilliSecounds);
            ResourceManager.Instance.Meat += MeatPerFarmer;
            SemaphoreLock.Release();
        }

    }
}
