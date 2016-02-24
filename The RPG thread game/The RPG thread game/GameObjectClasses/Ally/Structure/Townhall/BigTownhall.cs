using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    public class BigTownhall : Structure
    {
        public BigTownhall(Vector2 startPos) :
                base(startPos)
        {
            ScaleFactor = 0.75f;
            HealthLimit.SetMaxLimit(100);
            Health = 100;
            
            StructureType = StructureType.Townhall;
        }

        protected override void Init()
        {
            base.Init();
            GameWorld.AddObjectInNextCycle(new StructureButton(Position, SizeF, this));
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Image = Form1.Self.TownHallImg;
        }

        public override void Die()
        {
            new WinOrLoseGame("You lose " + Environment.NewLine + " Press any key to continue");
        }

        public override void Enter(Worker workerEntering)
        {
            base.Enter(workerEntering);
            if (workerEntering.GiveResourceAction != null)
            {
                workerEntering.GiveResourceAction();
                workerEntering.GiveResourceAction = null;
            }
            
        }
    }
}