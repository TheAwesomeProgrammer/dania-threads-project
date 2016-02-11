using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game;

namespace The_RPG_thread_game
{
    public abstract class UIButton : CollideableSprite
    {
        public MainMenu Sender;
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Color OnHoverColor { get; set; }
        public Vector2 TextPosition { get; set; }

        protected string ButtonText { get; set; }
        protected FontFamily Font { get; set; }
        protected int FontSize { get; set; }
        protected string UIText;
        protected UIText Text;

        private bool IsHovered;
        private bool HasClicked;

        protected UIButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF)
        {
            Sender = sender as MainMenu;
            Font = FontFamily.GenericSansSerif;
            OnHoverColor = Color.White;
            IsHovered = false;
            BackgroundColor = Color.Blue;
            ImagePath = "";
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            CheckCollisionWithMouse();
        }

        protected void CheckCollisionWithMouse()
        {
            Vector2 MousePosition = Mouse.Position;

            if (CollisionBox.Contains(MousePosition.ToPointF()))
            {
                if (Mouse.IsMouseDown && !HasClicked)
                {
                    OnClick();
                    HasClicked = true;
                }
                else if (!Mouse.IsMouseDown)
                {
                    HasClicked = false;
                }
                else
                {
                    OnHover();
                }
            }
            else
            {
                OnHoverExit();
            }
        }

        public override void Draw(Graphics graphics)
        {
            TextColor = Color.Black;
            ShouldHover();
            graphics.FillRectangle(new SolidBrush(BackgroundColor),
                new RectangleF(Position.X, Position.Y, SizeF.Width, SizeF.Height));
        }

        private void ShouldHover()
        {
            if (IsHovered == true)
            {
                Hover();
            }
        }

        protected void Hover()
        {
            TextColor = OnHoverColor;
        }

        public void OnHover()
        {
            IsHovered = true;
        }

        public void OnHoverExit()
        {
            IsHovered = false;
        }

        public abstract void OnClick();

        public override void OnCollision(List<CollideableSprite> spritesCollidingWith)
        {
        }
    }
}