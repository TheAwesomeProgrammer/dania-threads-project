using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public class MainMenu
    {
        public Graphics dc;
        public Thread GameWorldThread;
        public Thread NewMainMenuThread;
        private BufferedGraphics backBuffer;
        private Image bgImage;
        public List<UIButton> uiToDraw;
        public List<UIButton> uiToAdd;
        public List<UIButton> uiToRemove;
        public List<UIText> uiTextToWrite;
        public List<UIText> uiTextToAdd;
        public List<UIText> uiTextToRemove;
        public Rectangle Display { get; set; }
        public bool inMenu;

        private int ThreadId;

        public MainMenu(Graphics dc, Rectangle display)
        {
            backBuffer = BufferedGraphicsManager.Current.Allocate(dc, display);
            this.dc = backBuffer.Graphics;
            Display = display;
            uiToDraw = new List<UIButton>();
            uiToAdd = new List<UIButton>();
            uiToRemove = new List<UIButton>();
            uiTextToWrite = new List<UIText>();
            uiTextToAdd = new List<UIText>();
            uiTextToRemove = new List<UIText>();
            bgImage = Image.FromFile(@"Resources/bgImage2.PNG");
        }

        public void MenuLogic(int threadId)
        {
            ThreadId = threadId;
            uiToAdd.Add((new PlayGameButton(new Vector2(500, 150), new SizeF(250, 50), this)));
            uiToAdd.Add((new AboutButton(new Vector2(500, 220), new SizeF(250, 50), this)));
            uiToAdd.Add((new CreditButton(new Vector2(500, 290), new SizeF(250, 50), this)));
            uiToAdd.Add((new ExitButton(new Vector2(500, 360), new SizeF(250, 50), this)));
            while (ThreadManager.Instance.DoesThreadExist(threadId))
            {
                UIFunction();
                DrawUI();
                MouseActions();
            }
        }

        public void StopThread()
        {
            ThreadManager.Instance.RemoveThread(ThreadId);
        }

        private void UIFunction()
        {
            uiToDraw.AddRange(uiToAdd);
            uiTextToWrite.AddRange(uiTextToAdd);
            foreach (UIButton UIB in uiToRemove)
            {
                uiToDraw.Remove(UIB);
            }
            foreach (UIText UIT in uiTextToRemove)
            {
                uiTextToWrite.Remove(UIT);
            }
            ClearUILists();
        }

        private void ClearUILists()
        {
            uiToAdd.Clear();
            uiToRemove.Clear();
            uiTextToAdd.Clear();
            uiTextToRemove.Clear();
        }

        private void MouseActions()
        {
            foreach (UIButton UIB in uiToDraw)
            {
                Vector2 MousePosition = Mouse.Position;

                if (MousePosition.Y > UIB.Position.Y && MousePosition.Y < (UIB.Position.Y + UIB.SizeF.Height) &&
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
            dc.Clear(Color.White);
            dc.DrawImage(bgImage, new Rectangle(0, 0, 1280, 720));

            foreach (UIButton UIB in uiToDraw)
            {
                UIB.Draw(dc);
            }

            foreach (UIText UIT in uiTextToWrite)
            {
                UIT.Draw(dc);
            }

            backBuffer.Render();
        }
    }
}