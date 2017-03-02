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
    public partial class Patient_View : Form
    {
        public Patient_View()
        {

            InitializeComponent();
        }


        // CALL CLASS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

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

                        string Q1YesNo;
                        string Q2YesNo;
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
            this.StartPosition = FormStartPosition.CenterScreen;
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
                }
            }
            catch (Exception eh)
            {
                
                MessageBox.Show(eh.Message);
            }

        }
    }
}
