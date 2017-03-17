using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Animation;
using System.Threading;
using MySql;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using Transitions;

/// <summary>
/// DENTAL MANAGEMENT SYSTEM FOR SOFTWARE ENGINEERING
/// PROGRAMMED BY: DUSTIN
/// 
/// GITHUB: https://github.com/ddasutein
/// NOTE: DO NOT USE THIS IN A BUSINESS ENVIRONMENT. THIS IS ONLY A TECH DEMO OR A SMALL-TIME COLLEGE PROJECT.
/// I WILL BE THE ONE DECIDING WHETHER OR NOT THIS SOFTWARE CAN BE USED IN COMMERCIAL ENVIRONMENTS. FOR NOW, YOU MAY
/// CONTRIBUTE TO THIS AND MAKE CHANGES IF YOU WANT.
/// 
/// 
/// 
/// </summary>

namespace Dental_Management_System
{
    public partial class MainDashboard : MetroForm
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        // CALL ALL CLASS AND METHODS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

        // BACKGROUNDWORKERS
        LoadingDashDialogBox loadingDialogBox = new LoadingDashDialogBox();
        RefreshDialogBox refreshDialogBox = new RefreshDialogBox();
        BackgroundWorker retrievePatientDataInformation = new BackgroundWorker();
        BackgroundWorker retrieveScheduleInformation = new BackgroundWorker();

        // DATA TABLES
        public DataTable patientData = new DataTable();
        DataTable pullPatientData = new DataTable();
        DataTable pullPatientSchedule = new DataTable();

        bool IsConnectionActive;
        string getTotalAppointmentCount;

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private void LoadHomePageLogo()
        {
            if ((bool)Properties.Settings.Default["UseDefaultLogo"] == true)
            {
                pictureBox3.Image = Properties.Resources.placeholderimage1;
            }
            else if ((bool)Properties.Settings.Default["UseDefaultLogo"] == false)
            {
                pictureBox3.ImageLocation = Properties.Settings.Default["LogoFileLocation"].ToString();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // START ALL BACKGROUND THREADS
            retrievePatientDataInformation.DoWork += new DoWorkEventHandler(StartLoadingDatabase);
            retrievePatientDataInformation.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingDatabase);
            retrievePatientDataInformation.RunWorkerAsync();
            retrieveScheduleInformation.DoWork += new DoWorkEventHandler(StartLoadingScheduleInformation);
            retrieveScheduleInformation.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingScheduleInformation);
            retrieveScheduleInformation.RunWorkerAsync();
            loadingDialogBox.ShowDialog();


            ResizeRedraw = true;
            appTitle.Text = String.Format(AssemblyTitle);
            LoadHomePageLogo();

            // ENABLE DOUBLE BUFFERING                     
            EnableDoubleBuffering(BannerPanel, true);
            EnableDoubleBuffering(NavigationMenu, true);
            EnableDoubleBuffering(this, true);
            EnableDoubleBuffering(panel4, true);

            // INITIALIZE SETTINGS
            label4.Text = Properties.Settings.Default["DocAddress"].ToString();
            label6.Text = Properties.Settings.Default["DocNumber"].ToString();
            label12.Text = Properties.Settings.Default["DocOfficeName"].ToString();

            // LOAD HIERACHY STATUS
            AccountRestrictions();
        }

        // HIERACHY BOOLEAN VALUES
        public bool UserAccountTypeRegular = false;
        public bool UserAccountTypeDoctor = false;
        public bool UserAccountTypeAdmin = false;

        public void AccountRestrictions()
        {
            if (UserAccountTypeRegular == true)
            {
                // RESTRICT OPTIONS HERE
                
            }

            if (UserAccountTypeDoctor == true)
            {
            }

            if (UserAccountTypeAdmin == true)
            {
            }
        }

        void DisableModules()
        {
            // VIEW RECORD TAB

            dataGridView1.Visible = false;
            lblDatabaseError2.Visible = true;
            lblDatabaseError.Visible = true;
            lblsadface.Visible = true;
            btnNewPatient.Enabled = false;
            btnPayment.Enabled = false;
            panelSearch.Visible = false;

            // APPOINTMENT TAB

            dataGridView2.Visible = false;
            btnDeleteSchedule.Enabled = false;
            btnSendEmail.Enabled = false;
        }

        void EmptyDataGridMessage()
        {
            dataGridView1.Visible = false;
            //lblsadface.Visible = true;
            lblDatabaseError.Text = "No data found. Add a new patient to get started.";
            lblDatabaseError.Visible = true;
        }

        public void PerformLoadOfScheduleData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand countCommand = connection.CreateCommand();
                    countCommand.CommandText = "SELECT COUNT(*) FROM Patient_Schedule WHERE ID";
                    long count = (long)countCommand.ExecuteScalar();
                    getTotalAppointmentCount = "Current Appointments (" + count.ToString() + ")"; 

                    if (connection.State == ConnectionState.Open)
                        IsConnectionActive = true;
                    else if (connection.State == ConnectionState.Broken)
                        IsConnectionActive = false;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(databaseGetData.getScheduleDataFromDatabase, databaseConnectionLink.networkLink))
                    {
                        adapter.Fill(pullPatientSchedule);
                        connection.Close();
                        Thread.Sleep(2000);
                    }
                }
            }
            catch
            {

            }
        }

        public void PerformLoadOfPatientData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {

                    connection.Open();

                    using (MySqlDataAdapter data = new MySqlDataAdapter(databaseGetData.getDataFromDatabase, databaseConnectionLink.networkLink))
                    {
                        data.Fill(patientData);
                        connection.Close();
                        Thread.Sleep(2000);                       
                       
                    }
                }
            }
            catch(MySqlException exception)
            {

            }
            
        }

        public void StartLoadingUserAccountProfile(object sender, DoWorkEventArgs c)
        {

        }

        void StartLoadingScheduleInformation(object sender, DoWorkEventArgs a)
        {
            PerformLoadOfScheduleData();
        }

        void StopLoadingScheduleInformation(object sender, RunWorkerCompletedEventArgs a)
        {


            if (refreshDialogBox.Visible == true)
            {
                refreshDialogBox.Close();
            }

            try
            {

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.MultiSelect = false;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.ReadOnly = true;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ColumnCount = 5;
                dataGridView2.DataSource = pullPatientSchedule;

                dataGridView2.Columns[0].HeaderText = "#";
                dataGridView2.Columns[0].DataPropertyName = "ID";
                dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[0].Frozen = true;
                dataGridView2.Columns[1].HeaderText = "Time";
                dataGridView2.Columns[1].DataPropertyName = "Time";
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].HeaderText = "Date";
                dataGridView2.Columns[2].DataPropertyName = "Date";
                dataGridView2.Columns[2].Width = 90;
                dataGridView2.Columns[3].HeaderText = "Last Name";
                dataGridView2.Columns[3].DataPropertyName = "LastName";
                dataGridView2.Columns[4].HeaderText = "First Name";
                dataGridView2.Columns[4].DataPropertyName = "FirstName";
                dataGridView2.Columns[4].Width = 150;
            }
            catch
            {

            }
        }


        void StartLoadingDatabase(object sender, DoWorkEventArgs e)
        {
            PerformLoadOfPatientData();
        }

        void StopLoadingDatabase(object sender, RunWorkerCompletedEventArgs e)
        {

            loadingDialogBox.Dispose();

            if (refreshDialogBox.Visible == true)
            {
                refreshDialogBox.Close();
            }

            btnViewAppointments.Text = getTotalAppointmentCount;

            dataGridView1.Rows.Clear();


            if (patientData.Rows.Count == 0)
            {

                if (IsConnectionActive == true)
                {
                    EmptyDataGridMessage();

                }
                else if (IsConnectionActive == false)
                {
                    DisableModules();
                    return;
                }

            }

            else
            {
                try
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.ColumnCount = 7;
                    dataGridView1.DataSource = patientData;

                    // dataGridView2.Sort(dataGridView2.Columns[2], ListSortDirection.Ascending);

                    dataGridView1.Columns[0].HeaderText = "PID";
                    dataGridView1.Columns[0].DataPropertyName = "PID";
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[0].Frozen = true;
                    dataGridView1.Columns[1].HeaderText = "First Name";
                    dataGridView1.Columns[1].DataPropertyName = "FirstName";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].Frozen = true;
                    dataGridView1.Columns[2].HeaderText = "Last Name";
                    dataGridView1.Columns[2].DataPropertyName = "LastName";
                    dataGridView1.Columns[3].HeaderText = "Birthday";
                    dataGridView1.Columns[3].DataPropertyName = "Birthday";
                    dataGridView1.Columns[4].HeaderText = "Gender";
                    dataGridView1.Columns[4].DataPropertyName = "Gender";
                    dataGridView1.Columns[5].HeaderText = "Phone Number";
                    dataGridView1.Columns[5].DataPropertyName = "PhoneNumber";
                    dataGridView1.Columns[6].HeaderText = "Email";
                    dataGridView1.Columns[6].DataPropertyName = "Email";
                    dataGridView1.Columns[6].Width = 380;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var PID = dataGridView1.SelectedCells[0].Value.ToString();
            Patient_View patientView = new Patient_View();

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {

                if (dataGridView1.SelectedCells[0].Value.ToString() == String.Empty)
                {
                    return;
                }

                connection.Open();
                MySqlCommand validatePatientID = connection.CreateCommand();
                validatePatientID.CommandText = "SELECT * FROM Patient_Information WHERE PID=" + dataGridView1.SelectedCells[0].Value.ToString();
                MySqlDataReader validation = validatePatientID.ExecuteReader();
                if (validation.HasRows)
                {

                }
                else
                {
                    return;
                }
                connection.Close();
            }

            if (dataGridView1.SelectedCells[0].Value.ToString() == String.Empty)
            {
                return;
            }
            else
            {
                patientView.lbl_IDnum.Text = PID;

                if (UserAccountTypeRegular == true)
                {
                    patientView.UserAccountTypeRegular = true;
                }
                patientView.Show();
            }

        }


        /// <summary>
        /// 
        /// Allows the WinForms to run smoothly without any flickering. To add a Double Buffer to a component, go to 
        /// public void Dashboard_Load and add your compoents that you wish to double buffer. Recommended ONLY for 
        /// images in panels or using the ImageBox component.
        /// 
        /// For example, if you want to enable Double Buffering for a panel
        /// 
        /// EnableDoubleBuffering(YourPanelNameGoesHere, true);
        /// 
        /// 
        /// </summary>
        /// 

        public static void EnableDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            controlProperty.SetValue(control, value, null);
        }

        public void SignOutUser()
        {
            DialogResult LogoutMessage = MetroMessageBox.Show(this, "You are about to Log out. Any unsaved progress will be lost. Press OK to continue.", 
                this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Closes all open forms upon user sign out.

            List<Form> openForms = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                openForms.Add(form);
            }

            if (LogoutMessage == DialogResult.OK)
            {


                foreach (Form form in openForms)
                {

                    if (form.Name == "Patient_Registation")
                        form.Dispose();

                    if (form.Name == "AppSettings")
                        form.Dispose();

                    if (form.Name == "Patient_View")
                        form.Dispose();

                    if (form.Name == "ComposeMail")
                        form.Dispose();

                    if (form.Name == "ToothChartExternalWindow")
                        form.Dispose();

                }

                this.Dispose();
                Login loginForm = new Login();
                loginForm.Show();

            }
            else if (LogoutMessage == DialogResult.Cancel)
            {
                return;
            }

        }

        private void MainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void button_about_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();

            if (UserAccountTypeRegular == true)
                appSettings.UserAccountTypeRegular = true;

            if (UserAccountTypeDoctor == true)
                appSettings.UserAccountTypeDoctor = true;

            appSettings.ShowDialog();
        }

        private void button_payment_Click_1(object sender, EventArgs e)
        {
            PaymentModule paymentModule = new PaymentModule();
            paymentModule.Show();
        }

        private void button_signout_Click(object sender, EventArgs e)
        {
            SignOutUser();
        }

        private void button_newpatient_Click(object sender, EventArgs e)
        {
            Patient_Registation patientRegistration = new Patient_Registation(this);
            patientRegistration.Show();

        }

        private void Scheduleappoint_button_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Save();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            ComposeMail composeMail = new ComposeMail();
            composeMail.Show();
        }

        private void btnSetAppointment_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteSchedule.Enabled = true;

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {

                if (dataGridView2.SelectedCells[0].Value.ToString() == String.Empty)
                {
                    return;
                }
                else
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT patient_schedule.Time, patient_schedule.Date, patient_schedule.Service, patient_schedule.LastName, patient_schedule.FirstName, patient_schedule.Notes FROM Patient_Schedule WHERE ID=" + dataGridView2.SelectedCells[0].Value.ToString();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        lblAppointmentPatientDataTime.Text = (reader["Time"].ToString());
                        lblAppointmentPatientDataDate.Text = (reader["Date"].ToString());
                        lblAppointmentPatientDataService.Text = (reader["Service"].ToString());
                        lblAppointmentPatientDataLastName.Text = (reader["LastName"].ToString());
                        lblAppointmentPatientDataFirstName.Text = (reader["FirstName"].ToString());
                        txtBoxAppointPatientDataNotes.Text = (reader["Notes"].ToString());
                    }

                    connection.Close();
                
                }
            }
        }

        private void metroButtonDeleteSchedule_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {

                if (dataGridView2.SelectedCells[0].Value.ToString() == String.Empty)
                {
                    return;
                }
                else
                {

                    DialogResult confirmDeletionOfAppointment = MetroMessageBox.Show(this, "Are you sure you want to delete this scheduled appointment?" + "\n" + "\n" +
                        "Name: " + lblAppointmentPatientDataFirstName.Text + " " + lblAppointmentPatientDataLastName.Text + "\n" +
                        "Date and Time: " + lblAppointmentPatientDataDate.Text + " " + lblAppointmentPatientDataTime.Text + "\n" +
                        "Service: " + lblAppointmentPatientDataService.Text, "Appointments", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (confirmDeletionOfAppointment == DialogResult.Yes)
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand();
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Patient_Schedule WHERE ID=" + dataGridView2.SelectedCells[0].Value.ToString();
                        command.ExecuteReader();
                        connection.Close();

                        if (dataGridView2.SelectedCells[0].Selected)
                        {
                            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                        }

                    }
                    else if (confirmDeletionOfAppointment == DialogResult.No)
                    {
                        return;
                    }

                }
            }
        }

        private void btnRefreshDataGrid1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            patientData.Clear();

            BackgroundWorker initalizeDatabase = new BackgroundWorker();
            initalizeDatabase.DoWork += new DoWorkEventHandler(StartLoadingDatabase);
            initalizeDatabase.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingDatabase);
            initalizeDatabase.RunWorkerAsync();
            refreshDialogBox.ShowDialog();

            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                lblDatabaseError.Visible = false;
            }
            else if (dataGridView1.Visible == true)
            {
                return;
            }
        }

        private void btnRefreshAppointmentsList_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            pullPatientSchedule.Clear();
            BackgroundWorker retrieveScheduleInformation = new BackgroundWorker();
            retrieveScheduleInformation.DoWork += new DoWorkEventHandler(StartLoadingScheduleInformation);
            retrieveScheduleInformation.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingScheduleInformation);
            retrieveScheduleInformation.RunWorkerAsync();
            refreshDialogBox.ShowDialog();

        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab("tabPage3");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
