using System.Drawing;
using The_RPG_thread_game.Bar;

namespace The_RPG_thread_game
{
    public class KillableSprite : Faction
    {
        protected LifeObject LifeObject;
        protected Vector2 HealthBarOffset = new Vector2(0, -50);
        protected HealthBar HealthBar;

        public int Health
        {
            get { return LifeObject.Health; }
            set { LifeObject.Health = value; }
        }

        public KillableSprite(Vector2 startPos, Team team) :
            base(startPos, team)
        {
            LifeObject = new LifeObject(this);
            HealthBar = new HealthBar(this,new SizeF(100,20), HealthBarOffset );
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            HealthBar.Update(deltaTime);
            LifeObject.Update(deltaTime);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            HealthBar.Draw(graphics);
        }
    }
}