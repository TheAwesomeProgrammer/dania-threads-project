using System.Drawing;
using The_RPG_thread_game;
using The_RPG_thread_game.DragNDrop;

namespace The_RPG_thread_game
{
    public class FarmDragNDropButton : DragNDropButton
    {
        public FarmDragNDropButton(Vector2 position, SizeF sizeF, object mainMenuSender) :
            base(position, sizeF, mainMenuSender)
        {
            ScaleFactor = 0.5f;
            DragEnum = StructureType.Farm;
        }
    }
}