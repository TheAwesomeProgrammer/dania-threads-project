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

namespace The_RPG_thread_game
{
    public partial class Form1 : Form
    {
        private Graphics dc;
        private MainMenu mainMenu;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dc == null)
                dc = CreateGraphics();

            mainMenu = new MainMenu(dc, DisplayRectangle);
            Thread MainMenuThread = new Thread(() => mainMenu.MenuLogic());
            MainMenuThread.Start();
            MainMenuThread.IsBackground = false;
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
    }
}