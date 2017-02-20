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
    public partial class ComposeMail : Form
    {
        public ComposeMail()
        {
            InitializeComponent();
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFontSize.SelectedIndex == 0)
            {
                txtboxEmailBody.Font = new System.Drawing.Font(txtboxEmailBody.Font.Name, 9F);
            }
            if (cbFontSize.SelectedIndex == 1)
            {
                txtboxEmailBody.Font = new System.Drawing.Font(txtboxEmailBody.Font.Name, 14F);
            }
            if (cbFontSize.SelectedIndex == 2)
            {
                txtboxEmailBody.Font = new System.Drawing.Font(txtboxEmailBody.Font.Name, 24F);
            }
        }

        private void ComposeMail_Load(object sender, EventArgs e)
        {
        }

        private void ComposeMail_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
