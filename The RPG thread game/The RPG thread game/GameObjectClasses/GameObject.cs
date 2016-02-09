using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class GameObject
    {
        public Vector2 Position;

        protected Vector2 StartPos;


        public GameObject(Vector2 startPos)
        {
            StartPos = startPos;
            Position = startPos;
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void UpdateAnimation(float deltaTime)
        {
        }

        public virtual void Die()
        {
            GameWorld.RemoveObjectInNextCycle(this);
        }


    }
}