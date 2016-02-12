using System.Drawing;

namespace The_RPG_thread_game
{
    public class BuyWorkersButton : UIButton
    {
        private UIButton SenderButton;

        public BuyWorkersButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF, sender)
        {
            SenderButton = sender as UIButton;
            ButtonText = "Buy workers";
            FontSize = 6;
        }

        public override void OnClick()
        {
            SenderButton.RemoveAllButtons();
            AddButton(GameWorld.AddObjectInNextCycle(new BuyFarmer(Position + new Vector2(0, 0),
                SizeF, this,WorkerType.Farmer)) as UIButton);
            AddButton(GameWorld.AddObjectInNextCycle(new BuyMiner(Position + new Vector2(0, SizeF.Height + 10),
                SizeF, this, WorkerType.Miner)) as UIButton);
        }
    }
}