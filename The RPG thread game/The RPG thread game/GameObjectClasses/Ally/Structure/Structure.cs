using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class Structure : Ally
    {
        public bool HasEntered;

        public Structure(Vector2 startPos, string imagePath, float scaleFactor) : 
            base(startPos,imagePath,scaleFactor)
        {
            
        }

        public void Enter()
        {
            HasEntered = true;
        }

    }
}