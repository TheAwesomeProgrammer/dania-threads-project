using System.Drawing;

namespace The_RPG_thread_game
{
    public class NonCollidingSprite : Sprite
    {
        protected NonCollidingSprite(Vector2 startPos, string imagePath,float scaleFactor) : 
            base(startPos, imagePath, scaleFactor)
        {
            Image = Image.FromFile(imagePath);
            StartPos = startPos;
        }
    }
}