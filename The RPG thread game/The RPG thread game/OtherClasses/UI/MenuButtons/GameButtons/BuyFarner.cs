using System.Drawing;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    internal class BuyFarmer : BuyWorkerButton
    {

        public BuyFarmer(Vector2 position, SizeF sizeF, object sender, WorkerType workerType) :
            base(position, sizeF, sender, workerType)
        {
        }

        protected override void SetEndStructure()
        {
            EndStructure = FindStructure<Farm>();
        }

    }
}