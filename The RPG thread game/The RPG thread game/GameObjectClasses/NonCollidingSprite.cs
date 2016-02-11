using System.Drawing;

namespace The_RPG_thread_game
{
    public class NonCollidingSprite : Sprite
    {
        public NonCollidingSprite(Vector2 startPos) : 
            base(startPos)
        {
            
        }

        public NonCollidingSprite(Vector2 startPos, SizeF sizeF) :
            base(startPos, sizeF)
        {
        }
    }
}