using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dental_Management_System
{
    public partial class LoadingDashDialogBox : Form
    {
        public LoadingDashDialogBox()
        {
            InitializeComponent();

        }

        private void LoadingDashDialogBox_Load(object sender, EventArgs e)
        {

        }


        private const int NO_CLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cprams = base.CreateParams;
                cprams.ClassStyle = cprams.ClassStyle | NO_CLOSE_BUTTON ;
                return cprams ;
            }
        } 

        private void LoadingDashDialogBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
