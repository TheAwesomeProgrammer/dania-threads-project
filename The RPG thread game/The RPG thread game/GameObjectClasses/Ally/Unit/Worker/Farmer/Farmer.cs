using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public class Farmer : Worker
    {
        public Farmer(Vector2 startPos, Structure startStructure,Structure endStructure) :
                base(startPos, startStructure, endStructure)
        {
        }

       
    }
}