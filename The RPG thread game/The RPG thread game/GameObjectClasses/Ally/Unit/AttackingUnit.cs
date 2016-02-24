using System.Collections.Generic;
using System.Diagnostics;
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
            List<KillableSprite> UnitsInsideAttackRange = CollideableSprites.FindAll(
                collideableSprite => collideableSprite.CollidingWith(CollisionBox) &&
                                     collideableSprite is KillableSprite &&
                                     !collideableSprite.Equals(this)).Cast<KillableSprite>().ToList();
                                     
            if (UnitsInsideAttackRange.Count > 0)
            {
                foreach (var UnitToAttack in UnitsInsideAttackRange)
                {
                    Attack(UnitToAttack);
                }
              
            }

            
        }

        protected void Attack(KillableSprite killableSprite)
        {
            if (IsEnemy(killableSprite) && NextTimeToAttack <= Time.TimeSinceStart)
            {
                killableSprite.Health -= Damage;
                Debug.WriteLine("ATTACK "+Time.TimeSinceStart);
                NextTimeToAttack = (float)Time.TimeSinceStart + AttackSpeed;
            }
        }

       

     

        
    }
}