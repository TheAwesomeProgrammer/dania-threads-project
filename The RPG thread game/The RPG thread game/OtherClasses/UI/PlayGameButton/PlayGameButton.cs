﻿using System;
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

        public PlayGameButton(Vector2 position, SizeF sizeF, object mainMenuSender) : 
            base(position, sizeF, mainMenuSender)
        {
            ButtonText = "Play Game";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 73, position.Y + 13);
        }

        public override void OnClick()
        {
            Sender.StopThread();
            Form1.StartGameLoop();
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            graphics.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}