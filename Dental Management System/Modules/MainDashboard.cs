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

        // CALL CLASS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

        LoadingDashDialogBox loadingDialogBox = new LoadingDashDialogBox();
        DataTable patientData = new DataTable();
        DataTable pullPatientData = new DataTable();


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


        int pageSize = 999;
        int CurrentPageIndex = 1;
        int TotalPage = 0;


        void DisableModules()
        {
            dataGridView1.Visible = false;
            lblDatabaseError.Visible = true;
            lblsadface.Visible = true;
            btnNewPatient.Enabled = false;
            btnPayment.Enabled = false;
            txtboxSearch.Enabled = false;
        }

        public void PerformLoad()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand countCommand = connection.CreateCommand();
                    countCommand.CommandText = "SELECT COUNT(*) FROM Patient_Information WHERE Birthday";
                    long count = (long)countCommand.ExecuteScalar();
                    btnViewAppointments.Text = "View Appointments (" + count.ToString() + ")";


                    using (MySqlDataAdapter data = new MySqlDataAdapter(databaseGetData.getDataFromDatabase, databaseConnectionLink.networkLink))
                    {
                        data.Fill(patientData);

                        connection.Close();

                        Thread.Sleep(3000);

                    }
                }
            }
            catch(MySqlException exception)
            {

            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var PID = dataGridView1.SelectedCells[0].Value.ToString();
            Patient_View patientView = new Patient_View();

            if(dataGridView1.SelectedCells[0].Value.ToString() == String.Empty)
            {
                return;
            }
            else
            {
                patientView.lbl_IDnum.Text = PID;
                patientView.Show();
            }

        }


        void LoadDB(object sender, DoWorkEventArgs e)
        {
            PerformLoad();
        }

        void LoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            loadingDialogBox.Dispose();

            try
            {

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 7;              
                dataGridView1.DataSource = patientData;

                if (patientData.Rows.Count == 0)
                {
                 
                    //DisableModules();
                    //return;
                }

                else
                {
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
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            BackgroundWorker initalizeDatabase = new BackgroundWorker();
            initalizeDatabase.DoWork += new DoWorkEventHandler(LoadDB);
            initalizeDatabase.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadCompleted);
            initalizeDatabase.RunWorkerAsync();
            loadingDialogBox.ShowDialog();


            // PerformLoad();

            //Properties.Settings.Default["CalendarTest"].Value();
            System.DateTime holidayDate1 = new DateTime();
            ResizeRedraw = true;
            appVersion.Text = String.Format("v.{0}", AssemblyVersion);
            appTitle.Text= String.Format(AssemblyTitle);

            // ENABLE DOUBLE BUFFERING                     
            EnableDoubleBuffering(BannerPanel, true);
            EnableDoubleBuffering(NavigationMenu, true);
            EnableDoubleBuffering(this, true);
            EnableDoubleBuffering(panel4, true);


            // INITIALIZE SETTINGS
            label2.Text = Properties.Settings.Default["DoctorName"].ToString();
            label3.Text = Properties.Settings.Default["DoctorName"].ToString();
            label4.Text = Properties.Settings.Default["DocAddress"].ToString();
            label6.Text = Properties.Settings.Default["DocNumber"].ToString();
            label12.Text = Properties.Settings.Default["DocOfficeName"].ToString();

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

            if (LogoutMessage == DialogResult.OK)
            {
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
            appSettings.ShowDialog();
        }

        private void button_payment_Click_1(object sender, EventArgs e)
        {
            PaymentModu paymentModule = new PaymentModu();
            paymentModule.ShowDialog();
        }

        private void button_signout_Click(object sender, EventArgs e)
        {
            SignOutUser();
        }

        private void button_newpatient_Click(object sender, EventArgs e)
        {
            Patient_Registation patientRegistration = new Patient_Registation();
            patientRegistration.ShowDialog();

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

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
