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
    public partial class Login_ConfigureSQL : Form
    {
        public Login_ConfigureSQL()
        {
            InitializeComponent();

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


        // MYSQL CONNECTOR
        string con = "Server=" + Properties.Settings.Default["ConfigureSQL_IP"] + ';' + "Database=" + Properties.Settings.Default["ConfigureSQL_SelectDatabase"] + ";" + "UID=" + Properties.Settings.Default["ConfigureSQL_User"] + ';' + "PWD=" + Properties.Settings.Default["ConfigureSQL_Pass"];
        //MySqlConnection connection;

        private void Login_ConfigureSQL_Load(object sender, EventArgs e)
        {
            ///// System-wide settings related to MySQL database

            ConfigureSQL_SelectDatabase.Text = Properties.Settings.Default["ConfigureSQL_SelectDatabase"].ToString();
            //ConfigureSQL_SelectTable.Text = Properties.Settings.Default["ConfigureSQL_SelectTable"].ToString();
            ConfigureSQL_IP.Text = Properties.Settings.Default["ConfigureSQL_IP"].ToString();
            ConfigureSQL_Port.Text = Properties.Settings.Default["ConfigureSQL_Port"].ToString();
            ConfigureSQL_User.Text = Properties.Settings.Default["ConfigureSQL_User"].ToString();
            ConfigureSQL_Pass.Text = Properties.Settings.Default["ConfigureSQL_Pass"].ToString();

           

            string loadServer = "Server=" + Properties.Settings.Default["ConfigureSQL_IP"] + ';' + "UID=" + Properties.Settings.Default["ConfigureSQL_User"] + ';' + "PWD=" + Properties.Settings.Default["ConfigureSQL_Pass"];

            using (MySqlConnection connection = new MySqlConnection(loadServer))
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

            using (MySqlConnection connection = new MySqlConnection(loadServer))
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



            using (MySqlConnection connection = new MySqlConnection(loadServer))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SHOW DATABASES LIKE '%lms_%'";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var row = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            row += reader.GetValue(i);
                        ConfigureSQL_SelectDatabase.Items.Add(row);
                    }

                    connection.Close();

                }
                catch
                {
                    MessageBox.Show("Either one or more setting is incorrect, MySQL is not installed, or the MySQL service is not running.", "Configure MySQL Connection");
                }

            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["ConfigureSQL_SelectDatabase"] = ConfigureSQL_SelectDatabase.Text;
            //Properties.Settings.Default["ConfigureSQL_SelectTable"] = ConfigureSQL_SelectTable.Text;
            Properties.Settings.Default["ConfigureSQL_IP"] = ConfigureSQL_IP.Text;
            Properties.Settings.Default["ConfigureSQL_Port"] = int.Parse(ConfigureSQL_Port.Text);
            Properties.Settings.Default["ConfigureSQL_User"] = ConfigureSQL_User.Text;
            Properties.Settings.Default["ConfigureSQL_Pass"] = ConfigureSQL_Pass.Text;
            Properties.Settings.Default.Save();

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

            string chkserver = "Server=" + Properties.Settings.Default["ConfigureSQL_IP"] + ';' + "UID=" + Properties.Settings.Default["ConfigureSQL_User"] + ';' + "PWD=" + Properties.Settings.Default["ConfigureSQL_Pass"];

            using (MySqlConnection connection = new MySqlConnection(chkserver))
            {

                try
                {
                    ConfigureSQL_SelectDatabase.Items.Clear();
                    connection.Open();
                    MessageBox.Show("The MySQL server is currently running.", "Test Successful");

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SHOW DATABASES LIKE '%lms_%'";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var row = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            row += reader.GetValue(i);
                        ConfigureSQL_SelectDatabase.Items.Add(row);
                    }


                }
                catch
                {
                    ConfigureSQL_SelectDatabase.Items.Clear();
                    MessageBox.Show("Either your settings are incorrect, MySQL is not installed, or the " + "\n" + "MySQL service is not running. Please try again" + "\n"
                        + "\n" + "Error code: 01", "Test connection failed");
                }
                finally
                {
                    connection.Close();
                }
            }


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
            Properties.Settings.Default["ConfigureSQL_SelectDatabase"] = ConfigureSQL_SelectDatabase.Text;
            //Properties.Settings.Default["ConfigureSQL_SelectTable"] = ConfigureSQL_SelectTable.Text;
            Properties.Settings.Default["ConfigureSQL_IP"] = ConfigureSQL_IP.Text;
            Properties.Settings.Default["ConfigureSQL_Port"] = int.Parse(ConfigureSQL_Port.Text);
            Properties.Settings.Default["ConfigureSQL_User"] = ConfigureSQL_User.Text;
            Properties.Settings.Default["ConfigureSQL_Pass"] = ConfigureSQL_Pass.Text;
            Properties.Settings.Default.Save();
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
                ConfigureSQL_Pass.UseSystemPasswordChar = false;
            }
            else if (checkbox_showpass.Checked == false)
            {
                ConfigureSQL_Pass.UseSystemPasswordChar = true;
            }
        }

        private void ConfigureSQL_SelectTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigureSQL_SelectDatabase.Refresh();
        }

        private void button_gendb_Click(object sender, EventArgs e)
        {
            //GenerateDB gdb = new GenerateDB();
            //gdb.ShowDialog();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
