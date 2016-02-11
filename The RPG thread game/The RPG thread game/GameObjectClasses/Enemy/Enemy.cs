using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class Enemy : NonCollidingSprite
    {
        public Enemy(Vector2 startPos, string imagePath, float scaleFactor) :
            base(startPos, imagePath, scaleFactor)
        {

        }

    }
}