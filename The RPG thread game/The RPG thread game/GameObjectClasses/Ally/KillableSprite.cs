namespace The_RPG_thread_game
{
    public class KillableSprite : Faction
    {
        protected LifeObject LifeObject;

        public int Health
        {
            get { return LifeObject.Health; }
            set { LifeObject.Health = value; }
        }

        public KillableSprite(Vector2 startPos, Team team) :
            base(startPos,team)
        {
            LifeObject = new LifeObject(this);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            LifeObject.Update(deltaTime);
        }

    }
}