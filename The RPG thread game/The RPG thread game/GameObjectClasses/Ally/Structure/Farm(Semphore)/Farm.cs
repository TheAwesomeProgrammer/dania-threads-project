using System.Threading;
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
        }

        public override void Enter()
        {
            SemaphoreLock.WaitOne(-1);
            base.Enter();
            ResourceManager.Instance.Meat += MeatPerFarmer;
            SemaphoreLock.Release();
        }

    }
}
