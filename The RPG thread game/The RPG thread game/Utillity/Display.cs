using System.Drawing;
using System.Windows.Forms;

namespace The_RPG_thread_game.Utillity
{
    public class Display
    {
        private static Display MyInstance;
        private Rectangle DisplayRectangle;

        public static Display Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new Display();
                }
                return MyInstance;
            }
        }

        private Display() { }

        public void SetDisplayRectangle(Rectangle displayRectangle)
        {
            DisplayRectangle = displayRectangle;
        }

        public Size GetSize()
        {
            return DisplayRectangle.Size;
        }

        public Vector2 GetPosition()
        {
            return DisplayRectangle.Location.ToVector2();
        }
    }
}