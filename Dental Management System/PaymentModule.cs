﻿using System;
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

        private void txtboxAdditionalFee_TextChanged(object sender, EventArgs e)
        {
            labelAdditionalFee.Text = txtboxAdditionalFee.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtboxPatientIDNumber.Text == String.Empty)
            {
                MessageBox.Show("Please enter a Patient ID number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxServiceList.Text == String.Empty)
            {
                MessageBox.Show("Please select a service.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtboxAdditionalFee.Text.Length > 1)
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    try
                    {

                        double vattax1 = Convert.ToDouble(Properties.PaymentSettings.Default["VATTax"]);
                        double servicefee1 = Convert.ToDouble(labelServiceFee.Text);
                        double addtionalfee = Convert.ToDouble(labelAdditionalFee.Text);
                        double getSumTotal = servicefee1 + addtionalfee;

                        double multiply = getSumTotal * vattax1;
                        double div = multiply / 100;
                        double getNetPrice = getSumTotal + div;

                        labelVAT.Text = div.ToString();
                        labelTotalAmount.Text = getNetPrice.ToString("0.00");

                        connection.Open();
                        MySqlCommand updateCommand = new MySqlCommand();
                        updateCommand.CommandTimeout = 22000;
                        updateCommand.Connection = connection;
                        updateCommand.CommandText = "UPDATE Patient_Payment SET Service=@Service, ServiceFee=@ServiceFee, MiscFee=@MiscFee, Discount=@Discount, VAT=@VAT, Method=@Method, Total=@Total, LastVisit=@LastVisit WHERE PID=" + labelPatientID.Text;
                        updateCommand.Parameters.AddWithValue("@Service", String.Format("{0}", comboBoxServiceList.Text));
                        updateCommand.Parameters.AddWithValue("@ServiceFee", String.Format("{0}", servicefee1.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@MiscFee", String.Format("{0}", addtionalfee.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Discount", String.Format("{0}", label13.Text));
                        updateCommand.Parameters.AddWithValue("@VAT", String.Format("{0}", div.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Method", String.Format("{0}", comboBox2.Text));
                        updateCommand.Parameters.AddWithValue("@Total", String.Format("{0}", getNetPrice.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@LastVisit", String.Format("{0}", DateTime.Now.ToString("MM/dd/yyyy")));

                        updateCommand.ExecuteNonQuery();
                        updateCommand.Parameters.Clear();
                        connection.Close();
                    }
                    catch (Exception exa)
                    {
                        MessageBox.Show(exa.Message);
                    }
                }
            }
            else if (txtboxAdditionalFee.Text == String.Empty)
            {


                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    try
                    {

                        string empty = "0";
                        double servicefee = Convert.ToDouble(labelServiceFee.Text);
                        double vattax = Convert.ToDouble(Properties.PaymentSettings.Default["VATTax"]);
                        double total = servicefee * vattax;
                        double divide = total / 100;
                        double vatprice = divide;
                        double netprice = Convert.ToDouble(labelServiceFee.Text) + vatprice;

                        labelVAT.Text = divide.ToString();
                        labelTotalAmount.Text = netprice.ToString("0.00");

                        connection.Open();
                        MySqlCommand updateCommand = new MySqlCommand();
                        updateCommand.CommandTimeout = 22000;
                        updateCommand.Connection = connection;
                        updateCommand.CommandText = "UPDATE Patient_Payment SET Service=@Service, ServiceFee=@ServiceFee, MiscFee=@MiscFee, Discount=@Discount, VAT=@VAT, Method=@Method, Total=@Total, LastVisit=@LastVisit WHERE PID=" + labelPatientID.Text;
                        updateCommand.Parameters.AddWithValue("@Service", String.Format("{0}", comboBoxServiceList.Text));
                        updateCommand.Parameters.AddWithValue("@ServiceFee", String.Format("{0}", servicefee.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@MiscFee", String.Format("{0}", empty));
                        updateCommand.Parameters.AddWithValue("@Discount", String.Format("{0}", label13.Text));
                        updateCommand.Parameters.AddWithValue("@VAT", String.Format("{0}", divide.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Method", String.Format("{0}", comboBox2.Text));
                        updateCommand.Parameters.AddWithValue("@Total", String.Format("{0}", netprice.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@LastVisit", String.Format("{0}", DateTime.Now.ToString("MM/dd/yyyy")));

                        updateCommand.ExecuteNonQuery();
                        updateCommand.Parameters.Clear();
                        connection.Close();
                    }
                    catch (Exception exa)
                    {
                        MessageBox.Show(exa.Message);
                    }
                }
            }


            if (txtboxAdditionalFee.Text == null)
            {

            }
        }

        private void checkBoxEnableAdditionalFee_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableAdditionalFee.Checked == true)
            {
                txtboxAdditionalFee.Enabled = true;
            }
            else if (checkBoxEnableAdditionalFee.Checked == false)
            {
                txtboxAdditionalFee.Clear();
                txtboxAdditionalFee.Enabled = false;
            }

        }
    }

}


