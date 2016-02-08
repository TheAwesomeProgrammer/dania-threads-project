using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.OtherClasses;

namespace The_RPG_thread_game
{
    internal class MainMenu
    {
        private Graphics dc;
        private BufferedGraphics backBuffer;
        private Image bgImage;
        public List<UIButton> uiToDraw;
        public List<UIButton> uiToAdd;
        public List<UIButton> uiToRemove;
        public List<UIText>
        public Rectangle Display { get; set; }
        public bool inMenu;

        public MainMenu(Graphics dc, Rectangle display)
        {
            backBuffer = BufferedGraphicsManager.Current.Allocate(dc, display);
            this.dc = backBuffer.Graphics;
            Display = display;
            uiToDraw = new List<UIButton>();
            uiToAdd = new List<UIButton>();
            uiToRemove = new List<UIButton>();
            inMenu = true;
            bgImage = Image.FromFile(@"Resources/apple.png");
        }

        public void MenuLogic()
        {
            uiToAdd.Add((new PlayGameButton(new Vector2(500, 150), 250, 50, this)));
            uiToAdd.Add((new AboutButton(new Vector2(500, 220), 250, 50, this)));

            while (true)
            {
                UIFunction();
                MouseActions();
                DrawUI();
            }
        }

        private void UIFunction()
        {
            uiToDraw.AddRange(uiToAdd);
            foreach (UIButton UIB in uiToRemove)
            {
                uiToDraw.Remove(UIB);
            }
            ClearUILists();
        }

        private void ClearUILists()
        {
            uiToAdd.Clear();
            uiToRemove.Clear();
        }

        private void MouseActions()
        {
            foreach (UIButton UIB in uiToDraw)
            {
                if (Mouse.Y > UIB.Position.Y && Mouse.Y < (UIB.Position.Y + UIB.Height) &&
                   Mouse.X > UIB.Position.X && Mouse.X < (UIB.Position.X + UIB.Width))
                {
                    if (Mouse.IsMouseDown)
                    {
                        UIB.OnClick();
                    }
                    else
                    {
                        UIB.OnHover();
                    }
                }
                else
                {
                    UIB.OnHoverExit();
                }
            }
        }

        private void DrawUI()
        {
            dc.Clear(Color.White);
            dc.DrawImage(bgImage, new Rectangle(0, 0, 1280, 720));

            foreach (UIButton UIB in uiToDraw)
            {
                UIB.Draw(dc);
            }
            backBuffer.Render();
        }
    }
}