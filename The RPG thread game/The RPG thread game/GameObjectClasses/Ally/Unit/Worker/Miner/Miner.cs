using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class Miner : Worker
    {
        public Miner(Vector2 startPos, string imagePath, float scaleFactor, Structure startStructure,Structure endStructure) :
                base(startPos, imagePath, scaleFactor, startStructure, endStructure)
        {
        }
    }
}