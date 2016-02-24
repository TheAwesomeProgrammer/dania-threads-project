using System.Drawing;
using The_RPG_thread_game.Bar;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class KillableSprite : Faction
    {
        protected Vector2 HealthBarOffset = new Vector2(0, -50);
        protected HealthBar HealthBar;
        protected int MaxHealth = 3;
        protected int MyHealth = 3;

        protected Limit HealthLimit;

        public int Health
        {
            get { return MyHealth; }
            set { MyHealth = (int)HealthLimit.GetWithinLimit(value); }
        }

        public KillableSprite(Vector2 startPos, Team team) :
            base(startPos, team)
        {
            HealthLimit = new Limit(MaxHealth);
        }

        protected override void Init()
        {
            base.Init();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ShouldDie();
        }

        private void ShouldDie()
        {
            if (Health <= 0)
            {
                Die();
            }
        }

    }
}