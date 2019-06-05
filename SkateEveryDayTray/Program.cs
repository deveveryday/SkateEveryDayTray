using System;
using System.Windows.Forms;

namespace SkateEveryDayTray
{
    class Program
    {
        static void Main(string[] args)
        {

            NotifyIcon icon = new NotifyIcon();
            icon.Icon = new System.Drawing.Icon("./skate.ico");
            icon.Visible = true;
            icon.BalloonTipText = "Just Skate every day";
            icon.BalloonTipTitle = "Skate!";
            icon.BalloonTipIcon = ToolTipIcon.Info;
            icon.ShowBalloonTip(2000);
            Console.Read();
        }
    }
}
