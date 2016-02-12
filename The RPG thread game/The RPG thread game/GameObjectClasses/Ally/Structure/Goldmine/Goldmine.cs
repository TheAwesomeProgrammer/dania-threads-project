using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    internal class Goldmine : Structure
    {
        public Goldmine(Vector2 startPos) :
            base(startPos)
        {
            ScaleFactor = 0.5f;
            Health = 3;
            StructureType = StructureType.Goldmine;
        }
    }
}