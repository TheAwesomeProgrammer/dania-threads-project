using System.Drawing;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game
{
    public class WriteTextInfo : NonCollidingSprite
    {
        private int FontSize = 12;

        public WriteTextInfo(Vector2 startPos) :
            base(startPos)
        {
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.DrawString("Gold : "+ResourceManager.Instance.Gold, new Font(FontFamily.GenericSerif, FontSize),new SolidBrush(Color.Black),Position.ToPointF()  );
            graphics.DrawString("Meat : "+ResourceManager.Instance.Meat, new Font(FontFamily.GenericSerif, FontSize), new SolidBrush(Color.Black), (Position + new Vector2(0,20)).ToPointF());
        }
    }
}