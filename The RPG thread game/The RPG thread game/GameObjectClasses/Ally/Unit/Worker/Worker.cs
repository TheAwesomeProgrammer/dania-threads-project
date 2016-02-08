using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    internal abstract class Worker : Unit
    {
        private float Speed = 5;
        
        private Structure StartStructure;
        private Structure EndStructure;
        private WaypointFollow WaypointFollow;

        public Worker(Structure startStructure,Structure endStructure)
        {
            WaypointFollow = new WaypointFollow(Speed);
            StartStructure = startStructure;
            EndStructure = endStructure;
        }


    }
}