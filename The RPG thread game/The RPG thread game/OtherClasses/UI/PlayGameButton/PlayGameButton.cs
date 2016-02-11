using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_RPG_thread_game;

namespace The_RPG_thread_game
{
    internal class PlayGameButton : UIButton
    {
        private Graphics dc;
        private GameWorld gw;

        public PlayGameButton(Vector2 position, float width, float height, MainMenu mainMenuSender) : base(position, width, height, mainMenuSender)
        {
            ButtonText = "Play Game";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 73, position.Y + 13);
        }

        public override void OnClick()
        {
            
            Form1.StartGameLoop();
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}