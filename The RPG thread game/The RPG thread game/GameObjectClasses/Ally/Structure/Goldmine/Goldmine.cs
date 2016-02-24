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
    internal class Goldmine : Structure
    {
        private int GoldPerMiner = 5;

        private object SyncLock = new object();

        public Goldmine(Vector2 startPos) :
            base(startPos)
        {
            ScaleFactor = 0.5f;
            Health = 3;
            StructureType = StructureType.Goldmine;
        }

        public override void Enter(Worker workerEntering)
        {
            lock (SyncLock)
            {
                base.Enter(workerEntering);
                workerEntering.GiveResourceAction = () => ResourceManager.Instance.Gold += GoldPerMiner;
            }
        }
    }
}