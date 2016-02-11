using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game;

namespace The_RPG_thread_game
{
    internal abstract class UIButton
    {
        protected MainMenu mainMenuSender;
        protected GameWorld gwSender;
        protected string ButtonText { get; set; }
        protected FontFamily Font { get; set; }
        protected int FontSize { get; set; }
        public Vector2 Position { get; set; }
        private bool IsHovered;
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Color OnHoverColor { get; set; }
        public Vector2 TextPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        protected UIButton(Vector2 position, float width, float height, MainMenu mainMenuSender)
        {
            this.mainMenuSender = mainMenuSender;
            Position = position;
            Width = width;
            Height = height;
            OnHoverColor = Color.White;
            IsHovered = false;
            Font = FontFamily.GenericSansSerif;
            Position = new Vector2(position.X, position.Y);
        }
        protected UIButton(Vector2 position, float width, float height, GameWorld gwSender)
        {
            this.gwSender = gwSender;
            Position = position;
            Width = width;
            Height = height;
            OnHoverColor = Color.White;
            IsHovered = false;
            Font = FontFamily.GenericSansSerif;
            Position = new Vector2(position.X, position.Y);
        }
        public virtual void Draw(Graphics dc)
        {
            BackgroundColor = Color.Blue;
            TextColor = Color.Black;
            if (IsHovered == true)
            {
                TextColor = OnHoverColor;
            }
            dc.FillRectangle(new SolidBrush(BackgroundColor), new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height));
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
    }
}