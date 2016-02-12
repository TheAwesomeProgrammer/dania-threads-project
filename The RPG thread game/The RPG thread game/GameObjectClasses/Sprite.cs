using System;
using System.Diagnostics;
using System.Drawing;

namespace The_RPG_thread_game
{
    public abstract class Sprite : GameObject
    {
        public SizeF SizeF;

        protected Image Image;
        protected float ScaleFactor;
        
        protected string ImagePath = @"Resources\apple.png";

        protected Vector2 MyCenter
        {
            get { return new Vector2(Position.X + SizeF.Width/2, Position.Y + SizeF.Height/2); }
        }

        public Vector2 Center => MyCenter;

        protected Sprite(Vector2 startPos) : 
            base(startPos)
        {
           
        }

        protected Sprite(Vector2 startPos, SizeF sizeF) :
           base(startPos)
        {
            SetStats(sizeF);
        }

        protected Sprite(Vector2 startPos, string imagePath) :
            base(startPos)
        {
            ImagePath = imagePath;
        }

        private void SetStats(SizeF sizeF)
        {
            SizeF = sizeF;
        }

        protected override void Init()
        {
            LoadImage();
        }

        protected virtual void LoadImage()
        {
            if (ImagePath != "")
            {
                Image = Image.FromFile(ImagePath);
                if (ScaleFactor > 0)
                {
                    SizeF = new SizeF(ScaleFactor * Image.Height, ScaleFactor * Image.Width);
                }
            }
          
        }

        public virtual void Draw(Graphics graphics)
        {
            if (IsFirstRun)
            {
                IsFirstRun = false;
                Init();
            }
            graphics.DrawImage(Image,Position.X,Position.Y,SizeF.Width,SizeF.Height);
        }
    }
}