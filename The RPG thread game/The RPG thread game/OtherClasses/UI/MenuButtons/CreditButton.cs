using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class CreditButton : UIButton
    {
        public CreditButton(Vector2 position, SizeF sizeF, MainMenu Sender) :
            base(position, sizeF, Sender)
        {
            ButtonText = "Credit";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
            UIText = "\n\nThis game is made by\n\n      Kaser Nielsen\n\n     Mathias Larsen\n\n              And\n\n     Phillip Ullersted";
        }

        public override void OnClick()
        {
            foreach (UIButton UIB in Sender.uiToDraw)
            {
                Sender.uiToRemove.Add(UIB);
            }
            Text = new UIText(UIText, new Vector2(520, 100), Sender);
            Sender.uiTextToAdd.Add(Text);
            Sender.uiToAdd.Add(new BackButton(new Vector2(500, 400), new SizeF(250, 50), Sender));
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}