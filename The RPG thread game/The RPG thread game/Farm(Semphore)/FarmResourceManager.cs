using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Farm_Semphore_
{
    public class FarmResourceManager
    {
        public int Resource;

        private static FarmResourceManager MyInstance;
        private static readonly object SyncLock = new object();

        public static FarmResourceManager Instance
        {
            get
            {
                lock (SyncLock)
                {
                    if (MyInstance == null)
                    {
                        MyInstance = new FarmResourceManager();
                    }
                    return MyInstance;
                }
            }
        }

        // Private constructor, so that other classes can't create a FarmResourceManager.
        private FarmResourceManager(){}


       
        
    }
}
