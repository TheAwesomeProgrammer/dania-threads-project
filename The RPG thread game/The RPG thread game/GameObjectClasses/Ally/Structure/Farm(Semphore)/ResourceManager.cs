using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Farm_Semphore_
{
    public class ResourceManager
    {
        public int Meat = 100;
        public int Gold = 500;

        private static ResourceManager MyInstance;
        private static readonly object SyncLock = new object();

        public static ResourceManager Instance
        {
            get
            {
                lock (SyncLock)
                {
                    if (MyInstance == null)
                    {
                        MyInstance = new ResourceManager();
                    }
                    return MyInstance;
                }
            }
        }

        // Private constructor, so that other classes can't create a FarmResourceManager.
        private ResourceManager(){}


        public void Reset()
        {
            Meat = 100;
            Gold = 500;
        }
        
    }
}
