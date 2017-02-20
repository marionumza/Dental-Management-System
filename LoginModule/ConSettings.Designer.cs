namespace Dental_Management_System
{
    partial class Login_ConfigureSQL
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_testconnection = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_showpass = new System.Windows.Forms.CheckBox();
            this.sql_hostaddress = new System.Windows.Forms.TextBox();
            this.btn_help = new System.Windows.Forms.Button();
            this.sql_port = new System.Windows.Forms.TextBox();
            this.sql_user = new System.Windows.Forms.TextBox();
            this.sql_pass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.sqlver = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sqlcompile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sql_datasource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_gendb = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label2.Location = new System.Drawing.Point(39, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label3.Location = new System.Drawing.Point(212, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port number";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.Transparent;
            this.button_save.Enabled = false;
            this.button_save.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_save.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button_save.ForeColor = System.Drawing.Color.Black;
            this.button_save.Location = new System.Drawing.Point(298, 26);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(131, 27);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Save and Restart";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_testconnection
            // 
            this.button_testconnection.BackColor = System.Drawing.Color.Transparent;
            this.button_testconnection.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_testconnection.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button_testconnection.ForeColor = System.Drawing.Color.Black;
            this.button_testconnection.Location = new System.Drawing.Point(12, 26);
            this.button_testconnection.Name = "button_testconnection";
            this.button_testconnection.Size = new System.Drawing.Size(136, 25);
            this.button_testconnection.TabIndex = 12;
            this.button_testconnection.Text = "Test connection";
            this.button_testconnection.UseVisualStyleBackColor = false;
            this.button_testconnection.Click += new System.EventHandler(this.button_testconnection_Click);
            // 
            // button_apply
            // 
            this.button_apply.BackColor = System.Drawing.Color.Transparent;
            this.button_apply.Enabled = false;
            this.button_apply.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_apply.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button_apply.Location = new System.Drawing.Point(542, 26);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(104, 27);
            this.button_apply.TabIndex = 13;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = false;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_showpass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sql_hostaddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_help);
            this.groupBox1.Controls.Add(this.sql_port);
            this.groupBox1.Controls.Add(this.sql_user);
            this.groupBox1.Controls.Add(this.sql_pass);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 243);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // checkbox_showpass
            // 
            this.checkbox_showpass.AutoSize = true;
            this.checkbox_showpass.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.checkbox_showpass.Location = new System.Drawing.Point(42, 201);
            this.checkbox_showpass.Name = "checkbox_showpass";
            this.checkbox_showpass.Size = new System.Drawing.Size(112, 21);
            this.checkbox_showpass.TabIndex = 12;
            this.checkbox_showpass.Text = "Show Password";
            this.checkbox_showpass.UseVisualStyleBackColor = true;
            this.checkbox_showpass.CheckedChanged += new System.EventHandler(this.checkbox_showpass_CheckedChanged);
            // 
            // sql_hostaddress
            // 
            this.sql_hostaddress.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.sql_hostaddress.Location = new System.Drawing.Point(42, 52);
            this.sql_hostaddress.Name = "sql_hostaddress";
            this.sql_hostaddress.Size = new System.Drawing.Size(167, 25);
            this.sql_hostaddress.TabIndex = 1;
            this.sql_hostaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_IP_KeyPress);
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.Color.Transparent;
            this.btn_help.FlatAppearance.BorderSize = 0;
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_help.ForeColor = System.Drawing.Color.Black;
            this.btn_help.Location = new System.Drawing.Point(298, 109);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(24, 25);
            this.btn_help.TabIndex = 11;
            this.btn_help.Text = "?";
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // sql_port
            // 
            this.sql_port.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.sql_port.Location = new System.Drawing.Point(215, 52);
            this.sql_port.Name = "sql_port";
            this.sql_port.Size = new System.Drawing.Size(75, 25);
            this.sql_port.TabIndex = 5;
            this.sql_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Port_KeyPress);
            // 
            // sql_user
            // 
            this.sql_user.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.sql_user.Location = new System.Drawing.Point(42, 110);
            this.sql_user.Name = "sql_user";
            this.sql_user.Size = new System.Drawing.Size(248, 25);
            this.sql_user.TabIndex = 6;
            this.sql_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_User_KeyPress);
            // 
            // sql_pass
            // 
            this.sql_pass.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.sql_pass.Location = new System.Drawing.Point(42, 170);
            this.sql_pass.Name = "sql_pass";
            this.sql_pass.Size = new System.Drawing.Size(248, 25);
            this.sql_pass.TabIndex = 9;
            this.sql_pass.UseSystemPasswordChar = true;
            this.sql_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Pass_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label5.Location = new System.Drawing.Point(39, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Username (default: root)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label4.Location = new System.Drawing.Point(39, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password (default: \'root\')";
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Transparent;
            this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_cancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button_cancel.ForeColor = System.Drawing.Color.Black;
            this.button_cancel.Location = new System.Drawing.Point(434, 26);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(103, 27);
            this.button_cancel.TabIndex = 16;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // sqlver
            // 
            this.sqlver.AutoSize = true;
            this.sqlver.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlver.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.sqlver.Location = new System.Drawing.Point(7, 44);
            this.sqlver.Name = "sqlver";
            this.sqlver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sqlver.Size = new System.Drawing.Size(74, 13);
            this.sqlver.TabIndex = 18;
            this.sqlver.Text = "Not available";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(7, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Version:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(7, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Version compile machine:";
            // 
            // sqlcompile
            // 
            this.sqlcompile.AutoSize = true;
            this.sqlcompile.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlcompile.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.sqlcompile.Location = new System.Drawing.Point(7, 88);
            this.sqlcompile.Name = "sqlcompile";
            this.sqlcompile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sqlcompile.Size = new System.Drawing.Size(74, 13);
            this.sqlcompile.TabIndex = 20;
            this.sqlcompile.Text = "Not available";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_apply);
            this.panel1.Controls.Add(this.button_testconnection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 74);
            this.panel1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.sqlver);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.sqlcompile);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(401, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 243);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "About MySQL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sql_datasource);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 266);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Source";
            // 
            // sql_datasource
            // 
            this.sql_datasource.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.sql_datasource.FormattingEnabled = true;
            this.sql_datasource.Location = new System.Drawing.Point(27, 52);
            this.sql_datasource.Name = "sql_datasource";
            this.sql_datasource.Size = new System.Drawing.Size(183, 25);
            this.sql_datasource.TabIndex = 2;
            this.sql_datasource.SelectedIndexChanged += new System.EventHandler(this.ConfigureSQL_SelectDatabase_SelectedIndexChanged);
            this.sql_datasource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_SelectDatabase_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Database";
            // 
            // button_gendb
            // 
            this.button_gendb.BackColor = System.Drawing.Color.Transparent;
            this.button_gendb.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_gendb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_gendb.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_gendb.Location = new System.Drawing.Point(76, 83);
            this.button_gendb.Name = "button_gendb";
            this.button_gendb.Size = new System.Drawing.Size(144, 34);
            this.button_gendb.TabIndex = 14;
            this.button_gendb.Text = "Create new database";
            this.button_gendb.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 308);
            this.panel2.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 308);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_gendb);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(258, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 266);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Database name";
            // 
            // Login_ConfigureSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 382);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 374);
            this.Name = "Login_ConfigureSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection settings";
            this.Load += new System.EventHandler(this.Login_ConfigureSQL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_testconnection;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox sql_hostaddress;
        private System.Windows.Forms.Button btn_help;
        public System.Windows.Forms.TextBox sql_port;
        public System.Windows.Forms.TextBox sql_user;
        public System.Windows.Forms.TextBox sql_pass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkbox_showpass;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label sqlver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label sqlcompile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_gendb;
        public System.Windows.Forms.ComboBox sql_datasource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}