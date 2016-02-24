using System.Collections.Generic;
using System.Drawing;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class StructureButton : UIButton
    {
        private SizeF ButtonsToSpawnSizeF;

        public StructureButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF, sender)
        {
            ButtonsToSpawnSizeF = new SizeF(90,30);
            BackgroundColor = Color.Transparent;
        }

        public override void OnClick()
        {
            if (UiButtons.Count <= 0)
            {
                AddButton(GameWorld.AddObjectInNextCycle(new BuyStructuresButton(Position, ButtonsToSpawnSizeF, this)) as UIButton);
                AddButton(GameWorld.AddObjectInNextCycle(new BuyWorkersButton(Position + new Vector2(0,
                    ButtonsToSpawnSizeF.Height + 10), ButtonsToSpawnSizeF, this)) as UIButton);
            }
        }

      
    }
}