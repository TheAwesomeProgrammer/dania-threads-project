using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class Vector2
    {
        private float x;
        private float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2 Substract(Vector2 vec)
        {
            Vector2 newVec = new Vector2(x, y);
            newVec.X = vec.X - this.x;
            newVec.Y = vec.Y - this.y;

            return newVec;
        }

        private float Length()
        {
            return (float)Math.Sqrt((this.x * this.x) + (this.y * this.y));
        }

        public void Nomalize()
        {
            float length = Length();
            this.x = this.x / length;
            this.y = this.y / length;
        }
    }
}