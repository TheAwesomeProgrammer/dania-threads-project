namespace The_RPG_thread_game.GameObjectClasses.ThreadObjects
{
    public class LifeObjectDecorator : LifeObject
    {
        protected LifeObject MyLifeObject;

        public LifeObjectDecorator(LifeObject lifeObject) :
            base(lifeObject)
        {
            MyLifeObject = lifeObject;
        }
    }
}