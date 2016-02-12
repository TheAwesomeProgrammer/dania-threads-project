using System.Drawing;

namespace The_RPG_thread_game
{
    public class UpgradeButton : UIButton
    {
        public UpgradeButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF, sender)
        {
            ButtonText = "Upgrade";
            FontSize = 6;
        }

        public override void OnClick()
        {
            
        }
    }
}