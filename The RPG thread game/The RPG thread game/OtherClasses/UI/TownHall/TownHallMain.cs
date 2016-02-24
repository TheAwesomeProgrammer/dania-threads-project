using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game
{
    class TownHallMain 
    {
        public int UpgradeGoldPrice = 300;
        public int UpgradeFoodPrice = 50;
        public int WorkerGoldPrice = 20;
        public int WorkerFoodPrice = 50;

        public int CurrentLevel = 1;
        public int UpgradeProgess = 0;

        private bool ProgressNotHundred;
        private bool UpgradeTownHall;
        private ResourceManager ResourceManager = ResourceManager.Instance;
        private Form1 Form1;
        private int ProgressWaitTime = 100;

        public int CurrentUnits = 5;  
        public float ResourceHandleTime = 1f; // sek
        public int MaxUnits = 10;
        public float WorkerMoveSpeed = 1f;

        public int MSLevel = 1;
        public int DSLevel = 1;
        public int UCLevel = 1;


        public TownHallMain(Form1 form1)
        {
            Form1 = form1;
        }

        public void Upgrade()
        {
            ResourceManager.Gold -= UpgradeGoldPrice;
            ResourceManager.Meat -= UpgradeFoodPrice;
            UpgradeGoldPrice += 200;
            UpgradeFoodPrice += 15;
        }


        public bool CanUpgradeTownHall()
        {
            return ResourceManager.Gold > UpgradeGoldPrice && ResourceManager.Meat > UpgradeFoodPrice;
        }
        public bool CanBuildWorker()
        {
            return ResourceManager.Gold > WorkerGoldPrice && ResourceManager.Meat > WorkerFoodPrice;

        }

        public void ManageTownHallImages()
        {
            if (CurrentLevel > 3 && CurrentLevel < 6)
            {
                Form1.TownHallImg = Image.FromFile(@"Resources/Lvl2TownHall.png");
            }

            if (CurrentLevel > 6 && CurrentLevel < 9)
            {
                Form1.TownHallImg = Image.FromFile(@"Resources/Lvl3TownHall.png");
            }

            if (CurrentLevel > 9)
            {
                Form1.TownHallImg = Image.FromFile(@"Resources/Lvl4TownHall.png");
            }
        }

        public void BuildWorker(Worker workerToBuild)
        {
            ProgressWaitTime = 20;
            Progress();
            int WorkerThreadId = workerToBuild.GetObjectId();
            ThreadManager.Instance.AddThread(new Thread(() => workerToBuild.ThreadUpdateLoop(WorkerThreadId)),
                WorkerThreadId);
            GameWorld.AddObjectInNextCycle(workerToBuild);
        }

        public void UpdateTownHall()
        {
            ProgressWaitTime = 100;
            if (CanUpgradeTownHall())
            {
                ResourceManager.Gold -= UpgradeGoldPrice;
                ResourceManager.Meat -= UpgradeFoodPrice;
                Progress();
            }
        }
        

        private void Progress()
        {
            ProgressNotHundred = true;
            DateTime waitAbit;
            DateTime now = DateTime.Now;
            waitAbit = now.AddMilliseconds(ProgressWaitTime);

            while (ProgressNotHundred)
            {
                if (DateTime.Now > waitAbit)
                {
                    UpgradeProgess++;
                    now = DateTime.Now;
                    waitAbit = now.AddMilliseconds(ProgressWaitTime);
                    if (UpgradeProgess >= 100)
                    {
                        if (UpgradeTownHall)
                        {
                            ManageTownHallImages();
                            UpgradeManager();
                            UpgradeProgess = 0;
                            CurrentLevel++;
                            
                        }
                        ProgressNotHundred = false;
                    }
                }
            }
        }
        

        public void UpgradeManager()
        {
            if (Form1.MSChosen)
            {
                ResourceHandleTime -= 0.025f;
                MaxUnits += 5;
                WorkerMoveSpeed += 1f;
                Form1.MSChosen = false;
            }
            if (Form1.DSChosen)
            {
                ResourceHandleTime -= 0.1f;
                MaxUnits += 5;
                WorkerMoveSpeed += 0.25f;
                Form1.DSChosen = false;
            }
            if (Form1.UCChosen)
            {
                ResourceHandleTime -= 0.025f;
                MaxUnits += 20;
                WorkerMoveSpeed += +0.25f;
                Form1.UCChosen = false;
            }

        }
    }
}
