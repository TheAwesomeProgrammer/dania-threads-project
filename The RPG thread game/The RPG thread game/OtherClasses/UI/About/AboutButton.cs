﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game;

namespace The_RPG_thread_game
{
    internal class AboutButton : UIButton
    {
        public AboutButton(Vector2 position, SizeF sizeF, MainMenu mainMenuSender) : 
            base(position, sizeF, mainMenuSender)
        {
            ButtonText = "About";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
        }

        public override void OnClick()
        {
            foreach (UIButton UIB in Sender.uiToDraw)
            {
                Sender.uiToRemove.Add(UIB);
            }
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}