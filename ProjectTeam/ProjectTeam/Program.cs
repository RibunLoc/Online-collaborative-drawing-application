﻿using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DangNhap dangnhap = new DangNhap();
            if (dangnhap.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new SanhChinh());
            }

           
        }
    }
}