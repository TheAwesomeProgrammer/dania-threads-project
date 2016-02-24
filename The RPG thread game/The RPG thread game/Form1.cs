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
        public Image TownHallImg = Image.FromFile(@"Resources/Structures/Townhall.png");
        public Image ResourceBarImg = Image.FromFile(@"Resources/bar.png");
        public int QueuedWorkerCount = 0;

        public bool MSChosen;
        public bool DSChosen;
        public bool UCChosen;
        public static Form1 Self;

        private static int GameLoopThreadId = IDManager.Instance.GetID();
        private int MainMenuThreadId = IDManager.Instance.GetID();

        private Thread TownHallUpgradeThread;
        private static Thread GameLoopThread;

        private Graphics dc;
        private MainMenu mainMenu;
        private GameWorld GameWorld;
        private static ThreadManager ThreadManager;

        public Form1()
        {
            InitializeComponent();
            Self = this;
            Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void Init()
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

       

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}