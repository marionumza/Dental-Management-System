namespace Dental_Management_System
{
    partial class serverSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.sql_hostaddress = new System.Windows.Forms.TextBox();
            this.sql_port = new System.Windows.Forms.TextBox();
            this.sql_user = new System.Windows.Forms.TextBox();
            this.sql_pass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtboxCurrentDB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDatabaseSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkbox_showpass = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnableExternalNetwork = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCharacterLength = new System.Windows.Forms.Label();
            this.txtboxDatabasename = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mysqlserverlog_textbox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblOperatingSystemType = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDatabaseEngineVersion = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mysqlwebsitelink = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMysqlversion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCompileMachine = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Host Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port number";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(407, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 27);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button_save_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.Transparent;
            this.btnTestConnection.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestConnection.ForeColor = System.Drawing.Color.Black;
            this.btnTestConnection.Location = new System.Drawing.Point(452, 31);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(136, 25);
            this.btnTestConnection.TabIndex = 12;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.button_testconnection_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.Enabled = false;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnApply.Location = new System.Drawing.Point(567, 13);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 27);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // sql_hostaddress
            // 
            this.sql_hostaddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql_hostaddress.Location = new System.Drawing.Point(106, 31);
            this.sql_hostaddress.Name = "sql_hostaddress";
            this.sql_hostaddress.Size = new System.Drawing.Size(212, 23);
            this.sql_hostaddress.TabIndex = 1;
            this.sql_hostaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_IP_KeyPress);
            // 
            // sql_port
            // 
            this.sql_port.Enabled = false;
            this.sql_port.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql_port.Location = new System.Drawing.Point(106, 61);
            this.sql_port.Name = "sql_port";
            this.sql_port.Size = new System.Drawing.Size(75, 23);
            this.sql_port.TabIndex = 5;
            this.sql_port.Text = "3306";
            this.sql_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Port_KeyPress);
            // 
            // sql_user
            // 
            this.sql_user.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql_user.Location = new System.Drawing.Point(103, 35);
            this.sql_user.Name = "sql_user";
            this.sql_user.Size = new System.Drawing.Size(212, 23);
            this.sql_user.TabIndex = 6;
            this.sql_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_User_KeyPress);
            // 
            // sql_pass
            // 
            this.sql_pass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql_pass.Location = new System.Drawing.Point(103, 68);
            this.sql_pass.Name = "sql_pass";
            this.sql_pass.Size = new System.Drawing.Size(212, 23);
            this.sql_pass.TabIndex = 9;
            this.sql_pass.UseSystemPasswordChar = true;
            this.sql_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Pass_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(481, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtboxCurrentDB);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbDatabaseSelection);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 107);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Source";
            // 
            // txtboxCurrentDB
            // 
            this.txtboxCurrentDB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxCurrentDB.Location = new System.Drawing.Point(137, 31);
            this.txtboxCurrentDB.MaxLength = 32;
            this.txtboxCurrentDB.Name = "txtboxCurrentDB";
            this.txtboxCurrentDB.ReadOnly = true;
            this.txtboxCurrentDB.Size = new System.Drawing.Size(129, 23);
            this.txtboxCurrentDB.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Current Database:";
            // 
            // cbDatabaseSelection
            // 
            this.cbDatabaseSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseSelection.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.cbDatabaseSelection.FormattingEnabled = true;
            this.cbDatabaseSelection.Location = new System.Drawing.Point(137, 68);
            this.cbDatabaseSelection.Name = "cbDatabaseSelection";
            this.cbDatabaseSelection.Size = new System.Drawing.Size(129, 25);
            this.cbDatabaseSelection.TabIndex = 2;
            this.cbDatabaseSelection.SelectedIndexChanged += new System.EventHandler(this.ConfigureSQL_SelectDatabase_SelectedIndexChanged);
            this.cbDatabaseSelection.Click += new System.EventHandler(this.cbDatabaseSelection_Click);
            this.cbDatabaseSelection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_SelectDatabase_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Database:";
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDatabase.Location = new System.Drawing.Point(137, 117);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(129, 40);
            this.btnCreateDatabase.TabIndex = 14;
            this.btnCreateDatabase.Text = "Create database";
            this.btnCreateDatabase.UseVisualStyleBackColor = false;
            this.btnCreateDatabase.Click += new System.EventHandler(this.CreateDatabase_button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 324);
            this.panel2.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 318);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(639, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.checkbox_showpass);
            this.groupBox4.Controls.Add(this.sql_user);
            this.groupBox4.Controls.Add(this.sql_pass);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(8, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(625, 113);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MySQL Server User Credientials";
            // 
            // checkbox_showpass
            // 
            this.checkbox_showpass.AutoSize = true;
            this.checkbox_showpass.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.checkbox_showpass.Location = new System.Drawing.Point(321, 70);
            this.checkbox_showpass.Name = "checkbox_showpass";
            this.checkbox_showpass.Size = new System.Drawing.Size(112, 21);
            this.checkbox_showpass.TabIndex = 12;
            this.checkbox_showpass.Text = "Show Password";
            this.checkbox_showpass.UseVisualStyleBackColor = true;
            this.checkbox_showpass.CheckedChanged += new System.EventHandler(this.checkbox_showpass_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableExternalNetwork);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sql_hostaddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sql_port);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 101);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // chkEnableExternalNetwork
            // 
            this.chkEnableExternalNetwork.AutoSize = true;
            this.chkEnableExternalNetwork.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.chkEnableExternalNetwork.Location = new System.Drawing.Point(187, 62);
            this.chkEnableExternalNetwork.Name = "chkEnableExternalNetwork";
            this.chkEnableExternalNetwork.Size = new System.Drawing.Size(187, 21);
            this.chkEnableExternalNetwork.TabIndex = 13;
            this.chkEnableExternalNetwork.Text = "Connect to External Network";
            this.chkEnableExternalNetwork.UseVisualStyleBackColor = true;
            this.chkEnableExternalNetwork.CheckedChanged += new System.EventHandler(this.EnableExternalNetwork_cb_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.mysqlserverlog_textbox);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCharacterLength);
            this.groupBox3.Controls.Add(this.txtboxDatabasename);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnCreateDatabase);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 163);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New Database";
            // 
            // lblCharacterLength
            // 
            this.lblCharacterLength.AutoSize = true;
            this.lblCharacterLength.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterLength.Location = new System.Drawing.Point(17, 130);
            this.lblCharacterLength.Name = "lblCharacterLength";
            this.lblCharacterLength.Size = new System.Drawing.Size(93, 15);
            this.lblCharacterLength.TabIndex = 18;
            this.lblCharacterLength.Text = "Characters: 0/32";
            // 
            // txtboxDatabasename
            // 
            this.txtboxDatabasename.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxDatabasename.Location = new System.Drawing.Point(20, 85);
            this.txtboxDatabasename.MaxLength = 32;
            this.txtboxDatabasename.Name = "txtboxDatabasename";
            this.txtboxDatabasename.Size = new System.Drawing.Size(246, 23);
            this.txtboxDatabasename.TabIndex = 17;
            this.txtboxDatabasename.TextChanged += new System.EventHandler(this.txtboxDatabasename_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 45);
            this.label9.TabIndex = 3;
            this.label9.Text = "Create a new database here. Enter a name and \r\nclick \"Create database\". Max. of 3" +
    "2 characters \r\nwith no spaces or special characters.";
            // 
            // mysqlserverlog_textbox
            // 
            this.mysqlserverlog_textbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mysqlserverlog_textbox.Location = new System.Drawing.Point(295, 15);
            this.mysqlserverlog_textbox.MaxLength = 1024;
            this.mysqlserverlog_textbox.Name = "mysqlserverlog_textbox";
            this.mysqlserverlog_textbox.ReadOnly = true;
            this.mysqlserverlog_textbox.Size = new System.Drawing.Size(338, 267);
            this.mysqlserverlog_textbox.TabIndex = 16;
            this.mysqlserverlog_textbox.Text = "-- MySQL Server Log --";
            this.mysqlserverlog_textbox.TextChanged += new System.EventHandler(this.mysqlserverlog_textbox_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblOperatingSystemType);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.lblDatabaseEngineVersion);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.mysqlwebsitelink);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.lblMysqlversion);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.lblCompileMachine);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(639, 288);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblOperatingSystemType
            // 
            this.lblOperatingSystemType.AutoSize = true;
            this.lblOperatingSystemType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOperatingSystemType.ForeColor = System.Drawing.Color.Black;
            this.lblOperatingSystemType.Location = new System.Drawing.Point(440, 84);
            this.lblOperatingSystemType.Name = "lblOperatingSystemType";
            this.lblOperatingSystemType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblOperatingSystemType.Size = new System.Drawing.Size(68, 15);
            this.lblOperatingSystemType.TabIndex = 27;
            this.lblOperatingSystemType.Text = "Unavailable";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(440, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Server Operating System:";
            // 
            // lblDatabaseEngineVersion
            // 
            this.lblDatabaseEngineVersion.AutoSize = true;
            this.lblDatabaseEngineVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDatabaseEngineVersion.ForeColor = System.Drawing.Color.Black;
            this.lblDatabaseEngineVersion.Location = new System.Drawing.Point(440, 40);
            this.lblDatabaseEngineVersion.Name = "lblDatabaseEngineVersion";
            this.lblDatabaseEngineVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatabaseEngineVersion.Size = new System.Drawing.Size(68, 15);
            this.lblDatabaseEngineVersion.TabIndex = 25;
            this.lblDatabaseEngineVersion.Text = "Unavailable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(440, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Database Engine version:";
            // 
            // mysqlwebsitelink
            // 
            this.mysqlwebsitelink.AutoSize = true;
            this.mysqlwebsitelink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mysqlwebsitelink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.mysqlwebsitelink.LinkColor = System.Drawing.SystemColors.Highlight;
            this.mysqlwebsitelink.LinkVisited = true;
            this.mysqlwebsitelink.Location = new System.Drawing.Point(284, 185);
            this.mysqlwebsitelink.Name = "mysqlwebsitelink";
            this.mysqlwebsitelink.Size = new System.Drawing.Size(90, 15);
            this.mysqlwebsitelink.TabIndex = 24;
            this.mysqlwebsitelink.TabStop = true;
            this.mysqlwebsitelink.Text = "Official Website";
            this.mysqlwebsitelink.VisitedLinkColor = System.Drawing.Color.DimGray;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(284, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 45);
            this.label6.TabIndex = 23;
            this.label6.Text = "This software is powered by MySQL, an open source database \r\ndeveloped by Oracle " +
    "Corporation. License can be viewed at their\r\nofficial website.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dental_Management_System.Properties.Resources.mysql_logo;
            this.pictureBox1.Location = new System.Drawing.Point(17, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(284, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "System architecture";
            // 
            // lblMysqlversion
            // 
            this.lblMysqlversion.AutoSize = true;
            this.lblMysqlversion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMysqlversion.ForeColor = System.Drawing.Color.Black;
            this.lblMysqlversion.Location = new System.Drawing.Point(284, 40);
            this.lblMysqlversion.Name = "lblMysqlversion";
            this.lblMysqlversion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMysqlversion.Size = new System.Drawing.Size(68, 15);
            this.lblMysqlversion.TabIndex = 18;
            this.lblMysqlversion.Text = "Unavailable";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(284, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Server version:";
            // 
            // lblCompileMachine
            // 
            this.lblCompileMachine.AutoSize = true;
            this.lblCompileMachine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompileMachine.ForeColor = System.Drawing.Color.Black;
            this.lblCompileMachine.Location = new System.Drawing.Point(284, 84);
            this.lblCompileMachine.Name = "lblCompileMachine";
            this.lblCompileMachine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompileMachine.Size = new System.Drawing.Size(68, 15);
            this.lblCompileMachine.TabIndex = 20;
            this.lblCompileMachine.Text = "Unavailable";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnApply);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(653, 52);
            this.panel3.TabIndex = 23;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // serverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 376);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 374);
            this.Name = "serverSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MySQL Server Configuration Console";
            this.Load += new System.EventHandler(this.serverSettings_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.TextBox sql_hostaddress;
        public System.Windows.Forms.TextBox sql_port;
        public System.Windows.Forms.TextBox sql_user;
        public System.Windows.Forms.TextBox sql_pass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateDatabase;
        public System.Windows.Forms.ComboBox cbDatabaseSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMysqlversion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCompileMachine;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel mysqlwebsitelink;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox mysqlserverlog_textbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtboxDatabasename;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkbox_showpass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtboxCurrentDB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkEnableExternalNetwork;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCharacterLength;
        private System.Windows.Forms.Label lblOperatingSystemType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDatabaseEngineVersion;
        private System.Windows.Forms.Label label12;
    }
}