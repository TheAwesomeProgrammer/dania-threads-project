using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_RPG_thread_game.OtherClasses.TownHall
{
    class BuildWorkerButton
    {
        public int WorkerGoldPrice;
        public int WorkerFoodPrice;
        TownHallMain townHall;

        Thread BuildingWorker;

        public override void OnClick() // Build worker
        {
            BuildingWorker = new Thread(townHall.BuildingWorker);
            BuildingWorker.Start();
        }

    }
}
