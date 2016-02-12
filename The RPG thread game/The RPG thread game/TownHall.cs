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
    class TownHall
    {
        public int UpgradeGoldPrice = 300;
        public int UpgradeFoodPrice = 50;
        public int CurrentLevel = 1;
        public int UpgradeProgess = 0;

        private bool ProgressNotHundred;
        private ResourceManager ResourceManager = ResourceManager.Instance;
        private Form1 Form1;
        private int ProgressWaitTime = 100;

        public int CurrentUnits = 5;  // CurrentUnits = antallet af start units
        public float ResourceHandleTime = 1f; // sek
        public int MaxUnits = 10;
        public float WorkerMoveSpeed = 1f;

        public TownHall(Form1 form1)
        {
            Form1 = form1;
        }

        //public void TestThreads()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        new Thread(Form1.UseGold).Start();
        //    }
        //}

        public void Upgrade()
        {
            ResourceManager.Gold -= UpgradeGoldPrice;
            ResourceManager.Meat -= UpgradeFoodPrice;
            UpgradeGoldPrice += 200;
            UpgradeFoodPrice += 15;
        }



        public void Progress()
        {
            ProgressNotHundred = true;
            DateTime waitAbit;
            DateTime now = DateTime.Now;
            waitAbit = now.AddMilliseconds(ProgressWaitTime);

            while(ProgressNotHundred)
            {
                if(DateTime.Now > waitAbit)
                {
                    UpgradeProgess++;
                    now = DateTime.Now;
                    waitAbit = now.AddMilliseconds(ProgressWaitTime);
                    Form1.Invalidate(); // Update onpaint
                    if (UpgradeProgess >= 100)
                    {
                        //if(WorkerMoveSpeedChosen)
                        //{
                        //      ResourceHandleTime -= 0.025f; 
                        //      MaxUnits += 5;
                        //      WorkerMoveSpeed += 1f;
                        // }
                        //if(ResourceHandleTimeChosen)
                        //{
                        //    ResourceHandleTime -= 0.1f;
                        //    MaxUnits += 5;
                        //    WorkerMoveSpeed += 0.25f;
                        //}
                        //if(MaxUnitsChosen)
                        //{
                        //    ResourceHandleTime -= 0.025f;
                        //    MaxUnits += 20;
                        //    WorkerMoveSpeed += +0.25f;
                        //}
                       
                        //            lav en måde hvo¨rpå der vælges af de 3


                        // 12 levels af upgrades, ved 3, 6, 9, 12 bliver spriten opgraderet
                        // En flottere sprite
                        UpgradeProgess = 0;
                        CurrentLevel++;
                        ProgressNotHundred = false;
                    }
                } 
            }  
        }
    }
}
