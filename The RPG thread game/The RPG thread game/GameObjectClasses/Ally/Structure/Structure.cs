using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;

namespace The_RPG_thread_game
{
    public abstract class Structure : KillableSprite
    {
        public bool HasEntered = false;

        protected int WaitingTimeInMilliSecounds = 200;

        public Structure(Vector2 startPos) : 
            base(startPos,Team.Ally)
        {
        }

        public virtual void Enter()
        {
            HasEntered = true;
            Thread.Sleep(WaitingTimeInMilliSecounds);
        }

    }
}