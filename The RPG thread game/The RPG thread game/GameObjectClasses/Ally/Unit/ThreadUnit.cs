using The_RPG_thread_game.GameObjectClasses.ThreadObjects;

namespace The_RPG_thread_game
{
    public abstract class ThreadUnit : KillableSprite
    {
        public ThreadUpdating ThreadLifeObject;

        protected ThreadUnit(Vector2 startPos,Team team) :
                base(startPos, team)
        {
            ThreadLifeObject = new ThreadUpdating(this);
        }

        public virtual void ThreadUpdateLoop(int threadId)
        {
            ThreadLifeObject.ThreadUpdater(threadId);
        }
    }
}