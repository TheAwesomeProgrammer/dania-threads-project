using System.Threading;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game.GameObjectClasses.Ally.Structure
{
    public class Farm : The_RPG_thread_game.Structure
    {
        public int StartFarmerCount = 5;
        public int MaxFarmerCount = 5;
        public int MeatPerFarmer = 5;

        private Semaphore SemaphoreLock;

        public Farm(Vector2 startPos) :
            base(startPos)
        {
            SemaphoreLock = new Semaphore(StartFarmerCount, MaxFarmerCount);
            ScaleFactor = 0.5f;
            StructureType = StructureType.Farm;
        }

        public override void Enter(Worker workerEntering)
        {
            SemaphoreLock.WaitOne(-1);
            base.Enter(workerEntering);
            workerEntering.GiveResourceAction = () => ResourceManager.Instance.Meat += MeatPerFarmer;
            SemaphoreLock.Release();
        }

    }
}
