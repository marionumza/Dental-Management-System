using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Policy;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Dental_Management_System
{
    public partial class serverSettings : Form
    {
                         
        BackgroundWorker worker = new BackgroundWorker();
        ProcessingDialogBox processingDialogBox = new ProcessingDialogBox();

        // Calling all class and methods to be used in other methods.
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();


        public serverSettings()
        {

            InitializeComponent();
            worker.DoWork += (sender, args) => PerformReading();
            worker.RunWorkerCompleted += (sender, args) => ReadingCompleted();

        }

        private const int NO_CLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cprams = base.CreateParams;
                cprams.ClassStyle = cprams.ClassStyle | NO_CLOSE_BUTTON ;
                return cprams ;
            }
        } 

        // Puts the current thread to sleep for 5 seconds
        void PerformReading()
        {
            Thread.Sleep(5000);     
            NetworkTest();
        }

        // After the thread is finished reading, it proceeds to test connection and then closes.

        void ReadingCompleted()
        {
            processingDialogBox.Close();
            this.Show();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default["SQL_IP"] = sql_hostaddress.Text;
            Properties.Settings.Default["SQL_Port"] = sql_port.Text;
            Properties.Settings.Default["SQL_User"] = sql_user.Text;
            Properties.Settings.Default["SQL_Pass"] = sql_pass.Text;
            Properties.Settings.Default.UseWAN = chkEnableExternalNetwork.Checked;
            Properties.Settings.Default.Save();

            if (cbDatabaseSelection.Text == String.Empty)
            {
                return;
            }
            else if (cbDatabaseSelection.Text == cbDatabaseSelection.Text)
            {

                Properties.Settings.Default["SQL_Database"] = cbDatabaseSelection.Text;
                Properties.Settings.Default.Save();

                mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                "Database '" + cbDatabaseSelection.Text + "' now in use.");
            }

            txtboxCurrentDB.Text = cbDatabaseSelection.Text;
        }

        private void NetworkTest()
        {

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkTestLink))
            {

                try
                {
                    connection.Open();
                    MessageBox.Show("The connection to the MySQL server is currently active.", "Test Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    Getsqlcompilemachineversion();
                    Getsqldatabaseengineversion();
                    connection.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("Connection test failed. Please check the following: " + "\n" + "- The MySQL service is running"
                        + "\n" + "- MySQL server is installed" + "\n" + "- Application settings (e.g, Host address, Port, Username, Password)" + "\n" + "- Windows Firewall" + "\n" +
                        "\n" + "EXCEPTION TYPE" + "\n" + e.Message, 
                        "Test connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Getsqldatabaseengineversion()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLver = connection.CreateCommand();
                    getSQLver.CommandText = "SHOW VARIABLES LIKE 'version'";
                    MySqlDataReader verReader = getSQLver.ExecuteReader();
                    while (verReader.Read())
                    {
                        lblMysqlversion.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void Getsqlcompilemachineversion()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLdbver = connection.CreateCommand();
                    getSQLdbver.CommandText = "SHOW VARIABLES LIKE 'version_compile_machine'";
                    MySqlDataReader verReader = getSQLdbver.ExecuteReader();
                    while (verReader.Read())
                    {
                        lblCompileMachine.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void Getdatabaseengineversion()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLdbver = connection.CreateCommand();
                    getSQLdbver.CommandText = "SHOW VARIABLES LIKE 'innodb_version'";
                    MySqlDataReader verReader = getSQLdbver.ExecuteReader();
                    while (verReader.Read())
                    {
                        lblDatabaseEngineVersion.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void GetOStype()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLdbver = connection.CreateCommand();
                    getSQLdbver.CommandText = "SHOW VARIABLES LIKE 'version_compile_os'";
                    MySqlDataReader verReader = getSQLdbver.ExecuteReader();
                    while (verReader.Read())
                    {
                        lblOperatingSystemType.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void Getsqldatasourcefilter()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    //command.CommandText = "SHOW DATABASES LIKE '%lms_%'";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var row = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            row += reader.GetValue(i);
                        cbDatabaseSelection.Items.Add(row);
                    }

                    connection.Close();

                }
                catch
                {
                    MessageBox.Show("Either one or more setting is incorrect, MySQL is not installed, or the MySQL service is not running.", "Configure MySQL Connection");
                }

            }
        }

        private void serverSettings_Load(object sender, EventArgs e)
        {

            sql_hostaddress.Text = Properties.Settings.Default["SQL_IP"].ToString();
            txtboxCurrentDB.Text = Properties.Settings.Default["SQL_Database"].ToString();
            sql_port.Text = Properties.Settings.Default["SQL_Port"].ToString();
            sql_user.Text = Properties.Settings.Default["SQL_User"].ToString();
            sql_pass.Text = Properties.Settings.Default["SQL_Pass"].ToString();

            chkEnableExternalNetwork.Checked = Properties.Settings.Default.UseWAN;

        }

        /// <summary>
        /// Summons "About" information such as MySQL version and compile machine.
        /// </summary>
        /// 

        private void LoadAbout()
        {
            Getsqlcompilemachineversion();
            Getsqldatabaseengineversion();
            Getdatabaseengineversion();
            GetOStype();    
        }

        /// <summary>
        /// Loads and refreshes database list for combobox.
        /// </summary>
        /// 

        private void LoadDatabaseList()
        {

            string connectionString = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + 
                "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
                Properties.Settings.Default["SQL_Pass"];

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SHOW DATABASES";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var row = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            row += reader.GetValue(i);
                        cbDatabaseSelection.Items.Add(row);
                    }

                    connection.Close();

                }
                catch (MySqlException exception)
                {
                    mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                    exception.Message);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {

            DialogResult ConfirmSaveChanges = MessageBox.Show("You must restart this application for changes to take effect." + "\n" +
                "Would you like to restart?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (ConfirmSaveChanges == DialogResult.Yes)
            {
                SaveSettings();
                Application.Exit();
                //Application.Restart();
               // Application.ExitThread();
            }
            else if (ConfirmSaveChanges == DialogResult.No)
            {
                return;
            }

        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you wish to change the MySQL Username and Password, you can do so by using the MySQL Command Prompt." + "\n" + 
                "\n" + "See documentation for more details.", "Help");
        }


        private void button_testconnection_Click(object sender, EventArgs e)
        {
            this.Hide();
            worker.RunWorkerAsync();
            processingDialogBox.ShowDialog();

        }

        private void ConfigureSQL_IP_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;
        }

        private void ConfigureSQL_Port_KeyPress(object sender, KeyPressEventArgs keyEvent)
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;

            if (!char.IsControl(keyEvent.KeyChar)
                && !char.IsDigit(keyEvent.KeyChar)
                && keyEvent.KeyChar != '.')
            {
                MessageBox.Show("You can only enter numbers here", "Numbers only");
                keyEvent.Handled = true;
            }

        }

        private void ConfigureSQL_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;
        }
        private void ConfigureSQL_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            SaveSettings();
        }

        private void ConfigureSQL_SelectDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ConfigureSQL_SelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;

        }

        private void checkbox_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpass.Checked == true)
            {
                sql_pass.UseSystemPasswordChar = false;
            }
            else if (checkbox_showpass.Checked == false)
            {
                sql_pass.UseSystemPasswordChar = true;
            }
        }

        private void ConfigureSQL_SelectTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbDatabaseSelection.Refresh();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CreateDatabase_button_Click(object sender, EventArgs e)
        {

            if (txtboxDatabasename.Text == String.Empty)
            {
                MessageBox.Show("Field cannot be left blank.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmCreationofDB = MessageBox.Show("You are about to create the database, " +
                txtboxDatabasename.Text + "\n" + "\n" + "Would you to create it now?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (confirmCreationofDB == DialogResult.Yes)
            {

                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLinkCreateDatabase))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandTimeout = 200;

                        //CREATE DATABASE
                        command.CommandText = "CREATE DATABASE " + txtboxDatabasename.Text;
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Creating database.... " + txtboxDatabasename.Text);
                        command.ExecuteNonQuery();

                        //USE DATABASE
                        command.CommandText = "USE " + txtboxDatabasename.Text;
                        command.ExecuteNonQuery();

                        //CREATE TABLES
                        command.CommandText = "CREATE TABLE Patient_Information(PID BIGINT NOT NULL PRIMARY KEY, FirstName VARCHAR(255), MiddleName VARCHAR(255), LastName VARCHAR(255), Birthday DATE, Gender VARCHAR(32), PhoneNumber VARCHAR(16), Email VARCHAR(255), Occupation VARCHAR(255), ParentName VARCHAR(255), Relationship VARCHAR(64), HomePhone VARCHAR(16), CellPhone VARCHAR(16), WorkPhone VARCHAR(16), WorkExtPhone VARCHAR(16), Address VARCHAR(255)) ENGINE=InnoDB;";
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Preparing table 'Patient_Information'.... ");
                        command.ExecuteNonQuery();
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Done!");

                        command.CommandText = "CREATE TABLE Patient_MedHistory(med_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, PID BIGINT NOT NULL, Q1 VARCHAR(255), Q2 VARCHAR(255), ChartType VARCHAR(16),  Note1 TEXT,  Note2 TEXT,  Note3 TEXT,  Note4 TEXT,  Note5 TEXT,  Note6 TEXT,  Note7 TEXT,  Note8 TEXT,  Note9 TEXT,  Note10 TEXT,  Note11 TEXT,  Note12 TEXT,  Note13 TEXT,  Note14 TEXT,  Note15 TEXT,  Note16 TEXT,  Note17 TEXT,  Note18 TEXT,  Note19 TEXT,  Note20 TEXT,  Note21 TEXT,  Note22 TEXT,  Note23 TEXT,  Note24 TEXT,  Note25 TEXT,  Note26 TEXT,  Note27 TEXT,  Note28 TEXT,  Note29 TEXT,  Note30 TEXT,  Note31 TEXT,  Note32 TEXT, FOREIGN KEY fk_pid(PID) REFERENCES Patient_Information(PID) ON UPDATE CASCADE ON DELETE RESTRICT) ENGINE=InnoDB";
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Preparing table 'Patient_MedHistory'.... ");
                        command.ExecuteNonQuery();
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Done!");

                        command.CommandText = "CREATE TABLE Patient_Schedule(ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, Time VARCHAR(64), Date DATE, Service VARCHAR(24), LastName VARCHAR(255), FirstName VARCHAR(255), Notes VARCHAR(255))";
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Preparing table 'Patient_Schedule'.... ");
                        command.ExecuteNonQuery();
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Done!");

                        command.CommandText = "CREATE TABLE Dental_Services(ServiceName VARCHAR(64), Fee VARCHAR(32))";
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Preparing table 'Dental_Services'.... ");
                        command.ExecuteNonQuery();
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Done!");

                        connection.Close();

                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Database name '" + txtboxDatabasename.Text + "' has been successfully created.");

                        Properties.Settings.Default["SQL_Database"] = txtboxDatabasename.Text;
                        txtboxCurrentDB.Text = txtboxDatabasename.Text;
                        Properties.Settings.Default.Save();

                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        "Database '" + txtboxDatabasename.Text + "' now in use.");

                        txtboxDatabasename.Clear();

                    }
                    catch (MySqlException exception)
                    {
                        mysqlserverlog_textbox.AppendText(Environment.NewLine + "> " + DateTime.Now.ToString("hh:mm:ss : ") +
                        exception.Message);
                    }
                }

            }
            else if (confirmCreationofDB == DialogResult.No)
            {

            }
        }

        private void EnableExternalNetwork_cb_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (chkEnableExternalNetwork.Checked == true)
            {
                sql_port.Enabled = true;
            }
            else if (chkEnableExternalNetwork.Checked == false)
            {
                sql_port.Enabled = false;
            }
        }

        int LoadFromDatabaseOnce = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 2 && LoadFromDatabaseOnce == 0)
            {
                LoadAbout();
                LoadFromDatabaseOnce++;

            }
            else if (tabControl1.SelectedIndex == 2 && LoadFromDatabaseOnce == 1)
            {
                return;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                LoadDatabaseList();
            }

        }

        private void txtboxDatabasename_TextChanged(object sender, EventArgs e)
        {
            int characterCount = txtboxDatabasename.Text.Length;
            lblCharacterLength.Text = "Characters: " + characterCount + "/32";

        }

        private void cbDatabaseSelection_Click(object sender, EventArgs e)
        {
            cbDatabaseSelection.Items.Clear();
            LoadDatabaseList();
        }

        private void mysqlserverlog_textbox_TextChanged(object sender, EventArgs e)
        {
            mysqlserverlog_textbox.ScrollToCaret();
        }
    }
}
