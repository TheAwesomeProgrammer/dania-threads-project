using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.OtherClasses.UI.MenuButtons;

namespace The_RPG_thread_game
{
    internal class BackButton : UIButton
    {
        public BackButton(Vector2 position, SizeF sizeF, MainMenu Sender) :
            base(position, sizeF, Sender)
        {
            ButtonText = "Back";

            FontSize = 16;

            TextPosition = new Vector2(position.X + 93, position.Y + 13);
        }

        public override void OnClick()
        {
            foreach (UIText UIT in Sender.uiTextToWrite)
            {
                Sender.uiTextToRemove.Add(UIT);
            }
            Sender.uiToRemove.Add(this);
            Sender.uiToAdd.Add((new PlayGameButton(new Vector2(500, 150), new SizeF(250, 50), Sender)));
            Sender.uiToAdd.Add((new AboutButton(new Vector2(500, 220), new SizeF(250, 50), Sender)));
            Sender.uiToAdd.Add((new CreditButton(new Vector2(500, 290), new SizeF(250, 50), Sender)));
            Sender.uiToAdd.Add((new ExitButton(new Vector2(500, 360), new SizeF(250, 50), Sender)));
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(FontFamily, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}