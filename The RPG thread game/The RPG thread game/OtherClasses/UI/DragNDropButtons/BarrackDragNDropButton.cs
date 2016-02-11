using System.Drawing;
using The_RPG_thread_game.DragNDrop;

namespace The_RPG_thread_game
{
    public class BarrackDragNDropButton : DragNDropButton
    {
        public BarrackDragNDropButton(Vector2 position, SizeF sizeF, object Sender) :
            base(position, sizeF, Sender)
        {
            DragEnum = StructureType.Barrack;
        }
    }
}