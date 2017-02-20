using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Dental_Management_System
{
    public partial class Login_ConfigureSQL : Form
    {
        /// <summary>
        /// BackgroundWorker allows the secondary form "ProcessingDialogBox" to run for a specific amount of time
        /// to perform an action in the background. 
        /// 
        /// ProcessingDialogBox contains the dialog box for testing the connection to MySQL
        /// 
        /// </summary>
        /// 

        BackgroundWorker worker = new BackgroundWorker();
        ProcessingDialogBox pdb = new ProcessingDialogBox();

        public Login_ConfigureSQL()
        {
            InitializeComponent();

            worker.DoWork += (sender, args) => PerformReading();
            worker.RunWorkerCompleted += (sender, args) => ReadingCompleted();

        }

        /// <summary>
        /// Prevents the current form from being closed.
        /// </summary>

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
        }

        // After the thread is finished reading, it proceeds to test connection and then closes.
        void ReadingCompleted()
        {
            SqlTest();
            pdb.Close();
            this.Show();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default["SQL_IP"] = sql_hostaddress.Text;
            Properties.Settings.Default["SQL_Database"] = sql_datasource.Text;
            //Properties.Settings.Default["SQL_Port"] = int.Parse(sql_port.Text);
            Properties.Settings.Default["SQL_User"] = sql_user.Text;
            Properties.Settings.Default["SQL_Pass"] = sql_pass.Text;
            Properties.Settings.Default.Save();
        }

        public void SqlTest()
        {

            string sqlTestLink = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + "Database=" +
                Properties.Settings.Default["SQL_Database"] + ";" + "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
                Properties.Settings.Default["SQL_Pass"];

            using (MySqlConnection connection = new MySqlConnection(sqlTestLink))
            {

                try
                {
                    connection.Open();
                    MessageBox.Show("The connection to the MySQL server is currently active.", "Test Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    sql_compilemachineversion();
                    sql_databaseengineversion();
                    //sql_datasourcefilter();
                    connection.Close();

                }
                catch
                {
                    pdb.Close();
                    //sql_datasource.Items.Clear();
                    MessageBox.Show("Connection test failed. Please check the following: " + "\n" + "- The MySQL service is running"
                        + "\n" + "- MySQL server is installed" + "\n" + "- Application settings (e.g, IP, Port, Username, Password)", "Test connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
 
                }
            }
        }

        /// <summary>
        /// THIS STRING CONTAINS THE METHODS USED FOR THE MYSQL CONNECTION. MODIFY IF REQUIRED.
        /// CALL THIS STRING WHEN OPENING CONNECTION TO MYSQL.
        /// </summary>
        /// 

        string sqlConnector = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + "Database=" + 
            Properties.Settings.Default["SQL_Database"] + ";" + "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" + 
            Properties.Settings.Default["SQL_Pass"];

        private void sql_databaseengineversion()
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConnector))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLver = connection.CreateCommand();
                    getSQLver.CommandText = "SHOW VARIABLES LIKE 'innodb_version'";
                    MySqlDataReader verReader = getSQLver.ExecuteReader();
                    while (verReader.Read())
                    {
                        sqlver.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void sql_compilemachineversion()
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConnector))
            {
                try
                {
                    connection.Open();
                    MySqlCommand getSQLdbver = connection.CreateCommand();
                    getSQLdbver.CommandText = "SHOW VARIABLES LIKE 'version_compile_machine'";
                    MySqlDataReader verReader = getSQLdbver.ExecuteReader();
                    while (verReader.Read())
                    {
                        sqlcompile.Text = verReader.GetString(1);
                    }

                    connection.Close();
                }
                catch
                {

                }
            }
        }

        private void sql_datasourcefilter()
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConnector))
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
                        sql_datasource.Items.Add(row);
                    }

                    connection.Close();

                }
                catch
                {
                    MessageBox.Show("Either one or more setting is incorrect, MySQL is not installed, or the MySQL service is not running.", "Configure MySQL Connection");
                }

            }
        }


        private void Login_ConfigureSQL_Load(object sender, EventArgs e)
        {

            sql_hostaddress.Text = Properties.Settings.Default["SQL_IP"].ToString();
            sql_datasource.Text = Properties.Settings.Default["SQL_Database"].ToString();
            sql_port.Text = Properties.Settings.Default["SQL_Port"].ToString();
            sql_user.Text = Properties.Settings.Default["SQL_User"].ToString();
            sql_pass.Text = Properties.Settings.Default["SQL_Pass"].ToString();


        }

        private void button_save_Click(object sender, EventArgs e)
        {

            SaveSettings();
            MessageBox.Show("MySQL settings changed. The program will now close for" + "\n" + 
                "changes to take effect.", "Apply changes");
            Application.Exit();

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
            pdb.ShowDialog();

        }

        private void ConfigureSQL_IP_KeyPress(object sender, KeyPressEventArgs e)
        {
            button_save.Enabled = true;
            button_apply.Enabled = true;
        }

        private void ConfigureSQL_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            button_save.Enabled = true;
            button_apply.Enabled = true;

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                MessageBox.Show("You can only enter numbers here", "Numbers only");
                e.Handled = true;
            }

        }

        private void ConfigureSQL_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            button_save.Enabled = true;
            button_apply.Enabled = true;
        }
        private void ConfigureSQL_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            button_save.Enabled = true;
            button_apply.Enabled = true;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {

            button_cancel.Enabled = false;
            SaveSettings();
        }

        private void ConfigureSQL_SelectDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ConfigureSQL_SelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_save.Enabled = true;
            button_apply.Enabled = true;

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
            sql_datasource.Refresh();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
