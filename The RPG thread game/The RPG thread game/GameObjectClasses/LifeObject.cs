using System;
using System.Windows.Forms;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class LifeObject : GameObjectDecorator
    {
        protected int MaxHealth = 3;
        protected int MyHealth = 3;

        protected Limit HealthLimit;

        public int Health
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

        public LifeObject(GameObject gameObject) : 
            base(gameObject)
        {
            HealthLimit = new Limit(MaxHealth);
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

        public override void Die()
        {
            MyGameObject.Die();
            base.Die();
            
        }
    }
}