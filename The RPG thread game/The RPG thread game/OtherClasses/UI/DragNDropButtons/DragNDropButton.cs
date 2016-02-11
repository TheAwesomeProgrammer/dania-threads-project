using System;
using System.Drawing;
using The_RPG_thread_game.DragNDrop;

namespace The_RPG_thread_game
{
    public class DragNDropButton : UIButton
    {
        protected string DragImagePath;
        protected Enum DragEnum = StructureType.Farm;

        public DragNDropButton(Vector2 position, SizeF sizeF, object mainMenuSender) :
            base(position, sizeF, mainMenuSender)
        {
           
        }

        protected override void Init()
        {
            base.Init();
            DragImagePath = @"Resources\Structures\" + DragEnum + ".png";
        }


        public override void OnClick()
        {
            DropCreator DropCreator = new DropCreator(DragEnum, new StructureObjectCreator());
            GameObject DragObject = new DragObject(Mouse.Position, DragImagePath, DropCreator);
            GameWorld.AddObjectInNextCycle(DragObject);
        }
    }
}