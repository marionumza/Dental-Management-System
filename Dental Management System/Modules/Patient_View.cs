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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using itextsharp.pdfa.iTextSharp;
using MetroFramework.Forms;
using MetroFramework;

namespace Dental_Management_System
{
    public partial class Patient_View : Form
    {
        public Patient_View()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }


        // CALL CLASS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

        // STRINGS
        string Q1YesNo;
        string Q2YesNo;


        private void LoadInformation()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT FirstName, MiddleName, LastName, Birthday, Gender, PhoneNumber, Email, Occupation, ParentName, Relationship, HomePhone, CellPhone, WorkPhone, WorkExtPhone, Address FROM Patient_Information WHERE PID=" + lbl_IDnum.Text;
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        txtboxFirstName.Text = (reader["FirstName"].ToString());
                        txtboxMiddleName.Text = (reader["MiddleName"].ToString());
                        txtboxLastName.Text = (reader["LastName"].ToString());
                        cbBirthday.Text = (reader["Birthday"].ToString());
                        cbMaritalStatus.Text = (reader["Gender"].ToString());
                        txtboxPhoneNum.Text = (reader["PhoneNumber"].ToString());
                        txtboxEmail.Text = (reader["Email"].ToString());
                        txtboxOccupation.Text = (reader["Occupation"].ToString());
                        txtboxParentName.Text = (reader["ParentName"].ToString());
                        txtboxRelationship.Text = (reader["Relationship"].ToString());
                        txtboxCellphoneNum.Text = (reader["CellPhone"].ToString());
                        txtboxHomePhone.Text = (reader["HomePhone"].ToString());
                        txtboxWorkPhone.Text = (reader["WorkPhone"].ToString());
                        txtboxExtensionNum.Text = (reader["WorkExtPhone"].ToString());
                        txtboxAddress.Text = (reader["Address"].ToString());

                    }

                    connection.Close();
                    connection.Open();

                    MySqlCommand command2 = connection.CreateCommand();
                    command2.CommandText = "SELECT Q1, Q2, ChartType, Note1, Note2, Note3, Note4, Note5, Note6, Note7, Note8, Note9, Note10, Note11, Note12, Note13, Note14, Note15, Note16, Note17, Note18, Note19, Note20, Note21, Note22, Note23, Note24, Note25, Note26, Note27, Note28, Note29, Note30, Note31, Note32 FROM Patient_MedHistory WHERE PID=" + lbl_IDnum.Text;
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        string ValidateChartType;

                        Q1YesNo = (reader2["Q1"].ToString());
                        Q2YesNo = (reader2["Q2"].ToString());

                        if (Q1YesNo.ToString() == "Yes")
                        {
                            metroRadioButtonQ1Yes.Checked = true;
                            metroRadioButtonQ1No.Checked = false;
                        }
                        else if (Q1YesNo.ToString() == "No")
                        {
                            metroRadioButtonQ1Yes.Checked = false;
                            metroRadioButtonQ1No.Checked = true;
                        }

                        if (Q2YesNo.ToString() == "Yes")
                        {
                            metroRadioButtonQ2No.Checked = false;
                            metroRadioButtonQ2Yes.Checked = true;
                        }
                        else if (Q2YesNo.ToString() == "No")
                        {
                            metroRadioButtonQ2Yes.Checked = false;
                            metroRadioButtonQ2No.Checked = true;
                        }

                        ValidateChartType = (reader2["ChartType"].ToString());

                        if (ValidateChartType.ToString() == "Primary")
                        {
                            radioButtonPrimary.Checked = true;
                            radioButtonPermament.Checked = false;
                        }
                        else if (ValidateChartType.ToString() == "Permament")
                        {
                            radioButtonPermament.Checked = true;
                            radioButtonPrimary.Checked = false;
                        }

                        toothNote_1.Text = (reader2["Note1"].ToString());
                        toothNote_2.Text = (reader2["Note2"].ToString());
                        toothNote_3.Text = (reader2["Note3"].ToString());
                        toothNote_4.Text = (reader2["Note4"].ToString());
                        toothNote_5.Text = (reader2["Note5"].ToString());
                        toothNote_6.Text = (reader2["Note6"].ToString());
                        toothNote_7.Text = (reader2["Note7"].ToString());
                        toothNote_8.Text = (reader2["Note8"].ToString());
                        toothNote_9.Text = (reader2["Note9"].ToString());
                        toothNote_10.Text = (reader2["Note10"].ToString());
                        toothNote_11.Text = (reader2["Note11"].ToString());
                        toothNote_12.Text = (reader2["Note12"].ToString());
                        toothNote_13.Text = (reader2["Note13"].ToString());
                        toothNote_14.Text = (reader2["Note14"].ToString());
                        toothNote_15.Text = (reader2["Note15"].ToString());
                        toothNote_16.Text = (reader2["Note16"].ToString());
                        toothNote_17.Text = (reader2["Note17"].ToString());
                        toothNote_18.Text = (reader2["Note18"].ToString());
                        toothNote_19.Text = (reader2["Note19"].ToString());
                        toothNote_20.Text = (reader2["Note20"].ToString());
                        toothNote_21.Text = (reader2["Note21"].ToString());
                        toothNote_22.Text = (reader2["Note22"].ToString());
                        toothNote_23.Text = (reader2["Note23"].ToString());
                        toothNote_24.Text = (reader2["Note24"].ToString());
                        toothNote_25.Text = (reader2["Note25"].ToString());
                        toothNote_26.Text = (reader2["Note26"].ToString());
                        toothNote_27.Text = (reader2["Note27"].ToString());
                        toothNote_28.Text = (reader2["Note28"].ToString());
                        toothNote_29.Text = (reader2["Note29"].ToString());
                        toothNote_30.Text = (reader2["Note30"].ToString());
                        toothNote_31.Text = (reader2["Note31"].ToString());
                        toothNote_32.Text = (reader2["Note32"].ToString());

                    }

                    connection.Close();
                    connection.Open();

                    MySqlCommand command3 = connection.CreateCommand();
                    command3.CommandText = "SELECT Service, ServiceFee, MiscFee, Discount, VAT, Method, Total, LastVisit FROM Patient_Payment WHERE PID=" + lbl_IDnum.Text;
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        lblServiceType.Text = (reader3["Service"].ToString());
                        lblServiceFee.Text = (reader3["ServiceFee"].ToString());
                        lblAdditionalFees.Text = (reader3["MiscFee"].ToString());
                        lblDiscount.Text = (reader3["Discount"].ToString());
                        lblVAT.Text = (reader3["VAT"].ToString());
                        lblTotalAmount.Text = (reader3["Total"].ToString());
                        label55.Text = (reader3["LastVisit"].ToString());
    
                    }
                    connection.Close();

                }
                catch(Exception exception)
                {
                    DialogResult connectionError = MessageBox.Show(exception.Message + "Unable to connect to the MySql server. Check your settings and try again", this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if(connectionError == DialogResult.OK)
                    {
                        this.Dispose();
                    }

                }
            }
        }

        private void UpdateInformation()
        {

            string fieldate = cbBirthday.Value.ToString("yyyy-MM-dd");
            string question1 = null;
            string question2 = null;
            string charttype = null;

            if (metroRadioButtonQ1Yes.Checked == true)
            {
                question1 = metroRadioButtonQ1Yes.Text;
            }
            else if (metroRadioButtonQ1No.Checked == true)
            {
                question1 = metroRadioButtonQ1No.Text;
            }
            if (metroRadioButtonQ2Yes.Checked == true)
            {
                question2 = metroRadioButtonQ2Yes.Text;
            }
            else if (metroRadioButtonQ2No.Checked == true)
            {
                question2 = metroRadioButtonQ2No.Text;
            }

            if (radioButtonPrimary.Checked == true)
            {
                charttype = radioButtonPrimary.Text;
            }
            else if (radioButtonPermament.Checked == true)
            {
                charttype = radioButtonPermament.Text;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand updateCommand = new MySqlCommand();
                    updateCommand.CommandTimeout = 22000;
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Patient_Information SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Birthday=@Birthday, Gender=@Gender, PhoneNumber=@PhoneNumber, Email=@Email, Occupation=@Occupation, ParentName=@ParentName, Relationship=@Relationship, HomePhone=@HomePhone, CellPhone=@CellPhone, WorkPhone=@WorkPhone, WorkExtPhone=@WorkExtPhone, Address=@Address WHERE PID=" + lbl_IDnum.Text;
                    updateCommand.Parameters.AddWithValue("@FirstName", String.Format("{0}", txtboxFirstName.Text));
                    updateCommand.Parameters.AddWithValue("@MiddleName", String.Format("{0}", txtboxMiddleName.Text));
                    updateCommand.Parameters.AddWithValue("@LastName", String.Format("{0}", txtboxLastName.Text));
                    updateCommand.Parameters.AddWithValue("@Birthday", String.Format("{0}", fieldate));
                    updateCommand.Parameters.AddWithValue("@Gender", String.Format("{0}", cbMaritalStatus.Text));
                    updateCommand.Parameters.AddWithValue("@PhoneNumber", String.Format("{0}", txtboxPhoneNum.Text));
                    updateCommand.Parameters.AddWithValue("@Email", String.Format("{0}", txtboxEmail.Text));
                    updateCommand.Parameters.AddWithValue("@Occupation", String.Format("{0}", txtboxOccupation.Text));
                    updateCommand.Parameters.AddWithValue("@ParentName", String.Format("{0}", txtboxParentName.Text));
                    updateCommand.Parameters.AddWithValue("@Relationship", String.Format("{0}", txtboxRelationship.Text));
                    updateCommand.Parameters.AddWithValue("@HomePhone", String.Format("{0}", txtboxHomePhone.Text));
                    updateCommand.Parameters.AddWithValue("@Cellphone", String.Format("{0}", txtboxCellphoneNum.Text));
                    updateCommand.Parameters.AddWithValue("@Workphone", String.Format("{0}", txtboxWorkPhone.Text));
                    updateCommand.Parameters.AddWithValue("@WorkExtPhone", String.Format("{0}", txtboxExtensionNum.Text));
                    updateCommand.Parameters.AddWithValue("@Address", String.Format("{0}", txtboxAddress.Text));
                    updateCommand.ExecuteNonQuery();
                    updateCommand.Parameters.Clear();

                    updateCommand.CommandText = "UPDATE Patient_MedHistory SET Q1=@Q1, Q2=@Q2, ChartType=@ChartType, Note1=@Note1, Note2=@Note2, Note3=@Note3, Note4=@Note4, Note5=@Note5, Note6=@Note6, Note7=@Note7, Note8=@Note8, Note9=@Note9, Note10=@Note10, Note11=@Note11, Note12=@Note12, Note13=@Note13, Note14=@Note14, Note15=@Note15, Note16=@Note16, Note17=@Note17, Note18=@Note18, Note19=@Note19, Note20=@Note20, Note21=@Note21, Note22=@Note22, Note23=@Note23, Note24=@Note24, Note25=@Note25, Note26=@Note26, Note27=@Note27, Note28=@Note28, Note29=@Note29, Note30=@Note30, Note31=@Note31, Note32=@Note32 WHERE PID=" + lbl_IDnum.Text;
                    updateCommand.Parameters.AddWithValue("@Q1", String.Format("{0}", question1));
                    updateCommand.Parameters.AddWithValue("@Q2", String.Format("{0}", question2));
                    updateCommand.Parameters.AddWithValue("@ChartType", String.Format("{0}", charttype));
                    updateCommand.Parameters.AddWithValue("@Note1", String.Format("{0}", toothNote_1.Text));
                    updateCommand.Parameters.AddWithValue("@Note2", String.Format("{0}", toothNote_2.Text));
                    updateCommand.Parameters.AddWithValue("@Note3", String.Format("{0}", toothNote_3.Text));
                    updateCommand.Parameters.AddWithValue("@Note4", String.Format("{0}", toothNote_4.Text));
                    updateCommand.Parameters.AddWithValue("@Note5", String.Format("{0}", toothNote_5.Text));
                    updateCommand.Parameters.AddWithValue("@Note6", String.Format("{0}", toothNote_6.Text));
                    updateCommand.Parameters.AddWithValue("@Note7", String.Format("{0}", toothNote_7.Text));
                    updateCommand.Parameters.AddWithValue("@Note8", String.Format("{0}", toothNote_8.Text));
                    updateCommand.Parameters.AddWithValue("@Note9", String.Format("{0}", toothNote_9.Text));
                    updateCommand.Parameters.AddWithValue("@Note10", String.Format("{0}", toothNote_10.Text));
                    updateCommand.Parameters.AddWithValue("@Note11", String.Format("{0}", toothNote_11.Text));
                    updateCommand.Parameters.AddWithValue("@Note12", String.Format("{0}", toothNote_12.Text));
                    updateCommand.Parameters.AddWithValue("@Note13", String.Format("{0}", toothNote_13.Text));
                    updateCommand.Parameters.AddWithValue("@Note14", String.Format("{0}", toothNote_14.Text));
                    updateCommand.Parameters.AddWithValue("@Note15", String.Format("{0}", toothNote_15.Text));
                    updateCommand.Parameters.AddWithValue("@Note16", String.Format("{0}", toothNote_16.Text));
                    updateCommand.Parameters.AddWithValue("@Note17", String.Format("{0}", toothNote_17.Text));
                    updateCommand.Parameters.AddWithValue("@Note18", String.Format("{0}", toothNote_18.Text));
                    updateCommand.Parameters.AddWithValue("@Note19", String.Format("{0}", toothNote_19.Text));
                    updateCommand.Parameters.AddWithValue("@Note20", String.Format("{0}", toothNote_20.Text));
                    updateCommand.Parameters.AddWithValue("@Note21", String.Format("{0}", toothNote_21.Text));
                    updateCommand.Parameters.AddWithValue("@Note22", String.Format("{0}", toothNote_22.Text));
                    updateCommand.Parameters.AddWithValue("@Note23", String.Format("{0}", toothNote_23.Text));
                    updateCommand.Parameters.AddWithValue("@Note24", String.Format("{0}", toothNote_24.Text));
                    updateCommand.Parameters.AddWithValue("@Note25", String.Format("{0}", toothNote_25.Text));
                    updateCommand.Parameters.AddWithValue("@Note26", String.Format("{0}", toothNote_26.Text));
                    updateCommand.Parameters.AddWithValue("@Note27", String.Format("{0}", toothNote_27.Text));
                    updateCommand.Parameters.AddWithValue("@Note28", String.Format("{0}", toothNote_28.Text));
                    updateCommand.Parameters.AddWithValue("@Note29", String.Format("{0}", toothNote_29.Text));
                    updateCommand.Parameters.AddWithValue("@Note30", String.Format("{0}", toothNote_30.Text));
                    updateCommand.Parameters.AddWithValue("@Note31", String.Format("{0}", toothNote_31.Text));
                    updateCommand.Parameters.AddWithValue("@Note32", String.Format("{0}", toothNote_32.Text));
                    updateCommand.ExecuteNonQuery();
                    updateCommand.Parameters.Clear();

                    DialogResult confirmSaveChanges = MessageBox.Show("Patient information has been updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (confirmSaveChanges == DialogResult.OK)
                    {
                        metroToggleEditMode.Checked = false;
                    }

                    connection.Close();
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        void DisableTextBoxInChartNotes()
        {
            foreach (Control control in NotesPage1.Controls)
            {
                TextBox textBox = control as TextBox;
                
                if (textBox != null)
                {
                    textBox.Enabled = false;
                } 
            }

            foreach (Control control in NotesPage2.Controls)
            {
                TextBox textBox = control as TextBox;

                if (textBox != null)
                {
                    textBox.Enabled = false;
                }
            }
        }

        void EnableTextBoxInChartNotes()
        {
            foreach (Control control in NotesPage1.Controls)
            {
                TextBox textBox = control as TextBox;

                if (textBox != null)
                {
                    textBox.Enabled = true;
                }
            }

            foreach (Control control in NotesPage2.Controls)
            {
                TextBox textBox = control as TextBox;

                if (textBox != null)
                {
                    textBox.Enabled = true;
                }
            }
        }

        private void Patient_View_Load(object sender, EventArgs e)
        {
            LoadInformation();
            cbBirthday.Enabled = false;
            cbMaritalStatus.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            DisableTextBoxInChartNotes();

            // DESIGN
            this.Text = "Patient Medical Profile for " + firstname_readonly.Text + " " + lastname_readonly.Text;

        }


        private void firstname_txtbox_TextChanged(object sender, EventArgs e)
        {

            firstname_readonly.Text = txtboxFirstName.Text;
        }

        private void middlename_txtbox_TextChanged(object sender, EventArgs e)
        {
            middlename_readonly.Text = txtboxMiddleName.Text;
        }

        private void lastname_txtbox_TextChanged(object sender, EventArgs e)
        {
            lastname_readonly.Text = txtboxLastName.Text;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-'
                && e.KeyChar != ' '
                && e.KeyChar != '('
                && e.KeyChar != ')')
            {
                MessageBox.Show("Numbers can only be entered here", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-'
                && e.KeyChar != ' '
                && e.KeyChar != '('
                && e.KeyChar != ')')
            {
                MessageBox.Show("Numbers can only be entered here", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-'
                && e.KeyChar != ' '
                && e.KeyChar != '('
                && e.KeyChar != ')')
            {
                MessageBox.Show("Numbers can only be entered here", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void addnotes_button_Click(object sender, EventArgs e)
        {
            if (toothchart_panel.Visible == true)
            {
                toothchart_panel.Visible = false;
                toothcartnotes_panel.Visible = true;


            }
        }

        private void NextPage_button_Click(object sender, EventArgs e)
        {
            if (NotesPage1.Visible == true)
            {
                NotesPage1.Visible = false;
                NotesPage2.Visible = true;
                PrevPage_button.Enabled = true;
                NextPage_button.Enabled = false;
            }
        }

        private void PrevPage_button_Click(object sender, EventArgs e)
        {
            if (NotesPage2.Visible == true)
            {
                NotesPage2.Visible = false;
                NotesPage1.Visible = true;
                PrevPage_button.Enabled = false;
                NextPage_button.Enabled = true;
            }
        }

        private void return_button_Click(object sender, EventArgs e)
        {
            if (toothcartnotes_panel.Visible == true)
            {
                toothcartnotes_panel.Visible = false;
                toothchart_panel.Visible = true;
            }
        }

        private void Reset_button_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete '" + firstname_readonly.Text + " " + lastname_readonly.Text + "'?" +
                "\n" + "This process cannot be reversed." , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmDelete == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand deleteCommand = connection.CreateCommand();
                    deleteCommand.CommandText = "DELETE FROM Patient_Payment WHERE PID=" + lbl_IDnum.Text;
                    deleteCommand.ExecuteNonQuery();
                    deleteCommand.CommandText = "DELETE FROM Patient_MedHistory WHERE PID=" + lbl_IDnum.Text;
                    deleteCommand.ExecuteNonQuery();
                    deleteCommand.CommandText = "DELETE FROM Patient_Information WHERE PID=" + lbl_IDnum.Text;
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Patient deleted", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    this.Close();
                }
            }
            else if (confirmDelete == DialogResult.No)
            {
                return;
            }
        }

        private void Addpatient_button_Click(object sender, EventArgs e)
        {

            UpdateInformation();

        }

        private void Permament_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPermament.Checked == true)
            {
                ToothCharts_PicBox.Image = Properties.Resources.PermanentToothChart;

                toothNote_21.Enabled = true;
                toothNote_22.Enabled = true;
                toothNote_23.Enabled = true;
                toothNote_24.Enabled = true;
                toothNote_25.Enabled = true;
                toothNote_26.Enabled = true;
                toothNote_27.Enabled = true;
                toothNote_28.Enabled = true;
                toothNote_29.Enabled = true;
                toothNote_30.Enabled = true;
                toothNote_31.Enabled = true;
                toothNote_32.Enabled = true;

            }
        }

        private void primaryTeeth_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPrimary.Checked == true)
            {
                ToothCharts_PicBox.Image = Properties.Resources.PrimaryTeethChart;

                toothNote_21.Enabled = false;
                toothNote_22.Enabled = false;
                toothNote_23.Enabled = false;
                toothNote_24.Enabled = false;
                toothNote_25.Enabled = false;
                toothNote_26.Enabled = false;
                toothNote_27.Enabled = false;
                toothNote_28.Enabled = false;
                toothNote_29.Enabled = false;
                toothNote_30.Enabled = false;
                toothNote_31.Enabled = false;
                toothNote_32.Enabled = false;

            }
        }

        private void metroToggleEditMode_CheckedChanged(object sender, EventArgs e)
        {

            foreach (Control control in groupBox1.Controls)
            {
                TextBox textBox = control as TextBox;
                if (metroToggleEditMode.Checked == true)
                {

                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox5.Enabled = true;
                    EnableTextBoxInChartNotes();

                    if (textBox != null)
                    {
                        textBox.ReadOnly = false;
                        cbBirthday.Enabled = true;
                        cbMaritalStatus.Enabled = true;
                        btnSaveChanges.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
                else if (metroToggleEditMode.Checked == false)
                {
                    DisableTextBoxInChartNotes();

                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;

                    if (textBox != null)
                    {
                        textBox.ReadOnly = true;
                        cbBirthday.Enabled = false;
                        cbMaritalStatus.Enabled = false;
                        btnSaveChanges.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }

            }
            foreach (Control control in groupBox2.Controls)
            {
                TextBox textBox = control as TextBox;
                if (metroToggleEditMode.Checked == true)
                {
                    if (textBox != null)
                    {
                        textBox.ReadOnly = false;
                    }

                }
                else if (metroToggleEditMode.Checked == false)
                {
                    if (textBox != null)
                    {
                        textBox.ReadOnly = true;
                    }

                }
            }

        }

        private void btnOpenToothChartExternalWindow_Click(object sender, EventArgs e)
        {
            ToothChartExternalWindow toothChartExternalWindow = new ToothChartExternalWindow();

            if (radioButtonPrimary.Checked == true)
            {
                toothChartExternalWindow.pictureBox1.Image = Properties.Resources.PrimaryTeethChart;
                toothChartExternalWindow.Show();
                toothChartExternalWindow.Text = "Tooth Chart - Primary Teeth";
            }
            else if (radioButtonPermament.Checked == true)
            {
                toothChartExternalWindow.pictureBox1.Image = Properties.Resources.PermanentToothChart;
                toothChartExternalWindow.Show();
                toothChartExternalWindow.Text = "Tooth Chart - Permanent Teeth";
            }
        }

        private void Patient_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                openForms.Add(form);
            }

            foreach (Form form in openForms)
            {
                if (form.Name == "ToothChartExternalWindow")
                    form.Dispose();

            }
        }

        private void btnSetAppointment_Click(object sender, EventArgs e)
        {
            
            string getday = dateTimePicker_DateSelection.Value.ToString("yyyy-MM-dd");

            if (comboBox_ChooseTime.SelectedItem == null)
            {
                MessageBox.Show("Please select the time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (comboBox_ServiceType.SelectedItem == null)
            {
                MessageBox.Show("Please select a service.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO Patient_Schedule(Time, Date, Service, LastName, FirstName, Notes) VALUES (@Time, @Date, @Service, @LastName, @FirstName, @Notes)";
                    command.Parameters.AddWithValue("@Time", String.Format("{0}", comboBox_ChooseTime.Text));
                    command.Parameters.AddWithValue("@Date", String.Format("{0}", getday));
                    command.Parameters.AddWithValue("@Service", String.Format("{0}", comboBox_ServiceType.Text));
                    command.Parameters.AddWithValue("@LastName", String.Format("{0}", lastname_readonly.Text));
                    command.Parameters.AddWithValue("@FirstName", String.Format("{0}", firstname_readonly.Text));
                    command.Parameters.AddWithValue("@Notes", String.Format("{0}", textBox_Notes.Text));
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();

                    MessageBox.Show("Appointment has been scheduled for " + dateTimePicker_DateSelection.Value.ToString("MM/dd/yyyy") + " " + comboBox_ChooseTime.Text +
                        "\n" + "Service: " + comboBox_ServiceType.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnSetAppointment.Enabled = false;
                    

                }
            }
            catch (Exception eh)
            {
                
                MessageBox.Show(eh.Message);
            }

        }

        private void Patient_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string saveFileLocation = string.Empty;

        private void btnExportData_Click(object sender, EventArgs e)
        {


            string saveFileLocation = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = lbl_IDnum.Text + "-" + "Data" + "-" + txtboxLastName.Text;
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
                ClinicName.Alignment = Element.ALIGN_CENTER;

                Paragraph ClinicAddress = new Paragraph("Address: " + Properties.Settings.Default["DocAddress"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
                ClinicAddress.Alignment = Element.ALIGN_CENTER;

                Paragraph ClinicTelephoneNumber = new Paragraph("Tel no. " + Properties.Settings.Default["DocNumber"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
                ClinicTelephoneNumber.Alignment = Element.ALIGN_CENTER;

                Paragraph MedicalHeader = new Paragraph("Medical Profile", FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                // PATIENT DATA

                Paragraph PatientName = new Paragraph("Name: " + txtboxLastName.Text + ", " + txtboxFirstName.Text + " " + txtboxMiddleName.Text + ".", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph PatientDOB = new Paragraph("Date of Birth: " + cbBirthday.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph PatientGender = new Paragraph("Gender: " + cbMaritalStatus.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph PatientPhoneNumberAndEmail = new Paragraph("Phone Number: " + txtboxPhoneNum.Text + "         " + "Email: " + txtboxEmail.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph PatientOccupation = new Paragraph("Occupation: " + txtboxOccupation.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                // PARENT DATA

                Paragraph InCaseOfEmergency = new Paragraph("In case of emergencies, we should notify", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.ITALIC));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph ParentName = new Paragraph("Parent/Guardian Name: " + txtboxParentName.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph Relationship = new Paragraph("What is your relationship with this person? " + txtboxRelationship.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph HomeAndCellPhone = new Paragraph("Home Phone: " + txtboxHomePhone.Text + "            " + "Cellphone: " + txtboxCellphoneNum.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph WorkPhone = new Paragraph("Work Phone (if any): " + txtboxWorkPhone.Text + "          " + "Extension Number: " + txtboxExtensionNum.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                Paragraph HomeAddress = new Paragraph("Address: " + txtboxAddress.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHeader.Alignment = Element.ALIGN_LEFT;

                // MEDICAL RECORD

                Paragraph MedicalHistory = new Paragraph("Medical History", FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                MedicalHistory.Alignment = Element.ALIGN_LEFT;

                Paragraph MedicalHistoryDisclaimer = new Paragraph("For the following questions circle YES or NO, or whichever applies. Your answers are for our records and will be considered confidential.", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MedicalHistory.Alignment = Element.ALIGN_LEFT;

                Paragraph Question1 = new Paragraph("1. " + "Are you in good health?........................................................................................................................    " + Q1YesNo, 
                    FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
                Question1.Alignment = Element.ALIGN_LEFT;

                Paragraph Question2 = new Paragraph("2. " + "Have you ever been hospitalized or had a major operation?............................................................    " + Q2YesNo,
                    FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
                Question2.Alignment = Element.ALIGN_LEFT;

                Paragraph FinalDisclaimer = new Paragraph("To the best of my knowledge, the questions on this form have been accurately answered. I understand that providing incorrect information can be dangerous to my (or patient’s) health. It is my responsibility to inform the dental office of any changes in medical status.",
                    FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                FinalDisclaimer.Alignment = Element.ALIGN_LEFT;

                Paragraph ParentSignature = new Paragraph("SIGNATURE OF PATIENT, PARENT, OR GUARDIAN: _____________________________________________________",
                    FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                ParentSignature.Alignment = Element.ALIGN_LEFT;

                Paragraph DentistSignature = new Paragraph("DENTIST’S SIGNATURE",
                    FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                DentistSignature.Alignment = Element.ALIGN_LEFT;

                Paragraph PrintedDate = new Paragraph("PRINTED ON: " + DateTime.Now.ToString("MM/dd/yyyy"),
                    FontFactory.GetFont(FontFactory.HELVETICA, 6, iTextSharp.text.Font.NORMAL));
                PrintedDate.Alignment = Element.ALIGN_RIGHT;

                doc.Add(ClinicName);
                doc.Add(ClinicAddress);
                doc.Add(ClinicTelephoneNumber);
                doc.Add(new Paragraph("\n"));
                doc.Add(MedicalHeader);
                doc.Add(PatientName);
                doc.Add(PatientDOB);
                doc.Add(PatientGender);
                doc.Add(PatientPhoneNumberAndEmail);
                doc.Add(PatientOccupation);
                doc.Add(new Paragraph("\n"));
                doc.Add(InCaseOfEmergency);
                doc.Add(ParentName);
                doc.Add(Relationship);
                doc.Add(HomeAndCellPhone);
                doc.Add(WorkPhone);
                doc.Add(HomeAddress);
                doc.Add(new Paragraph("\n"));
                doc.Add(MedicalHistory);
                doc.Add(MedicalHistoryDisclaimer);
                doc.Add(Question1);
                doc.Add(Question2);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(FinalDisclaimer);
                doc.Add(new Paragraph("\n"));
                doc.Add(ParentSignature);
                doc.Add(new Paragraph("\n"));
                doc.Add(DentistSignature);
                doc.Add(new Paragraph("\n"));
                doc.Add(PrintedDate);



                doc.Close();

                MetroMessageBox.Show(this, "Your PDF has been saved in" + "\n" + saveFileDialog.FileName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception exception)
            {
                MetroMessageBox.Show(this, exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }

        private void btnGotoPayment_Click(object sender, EventArgs e)
        {
            PaymentModule paymentModule = new PaymentModule();
            paymentModule.txtboxPatientIDNumber.Text = lbl_IDnum.Text;
            paymentModule.Show();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {

            string saveFileLocation = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = lbl_IDnum.Text + "-" + "Receipt" + "-" +txtboxLastName.Text;
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

                Paragraph OfficialHeader = new Paragraph("OFFICIAL RECEIPT", FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                OfficialHeader.Alignment = Element.ALIGN_LEFT;

                // BREAK DOWN FEE

                Paragraph ServiceType = new Paragraph("Service:......................... " + lblServiceType.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                ServiceType.Alignment = Element.ALIGN_LEFT;

                Paragraph ServiceFee = new Paragraph("Service fee:................... " + lblServiceFee.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                ServiceFee.Alignment = Element.ALIGN_LEFT;

                Paragraph MiscFee = new Paragraph("Additional fees:.............. " + lblAdditionalFees.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                MiscFee.Alignment = Element.ALIGN_LEFT;

                Paragraph Discount = new Paragraph("Discount:....................... " + lblDiscount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                Discount.Alignment = Element.ALIGN_LEFT;

                Paragraph VAT = new Paragraph("VAT............................... " + lblVAT.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                VAT.Alignment = Element.ALIGN_LEFT;

                Paragraph TotalAmount = new Paragraph("Total Amount:............. " + lblTotalAmount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
                TotalAmount.Alignment = Element.ALIGN_LEFT;

                Paragraph SeniorID = new Paragraph("Senior Citizen TIN: ", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                SeniorID.Alignment = Element.ALIGN_LEFT;

                Paragraph PWDID = new Paragraph("OSCA/PWD ID: ", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                PWDID.Alignment = Element.ALIGN_LEFT;

                Paragraph TINNUMBER = new Paragraph("TIN #: " + "221-463-613-000" + " | " + "BIR: " + "3AU0001004336", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                TINNUMBER.Alignment = Element.ALIGN_LEFT;

                Paragraph DATEISSUED = new Paragraph("Date Issued: " + "April 3, 2013" + " | " + "Expiration: " + "June 30, 2018", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                DATEISSUED.Alignment = Element.ALIGN_LEFT;

                Paragraph PRINTDATE = new Paragraph("Receipt Print Date: " + DateTime.Now.ToString("MM/dd/yyyy"), FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                PRINTDATE.Alignment = Element.ALIGN_LEFT;

                Paragraph DOCSIGN = new Paragraph("SIGNED BY (Cashier/Authorized Representative)", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                DOCSIGN.Alignment = Element.ALIGN_LEFT;

                Paragraph DISCLAIMER = new Paragraph("THIS DOCUMENT IS NOT VALID FOR CLAIMING INPUT TAXES" + "\n" + "THIS OFFICIAL RECEIPT SHALL BE VALID FOR FIVE(5) YEARS FROM THE DATE OF PRINTING", FontFactory.GetFont(FontFactory.HELVETICA, 5, iTextSharp.text.Font.NORMAL));
                DISCLAIMER.Alignment = Element.ALIGN_CENTER;

                Paragraph CUTHERE = new Paragraph("-------------------------------------------------------------------------------CUT HERE--------------------------------------------------------------------", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                CUTHERE.Alignment = Element.ALIGN_LEFT;

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
                doc.Add(CUTHERE);

                doc.Close();

                MetroMessageBox.Show(this, "Your PDF has been saved in" + "\n" + saveFileDialog.FileName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exception)
            {
                MetroMessageBox.Show(this, exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
