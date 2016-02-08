using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using The_RPG_thread_game.Farm_Semphore_;

namespace The_RPG_thread_game
{
    public partial class Form1 : Form
    {
      
        TownHall townHall;
        static object resourcesLock = new object();
        
        public bool TryingToUpgradeTownHall;
        public bool TryingToUseGoldElsewere;
        Thread TownHallUpgradeThread;

        public Form1()
        {            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            townHall = new TownHall(this);
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
            dc.DrawString(Gold+ ResourceManager.Instance.Gold, f, w, 100, 20);
            dc.DrawString(Food+ ResourceManager.Instance.Meat, f, w, 150, 20);
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
                if(TryingToUseGoldElsewere)
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
    }  
}
