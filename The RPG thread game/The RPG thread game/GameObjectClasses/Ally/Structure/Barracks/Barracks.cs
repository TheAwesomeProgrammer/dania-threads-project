using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    internal class Barracks : AttackingStructure
    {
        

        public Barracks(Vector2 startPos) :
            base(startPos)
        {
            AttackSpeed = 5;
            ScaleFactor = 0.5f;
            ImagePath = @"Resources\Structures\Barrack.png";
        }

    }
}