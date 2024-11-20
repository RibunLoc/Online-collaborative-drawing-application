using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //while (true)
            //{
            //    DangNhap dangnhap = new DangNhap();
            //    if (dangnhap.ShowDialog() == DialogResult.OK)
            //    {
            //        SanhChinh home = new SanhChinh();
            //        home.ShowDialog();

            //        if (home.DialogResult == DialogResult.Cancel)
            //            continue;
            //        else
            //            break;
            //    }
            //    else
            //        break;
            //}

            Application.Run(new SanhChinh());


        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetProcessDPIAware();
    }
}
