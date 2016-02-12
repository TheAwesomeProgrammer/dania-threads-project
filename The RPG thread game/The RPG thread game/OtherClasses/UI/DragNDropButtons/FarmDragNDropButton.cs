using System.Drawing;
using The_RPG_thread_game;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    public class FarmDragNDropButton : DragNDropButton
    {
        public FarmDragNDropButton(Vector2 position, SizeF sizeF, object Sender) :
            base(position, sizeF, Sender)
        {
            ScaleFactor = 0.5f;
            DragEnum = StructureType.Farm;
            
        }
    }
}