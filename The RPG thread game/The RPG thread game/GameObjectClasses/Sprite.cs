using System.Drawing;

namespace The_RPG_thread_game
{
    public abstract class Sprite : GameObject
    {
        protected Image Image;

        protected Sprite(Vector2 startPos,string imagePath) : 
            base(startPos)
        {
            Image = Image.FromFile(imagePath);
            StartPos = startPos;
        }

        public virtual void Draw(Graphics graphics)
        {

        }
    }
}