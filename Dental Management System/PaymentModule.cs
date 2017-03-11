using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Dental_Management_System
{
    public partial class PaymentModule : Form
    {
        public PaymentModule()
        {
            InitializeComponent();
        }

        // CALL CLASS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

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

        private void txtboxPatientIDNumber_TextChanged(object sender, EventArgs e)
        {
            labelPatientID.Text = txtboxPatientIDNumber.Text;

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT FirstName, LastName FROM Patient_Information WHERE PID=" + txtboxPatientIDNumber.Text;
                    MySqlDataReader reader = command.ExecuteReader();

                    string PatientFirstName = null;
                    string PatientLastName = null;
                    while (reader.Read())
                    {
                 
                        PatientFirstName = (reader["FirstName"].ToString());
                        PatientLastName = (reader["LastName"].ToString());

                    }

                    string PatientFullName = PatientFirstName + " " + PatientLastName;
                    labelPatientName.Text = PatientFullName;
                }
                catch
                {

                }

                    connection.Close();
                }
            }

        private void CheckIfServiceListContainsNoData()
        {
            if (comboBoxServiceList.Items.Count == 0)
            {
                MessageBox.Show("Please go to Settings and add your Services before using this module.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                button2.Enabled = false;
            }
        }
        

        private void PaymentModule_Load(object sender, EventArgs e)
        {
            LoadServices();
            CheckIfServiceListContainsNoData();
            
        }

        private void LoadServices()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT dental_services.ServiceName FROM Dental_Services";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var row = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            row += reader.GetValue(i);

                        comboBoxServiceList.Items.Add(row);

                    }

                    connection.Close();

                }
                catch (MySqlException exception)
                {

                }
            }
        }

        private void comboBoxServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    string servicelisting = comboBoxServiceList.SelectedItem.ToString();
                    command.CommandText = "SELECT dental_services.Fee FROM Dental_Services WHERE ServiceName='" + servicelisting + "';";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        labelServiceFee.Text = (reader["Fee"].ToString());

                    }

                    connection.Close();

                }
                catch (MySqlException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }
    }

}


