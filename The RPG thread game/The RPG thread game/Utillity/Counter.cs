using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Utillity
{
    public class Counter
    {

        private Dictionary<long,double> Counters = new Dictionary<long, double>();
        private static Counter MyInstance;
        private static Time Time;

        public static Counter Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new Counter();
                }
                return MyInstance;
            }
        }

        // Singleton. So other classes can't create a couter, because we only want there to exist one couter at all times.
        private Counter()
        {
            Time = Time.Instance;
        }
        

        public void StartCounter(long id)
        {
            if (Counters.ContainsKey(id))
            {
                Counters[id] = Time.TimeSinceStart;
            }
            else
            {
                Counters.Add(id, Time.TimeSinceStart);
            }
        }

        public double GetTimeGone(long id)
        {
            return Time.TimeSinceStart - Counters[id];
        }
        

        public void EndCounter(long id)
        {
            Counters.Remove(id);
        }
        

    }
}
