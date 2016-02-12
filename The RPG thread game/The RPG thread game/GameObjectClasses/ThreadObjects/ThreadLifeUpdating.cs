namespace The_RPG_thread_game.GameObjectClasses.ThreadObjects
{
    public class ThreadLifeUpdating : GameObjectDecorator, Threadable
    {
        protected ThreadUpdating ThreadUpdating;

        public ThreadLifeUpdating(LifeObject lifeObject) :
            base(lifeObject)
        {
            lifeObject.SetThreadable();
            ThreadUpdating = new ThreadUpdating(lifeObject);
        }

        public void ThreadUpdater(int threadId)
        {
            ThreadUpdating.ThreadUpdater(threadId);
        }
    }
}