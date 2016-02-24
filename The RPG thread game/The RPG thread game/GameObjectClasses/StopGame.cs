using System.Threading;

namespace The_RPG_thread_game
{
    public class StopGame : GameObject
    {
        public StopGame() :
            base(new Vector2(0, 0))
        {

        }

        public void Stop()
        {
            GameWorld.RemoveAllObjects();
            GameWorld.AddObjectInNextCycle(this);
        }

        public override void Update(double deltaTime)
        {
            if (Keyboard.IsAnyKeyDown())
            {
                ThreadManager.Instance.RemoveAllThreads();
                Thread.Sleep(100);
                Form1.Self.Init();
                GameWorld.RemoveAllObjects();
            }
        }

    }
}