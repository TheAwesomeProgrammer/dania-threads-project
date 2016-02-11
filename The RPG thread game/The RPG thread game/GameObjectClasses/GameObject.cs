using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;

namespace The_RPG_thread_game
{
    public abstract class GameObject
    {
        public Vector2 Position;

        public bool IsThreadable;

        protected Vector2 StartPos;

        protected bool IsFirstRun = true;

        public GameObject(Vector2 startPos)
        {
            StartPos = startPos;
            Position = startPos;
        }

        public virtual void Update(double deltaTime)
        {
            if (IsFirstRun)
            {
                IsFirstRun = false;
                Init();
            }
        }

        public virtual void UpdateAnimation(double deltaTime)
        {
        }

        protected virtual void Init()
        {

        }


        public virtual void Die()
        {
            GameWorld.RemoveObjectInNextCycle(this);
        }


    }
}