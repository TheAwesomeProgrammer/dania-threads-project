using System.Collections.Generic;
using System.Drawing;
using The_RPG_thread_game.Interfaces;

namespace The_RPG_thread_game
{
    public abstract class CollideableSprite : Sprite,Collideable
    {

        public RectangleF CollisionBox => new RectangleF(Position.ToPointF(),SizeF);

        protected CollideableSprite(Vector2 startPos) : 
            base(startPos)
        {
            
        }

        protected CollideableSprite(Vector2 startPos, SizeF sizeF) :
            base(startPos, sizeF)
        {

        }

        protected CollideableSprite(Vector2 startPos,string imagePath) :
            base(startPos, imagePath)
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            CheckCollision();
        }

        private void CheckCollision()
        {
            List<CollideableSprite> CollidingSprites = GameWorld.ColliableSprites;
            List<CollideableSprite> SpritesCollidingWith = CollidingSprites.FindAll(
                otherSprite => CollidingWith(otherSprite.CollisionBox) && otherSprite != this);

            if (SpritesCollidingWith.Count > 0)
            {
                OnCollision(SpritesCollidingWith);
            }
            
        }

        public bool CollidingWith(RectangleF otherSprite)
        {
            return CollisionBox.IntersectsWith(otherSprite);
        }

        public virtual void OnCollision(List<CollideableSprite> spritesCollidingWith)
        {
            
        }
    }
}