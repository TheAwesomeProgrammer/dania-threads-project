using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class Enemy : AliveGameObject
    {
        public Enemy(Vector2 startPos,int health) :
            base(startPos, health)
        {
            
        }

    }
}