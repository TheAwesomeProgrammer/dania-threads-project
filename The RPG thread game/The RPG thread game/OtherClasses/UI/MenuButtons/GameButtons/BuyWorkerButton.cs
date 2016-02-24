using System;
using System.Drawing;
using System.Threading;
using The_RPG_thread_game.Factories;
using The_RPG_thread_game.OtherClasses.TownHall;

namespace The_RPG_thread_game
{
    public abstract class BuyWorkerButton : UIButton
    {
        protected Structure TownHall;
        protected Structure EndStructure;
        protected WorkerCreator WorkerCreator;
        protected WorkerObjectCreator WorkerObjectCreator;

        private Recruiter Recruiter = new Recruiter();

        private WorkerType WorkerType;

        public BuyWorkerButton(Vector2 position, SizeF sizeF, object sender,WorkerType workerType) :
            base(position, sizeF, sender)
        {
            WorkerType = workerType;
            FontSize = 6;
            TownHall = FindTownHall();
            WorkerObjectCreator = new WorkerObjectCreator();
            ButtonText = "Buy " + workerType;
        }

        public override void OnClick()
        {
            AddWorker();
        }

        protected void AddWorker()
        {
            SetEndStructure();
            WorkerCreator = new WorkerCreator(WorkerType, WorkerObjectCreator, Center, TownHall, EndStructure);
            if (EndStructure != null)
            {
                Worker Worker = WorkerCreator.CreateObject() as Worker;
                ThreadManager.Instance.AddThread(new Thread(() => Recruiter.BuildWorker(Worker)), Recruiter.GetObjectId()); 
            }
        }

        protected BigTownhall FindTownHall()
        {
            return (BigTownhall)GameWorld.Sprites.Find(sprite => sprite is BigTownhall &&
                                                    (sprite as Faction).Team == Team.Ally);
        }

        protected T FindStructure<T>() where T : Structure
        {
            return (T)GameWorld.Sprites.Find(sprite => sprite is T);
        }

        protected abstract void SetEndStructure();

    }
}