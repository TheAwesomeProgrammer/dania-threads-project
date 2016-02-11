using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_RPG_thread_game.OtherClasses.TownHall
{
    abstract class WorkerBuilder : Builder
    {
        public WorkerBuilder() : base(5, 5, new TimeSpan(0, 0, 0, 2, 0)) // 5 guld, 5 food, Days, hours, minutes, seconds, milliseconds.
        {

        }
        public override Unit Build()
        {
            Thread.Sleep(buildTime);
            return new Worker();

        }
    }
}
