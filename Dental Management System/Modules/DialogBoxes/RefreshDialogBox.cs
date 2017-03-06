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
    public partial class RefreshDialogBox : Form
    {
        public RefreshDialogBox()
        {
            InitializeComponent();
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

        private void RefreshDialogBox_Load(object sender, EventArgs e)
        {

        }
    }
}
