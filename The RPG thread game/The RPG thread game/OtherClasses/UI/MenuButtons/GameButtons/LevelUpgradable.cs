using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class LevelUpgradable : UIButton
    {
        public LevelUpgradable(Vector2 position, float width, float height, GameObject goSender, GameWorld gwSender) : base(position, width, height, goSender, gwSender)
        {
            ButtonText = "Level Up (" + goSender.LvlUpCost + ")";
            FontSize = 16;
            TextPosition = new Vector2(position.X + 93, position.Y + 13);
        }

        public override void OnClick()
        {
            foreach (UIButton UIB in gwSender.uiToDraw)
            {
                gwSender.uiToRemove.Add(UIB);
            }
            (goSender as Upgradable).OnLvlUp();
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);

            dc.DrawString(ButtonText, new Font(Font, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
        }
    }
}