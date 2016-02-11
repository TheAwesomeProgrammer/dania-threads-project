using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace The_RPG_thread_game
{
    class TownHallUpButton : UIButton
    {
        TownHallMain townHall;
        Thread TownHallUpgradeThread;
        private Graphics dc;
        private GameWorld gw;
        public bool buildingWorker;
        public int WorkerGoldPrice;
        public int WorkerFoodPrice;

        public TownHallUpButton(Vector2 position, float width, float height, GameWorld ButtonSender) : base(position, width, height, ButtonSender) // Tilpas // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            ButtonText = "Upgrade";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
        }

        public override void OnClick() // Upgrade townhall
        {
                TownHallUpgradeThread = new Thread(townHall.UpgradingTownHall);
                TownHallUpgradeThread.Start();
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
        
        public void UpgradeChoises() // !!!!!!!!!!!!!!!!!!!!!!
        {
            // Movementspeed knap instantier
            // Deliverspeed knap instantier
            // UnitCap knap instantier
        }
    }
}
