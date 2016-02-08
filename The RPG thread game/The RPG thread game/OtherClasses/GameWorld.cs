using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    internal class GameWorld
    {
        public List<GameObject> Objects { get; set; } = new List<GameObject>();
        public List<GameObject> ObjectsToAdd { get; set; } = new List<GameObject>();
        public List<GameObject> ObjectsToRemove = new List<GameObject>();

        private DateTimeTimer Timer;
        private Graphics Graphics;
        private Rectangle DisplayRectangle;

        public GameWorld(Graphics dc, Rectangle displayRect)
        {
            Graphics = dc;
            DisplayRectangle = displayRect;
            Timer = DateTimeTimer.Instance;
        }

        public void GameLoop()
        {
            float DeltaTime = (float)Timer.GetTimeGone(GetHashCode()).TotalMilliseconds/1000;

            Update(DeltaTime);
            Draw(Graphics);


            Timer.StartTimer(GetHashCode());
        }

        public void Update(float deltaTime)
        {
            Objects.DoActionOnItems(gameObject => gameObject.Update(deltaTime));
        }

        public void Draw(Graphics graphics)
        {
            Objects.DoActionOnItemsMatchingPredicate(gameObject => gameObject is Sprite,
                gameObject => (gameObject as Sprite).Draw(graphics));
        }

        public void RemoveObjectInNextCycle(GameObject objectToRemove)
        {
            ObjectsToRemove.Add(objectToRemove);
        }

        public void AddObjectInNextCycle(GameObject objectToAdd)
        {
            ObjectsToAdd.Add(objectToAdd);
        }

        public void RemoveObjects()
        {
            Objects.RemoveAll(Object => ObjectsToRemove.Contains(Object));
            ObjectsToRemove.Clear();
        }

        public void AddObjects()
        {
            Objects.AddAll(Object => ObjectsToAdd.Contains(Object));
            ObjectsToAdd.Clear();
        }
    }
}