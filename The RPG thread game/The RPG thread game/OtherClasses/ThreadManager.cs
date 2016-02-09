using System.Collections.Generic;
using System.Threading;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class ThreadManager
    {
        private Dictionary<int,Thread> Threads = new Dictionary<int, Thread>(); 
        

        private static ThreadManager MyInstance;
        
        public static ThreadManager Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new ThreadManager();
                }
                return MyInstance;
            }
        }

        private ThreadManager() { }

        public void SetMainThread(Thread thread,int id)
        {
            Thread DoesThreadExist = Threads[id];

            if (DoesThreadExist.Equals(null))
            {
                Threads.Add(id, thread);
                thread.StartAndRunInFront();
            }
            else if(!DoesThreadExist.IsAlive)
            {
                DoesThreadExist = thread;
            }

        }

        public bool IsMainThread(int id)
        {
            return Threads.ContainsKey(id);
        }

       
        
    }
}