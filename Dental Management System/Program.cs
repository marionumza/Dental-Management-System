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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            //Application.Run(new ViewPatientRecords());
            Application.Run(new Login());

            if (result == DialogResult.OK)
            {
                Application.Run(new MainDashboard());
            }

        }
    }
}
