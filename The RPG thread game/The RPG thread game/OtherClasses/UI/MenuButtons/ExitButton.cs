using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class ExitButton : UIButton
    {
        public ExitButton(Vector2 position, SizeF sizeF, MainMenu Sender) :
            base(position, sizeF, Sender)
        {
            ButtonText = "Exit game";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 77, position.Y + 13);
        }

        public override void OnClick()
        {
            Environment.Exit(0);
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}