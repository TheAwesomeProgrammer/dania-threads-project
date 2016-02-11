using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal abstract class Infantry : Unit
    {
        public Infantry(Vector2 startPos) : 
            base(startPos,Team.Ally)
        {

        }
    }
}