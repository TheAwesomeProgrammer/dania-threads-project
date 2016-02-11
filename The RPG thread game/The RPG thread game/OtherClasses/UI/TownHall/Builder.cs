using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game.OtherClasses.TownHall
{
    abstract class Builder
    {  
        protected TimeSpan buildTime;
        private int GoldPrice;
        private int FoodPrice;
        private TownHallMain TownHall;


        public int Price
        {
            get { return GoldPrice; }
        }

        public Builder(int GoldPrice, int FoodPrice, TimeSpan buildTime) 
        {
            this.buildTime = buildTime;
            this.GoldPrice = TownHall.WorkerGoldPrice;
            this.FoodPrice = TownHall.WorkerFoodPrice;
        }

        public abstract Unit Build();
    }
}
