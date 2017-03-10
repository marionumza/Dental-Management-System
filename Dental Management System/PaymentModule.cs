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
    public partial class PaymentModule : Form
    {
        public PaymentModule()
        {
            InitializeComponent();
        }

        private void radioButtonNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNone.Checked == true)
            {
                lblSeniorCitizenTIN.Enabled = false;
                lblOSCAPWDID.Enabled = false;
                txtboxSeniorTIN.Enabled = false;
                txtboxPWDNumber.Enabled = false;
            }
            else
            {
                lblSeniorCitizenTIN.Enabled = false;
                lblOSCAPWDID.Enabled = false;
                txtboxSeniorTIN.Enabled = false;
                txtboxPWDNumber.Enabled = false;
            }
        }

        private void radioButtonSCPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSCPWD.Checked == true)
            {
                lblSeniorCitizenTIN.Enabled = true;
                lblOSCAPWDID.Enabled = true;
                txtboxSeniorTIN.Enabled = true;
                txtboxPWDNumber.Enabled = true;
            }
            else
            {
                lblSeniorCitizenTIN.Enabled = false;
                lblOSCAPWDID.Enabled = false;
                txtboxSeniorTIN.Enabled = false;
                txtboxPWDNumber.Enabled = false;
            }
        }
    }
}
