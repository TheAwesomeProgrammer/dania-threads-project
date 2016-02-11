using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game.Utillity
{
    public class Render
    {
        public Graphics Graphics;

        private BufferedGraphics BackBuffer;

        public Render(Graphics dc, Rectangle display)
        {
            BackBuffer = BufferedGraphicsManager.Current.Allocate(dc, display);
            Graphics = BackBuffer.Graphics;
        }

       
        public void Clear()
        {
            Graphics.Clear(Color.White);
        }

        public void RenderBackBuffer()
        {
            BackBuffer.Render();
        }
    }
}
