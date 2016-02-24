using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game.OtherClasses.TownHall
{
    public class Recruiter : GameObject
    {
        // Først laver vi en semafor så der kan komme 5 ind, og inden i den lave en lock så kun 1 ka køre af gangen.
        private ResourceManager ResourceManager = ResourceManager.Instance;
        private Form1 Form1 = Form1.Self;
        private TownHallMain TownHall = new TownHallMain(Form1.Self);
        private static Semaphore BuildManager = new Semaphore(0,5);
        private static readonly object BuildManagerLock = new object();
        public int BuildTime = 1000;

        public Recruiter() :
            base(new Vector2(0,0))
        {
            
        }


        public void BuildWorker(Worker workerToBuild)
        {

            BuildManager.WaitOne(0);
            Form1.QueuedWorkerCount++;
            bool Building = false;

            lock (BuildManagerLock)
            {
                if (ResourceManager.Gold >= TownHall.WorkerGoldPrice &&
                    ResourceManager.Meat >= TownHall.WorkerFoodPrice)
                {
                    ResourceManager.Gold -= TownHall.WorkerGoldPrice;
                    ResourceManager.Meat -= TownHall.WorkerFoodPrice;
                    Building = true;
                }
            }
            if (Building)
            {
                TownHall.BuildWorker(workerToBuild);
            }


            Form1.QueuedWorkerCount--;
            BuildManager.Release(); // Releaser vores semaphore så andre tråde kan komme til.
                
            
        }


    }
}


