using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public class UIText
    {
        private MainMenu Sender;
        private string Text { get; set; }
        private FontFamily Font { get; set; }
        private int FontSize { get; set; }
        public Vector2 Position { get; set; }

        public UIText(string text, Vector2 position, MainMenu Sender)
        {
            Text = text;
            this.Sender = Sender;
            Position = position;
            FontSize = 16;
            Font = FontFamily.GenericSansSerif;
        }

        public void Draw(Graphics dc)
        {
            dc.DrawString(Text, new Font(Font, FontSize), new SolidBrush(Color.Black), Position.X, Position.Y);
        }
    }
}