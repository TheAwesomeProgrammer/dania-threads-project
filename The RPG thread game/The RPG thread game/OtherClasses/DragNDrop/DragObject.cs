using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using The_RPG_thread_game.Factories;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game.DragNDrop
{
    public class DragObject : CollideableSprite
    {
        private DropCreator DropCreator;
        private bool CanDrop;
        protected int GoldCost = 100;
        protected int MeatCost = 25;


        public DragObject(Vector2 startPos,string imagePath, DropCreator dropCreator) : 
            base(startPos, imagePath)
        {
            DropCreator = dropCreator;
            ScaleFactor = 0.5f;
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
            ResourceManager.Instance.Meat -= MeatCost;
            ResourceManager.Instance.Gold -= GoldCost;
            DropCreator.SetDropStats(Position);
            GameObject CreatedObject = DropCreator.CreateObject();
            GameWorld.AddObjectInNextCycle(CreatedObject);
            Die();
        }

    }
}