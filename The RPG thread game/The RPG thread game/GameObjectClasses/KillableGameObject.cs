using System.Windows.Forms;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class KillableGameObject : GameObject
    {
        protected int MaxHealth;
        protected int MyHealth;

        protected Limit HealthLimit;

        protected int Health
        {
            get { return MyHealth; }
            set
            {
                if (HealthLimit.IsWithinLimit(value))
                {
                    MyHealth = value;
                }
                else
                {
                    MyHealth = 0;
                }
            }
        }

        public KillableGameObject(Vector2 startPos) : 
            base(startPos)
        {
            HealthLimit = new Limit(MaxHealth);
        }

        public override void Update(float deltaTime)
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