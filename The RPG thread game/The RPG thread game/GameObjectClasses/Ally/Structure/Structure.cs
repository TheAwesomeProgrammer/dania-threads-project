using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    public abstract class Structure : KillableSprite
    {
        public bool HasEntered = false;
        public StructureType StructureType = StructureType.Townhall;

        protected int WaitingTimeInMilliSecounds = 200;
        

        public Structure(Vector2 startPos) : 
            base(startPos,Team.Ally)
        {
           
        }

        public Structure(Vector2 startPos,Team team) :
            base(startPos, team)
        {

        }

        protected override void Init()
        {
            
            ImagePath = @"Resources\Structures\" + StructureType + ".png";
            base.Init();
        }

        public virtual void Enter(Worker workerEntering)
        {
            HasEntered = true;
            Thread.Sleep(WaitingTimeInMilliSecounds);
        }

    }
}