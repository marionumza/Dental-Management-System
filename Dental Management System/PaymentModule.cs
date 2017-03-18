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
using iTextSharp.text;
using iTextSharp.text.pdf;
using itextsharp.pdfa.iTextSharp;
using MetroFramework.Forms;
using MetroFramework;
using System.IO;

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
                label13.Text = "None";
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
                label13.Text = "SC/PWD";
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
                MessageBox.Show("Please go to Settings and add your Services before using this module." + "\n" +
                    "Contact your system administrator for assistance.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            labelService.Text = comboBoxServiceList.Text;

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

            if (radioButtonSCPWD.Checked == true)
            {

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

                        labelVAT.Text = div.ToString("0.00");
                        labelTotalAmount.Text = getNetPrice.ToString("0.00");

                        /* FORMULA FOR SENIOR/PWD DISCOUNT
                         * 
                         * Senior Discount is equals to 0.20
                         * Take NETPRICE then MULTIPLY BY 0.20
                         * Example: P800 X 0.20 = 160
                         * 
                         * 160 is your discount. 
                         * 
                         * Take the NETPRICE (800) then minus from your discounted price (160).
                         * Total should be (640)
                         * 
                         * */

                        string totalcost = null;

                        if (radioButtonSCPWD.Checked == true)
                        {
                            double seniordiscount = getNetPrice * 0.20;
                            double seniordiscount1 = seniordiscount;
                            double finalnetprice = getNetPrice - seniordiscount1;
                            totalcost = labelTotalAmount.Text = finalnetprice.ToString("0.00");
                        }
                        else if (radioButtonSCPWD.Checked == false)
                        {
                            totalcost = getNetPrice.ToString("0.00");
                        }

                        connection.Open();
                        MySqlCommand updateCommand = new MySqlCommand();
                        updateCommand.CommandTimeout = 22000;
                        updateCommand.Connection = connection;
                        updateCommand.CommandText = "UPDATE Patient_Payment SET Service=@Service, ServiceFee=@ServiceFee, MiscFee=@MiscFee, Discount=@Discount, VAT=@VAT, Method=@Method, Total=@Total, LastVisit=@LastVisit, SeniorTIN=@SeniorTIN, PWDID=@PWDID WHERE PID=" + labelPatientID.Text;
                        updateCommand.Parameters.AddWithValue("@Service", String.Format("{0}", comboBoxServiceList.Text));
                        updateCommand.Parameters.AddWithValue("@ServiceFee", String.Format("{0}", servicefee1.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@MiscFee", String.Format("{0}", addtionalfee.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Discount", String.Format("{0}", label13.Text));
                        updateCommand.Parameters.AddWithValue("@VAT", String.Format("{0}", div.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Method", String.Format("{0}", comboBox2.Text));
                        updateCommand.Parameters.AddWithValue("@Total", String.Format("{0}", totalcost));
                        updateCommand.Parameters.AddWithValue("@LastVisit", String.Format("{0}", DateTime.Now.ToString("MM/dd/yyyy")));
                        updateCommand.Parameters.AddWithValue("@SeniorTIN", String.Format("{0}", txtboxSeniorTIN.Text));
                        updateCommand.Parameters.AddWithValue("@PWDID", String.Format("{0}", txtboxPWDNumber.Text));
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

                        labelVAT.Text = divide.ToString("0.00");
                        labelTotalAmount.Text = netprice.ToString("0.00");


                        /* FORMULA FOR SENIOR/PWD DISCOUNT
                         * 
                         * Senior Discount is equals to 0.20
                         * Take NETPRICE then MULTIPLY BY 0.20
                         * Example: P800 X 0.20 = 160
                         * 
                         * 160 is your discount. 
                         * 
                         * Take the NETPRICE (800) then minus from your discounted price (160).
                         * Total should be (640)
                         * 
                         * */

                        string totalcost = null;

                        if (radioButtonSCPWD.Checked == true)
                        {

                            double seniordiscount = netprice * 0.20;
                            double seniordiscount1 = seniordiscount;
                            double finalnetprice = netprice - seniordiscount1;
                            totalcost = labelTotalAmount.Text = finalnetprice.ToString("0.00");
                        }
                        else if (radioButtonSCPWD.Checked == false)
                        {
                            totalcost = netprice.ToString("0.00");
                        }

                        connection.Open();
                        MySqlCommand updateCommand = new MySqlCommand();
                        updateCommand.CommandTimeout = 22000;
                        updateCommand.Connection = connection;
                        updateCommand.CommandText = "UPDATE Patient_Payment SET Service=@Service, ServiceFee=@ServiceFee, MiscFee=@MiscFee, Discount=@Discount, VAT=@VAT, Method=@Method, Total=@Total, LastVisit=@LastVisit, SeniorTIN=@SeniorTIN, PWDID=@PWDID WHERE PID=" + labelPatientID.Text;
                        updateCommand.Parameters.AddWithValue("@Service", String.Format("{0}", comboBoxServiceList.Text));
                        updateCommand.Parameters.AddWithValue("@ServiceFee", String.Format("{0}", servicefee.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@MiscFee", String.Format("{0}", empty));
                        updateCommand.Parameters.AddWithValue("@Discount", String.Format("{0}", label13.Text));
                        updateCommand.Parameters.AddWithValue("@VAT", String.Format("{0}", divide.ToString("0.00")));
                        updateCommand.Parameters.AddWithValue("@Method", String.Format("{0}", comboBox2.Text));
                        updateCommand.Parameters.AddWithValue("@Total", String.Format("{0}", totalcost));
                        updateCommand.Parameters.AddWithValue("@LastVisit", String.Format("{0}", DateTime.Now.ToString("MM/dd/yyyy")));
                        updateCommand.Parameters.AddWithValue("@SeniorTIN", String.Format("{0}", txtboxSeniorTIN.Text));
                        updateCommand.Parameters.AddWithValue("@PWDID", String.Format("{0}", txtboxPWDNumber.Text));

                        updateCommand.ExecuteNonQuery();
                        updateCommand.Parameters.Clear();
                        connection.Close();
                    }
                    catch (Exception exa)
                    {
                        MessageBox.Show(exa.Message);
                    }
                }

                buttonExport.Enabled = true;
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

        private void txtboxPatientIDNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtboxAdditionalFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtboxSeniorTIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtboxPWDNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            string saveFileLocation = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = labelPatientID.Text + "-" + "Receipt" + "-" + labelPatientName.Text;
            saveFileDialog.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    saveFileLocation = saveFileDialog.FileName;
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    return;
            }

            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(saveFileLocation, FileMode.Create));

                doc.Open();

                // BASIC INFORMATION FOR CLINIC

                Paragraph ClinicName = new Paragraph(Properties.Settings.Default["DocOfficeName"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                ClinicName.Alignment = Element.ALIGN_LEFT;

                Paragraph ClinicAddress = new Paragraph("Address: " + Properties.Settings.Default["DocAddress"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
                ClinicAddress.Alignment = Element.ALIGN_LEFT;

                Paragraph ClinicTelephoneNumber = new Paragraph("Tel no. " + Properties.Settings.Default["DocNumber"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
                ClinicTelephoneNumber.Alignment = Element.ALIGN_LEFT;

                Paragraph OfficialHeader = new Paragraph("OFFICIAL RECEIPT - CUSTOMER'S COPY", FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                OfficialHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph OfficialHeader1 = new Paragraph("OFFICIAL RECEIPT - DOCTOR'S COPY", FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                OfficialHeader1.Alignment = Element.ALIGN_LEFT;

                // BREAK DOWN FEE

                Paragraph ServiceType = new Paragraph("Service:......................... " + labelService.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                ServiceType.Alignment = Element.ALIGN_LEFT;

                Paragraph ServiceFee = new Paragraph("Service fee:................... " + labelServiceFee.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                ServiceFee.Alignment = Element.ALIGN_LEFT;

                Paragraph MiscFee = new Paragraph("Additional fees:.............. " + labelAdditionalFee.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MiscFee.Alignment = Element.ALIGN_LEFT;

                Paragraph Discount = new Paragraph("Discount:....................... " + label13.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                Discount.Alignment = Element.ALIGN_LEFT;

                Paragraph VAT = new Paragraph("VAT............................... " + labelVAT.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                VAT.Alignment = Element.ALIGN_LEFT;

                Paragraph TotalAmount = new Paragraph("Total Amount:............. " + labelTotalAmount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
                TotalAmount.Alignment = Element.ALIGN_LEFT;

                Paragraph SeniorID = new Paragraph("Senior Citizen TIN: " + txtboxSeniorTIN.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                SeniorID.Alignment = Element.ALIGN_LEFT;

                Paragraph PWDID = new Paragraph("OSCA/PWD ID: " + txtboxPWDNumber.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                PWDID.Alignment = Element.ALIGN_LEFT;

                Paragraph TINNUMBER = new Paragraph("TIN #: " + Properties.PaymentSettings.Default["TINnumber"].ToString() + " | " + "BIR: " + Properties.PaymentSettings.Default["BIRnumber"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                TINNUMBER.Alignment = Element.ALIGN_LEFT;

                Paragraph DATEISSUED = new Paragraph("Date Issued: " + Properties.PaymentSettings.Default["TAXpermitIssueDate"].ToString() + " | " + "Expiration: " + Properties.PaymentSettings.Default["TAXpermitExpireDate"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                DATEISSUED.Alignment = Element.ALIGN_LEFT;

                Paragraph PRINTDATE = new Paragraph("Receipt Print Date: " + DateTime.Now.ToString("MM/dd/yyyy"), FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                PRINTDATE.Alignment = Element.ALIGN_LEFT;

                Paragraph DOCSIGN = new Paragraph("SIGNED BY (Cashier/Authorized Representative)", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                DOCSIGN.Alignment = Element.ALIGN_LEFT;

                Paragraph DISCLAIMER = new Paragraph("THIS DOCUMENT IS NOT VALID FOR CLAIMING INPUT TAXES" + "\n" + "THIS OFFICIAL RECEIPT SHALL BE VALID FOR FIVE(5) YEARS FROM THE DATE OF PRINTING", FontFactory.GetFont(FontFactory.HELVETICA, 5, iTextSharp.text.Font.NORMAL));
                DISCLAIMER.Alignment = Element.ALIGN_CENTER;

                Paragraph CUTHERE = new Paragraph("-------------------------------------------------------------------------------CUT HERE--------------------------------------------------------------------", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                CUTHERE.Alignment = Element.ALIGN_LEFT;

                // CUSTOMER'S COPY
                doc.Add(ClinicName);
                doc.Add(ClinicAddress);
                doc.Add(ClinicTelephoneNumber);
                doc.Add(new Paragraph("\n"));
                doc.Add(OfficialHeader);
                doc.Add(new Paragraph("\n"));
                doc.Add(ServiceType);
                doc.Add(ServiceFee);
                doc.Add(MiscFee);
                doc.Add(Discount);
                doc.Add(VAT);
                doc.Add(TotalAmount);
                doc.Add(new Paragraph("\n"));
                doc.Add(SeniorID);
                doc.Add(PWDID);
                doc.Add(new Paragraph("\n"));
                doc.Add(TINNUMBER);
                doc.Add(DATEISSUED);
                doc.Add(PRINTDATE);
                doc.Add(new Paragraph("\n"));
                doc.Add(DOCSIGN);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(DISCLAIMER);
                doc.Add(new Paragraph("\n"));
                doc.Add(CUTHERE);
                // DOCTOR'S COPY
                doc.Add(new Paragraph("\n"));
                doc.Add(ClinicName);
                doc.Add(ClinicAddress);
                doc.Add(ClinicTelephoneNumber);
                doc.Add(new Paragraph("\n"));
                doc.Add(OfficialHeader1);
                doc.Add(new Paragraph("\n"));
                doc.Add(ServiceType);
                doc.Add(ServiceFee);
                doc.Add(MiscFee);
                doc.Add(Discount);
                doc.Add(VAT);
                doc.Add(TotalAmount);
                doc.Add(new Paragraph("\n"));
                doc.Add(SeniorID);
                doc.Add(PWDID);
                doc.Add(new Paragraph("\n"));
                doc.Add(TINNUMBER);
                doc.Add(DATEISSUED);
                doc.Add(PRINTDATE);
                doc.Add(new Paragraph("\n"));
                doc.Add(DOCSIGN);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(DISCLAIMER);

                doc.Close();

                MetroMessageBox.Show(this, "Your PDF has been saved in" + "\n" + saveFileDialog.FileName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MetroMessageBox.Show(this, exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }

}


