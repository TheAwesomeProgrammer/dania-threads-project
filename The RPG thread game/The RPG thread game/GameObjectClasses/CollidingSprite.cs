using System.Drawing;

namespace The_RPG_thread_game
{
    public abstract class CollidingSprite : Sprite
    {
        protected CollidingSprite(Vector2 startPos, string imagePath) : 
            base(startPos, imagePath)
        {
            Image = Image.FromFile(imagePath);
            StartPos = startPos;
        }

        public abstract void OnPredictedCollision();
    }
}