using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal abstract class GameObject
    {
        protected string ImagePath { get; set; }
        protected Vector2 StartPos { get; set; }
        protected int Health { get; set; }

        //string imagePath, Vector2 startPos, int health
        protected GameObject()
        {
        }

        public virtual void Draw(Graphics dc)
        {
        }

        public virtual void Update(float fps)
        {
        }

        public virtual void UpdateAnimation(float fps)
        {
        }

        //public RectangleF CollisionBox
        //{
        //    get
        //    {
        //        return;
        //    }
        //}

        public abstract void OnPredictedCollision();
    }
}