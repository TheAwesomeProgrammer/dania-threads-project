using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game.GameObjectClasses.ThreadObjects
{
    public class ThreadLifeObject : LifeObjectDecorator,Threadable
    {
        private ThreadUpdating ThreadGameObject;

        public ThreadLifeObject(LifeObject nonThreadLifeObject) : 
            base(nonThreadLifeObject)
        {
            ThreadGameObject = new ThreadUpdating(MyLifeObject);
            MyLifeObject.SetThreadable();
        }


        public void ThreadUpdater(int threadId)
        {
            while (ThreadManager.Instance.DoesThreadExist(threadId))
            {
                ThreadGameObject.ThreadUpdater(threadId);
            }
        }

        
        
    }
}
