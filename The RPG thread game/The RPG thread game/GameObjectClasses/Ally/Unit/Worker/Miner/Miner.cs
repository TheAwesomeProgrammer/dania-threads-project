using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class Miner : Worker
    {
        public Miner(Vector2 startPos, Structure startStructure,Structure endStructure) :
                base(startPos, startStructure, endStructure)
        {
            ScaleFactor = 0.5f;
            ImagePath = @"Resources\Minerleft.png";
        }
    }
}