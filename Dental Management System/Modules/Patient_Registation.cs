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
    public partial class Patient_Registation : Form
    {

        private readonly MainDashboard fm1;
        public Patient_Registation(MainDashboard dashboard)
        {
            InitializeComponent();

            fm1 = dashboard;
        }



        private void Patient_Registation_Load(object sender, EventArgs e)
        {
            this.cbBirthday.Value = DateTime.Now;
            IDGenerator();

            firstname_readonly.Text = "- - -";
            middlename_readonly.Text = "- - -";
            lastname_readonly.Text = "- - -";



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

        /// <summary>
        /// Allows the MessageBox to display only once after selecting SelectedIndex 2 (Tooth Chart)
        /// </summary>
        /// 
        int RunMessageBoxOnce = 0;

        private void Patient_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (Patient_TabControl.SelectedIndex == 2 && RunMessageBoxOnce == 0)
            {
                MessageBox.Show("Note: This field can be left blank for new patients with no previous medical history", this.Text
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                RunMessageBoxOnce++;

            }
            else if (Patient_TabControl.SelectedIndex == 2 && RunMessageBoxOnce == 1)
            {
                return;
            } */
        }

        void IDGenerator()
        {
            Random GenerateID = new Random();
            lbl_IDnum.Text = GenerateID.Next(10000, 99999).ToString();
        }

        void ResetAll()
        {

            firstname_readonly.Text = "- - -";
            middlename_readonly.Text = "- - -";
            lastname_readonly.Text = "- - -";
            IDGenerator();

            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = String.Empty;
                }
            }

            foreach (Control control2 in groupBox2.Controls)
            {
                if (control2 is TextBox)
                {
                    control2.Text = String.Empty;
                }
            }
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
            ResetAll();
        }

        private void Addpatient_button_Click(object sender, EventArgs e)
        {

            string connectionString = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + "Database=" +
            Properties.Settings.Default["SQL_Database"] + ";" + "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
            Properties.Settings.Default["SQL_Pass"];

            string fieldate = cbBirthday.Value.ToString("yyyy-MM-dd");
            string question1 = null;
            string question2 = null;
            string charttype = null;

            if (metroRadioButtonQ1YES.Checked == true)
            {
                question1 = metroRadioButtonQ1YES.Text;
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

            if (primaryTeeth_rb.Checked == true)
            {
                charttype = primaryTeeth_rb.Text;
            }
            else if (Permament_rb.Checked == true)
            {
                charttype = Permament_rb.Text;
            }


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();                 
                    command.Connection = connection;

                    // HIGHER TIMEOUT ENSURES THAT THERE IS MORE TIME TO EXECUTE THE QUERY, ESPECIALLY IF THERE ARE MANY TO PROCESS
                    command.CommandTimeout = 22000;

                    if (txtboxFirstName.Text == String.Empty || txtboxLastName.Text == String.Empty)
                    {
                        MessageBox.Show("Patient name can't be left blank.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        command.CommandText = "INSERT INTO Patient_Information (PID, FirstName, MiddleName, LastName, Birthday, Gender, PhoneNumber, Email, Occupation, ParentName, Relationship, HomePhone, CellPhone, WorkPhone, WorkExtPhone, Address) VALUES (@PID, @FirstName, @MiddleName, @LastName, @Birthday, @Gender, @PhoneNumber, @Email, @Occupation, @ParentName, @Relationship,  @HomePhone, @CellPhone, @WorkPhone, @WorkExtPhone, @Address)";
                        command.Parameters.AddWithValue("@PID", lbl_IDnum.Text);
                        command.Parameters.AddWithValue("@FirstName", String.Format("{0}", txtboxFirstName.Text));
                        command.Parameters.AddWithValue("@MiddleName", String.Format("{0}", txtboxMiddleName.Text));
                        command.Parameters.AddWithValue("@LastName", String.Format("{0}", txtboxLastName.Text));
                        command.Parameters.AddWithValue("@Birthday", String.Format("{0}", fieldate));
                        command.Parameters.AddWithValue("@Gender", String.Format("{0}", cbMaritalStatus.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", String.Format("{0}", txtboxPhoneNum.Text));
                        command.Parameters.AddWithValue("@Email", String.Format("{0}", txtboxEmail.Text));
                        command.Parameters.AddWithValue("@Occupation", String.Format("{0}", txtboxOccupation.Text));
                        command.Parameters.AddWithValue("@ParentName", String.Format("{0}", txtboxParentName.Text));
                        command.Parameters.AddWithValue("@Relationship", String.Format("{0}", txtboxRelationship.Text));
                        command.Parameters.AddWithValue("@HomePhone", String.Format("{0}", txtboxHomePhone.Text));
                        command.Parameters.AddWithValue("@Cellphone", String.Format("{0}", txtboxCellphoneNum.Text));
                        command.Parameters.AddWithValue("@Workphone", String.Format("{0}", txtboxWorkPhone.Text));
                        command.Parameters.AddWithValue("@WorkExtPhone", String.Format("{0}", txtboxExtensionNum.Text));
                        command.Parameters.AddWithValue("@Address", String.Format("{0}", txtboxAddress.Text));
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        command.CommandText = "INSERT INTO Patient_MedHistory (PID, Q1, Q2, ChartType, Note1, Note2, Note3, Note4, Note5, Note6, Note7, Note8, Note9, Note10, Note11, Note12, Note13, Note14, Note15, Note16, Note17, Note18, Note19, Note20, Note21, Note22, Note23, Note24, Note25, Note26, Note27, Note28, Note29, Note30, Note31, Note32) VALUES (@PID, @Q1, @Q2, @ChartType, @Note1, @Note2, @Note3, @Note4, @Note5, @Note6, @Note7, @Note8, @Note9, @Note10, @Note11, @Note12, @Note13, @Note14, @Note15, @Note16, @Note17, @Note18, @Note19, @Note20, @Note21, @Note22, @Note23, @Note24, @Note25, @Note26, @Note27, @Note28, @Note29, @Note30, @Note31, @Note32)";
                        command.Parameters.AddWithValue("@PID", lbl_IDnum.Text);
                        command.Parameters.AddWithValue("@Q1", String.Format("{0}", question1));
                        command.Parameters.AddWithValue("@Q2", String.Format("{0}", question2));
                        command.Parameters.AddWithValue("@ChartType", String.Format("{0}", charttype));
                        command.Parameters.AddWithValue("@Note1", String.Format("{0}", toothNote_1.Text));
                        command.Parameters.AddWithValue("@Note2", String.Format("{0}", toothNote_2.Text));
                        command.Parameters.AddWithValue("@Note3", String.Format("{0}", toothNote_3.Text));
                        command.Parameters.AddWithValue("@Note4", String.Format("{0}", toothNote_4.Text));
                        command.Parameters.AddWithValue("@Note5", String.Format("{0}", toothNote_5.Text));
                        command.Parameters.AddWithValue("@Note6", String.Format("{0}", toothNote_6.Text));
                        command.Parameters.AddWithValue("@Note7", String.Format("{0}", toothNote_7.Text));
                        command.Parameters.AddWithValue("@Note8", String.Format("{0}", toothNote_8.Text));
                        command.Parameters.AddWithValue("@Note9", String.Format("{0}", toothNote_9.Text));
                        command.Parameters.AddWithValue("@Note10", String.Format("{0}", toothNote_10.Text));
                        command.Parameters.AddWithValue("@Note11", String.Format("{0}", toothNote_11.Text));
                        command.Parameters.AddWithValue("@Note12", String.Format("{0}", toothNote_12.Text));
                        command.Parameters.AddWithValue("@Note13", String.Format("{0}", toothNote_13.Text));
                        command.Parameters.AddWithValue("@Note14", String.Format("{0}", toothNote_14.Text));
                        command.Parameters.AddWithValue("@Note15", String.Format("{0}", toothNote_15.Text));
                        command.Parameters.AddWithValue("@Note16", String.Format("{0}", toothNote_16.Text));
                        command.Parameters.AddWithValue("@Note17", String.Format("{0}", toothNote_17.Text));
                        command.Parameters.AddWithValue("@Note18", String.Format("{0}", toothNote_18.Text));
                        command.Parameters.AddWithValue("@Note19", String.Format("{0}", toothNote_19.Text));
                        command.Parameters.AddWithValue("@Note20", String.Format("{0}", toothNote_20.Text));
                        command.Parameters.AddWithValue("@Note21", String.Format("{0}", toothNote_21.Text));
                        command.Parameters.AddWithValue("@Note22", String.Format("{0}", toothNote_22.Text));
                        command.Parameters.AddWithValue("@Note23", String.Format("{0}", toothNote_23.Text));
                        command.Parameters.AddWithValue("@Note24", String.Format("{0}", toothNote_24.Text));
                        command.Parameters.AddWithValue("@Note25", String.Format("{0}", toothNote_25.Text));
                        command.Parameters.AddWithValue("@Note26", String.Format("{0}", toothNote_26.Text));
                        command.Parameters.AddWithValue("@Note27", String.Format("{0}", toothNote_27.Text));
                        command.Parameters.AddWithValue("@Note28", String.Format("{0}", toothNote_28.Text));
                        command.Parameters.AddWithValue("@Note29", String.Format("{0}", toothNote_29.Text));
                        command.Parameters.AddWithValue("@Note30", String.Format("{0}", toothNote_30.Text));
                        command.Parameters.AddWithValue("@Note31", String.Format("{0}", toothNote_31.Text));
                        command.Parameters.AddWithValue("@Note32", String.Format("{0}", toothNote_32.Text));
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        command.CommandText = "INSERT INTO Patient_Payment(PID) VALUES (@PID)";
                        command.Parameters.AddWithValue("@PID", lbl_IDnum.Text);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        MessageBox.Show("New patient has been added" + "\n" + "\n" +
                            "Name: " + firstname_readonly.Text + " " + lastname_readonly.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        ResetAll();

                        

                    }
                  
                    
                }
                catch (MySqlException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }



        }

        private void Permament_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (Permament_rb.Checked == true)
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
            if (primaryTeeth_rb.Checked == true)
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

        private void btnOpenToothChartExternalWindow_Click(object sender, EventArgs e)
        {
            ToothChartExternalWindow toothChartExternalWindow = new ToothChartExternalWindow();

            if (primaryTeeth_rb.Checked == true)
            {
                toothChartExternalWindow.pictureBox1.Image = Properties.Resources.PrimaryTeethChart;
                toothChartExternalWindow.Show();
                toothChartExternalWindow.Text = "Tooth Chart - Primary Teeth";
            }
            else if (Permament_rb.Checked == true)
            {
                toothChartExternalWindow.pictureBox1.Image = Properties.Resources.PermanentToothChart;
                toothChartExternalWindow.Show();
                toothChartExternalWindow.Text = "Tooth Chart - Permanent Teeth";
            }
        }

        private void Patient_Registation_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
