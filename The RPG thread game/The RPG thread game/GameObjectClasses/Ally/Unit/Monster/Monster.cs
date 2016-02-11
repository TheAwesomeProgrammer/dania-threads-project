using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class Monster : AttackingUnit
    {

        protected int Speed = 200;

        protected Vector2 PixelsToMove;

        private WaypointFollow WaypointFollow;
        private Vector2 EndPosition;
        private bool Moving;

        public Monster(Vector2 startPos,Vector2 endPostion,Team team) :
            base(startPos,team)
        {
            ScaleFactor = 0.5f;
            EndPosition = endPostion;
        }

        protected override void Init()
        {
            base.Init();
            WaypointFollow = new WaypointFollow(Speed);
            WaypointFollow.MoveToPoint(Position, EndPosition);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ShouldMove(deltaTime);
            ShouldDie();
            Moving = true;
        }

        private void ShouldMove(double deltaTime)
        {
            if (Moving)
            {
                Move(deltaTime);
            }
        }

        private void Move(double deltaTime)
        {
            Position = WaypointFollow.GetCurrentPoint(Position,deltaTime);
        }

        private void ShouldDie()
        {
            if (WaypointFollow.HasReachedTarget(Position))
            {
                Die();
            }
        }

        public override void OnCollision(List<CollideableSprite> spritesCollidingWith)
        {
            if (spritesCollidingWith.Exists(spriteCollidingWith => spriteCollidingWith is Unit &&
                                                                   IsEnemy(spriteCollidingWith as Unit)))
            {
                WaypointFollow.MoveToPoint(Position,EndPosition);
                Moving = false;

            }
            
        }
    }
}