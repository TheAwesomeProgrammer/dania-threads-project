using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;

using System.Threading;

using System.Threading.Tasks;
using System.Windows.Forms;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public partial class Form1 : Form
    {
        private TownHall townHall;
        private static object resourcesLock = new object();

        public bool TryingToBuildWOrker;
        public bool TryingToUpgradeTownHall;
        public bool TryingToUseGoldElsewere;
        public Image TownHallImg = Image.FromFile(@"Resources/Lvl1TownHall.png");
        public Image ResourceBarImg = Image.FromFile(@"Resources/bar.png");
        public int QueuedWorkerCount = 0;

        public bool MSChosen;
        public bool DSChosen;
        public bool UCChosen;

        private static int GameLoopThreadId = 1;
        private int MainMenuThreadId = 2;
        private int TimeThreadId = 3;

        private Thread TownHallUpgradeThread;
        private static Thread GameLoopThread;

        private Graphics dc;
        private MainMenu mainMenu;
        private GameWorld GameWorld;
        private static ThreadManager ThreadManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dc == null)
                dc = CreateGraphics();

            townHall = new TownHall(this);
            mainMenu = new MainMenu(dc, DisplayRectangle);
            GameWorld = new GameWorld(dc, DisplayRectangle);
            GameLoopThread = new Thread(() => GameWorld.GameLoop(GameLoopThreadId));
            ThreadManager = ThreadManager.Instance;
            Thread MainMenuThread = new Thread(() => mainMenu.MenuLogic(MainMenuThreadId));
            ThreadManager.AddThread(MainMenuThread, MainMenuThreadId, ThreadPriority.Highest);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            ThreadManager.RemoveAllThreads();
        }

        public static void StartGameLoop()
        {
            ThreadManager.AddThread(GameLoopThread, GameLoopThreadId, ThreadPriority.Highest);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Sends the mouse positions every time
            Mouse.Position.X = e.X;
            Mouse.Position.Y = e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //sets the mouse click to true if the mouse is presse
            Mouse.IsMouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse.IsMouseDown = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Rectangle r = new Rectangle(295, 170, 130, 80); // x, y, højde, bredde
            Color farven = Color.Black;
            Color white = Color.White;
            Pen p = new Pen(farven, 3);
            Font f = new Font("Arial", 16);
            string text = "Town Hall";
            string Gold = "Gold: ";
            string Food = "Food: ";
            Brush b = new SolidBrush(Color.Black);
            Brush w = new SolidBrush(Color.White);
            //dc.DrawImage(bar, 0, 0, 100, 10);
            dc.DrawRectangle(p, r);
            dc.DrawString(text, f, b, 300, 200);
            dc.DrawString(townHall.CurrentLevel.ToString(), f, b, 300, 180);
            dc.DrawString(townHall.UpgradeGoldPrice + "$", f, b, 530, 200);
            dc.DrawString(townHall.UpgradeFoodPrice + "Food", f, b, 530, 220);
            dc.DrawString(townHall.UpgradeProgess + "%", f, b, 600, 200);
            dc.DrawString(Gold + ResourceManager.Instance.Gold, f, w, 100, 20);
            dc.DrawString(Food + ResourceManager.Instance.Meat, f, w, 150, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TownHallUpgradeThread = new Thread(townHall.UpgradingTownHall);
            TownHallUpgradeThread.Start();
        }

        public void UseGold()
        {
            MessageBox.Show("Attempting to use resources.");
            lock (resourcesLock)
            {
                MessageBox.Show("The resources were avalible and are now locked for the purchase.");
                if (TryingToUseGoldElsewere)
                {
                }
                if (TryingToUpgradeTownHall)
                {
                    // show 3 knapper hvor der kana vælges Chose upgrade! Increase worker movementspeed, Increase worker deliveringspeed, Increase max unit count
                    townHall.Upgrade();
                    townHall.Progress();
                    TryingToUpgradeTownHall = false;
                }

                Thread.Sleep(2000);
                MessageBox.Show("Purchase complete. Remaning resources are now avalible.");
            }
        }

        public void UpgradeChosen()
        {
            townHall.Upgrade();
            townHall.Progress();
            TryingToUpgradeTownHall = false;
            MessageBox.Show("Purchase complete. Remaning resources are now avalible.");
        }
    }
}