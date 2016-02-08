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
        protected Vector2 StartPos;
        

        protected 

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void UpdateAnimation(float deltaTime)
        {
        }

        //public RectangleF CollisionBox
        //{
        //    get
        //    {
        //        return;
        //    }
        //}
        
    }
}