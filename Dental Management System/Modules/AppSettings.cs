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
using System.Security.Cryptography;

namespace Dental_Management_System
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
            int IDNumber;
        }

        // CALL CLASS
        DatabaseConnectionLink databaseConnectionLink = new DatabaseConnectionLink();
        DatabaseGetData databaseGetData = new DatabaseGetData();

        // DATA TABLES
        DataTable DentalClinicServices = new DataTable();
        DataTable ClinicServices = new DataTable();
        DataTable UserAccounts = new DataTable();

        BackgroundWorker retrieveDentalClinicServicesData = new BackgroundWorker();
        BackgroundWorker retrieveDentalUserAccountData = new BackgroundWorker();
        RefreshDialogBox refreshDialogBox = new RefreshDialogBox();

        public const bool ValidateAccountType = false;

        private void AppSettings_Load(object sender, EventArgs e)
        {

            // LOAD SETTINGS FOR "GENERAL" TAB
            textBox1.Text = Properties.Settings.Default["DocAddress"].ToString();
            DocNumber_txtbox.Text = Properties.Settings.Default["DocNumber"].ToString();
            textBox4.Text = Properties.Settings.Default["DocOfficeName"].ToString();
            DisableGroupBox();
            metroButtonToggleHideConfigureButtonCheckState();

            // LOAD SERVICES AND FEES
            txtboxVATPercent.Text = Properties.PaymentSettings.Default["VATTax"].ToString();
            retrieveDentalClinicServicesData.DoWork += new DoWorkEventHandler(StartLoadingOfDentalServices);
            retrieveDentalClinicServicesData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingOfDentalServices);
            retrieveDentalClinicServicesData.RunWorkerAsync();
            retrieveDentalUserAccountData.DoWork += new DoWorkEventHandler(StartLoadingUserAccountList);
            retrieveDentalUserAccountData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingUserAccountList);
            retrieveDentalUserAccountData.RunWorkerAsync();


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
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = false;
            }

            if (UserAccountTypeDoctor == true)
            {
            }

            if (UserAccountTypeAdmin == true)
            {
            }
        }

        MainDashboard dashboard = (MainDashboard)Application.OpenForms["MainDashboard"];
        bool EnableBannerYesNo = (bool)Properties.Settings.Default["ShowBannerYesNo"];

        string connectionString = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' +
        "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
        Properties.Settings.Default["SQL_Pass"];

        int RunMessageBoxOnce = 0;
        int LoadDatabaseListOnce = 0;

        public void DisableGroupBox()
        {
            if (ValidateAccountType == true)
            {
                groupBox5.Enabled = false;
            }
        }

        private void metroButtonToggleHideConfigureButtonCheckState()
        {
            if ((bool)Properties.Settings.Default["HideConfigureButtonAtLogin"] == true)
            {
                metroToggleHideConfigureButtonAtLogin.Checked = true;
            }
            else if ((bool)Properties.Settings.Default["HideConfigureButtonAtLogin"] == false)
            {
                metroToggleHideConfigureButtonAtLogin.Checked = false;
            }
        }


        public void SaveSettings()
        {

            DialogResult ConfirmSaveChanges = MessageBox.Show("You must restart this application for changes to take effect." + "\n" +
                "Would you like to restart?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (ConfirmSaveChanges == DialogResult.Yes)
            {
                Properties.Settings.Default["DoctorName"] = txtboxUsername.Text;
                Properties.Settings.Default["DocAddress"] = textBox1.Text;
                Properties.Settings.Default["DocNumber"] = DocNumber_txtbox.Text;
                Properties.Settings.Default["DocOfficeName"] = textBox4.Text;
                Properties.PaymentSettings.Default["VATTax"] = Convert.ToInt32(txtboxVATPercent.Text);

                if (metroToggleHideConfigureButtonAtLogin.Checked == true)
                {
                    Properties.Settings.Default["HideConfigureButtonAtLogin"] = true;
                }
                else
                {
                    Properties.Settings.Default["HideConfigureButtonAtLogin"] = false;
                }

                Properties.Settings.Default.Save();
                Properties.PaymentSettings.Default.Save();
                Application.Exit();
            }
            else if (ConfirmSaveChanges == DialogResult.No)
            {
                return;
            }
        }



        public String CreateSalt(int size)
        {
            var RNG = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var BUFFER = new Byte[size];
            RNG.GetBytes(BUFFER);
            return Convert.ToBase64String(BUFFER);
        }

        public String GenerateSHA256Hash(String input, String Salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + Salt);
            System.Security.Cryptography.SHA256Managed sha256hash =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hash.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private void button_applysettings_Click(object sender, EventArgs e)
        {

            SaveSettings();

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocNumber_txtbox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 4 && RunMessageBoxOnce == 0)
            {
                if (UserAccountTypeRegular == true)
                {
                    return;
                }
                else if (UserAccountTypeRegular == false)
                {
                    MessageBox.Show("WARNING: Only use the database file generated by this program. Any use of other database file may not function correctly.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    RunMessageBoxOnce++;
                }

            }
            else if (tabControl1.SelectedIndex == 4 && RunMessageBoxOnce == 1)
            {
                return;
            }

            if (tabControl1.SelectedIndex == 3 && LoadDatabaseListOnce == 0)
            {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
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
                            cbDatabaseList.Items.Add(row);
                        }

                        connection.Close();
                        LoadDatabaseListOnce++;

                    }
                    catch (MySqlException exception)
                    {

                    }
                }
            }
            else if (tabControl1.SelectedIndex == 3 && LoadDatabaseListOnce == 1)
            {
                return;
            }
        }

        private void CreateUser_button_Click(object sender, EventArgs e)
        {
            if (txtboxUserPassword.Text == String.Empty)
            {
                MessageBox.Show("Password field cannot be blank", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtboxUserPassword.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", this.Text);
                txtboxUserPassword.Clear();
                txtboxUserPassword.Focus();
                return;
            }

            if (txtboxUserPassword.Text != txtboxUserPasswordConfirm.Text)
            {
                MessageBox.Show("Password does not match.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            String salt = CreateSalt(6);
            String hashedPassword = GenerateSHA256Hash(txtboxUserPassword.Text, salt);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;

                    string fullname = txtboxFirstName.Text + " " + txtboxLastName.Text;
                    command.CommandText = "INSERT INTO UserAccounts(Name, Username, DoctorName, AccountType, Password) VALUES (@Name, @Username, @DoctorName, @AccountType, @Password)";
                    command.Parameters.AddWithValue("@Name", String.Format("{0}", fullname));
                    command.Parameters.AddWithValue("@Username", String.Format("{0}", txtboxUsername.Text));
                    command.Parameters.AddWithValue("@DoctorName", String.Format("{0}", txtboxDoctorName.Text));
                    command.Parameters.AddWithValue("@AccountType", String.Format("{0}", cboxAccountType.Text));

                    // YES I KNOW THIS IS NOT THE BEST PRACTICE TO STORE PASSWORDS IN PLAIN TEXT. 
                    command.Parameters.AddWithValue("@Password", String.Format("{0}", txtboxUserPasswordConfirm.Text));
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
            catch
            {

            }


            //MessageBox.Show(salt + hashedPassword);
        }

        private void ShowUserPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowUserPassword.Checked == true)
            {
                txtboxUserPassword.UseSystemPasswordChar = false;
            }
            else if (ShowUserPassword.Checked == false)
            {
                txtboxUserPassword.UseSystemPasswordChar = true;
            }

        }

        private void userpasswordconfirm_txtbox_Enter(object sender, EventArgs e)
        {
            if (txtboxUserPassword.UseSystemPasswordChar == false)
            {
                txtboxUserPassword.UseSystemPasswordChar = true;
                ShowUserPassword.Checked = false;
            }
        }

        private void CreateNewUser_Button_Click(object sender, EventArgs e)
        {
            if (ViewUsersPanel.Visible == true)
            {
                ViewUsersPanel.Visible = false;                
                CreateNewUser_Button.Enabled = false;
                CreateUserPanel.Visible = true;
                ViewUserAccounts_Button.Enabled = true;

            }
        }

        private void ViewUserAccounts_Button_Click(object sender, EventArgs e)
        {
            if (CreateUserPanel.Visible == true)
            {
                CreateUserPanel.Visible = false;
                ViewUsersPanel.Visible = true;
                ViewUserAccounts_Button.Enabled = false;
                CreateNewUser_Button.Enabled = true;
            }
        }

        private void restoreDatabase_button_Click(object sender, EventArgs e)
        {
            DialogResult confirmDatabaseRestore = MessageBox.Show("You are about to restore the database. Would you like to continue?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmDatabaseRestore == DialogResult.Yes)
            {
                MessageBox.Show("Database restoration successful. Application must restart for changes to take effect.", 
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
            else if (confirmDatabaseRestore == DialogResult.No)
            {
                return;
            }
        }

        private void serverSettings_button_Click(object sender, EventArgs e)
        {
            serverSettings serverConfig = new serverSettings();
            serverConfig.ShowDialog();
        }


        private void accountType_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboxAccountType.SelectedIndex == 0)
            {
                txtboxDoctorName.Enabled = true;
            }

            if (cboxAccountType.SelectedIndex == 1)
            {
                txtboxDoctorName.Enabled = true;
            }

            if (cboxAccountType.SelectedIndex == 2)
            {
                txtboxDoctorName.Enabled = false;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (ValidateAccountType == true)
            {
                if (e.TabPage == tabControl1.TabPages[1])
                {
                    MessageBox.Show("You must be an adminstrator to access this function.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void btnDeleteDatabase_Click(object sender, EventArgs e)
        {

            if (cbDatabaseList.Text == String.Empty)
            {
                MessageBox.Show("Please select a database.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (cbDatabaseList.Text == Properties.Settings.Default["SQL_Database"].ToString())
            {
                MessageBox.Show("You cannot delete this database while in use.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cbDatabaseList.Text == "mysql1")
            {
                MessageBox.Show("Cannot delete this database. Choose another.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    DialogResult confirmDelete =MessageBox.Show("Are you sure you want to delete this?" + "\n" + "\n" + 
                        cbDatabaseList.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (confirmDelete == DialogResult.Yes)
                    {
                        connection.Open();
                        MySqlCommand deleteCommand = new MySqlCommand();
                        deleteCommand.Connection = connection;
                        deleteCommand.CommandText = "DROP DATABASE " + cbDatabaseList.Text;
                        deleteCommand.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Database has been deleted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (confirmDelete == DialogResult.No)
                    {
                        return;
                    }


                }
            }
        }

        void StartLoadingUserAccountList(object sender, DoWorkEventArgs f)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {

                    connection.Open();

                    using (MySqlDataAdapter data = new MySqlDataAdapter(databaseGetData.getUserAccounts, databaseConnectionLink.networkLink))
                    {
                        data.Fill(UserAccounts);
                        connection.Close();
                        Thread.Sleep(1000);
                    }
                }
            }
            catch
            {

            }
        }

        void StopLoadingUserAccountList(object sender, RunWorkerCompletedEventArgs f)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 3;
                dataGridView1.DataSource = UserAccounts;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].DataPropertyName = "ID";
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[0].Frozen = true;
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[1].DataPropertyName = "Username";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Frozen = true;
                dataGridView1.Columns[2].HeaderText = "Account Type";
                dataGridView1.Columns[2].DataPropertyName = "AccountType";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[2].Frozen = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void StartLoadingOfDentalServices(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {

                    connection.Open();

                    using (MySqlDataAdapter data = new MySqlDataAdapter(databaseGetData.getDentalClincFromDatabase, databaseConnectionLink.networkLink))
                    {
                        data.Fill(ClinicServices);
                        connection.Close();
                        Thread.Sleep(1000);
                    }
                }
            }
            catch
            {

            }
        }

        void StopLoadingOfDentalServices(object sender, RunWorkerCompletedEventArgs e)
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
                dataGridView2.ColumnCount = 2;
                dataGridView2.DataSource = ClinicServices;

                dataGridView2.Columns[0].HeaderText = "Service Name";
                dataGridView2.Columns[0].DataPropertyName = "ServiceName";
                dataGridView2.Columns[0].Width = 100;
                dataGridView2.Columns[0].Frozen = true;
                dataGridView2.Columns[1].HeaderText = "Fee";
                dataGridView2.Columns[1].DataPropertyName = "Fee";
                dataGridView2.Columns[1].Width = 175;
                dataGridView2.Columns[1].Frozen = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void btnAddNewService_Click(object sender, EventArgs e)
        {

            if (txtboxServiceName.Text == String.Empty)
            {
                MessageBox.Show("Please enter a service name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (txtboxServiceFee.Text == String.Empty)
            {
                MessageBox.Show("Enter fee amount.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Dental_Services (ServiceName, Fee) VALUES (@ServiceName, @Fee)";
                    command.Parameters.AddWithValue("@ServiceName", txtboxServiceName.Text);
                    command.Parameters.AddWithValue("@Fee", String.Format("{0}", txtboxServiceFee.Text));
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();

                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    ClinicServices.Clear();
                    BackgroundWorker retrieveDentalClinicServicesData = new BackgroundWorker();
                    retrieveDentalClinicServicesData.DoWork += new DoWorkEventHandler(StartLoadingOfDentalServices);
                    retrieveDentalClinicServicesData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StopLoadingOfDentalServices);
                    retrieveDentalClinicServicesData.RunWorkerAsync();
                    refreshDialogBox.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("This service already exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(databaseGetData.getALLDentalClinicFromDatabase, databaseConnectionLink.networkLink))
                {
                    try
                    {

                        connection.Open();
                        DentalClinicServices = ((DataTable)dataGridView2.DataSource).GetChanges();
                        if (DentalClinicServices != null)
                        {
                            MySqlCommandBuilder mcb = new MySqlCommandBuilder(adapter);
                            adapter.UpdateCommand = mcb.GetUpdateCommand();
                            adapter.Update(DentalClinicServices);
                            ((DataTable)dataGridView2.DataSource).AcceptChanges();

                            MessageBox.Show("Changes have been saved to the database.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        connection.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void metroToggleEnableEditing_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleEnableEditing.Checked == true)
            {
                dataGridView2.ReadOnly = false;
                dataGridView2.AllowUserToDeleteRows = true;
                labelEditModeStatus.Text = "ENABLED";
            }
            else if (metroToggleEnableEditing.Checked == false)
            {
                dataGridView2.ReadOnly = true;
                dataGridView2.AllowUserToDeleteRows = false;
                labelEditModeStatus.Text = "DISABLED";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == dataGridView2.Columns["Fee"].Index)
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
        }

        private void txtboxServiceFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
            {

                if (dataGridView1.SelectedCells[0].Value.ToString() == "1")
                {
                    buttonViewAccountDelete.Enabled = false;
                    comboBoxViewUserAccountType.Enabled = false;
                }

                if (dataGridView1.SelectedCells[0].Value.ToString() == String.Empty)
                {
                    return;
                }
                else
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT UserAccounts.ID, UserAccounts.Name, UserAccounts.UserName, UserAccounts.DoctorName FROM UserAccounts WHERE ID=" + dataGridView1.SelectedCells[0].Value.ToString();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        textBoxViewAccountName.Text = (reader["Name"].ToString());
                        textBoxViewAccountUsername.Text = (reader["Username"].ToString());
                        textBoxViewAccountDoctorName.Text = (reader["DoctorName"].ToString());

                    }

                    connection.Close();

                }
            }
        }

        private void buttonViewAccountSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionLink.networkLink))
                {
                    connection.Open();
                    MySqlCommand updateCommand = new MySqlCommand();
                    updateCommand.CommandTimeout = 22000;
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE UserAccounts SET Name=@Name, Username=@Username, DoctorName=@DoctorName, AccountType=@AccountType, Password=@Password WHERE ID=" + dataGridView1.SelectedCells[0].Value.ToString();
                    updateCommand.Parameters.AddWithValue("@Name", String.Format("{0}", textBoxViewAccountName.Text));
                    updateCommand.Parameters.AddWithValue("@Username", String.Format("{0}", textBoxViewAccountUsername.Text));
                    updateCommand.Parameters.AddWithValue("@DoctorName", String.Format("{0}", textBoxViewAccountDoctorName.Text));
                    updateCommand.Parameters.AddWithValue("@AccountType", String.Format("{0}", comboBoxViewUserAccountType.Text));
                    updateCommand.Parameters.AddWithValue("@Password", String.Format("{0}", textBoxViewAccountConfirmPassword.Text));    
                    updateCommand.ExecuteNonQuery();
                    updateCommand.Parameters.Clear();

                    DialogResult confirmSaveChanges = MessageBox.Show("User account has been updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
