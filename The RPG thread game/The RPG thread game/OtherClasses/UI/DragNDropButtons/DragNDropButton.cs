using System;
using System.Drawing;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Factories;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    public class DragNDropButton : UIButton
    {
        protected string DragImagePath;
        protected Enum DragEnum = StructureType.Farm;
        private UIButton SenderButton;

        public DragNDropButton(Vector2 position, SizeF sizeF, object Sender) :
            base(position, sizeF, Sender)
        {
            SenderButton = Sender as UIButton;
            
            FontSize = 6;
        }

        protected override void Init()
        {
            ButtonText = DragEnum.ToString();
            DragImagePath = @"Resources\Structures\" + DragEnum + ".png";
            base.Init();
        }

        public override void OnClick()
        {
            
            SenderButton?.RemoveAllButtons();
            DropCreator DropCreator = new DropCreator(DragEnum, new StructureObjectCreator());
            GameObject DragObject = new DragObject(Mouse.Position, DragImagePath, DropCreator);
            GameWorld.AddObjectInNextCycle(DragObject);
        }
    }
}