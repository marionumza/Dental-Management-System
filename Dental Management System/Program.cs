using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dental_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static DialogResult result;

        public static DialogResult dialogResult
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        [STAThread]
        static void Main()
        {

            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
           // Application.Run(new AppSettings());
            
            Application.Run(new Login());

            if (result == DialogResult.OK)
            {
                
                Application.Run(new MainDashboard());
            }

        }
    }
}
