using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkateEveryDayTrayWin
{
    public partial class Form1 : Form
    {

        NotifyIcon icon = new NotifyIcon();

        public Form1()
        {
            InitializeComponent();

            
            icon.Icon = new System.Drawing.Icon("./skate.ico");
            icon.Visible = true;
            icon.BalloonTipText = "Just Skate every day";
            icon.BalloonTipTitle = "Skate!";
            icon.BalloonTipIcon = ToolTipIcon.Warning;
            icon.ShowBalloonTip(1000);
            icon.MouseUp += Icon_MouseUp;
            icon.DoubleClick += Icon_DoubleClick;
            icon.MouseClick += Icon_MouseClick;
            icon.BalloonTipClicked += Icon_BalloonTipClicked;
            icon.Text = "SkateEveryDay!";

            this.Hide();
            Opacity = 0;

            timer1.Enabled = true;
            timer1.Interval = 3600000;
        }

        private void Icon_BalloonTipClicked(object sender, EventArgs e)
        {

            Process.Start("http://www.skateeveryday.com.br");
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                icon.BalloonTipText = "Dont forget the PortalHoras shit";
                icon.BalloonTipTitle = "Skate!";
                icon.BalloonTipIcon = ToolTipIcon.Error;
                icon.ShowBalloonTip(1000);
            }
            else//left or middle click
            {
                icon.BalloonTipText = "Go to the SkateEveryDay.com.br";
                icon.BalloonTipTitle = "Skate!";
                icon.BalloonTipIcon = ToolTipIcon.Info;
                icon.ShowBalloonTip(1000);
            }
        }

        private void Icon_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Icon_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.Hour >16 && DateTime.Now.Hour < 18)
            {
                icon.BalloonTipText = "Dont forget the PortalHoras shit";
                icon.BalloonTipTitle = "Skate!";
                icon.BalloonTipIcon = ToolTipIcon.Error;
            }
            else
            {
                icon.BalloonTipText = "Just Skate every day";
                icon.BalloonTipTitle = "Skate!";
                icon.BalloonTipIcon = ToolTipIcon.Warning;
            }

            icon.ShowBalloonTip(1000);
        }
    }
}
