using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    internal class GameWorld
    {
        public static List<GameObject> Objects = new List<GameObject>();
        public static List<CollideableSprite> ColliableSprites = new List<CollideableSprite>();
        public static List<Sprite> Sprites = new List<Sprite>();

        private const int FrameRate = 60;

        private static List<GameObject> ObjectsToAdd = new List<GameObject>();
        private static List<GameObject> ObjectsToRemove = new List<GameObject>();
        private Counter Counter;
        private ThreadManager ThreadManager;
        private Render Render;
        private Time Time;
        private DateTime StartTime;
        private DateTime EndTime;

        private double NextUpdateTime;



        public GameWorld(Graphics dc, Rectangle displayRect)
        {
            ResourceManager.Instance.Reset();
            Render = new Render(dc,displayRect);
            Display.Instance.SetDisplayRectangle(displayRect);
            ThreadManager = ThreadManager.Instance;
            Counter = Counter.Instance;
            Time = Time.Instance;
        }

        public void GameLoop(int threadId)
        {
           Setup();

            while (ThreadManager.DoesThreadExist(threadId))
            {
                double DeltaTime = (EndTime - StartTime).TotalMilliseconds/1000;
                NextUpdateTime += DeltaTime;
                StartTime = DateTime.Now;
                
                if (NextUpdateTime >= (double)1 / FrameRate)
                {
                    Update(NextUpdateTime);
                    Draw(Render.Graphics);
                    NextUpdateTime = 0;
                }

                EndTime = DateTime.Now;
            }
        }

        private void Setup()
        {
            Counter.StartCounter(IDManager.Instance.GetID());
            AddObjectInNextCycle(new StaticSprite(new Vector2(0, 0), @"Resources\bgImage2.png", new SizeF(1280, 720)));
            AddObjectInNextCycle(new StructureMonsterSpawner());
            AddObjectInNextCycle(new BigTownhall(new Vector2(850,300)));
            AddObjectInNextCycle(new EnemyBigTownHall(new Vector2(150, 300)));
            AddObjectInNextCycle(new WriteTextInfo(new Vector2(0,0)));
        }

        private void Update(double deltaTime)
        {
            Time.AddTime(deltaTime);
            RemoveObjects();
            AddObjects();
            UpdateObjects(deltaTime);
        }

        private void AddObjects()
        {
            Sprites.AddRange(ObjectsToAdd.FindAll(Object => Object is Sprite).Cast<Sprite>().ToList());
            ColliableSprites.AddRange(ObjectsToAdd.FindAll(Object => Object is CollideableSprite).Cast<CollideableSprite>().ToList());
            Objects.AddRange(ObjectsToAdd);

            ObjectsToAdd.Clear();
        }

        private void RemoveObjects()
        {
            Objects.RemoveAll(Object => ObjectsToRemove.Contains(Object));
            ColliableSprites.RemoveAll(Object => ObjectsToRemove.Contains(Object));
            Sprites.RemoveAll(Object => ObjectsToRemove.Contains(Object));

            ObjectsToRemove.Clear();
        }

        private void UpdateObjects(double deltaTime)
        {
            Objects.DoActionOnItemsMatchingPredicate(gameObject => !gameObject.IsThreadable,
                gameObject => gameObject.Update(deltaTime));
        }

        private void Draw(Graphics graphics)
        {
            Render.Clear();

            DrawObjects(graphics);
            
            Render.RenderBackBuffer();
        }

        private void DrawObjects(Graphics graphics)
        {
            Sprites.DoActionOnItems(sprite => sprite.Draw(graphics));
        }

        public static void RemoveObjectInNextCycle(GameObject objectToRemove)
        {
            ObjectsToRemove.Add(objectToRemove);
        }

        public static GameObject AddObjectInNextCycle(GameObject objectToAdd)
        {
            ObjectsToAdd.Add(objectToAdd);
            return objectToAdd;
        }

        public static void RemoveAllObjects()
        {
            ObjectsToRemove.AddRange(Objects);
            ObjectsToRemove.AddRange(Sprites);
            ObjectsToRemove.AddRange(ColliableSprites);
        }

      
    }
}