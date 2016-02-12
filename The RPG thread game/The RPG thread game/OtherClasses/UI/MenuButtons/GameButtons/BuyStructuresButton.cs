using System.Drawing;

namespace The_RPG_thread_game
{
    public class BuyStructuresButton : UIButton
    {
        private UIButton SenderButton;
        private int HashCode;


        public BuyStructuresButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF, sender)
        {
            HashCode = GetObjectId();
            ButtonText = "Buy structures";
            SenderButton = sender as StructureButton;
            FontSize = 6;
        }

        public override void OnClick()
        {
            SenderButton.RemoveAllButtons();
            AddButton(GameWorld.AddObjectInNextCycle(new BarrackDragNDropButton(Position + new Vector2(0, 0), 
                SizeF, this)) as UIButton);
            AddButton(GameWorld.AddObjectInNextCycle(new FarmDragNDropButton(Position + new Vector2(0, SizeF.Height + 10),
                SizeF, this)) as UIButton);
            AddButton(GameWorld.AddObjectInNextCycle(new GoldMineDragNDrop(Position + new Vector2(0, SizeF.Height * 2 + 20),
                SizeF, this)) as UIButton);
        }
    }
}