using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class AttackingUnit : Unit
    {
        public bool IsFighting;

        protected int AttackRange = 200;
        protected int Damage = 1;

        protected float AttackSpeed = 1;

        protected Rectangle AttackRangeBox;

        private float NextTimeToAttack;
        private Time Time;

        protected AttackingUnit(Vector2 startPos,Team team) :
            base(startPos,team)
        {
            
        }

        protected override void Init()
        {
            base.Init();
            Time = Time.Instance;
            AttackRangeBox = new Rectangle(Center.ToPoint(), new Size(AttackRange, AttackRange));
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            AnyoneInsideAttackRange();
        }

        private void AnyoneInsideAttackRange()
        {
            List<CollideableSprite> CollideableSprites = GameWorld.ColliableSprites;
            List<Unit> UnitsInsideAttackRange = CollideableSprites.FindAll(
                collideableSprite => collideableSprite.CollidingWith(CollisionBox) &&
                                     collideableSprite is Unit &&
                                     !collideableSprite.Equals(this)).Cast<Unit>().ToList();
                                     
            if (UnitsInsideAttackRange.Count > 0)
            {
                foreach (var UnitToAttack in UnitsInsideAttackRange)
                {
                    Attack(UnitToAttack);
                }
              
            }

            
        }

        protected void Attack(Unit unitToAttack)
        {
            if (IsEnemy(unitToAttack) && NextTimeToAttack <= Time.TimeSinceStart)
            {
                unitToAttack.Health -= Damage;
                NextTimeToAttack = (float)Time.TimeSinceStart + NextTimeToAttack;
            }
        }

       

     

        
    }
}