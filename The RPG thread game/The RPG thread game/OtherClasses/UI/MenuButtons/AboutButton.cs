using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class AboutButton : UIButton
    {
        public AboutButton(Vector2 position, SizeF sizeF, MainMenu Sender) :
            base(position, sizeF, Sender)
        {
            ButtonText = "About";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
            UIText = "hej";
        }

        public override void OnClick()
        {
            foreach (UIButton UIB in Sender.uiToDraw)
            {
                Sender.uiToRemove.Add(UIB);
            }
            Text = new UIText(UIText, new Vector2(100, 100), Sender);
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