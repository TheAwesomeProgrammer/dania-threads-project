using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class GameWorld
    {
        public List<GameObject> Objects { get; set; } = new List<GameObject>();
        public List<GameObject> ObjectsToAdd { get; set; } = new List<GameObject>();
        public List<GameObject> ObjectsToRemove { get; set; } = new List<GameObject>();

        public GameWorld(Graphics dc, Rectangle displayRect)
        {
            Objects = new List<GameObject>();
            ObjectsToAdd = new List<GameObject>();
            ObjectsToRemove = new List<GameObject>();
        }

        public void GameLoop()
        {
        }
    }
}