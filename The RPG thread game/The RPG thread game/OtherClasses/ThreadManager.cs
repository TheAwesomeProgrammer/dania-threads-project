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

        public void AddThread(Thread thread,int id,ThreadPriority threadPriority)
        {
            if (!Threads.ContainsKey(id))
            {
                Threads.Add(id, thread);
            }
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread.StartAndRunInFront();
                }
                thread.Priority = threadPriority;
            }
        }

        public void AddThread(Thread thread, int id)
        {
            AddThread(thread,id,ThreadPriority.Normal);
        }

        public bool DoesThreadExist(int id)
        {
            return Threads.ContainsKey(id);
        }

        public void RemoveThread(int id)
        {
            Threads.Remove(id);
        }

        public void RemoveAllThreads()
        {
            Threads.Clear();
        }

       
        
    }
}