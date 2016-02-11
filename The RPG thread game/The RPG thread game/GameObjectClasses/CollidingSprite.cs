using System.Collections.Generic;
using System.Drawing;

namespace The_RPG_thread_game
{
    public abstract class CollidingSprite : Sprite
    {


        public RectangleF CollisionBox => new RectangleF(Position.ToPointF(),Size);

        protected CollidingSprite(Vector2 startPos, string imagePath,float scaleFactor) : 
            base(startPos, imagePath, scaleFactor)
        {
            
        }

        protected CollidingSprite(Vector2 startPos, string imagePath, SizeF size) :
            base(startPos, imagePath, size)
        {

        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            CheckCollision();
        }

        private void CheckCollision()
        {
            List<CollidingSprite> CollidingSprites = GameWorld.CollidingSprites;
            List<CollidingSprite> SpritesCollidingWith = CollidingSprites.FindAll(
                otherSprite => CollidingWith(otherSprite.CollisionBox));

            OnCollision(SpritesCollidingWith);
        }

        public bool CollidingWith(RectangleF otherSprite)
        {
            return CollisionBox.IntersectsWith(otherSprite);
        }

        public abstract void OnCollision(List<CollidingSprite> spritesCollidingWith);
    }
}