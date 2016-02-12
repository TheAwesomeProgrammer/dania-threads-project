using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game.Factories
{
    public class WorkerObjectCreator : Factory
    {
        public GameObject CrateObject(Creator creator)
        {
            WorkerType WorkerType = (WorkerType) creator.AnEnum;
            WorkerCreator WorkerCreator = (WorkerCreator) creator;

            switch (WorkerType)
            {
                case WorkerType.Farmer:
                    return new Farmer(WorkerCreator.StartPosition, WorkerCreator.StartStructure,
                        WorkerCreator.EndStructure);
                case WorkerType.Miner:
                    return new Miner(WorkerCreator.StartPosition, WorkerCreator.StartStructure,
                        WorkerCreator.EndStructure);

                default:
                    return new EmptyWorker();
            }
        }
    }
}