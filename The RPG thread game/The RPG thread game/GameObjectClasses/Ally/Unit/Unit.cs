using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class Unit : KillableSprite
    {
        public Unit(Vector2 startPos, Team team) :
           base(startPos,team)
        {


        }
    }
}