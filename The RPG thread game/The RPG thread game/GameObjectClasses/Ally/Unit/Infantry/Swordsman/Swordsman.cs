using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class Swordsman : Infantry
    {
        public Swordsman(Vector2 startPos, string imagePath, float scaleFactor) : 
            base(startPos,imagePath,scaleFactor)
        {

        }
    }
}