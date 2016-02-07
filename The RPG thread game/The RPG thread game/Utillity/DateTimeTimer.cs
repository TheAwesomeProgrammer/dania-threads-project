using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Utillity
{
    public class DateTimeTimer
    {

        private Dictionary<long,DateTime> Timers = new Dictionary<long, DateTime>();
        private static DateTimeTimer MyInstance;

        public static DateTimeTimer Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new DateTimeTimer();
                }
                return MyInstance;
            }
        }

        // Singleton. So other classes can't create a timer, because we only want there to exist one timer at all times.
        private DateTimeTimer(){ }
        

        public void StartTimer(long id)
        {
            if (Timers.ContainsKey(id))
            {
                Timers.Remove(id);
            }
            Timers.Add(id, DateTime.Now);

        }

        public TimeSpan GetTimeGone(long id)
        {
            return DateTime.Now - Timers[id];
        }

        public void EndTimer(long id)
        {
            Timers.Remove(id);
        }
        

    }
}
