using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class BuyMiner : UIButton
    {
        public BuyMiner(Vector2 position, float width, float height, GameObject goSender, GameWorld gwSender) : base(position, width, height, goSender, gwSender)
        {
            ButtonText = "Buy Miner";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
        }

        public override void OnClick()
        {
            foreach (UIButton UIB in gwSender.uiToDraw)
            {
                gwSender.uiToRemove.Add(UIB);
            }
            Miner miner = new Miner(@"Resources/Minerleft.png;Resources/Minerright.png", new Vector2(goSender.Position.X, goSender.Position.Y + 10), gwSender, 1, 100, 100, 5, 5, gwSender.goldMine, gwSender.townhall);
            Thread t = new Thread(miner.ThreadCreateThis);
            t.Start();
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}