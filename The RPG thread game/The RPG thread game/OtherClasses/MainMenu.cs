using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_RPG_thread_game;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class MainMenu
    {
        public List<UIButton> uiToDraw;
        public List<UIButton> uiToAdd;
        public List<UIButton> uiToRemove;
        public Rectangle Display { get; set; }
        public bool inMenu;

        private Graphics Graphics;
        private Image bgImage;
        private int ThreadId;
        private Render Render;
       

        public MainMenu(Graphics dc, Rectangle display)
        {
            Render = new Render(dc,display);
            Graphics = Render.Graphics;
            Display = display;
            uiToDraw = new List<UIButton>();
            uiToAdd = new List<UIButton>();
            uiToRemove = new List<UIButton>();
            inMenu = true;
            bgImage = Image.FromFile(@"Resources/apple.png");
        }

        public void MenuLogic(int threadId)
        {
            ThreadId = threadId;
            uiToAdd.Add((new PlayGameButton(new Vector2(500, 150), new SizeF(250,50), this)));
            uiToAdd.Add((new AboutButton(new Vector2(500, 220), new SizeF(250,50), this)));

            while (ThreadManager.Instance.DoesThreadExist(threadId))
            {
                UIFunction();
                MouseActions();
                DrawUI();
            }
        }

        public void StopThread()
        {
            ThreadManager.Instance.RemoveThread(ThreadId);
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
                Vector2 MousePosition = Mouse.Position;

                if (MousePosition.Y > UIB.Position.Y && MousePosition.Y< (UIB.Position.Y + UIB.SizeF.Height) &&
                   MousePosition.X > UIB.Position.X && MousePosition.X < (UIB.Position.X + UIB.SizeF.Width))
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
            Render.Clear();
            Graphics.DrawImage(bgImage, new Rectangle(0, 0, 1280, 720));

            foreach (UIButton UIB in uiToDraw)
            {
                UIB.Update(0);
                UIB.Draw(Graphics);
            }
            Render.RenderBackBuffer();
        }
    }
}