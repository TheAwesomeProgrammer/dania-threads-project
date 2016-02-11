using System.Drawing;

namespace The_RPG_thread_game
{
    public abstract class Sprite : GameObject
    {
        protected Image Image;
        protected float ScaleFactor;
        protected SizeF Size;

        protected Sprite(Vector2 startPos,string imagePath,float scaleFactor) : 
            base(startPos)
        {
            Image = Image.FromFile(imagePath);
            ScaleFactor = scaleFactor;
            Size = new SizeF(ScaleFactor * Image.Height,ScaleFactor * Image.Width);
            StartPos = startPos;
        }

        protected Sprite(Vector2 startPos, string imagePath, SizeF size) :
           base(startPos)
        {
            Image = Image.FromFile(imagePath);
            Size = size;
            StartPos = startPos;
        }

        public virtual void Draw(Graphics graphics)
        {

        }
    }
}