using System.Drawing;

namespace The_RPG_thread_game
{
    public class StaticSprite : NonCollidingSprite
    {
        public StaticSprite(Vector2 startPos, string imagePath,SizeF sizeF) :
            base(startPos, imagePath, sizeF)
        {
            
        }
         
    }
}