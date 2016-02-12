using System;
using System.Drawing;

namespace The_RPG_thread_game
{
    public class Vector2
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

        public Vector2 Normalized
        {
            get
            {
                float length = Length();
                return new Vector2(x / length, y / length);
            }
        }

        public float DistanceToVector(Vector2 vector)
        {
            Vector2 VectorsSubtracted = vector - (this);
            return (float)Math.Sqrt(Math.Pow(VectorsSubtracted.x, 2) + Math.Pow(VectorsSubtracted.y, 2));
        }

        public static Vector2 operator *(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x * vector2.x,vector1.y * vector2.y);
        }
      
        public static Vector2 operator *(Vector2 vector1, float value)
        {
            return new Vector2(vector1.x * value, vector1.y * value);
        }

        public static Vector2 operator /(Vector2 vector1, float value)
        {
            return new Vector2(vector1.x / value, vector1.y / value);
        }

        public static Vector2 operator +(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x + vector2.x, vector1.y + vector2.y);
        }

        public static Vector2 operator -(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x - vector2.x, vector1.y - vector2.y);
        }


        public PointF ToPointF()
        {
            return new PointF(x,y);
        }

        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
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