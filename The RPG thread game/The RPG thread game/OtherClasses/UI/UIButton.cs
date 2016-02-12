using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game;
using The_RPG_thread_game.Utillity;

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
        protected FontFamily FontFamily { get; set; }
        protected int FontSize { get; set; }
        protected string UIText;
        protected UIText Text;
        protected List<UIButton> UiButtons = new List<UIButton>();

        private bool IsHovered;
        private bool LastMouseDown;

        protected UIButton(Vector2 position, SizeF sizeF, object sender) :
            base(position, sizeF)
        {
            FontSize = 16;
            ButtonText = "";
            Sender = sender as MainMenu;
            FontFamily = FontFamily.GenericSansSerif;
            OnHoverColor = Color.White;
            IsHovered = false;
            BackgroundColor = Color.Blue;
            ImagePath = "";
            LastMouseDown = Mouse.IsMouseDown;
        }

        private Vector2 GetButtonTextCenter(Graphics graphics,string text,Font font)
        {
            Vector2 TextSizeF = graphics.MeasureString(text, font).ToVector2();
            Vector2 RoomBetweenButtonAndText = SizeF.ToVector2() - TextSizeF;

            return Position + (RoomBetweenButtonAndText / 2);
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
                if (Mouse.IsMouseDown && LastMouseDown == false)
                {
                    OnClick();
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
            LastMouseDown = Mouse.IsMouseDown;
        }

        public override void Draw(Graphics graphics)
        {
            TextPosition = GetButtonTextCenter(graphics, ButtonText, new Font(FontFamily,FontSize));
            TextColor = Color.Black;
            ShouldHover();
            graphics.FillRectangle(new SolidBrush(BackgroundColor),
                new RectangleF(Position.X, Position.Y, SizeF.Width, SizeF.Height));
            graphics.DrawString(ButtonText, new Font(FontFamily, FontSize), new SolidBrush(TextColor), TextPosition.X, TextPosition.Y);
            
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

        protected void AddButton(UIButton uiButton)
        {
            UiButtons.Add(uiButton);
        }

        public void RemoveAllButtons()
        {
            UiButtons.DoActionOnItems(GameWorld.RemoveObjectInNextCycle);
            UiButtons.Clear();
        }
    }
}