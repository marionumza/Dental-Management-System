﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MySql;
using MySql.Data.Entity;

namespace Dental_Management_System
{
    public partial class LoginForm : Form
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
        LoadingDashDialogBox dashboardLoading = new LoadingDashDialogBox();
        MainDashboard dashboard = new MainDashboard();

        public void serverConnection()
        {
            String server = "Server=localhost;Database=sampleTest1;UID=root;PWD=root";
        }

        public LoginForm()
        {
            InitializeComponent();

            worker.DoWork += (sender, args) => PerformReading();
            worker.RunWorkerCompleted += (sender, args) => ReadingCompleted();
            EnableDoubleBuffering(this, true);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtBoxPass.Text = "Password";
            txtBoxPass.UseSystemPasswordChar = false;

            appVersion.Text = String.Format("Version: {0}", AssemblyVersion);

        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        // Puts the current thread to sleep for 5 seconds
        void PerformReading()
        {
            Thread.Sleep(3000);
        }

        // After the thread is finished reading, it proceeds to test connection and then closes.
        void ReadingCompleted()
        {
            dashboardLoading.Close();
            dashboard.Show();
        }

        public static void EnableDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            controlProperty.SetValue(control, value, null);
        }

        public void LoginCheck()
        {
            try
            {

                if (txtBoxUser.Text == "dev" || txtBoxPass.Text == "dev")
                {
                    //MessageBox.Show("Login Successful", "Log in");
                    worker.RunWorkerAsync();
                    this.Hide();
                    dashboardLoading.ShowDialog();

                }
                else if (txtBoxUser.Text != "" || txtBoxPass.Text != "")
                {

                    MessageBox.Show("Incorrect password", "Log in");
                    txtBoxPass.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Login credentials");
                txtBoxPass.Clear();
                txtBoxUser.Text = "Username";
                txtBoxPass.Text = "Password";
                txtBoxPass.UseSystemPasswordChar = false;
            }
        }


        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            LoginCheck();

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Login_ConfigureSQL cfgg = new Login_ConfigureSQL();
            cfgg.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBoxPass_Click(object sender, EventArgs e)
        {
            txtBoxPass.Clear();
            txtBoxPass.UseSystemPasswordChar = true;
        }

        private void txtBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            txtBoxPass.UseSystemPasswordChar = true;
        }

        private void txtBoxPass_Enter(object sender, EventArgs e)
        {
            txtBoxPass.Clear();
            txtBoxPass.UseSystemPasswordChar = true;
        }

        private void txtBoxUser_Click(object sender, EventArgs e)
        {
            txtBoxUser.Clear();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void appVersion_DoubleClick(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
