using System;

namespace The_RPG_thread_game.Utillity
{
    public class Time
    {
        private static Time MyInstance;

        public static Time Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new Time();
                }
                return MyInstance;
            }
        }

        private Time() { }

        public double TimeSinceStart;


        public void AddTime(double time)
        {
            TimeSinceStart += time;
        }

      
    }
}