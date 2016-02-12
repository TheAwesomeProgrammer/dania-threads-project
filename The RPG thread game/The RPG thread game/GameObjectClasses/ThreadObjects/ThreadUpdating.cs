using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game.GameObjectClasses.ThreadObjects
{
    public class ThreadUpdating : GameObjectDecorator, Threadable
    {

        private Counter Counter;

        public ThreadUpdating(GameObject nonThreadedGameObject) : 
            base(nonThreadedGameObject)
        {
            SetThreadable();
            Counter = Counter.Instance;
            Counter.StartCounter(GetObjectId());
        }

        public void ThreadUpdater(int threadId)
        {
            while (ThreadManager.Instance.DoesThreadExist(threadId))
            {
                ThreadUpdate();
            }
        }

        protected  void ThreadUpdate()
        {
            double DeltaTime = Counter.GetTimeGone(GetObjectId());

            Counter.StartCounter(GetObjectId());
            MyGameObject.Update(DeltaTime);
            MyGameObject.UpdateAnimation(DeltaTime);
        }


    }
}
