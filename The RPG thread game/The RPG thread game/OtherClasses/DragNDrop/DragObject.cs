using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace The_RPG_thread_game.DragNDrop
{
    public class DragObject : CollideableSprite
    {
        private DropCreator DropCreator;
        private bool CanDrop;

        public DragObject(Vector2 startPos,string imagePath, DropCreator dropCreator) : 
            base(startPos, imagePath)
        {
            DropCreator = dropCreator;
        }  

        public override void OnCollision(List<CollideableSprite> spritesCollidingWith)
        {
            CanDrop = false;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ShouldDrag();
        }

        private void ShouldDrag()
        {
            if (Mouse.IsMouseDown)
            {
                Dragging();
            }
            else
            {
                ShouldDrop();
            }
        }

        private void Dragging()
        {
            CanDrop = true;
            Position = Mouse.Position + new Vector2(-SizeF.Width / 2, -SizeF.Height / 2);
        }

        private void ShouldDrop()
        {
            if (CanDrop)
            {
                Drop();
            }
            Die();
        }

        public void Drop()
        {
            DropCreator.SetDropStats(Position);
            GameObject CreatedObject = DropCreator.CreateObject();
            GameWorld.AddObjectInNextCycle(CreatedObject);
            Die();
        }
    }
}