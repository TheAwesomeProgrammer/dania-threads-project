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
using System.Threading.Tasks;
using System.Windows.Forms;
using The_RPG_thread_game.Farm_Semphore_;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public partial class Form1 : Form
    {      
        TownHallMain townHall;
        static object resourcesLock = new object();
        public bool TryingToUpgradeTownHall;
        public bool TryingToBuildWOrker;
        private Thread TownHallUpgradeThread;
        private static Thread GameLoopThread;
        private Graphics dc;
        private MainMenu mainMenu;
        private GameWorld GameWorld;
        private static ThreadManager ThreadManager;
        public Image TownHallImg = Image.FromFile(@"Resources/Lvl1TownHall.png");
        public Image ResourceBarImg = Image.FromFile(@"Resources/bar.png");
        public int QueuedWorkerCount = 0;

        public bool MSChosen;
        public bool DSChosen;
        public bool UCChosen;


        public Form1()
        {            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dc == null)
                dc = CreateGraphics();

            townHall = new TownHallMain(this);
            mainMenu = new MainMenu(dc, DisplayRectangle);
            GameWorld = new GameWorld(dc,DisplayRectangle);
            ThreadManager = ThreadManager.Instance;
            Thread MainMenuThread = new Thread(() => mainMenu.MenuLogic());
            GameLoopThread = new Thread(() => GameWorld.GameLoop());
            //ThreadManager.SetMainThread(MainMenuThread);
        }

        public static void StartGameLoop()
        {
            //ThreadManager.SetMainThread(GameLoopThread); 
        }

        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Sends the mouse positions every time
            Mouse.X = e.X;
            Mouse.Y = e.Y;
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
            Pen p = new Pen(farven, 3);
            Font f = new Font("Arial", 16);
            Brush b = new SolidBrush(Color.Black);
            Brush w = new SolidBrush(Color.White);
            // Town Hall
            string QueuedUnitCount = "Queued Unit count: ";
            string TownHallTitle = "Town Hall";
            dc.DrawImage(TownHallImg, new Rectangle(300, 300, 300, 300));
            dc.DrawRectangle(p, r);
            dc.DrawString(TownHallTitle, f, b, 300, 200);
            dc.DrawString(townHall.CurrentLevel.ToString(), f, b, 300, 180);
            dc.DrawString(townHall.UpgradeGoldPrice + "$", f, b, 530, 200);
            dc.DrawString(townHall.UpgradeFoodPrice + "Food", f, b, 530, 220);
            dc.DrawString(townHall.UpgradeProgess + "%", f, b, 600, 200);
            dc.DrawString(QueuedUnitCount+QueuedWorkerCount.ToString(), f, b, 600, 150);
            // Resource bar
            string Gold = "Gold: ";
            string Food = "Food: ";
            string UnitCount = "Units: ";
            dc.DrawImage(ResourceBarImg, new Rectangle(0, 0, 100, 1000));
            dc.DrawString(UnitCount + townHall.CurrentUnits + "/" + townHall.MaxUnits, f, w, 10, 500);
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
                MessageBox.Show("The resources were avalible and are now accessed.");
                if(TryingToBuildWOrker)
                {
                    // Do something. // Build worker, soldier, tower etc.
                }
                if (TryingToUpgradeTownHall)
                {
                    //!!!!!!!!!!!!!!!!!!!!!!!!! show 3 knapper hvor der kana vælges Chose upgrade! Increase worker movementspeed, Increase worker deliveringspeed, Increase max unit count

                    // if Movementspeed knap tastet
                         // UpgradeChosen();
                         // MSChosen = true;;
                    //  if Deliverspeed knap tastet
                         // UpgradeChosen();
                         // DSChosen = true;
                    // if  UnitCap knap tastet
                         // UpgradeChosen();
                         // UCChosen = true;
                }

                Thread.Sleep(2000);
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

       

      
