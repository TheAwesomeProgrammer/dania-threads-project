namespace The_RPG_thread_game.GameObjectClasses.ThreadObjects
{
    public abstract class GameObjectDecorator : GameObject
    {
        protected GameObject MyGameObject;

        public GameObjectDecorator(GameObject gameObject) :
            base(gameObject.Position)
        {
            MyGameObject = gameObject;
        }

        public void SetThreadable()
        {
            MyGameObject.IsThreadable = true;
        }

    }
}