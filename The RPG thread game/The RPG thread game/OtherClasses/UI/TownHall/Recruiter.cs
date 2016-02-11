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
    abstract class Recruiter
    {
        // Først laver vi en semafor så der kan komme 5 ind, og inden i den lave en lock så kun 1 ka køre af gangen.
        private ResourceManager ResourceManager;
        private TownHallMain TownHall;
        private Form1 Form1;
        private BuildWorkerButton BuildWorkerButton;
        static Semaphore BuildManager = new Semaphore(0, 5);
        static readonly object BuildManagerLock = new object();
        public int BuildTime = 1000;


        public Unit BuildWorker(Builder builder)
        {
            if (BuildManager.WaitOne(0)) 
            {
                Form1.QueuedWorkerCount++;
                MessageBox.Show("Thread {0} queued a worker.", Thread.CurrentThread.Name);
                try
                { 
                     bool building = false;

                     lock (BuildManagerLock)
                    {
                         if (ResourceManager.Gold > TownHall.WorkerGoldPrice && ResourceManager.Meat > TownHall.WorkerFoodPrice && TownHall.CurrentUnits < TownHall.MaxUnits)
                         {
                              ResourceManager.Gold -= TownHall.WorkerGoldPrice;
                              ResourceManager.Meat -= TownHall.WorkerFoodPrice;
                              building = true;
                         }
                     }       
                     if(building)
                     {
                          MessageBox.Show("Thread {0} is building a unit.", Thread.CurrentThread.Name);
                          Thread.Sleep(5000); // sæt en procenttæller på her?
                          return builder.Build();
                     }
                     else
                     {
                          MessageBox.Show("Not enough resources and/or unitcap reached.");
                          return null;
                     }
                }
            
                finally
                {
                    Form1.QueuedWorkerCount--;
                    BuildManager.Release(); // Releaser vores semaphore så andre tråde kan komme til.
                }
            }
            else
            {
                MessageBox.Show("Cant build more workers.");
            }
            return null;
        } 
    }
}


//Recruiter = barracks
//Builder = Builder
//WorkerBuilder = soldierbuilder
//Worker = soldier
//Unit = Unit



// Lav en knap mere på basen til Build WORKER --> Under button click Thread recruit = new Thread(() => recruiter.BuildWorker(new WorkerBuilder())); recruit.Start(); Under Worker skal der instantieres og vises en ny worker. public bool buildingWorker = true; Progress(); 

// lav de 3 knapper og uncomment deres kode
// Under townhalls anden funktion skal være byg builder
// townhallup botton metode upgradechoisses
