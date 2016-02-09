using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Interfaces;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class Ally : NonCollidingSprite
    {
       

        public Ally(Vector2 startPos,string imagePath,float scaleFactor) :
            base(startPos, imagePath, scaleFactor)
        {
            
        }

      

    }
}