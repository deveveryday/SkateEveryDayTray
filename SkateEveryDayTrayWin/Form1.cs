using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SkateEveryDayTrayWin
{
    public partial class Form1 : Form
    {

        NotifyIcon icon = new NotifyIcon();

        string[] tricks = new string[]{
                            "VarialFlip",
                            "360Flip",
                            "Shuvit Heelflip",
                            "FS 180",
                            "BS 180",
                            "Switch Ollie",
                            "Nollie",
                            "Fakie Ollie",
                            "Fakie Flip",
                            "Fakie Heelflip",
                            "Switch FS 180",
                            "Halfcab",
                            "Halfcab Flip",
                            "360 Varial",
                            "Switch Flip",
                            "Nose Slide",
                            "Tail Slide",
                            "Flip Nose Slide",
                            "Ollie to manual"
                         };

        public Form1()
        {
            InitializeComponent();


            icon.Icon = new System.Drawing.Icon("./skate18.ico");
            icon.Visible = true;
            icon.BalloonTipText = "Try to skate today";
            icon.BalloonTipTitle = "SKATEeveryday";
            icon.BalloonTipIcon = ToolTipIcon.Warning;
            icon.ShowBalloonTip(1000);
            icon.MouseUp += Icon_MouseUp;
            
            icon.MouseClick += Icon_MouseClick;
            icon.BalloonTipClicked += Icon_BalloonTipClicked;
            icon.DoubleClick += Icon_DoubleClick1;
            icon.Text = "SKATEeveryday!";
            
            this.Hide();
            Opacity = 0;

            timer1.Enabled = true;
            timer1.Interval = 3600000;
        }

        private void Icon_BalloonTipClicked(object sender, EventArgs e)
        {
            AnimeIcon(200, 30);
        }

        private void Icon_DoubleClick1(object sender, EventArgs e)
        {
            string text = ((NotifyIcon)sender).BalloonTipText;
            if (text.Contains(".com.br"))
            {
                Process.Start("http://www.skateeveryday.com.br/?today=Dev apps for Zurich Brazil");
            }
            else if (text.Contains("PortalHoras"))
            {
                Process.Start("http://portalhoras.stefanini.com/?where=ZURIIICHHHH");
            }
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            

            icon.BalloonTipText = tricks[new Random().Next(0, tricks.Length)]; //"Go to the SkateEveryDay.com.br";
            icon.BalloonTipTitle = "Skate!";
            icon.BalloonTipIcon = ToolTipIcon.Info;
            icon.ShowBalloonTip(1000);

            
            if (e.Button == MouseButtons.Right)
            {
                AnimeIcon(200, 10);
                icon.Icon = NextIcon();
                //icon.BalloonTipText = "Dont forget the PortalHoras shit";
                //icon.BalloonTipTitle = "Skate!";
                //icon.BalloonTipIcon = ToolTipIcon.Error;
                //icon.ShowBalloonTip(1000);
            }
            else//left or middle click
            {
                AnimeIcon(500, 5);
                icon.Icon = NextIcon();
                
                //icon.BalloonTipText = tricks[new Random().Next(0, 13)]; //"Go to the SkateEveryDay.com.br";
                //icon.BalloonTipTitle = "Skate!";
                //icon.BalloonTipIcon = ToolTipIcon.Info;
                //icon.ShowBalloonTip(1000);
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
            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 8)
            {
                icon.Icon = new System.Drawing.Icon("./skate1.ico");
                icon.BalloonTipText = "Dont forget the PortalHoras shit";
                icon.BalloonTipTitle = "Start the Dev day!";
                icon.BalloonTipIcon = ToolTipIcon.Error;

                timer2.Interval = 180000;
            }
            else if (DateTime.Now.Hour > 11 && DateTime.Now.Hour < 12)
            {
                icon.Icon = new System.Drawing.Icon("./skate2.ico");
                icon.BalloonTipText = "Dont forget the PortalHoras shit";
                icon.BalloonTipTitle = "Dev!";
                icon.BalloonTipIcon = ToolTipIcon.Error;

                timer2.Interval = 120000;
            }
            else if (DateTime.Now.Hour > 16 && DateTime.Now.Hour < 18)
            {
                icon.Icon = new System.Drawing.Icon("./skate3.ico");
                icon.BalloonTipText = "Dont forget the PortalHoras shit";
                icon.BalloonTipTitle = "Ending the Dev day!";
                icon.BalloonTipIcon = ToolTipIcon.Error;

                timer2.Interval = 60000;
            }
            else
            {
                icon.Icon = new System.Drawing.Icon("./skate4.ico");
                icon.BalloonTipText = $"Try to land a {tricks[new Random().Next(0, tricks.Length)]} today";
                icon.BalloonTipTitle = "SKATEeveryday";
                icon.BalloonTipIcon = ToolTipIcon.Warning;

                timer2.Interval = 180000;   
            }

            icon.Visible = true;
            icon.ShowBalloonTip(1000);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            icon.Icon = NextIcon();
        }

        private System.Drawing.Icon NextIcon(string icoName = "skate", int ini = 1, int end = 21)
        {
            return new System.Drawing.Icon($"./{icoName}{new Random().Next(ini, end)}.ico");
        }

        private void AnimeIcon(int milliseconds = 1000, int repetitions = 10)
        {
            for(int i = 0; i < repetitions; i++)
            {
                Thread.Sleep(milliseconds);
                icon.Icon = NextIcon();
            }
        }

        private void FlipIcon(int milliseconds = 1000, int repetitions = 10)
        {
            for (int i = 0; i < repetitions; i++)
            {
                Thread.Sleep(milliseconds);
                icon.Icon = NextIcon("skateflip", 1, 2);
            }
        }
    }
}
