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
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigureSQL_SelectDatabase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_testconnection = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_showpass = new System.Windows.Forms.CheckBox();
            this.ConfigureSQL_IP = new System.Windows.Forms.TextBox();
            this.btn_help = new System.Windows.Forms.Button();
            this.ConfigureSQL_Port = new System.Windows.Forms.TextBox();
            this.ConfigureSQL_User = new System.Windows.Forms.TextBox();
            this.ConfigureSQL_Pass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_gendb = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sqlver = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sqlcompile = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select record";
            // 
            // ConfigureSQL_SelectDatabase
            // 
            this.ConfigureSQL_SelectDatabase.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.ConfigureSQL_SelectDatabase.FormattingEnabled = true;
            this.ConfigureSQL_SelectDatabase.Location = new System.Drawing.Point(27, 52);
            this.ConfigureSQL_SelectDatabase.Name = "ConfigureSQL_SelectDatabase";
            this.ConfigureSQL_SelectDatabase.Size = new System.Drawing.Size(183, 25);
            this.ConfigureSQL_SelectDatabase.TabIndex = 2;
            this.ConfigureSQL_SelectDatabase.SelectedIndexChanged += new System.EventHandler(this.ConfigureSQL_SelectDatabase_SelectedIndexChanged);
            this.ConfigureSQL_SelectDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_SelectDatabase_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.label2.Location = new System.Drawing.Point(39, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Host address";
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
            this.button_save.BackColor = System.Drawing.Color.DarkRed;
            this.button_save.Enabled = false;
            this.button_save.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(432, 330);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(131, 28);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Save and Restart";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_testconnection
            // 
            this.button_testconnection.BackColor = System.Drawing.Color.Transparent;
            this.button_testconnection.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_testconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_testconnection.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_testconnection.ForeColor = System.Drawing.Color.Black;
            this.button_testconnection.Location = new System.Drawing.Point(215, 232);
            this.button_testconnection.Name = "button_testconnection";
            this.button_testconnection.Size = new System.Drawing.Size(136, 28);
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
            this.button_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_apply.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_apply.Location = new System.Drawing.Point(119, 330);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(126, 28);
            this.button_apply.TabIndex = 13;
            this.button_apply.Text = "Apply Settings";
            this.button_apply.UseVisualStyleBackColor = false;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_showpass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ConfigureSQL_IP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_testconnection);
            this.groupBox1.Controls.Add(this.btn_help);
            this.groupBox1.Controls.Add(this.ConfigureSQL_Port);
            this.groupBox1.Controls.Add(this.ConfigureSQL_User);
            this.groupBox1.Controls.Add(this.ConfigureSQL_Pass);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 272);
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
            // ConfigureSQL_IP
            // 
            this.ConfigureSQL_IP.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.ConfigureSQL_IP.Location = new System.Drawing.Point(42, 52);
            this.ConfigureSQL_IP.Name = "ConfigureSQL_IP";
            this.ConfigureSQL_IP.Size = new System.Drawing.Size(167, 25);
            this.ConfigureSQL_IP.TabIndex = 1;
            this.ConfigureSQL_IP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_IP_KeyPress);
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
            // ConfigureSQL_Port
            // 
            this.ConfigureSQL_Port.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.ConfigureSQL_Port.Location = new System.Drawing.Point(215, 52);
            this.ConfigureSQL_Port.Name = "ConfigureSQL_Port";
            this.ConfigureSQL_Port.Size = new System.Drawing.Size(75, 25);
            this.ConfigureSQL_Port.TabIndex = 5;
            this.ConfigureSQL_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Port_KeyPress);
            // 
            // ConfigureSQL_User
            // 
            this.ConfigureSQL_User.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.ConfigureSQL_User.Location = new System.Drawing.Point(42, 110);
            this.ConfigureSQL_User.Name = "ConfigureSQL_User";
            this.ConfigureSQL_User.Size = new System.Drawing.Size(248, 25);
            this.ConfigureSQL_User.TabIndex = 6;
            this.ConfigureSQL_User.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_User_KeyPress);
            // 
            // ConfigureSQL_Pass
            // 
            this.ConfigureSQL_Pass.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.ConfigureSQL_Pass.Location = new System.Drawing.Point(42, 170);
            this.ConfigureSQL_Pass.Name = "ConfigureSQL_Pass";
            this.ConfigureSQL_Pass.Size = new System.Drawing.Size(248, 25);
            this.ConfigureSQL_Pass.TabIndex = 9;
            this.ConfigureSQL_Pass.UseSystemPasswordChar = true;
            this.ConfigureSQL_Pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSQL_Pass_KeyPress);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_gendb);
            this.groupBox2.Controls.Add(this.ConfigureSQL_SelectDatabase);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(393, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 156);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Source";
            // 
            // button_gendb
            // 
            this.button_gendb.BackColor = System.Drawing.Color.Transparent;
            this.button_gendb.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_gendb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_gendb.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_gendb.Location = new System.Drawing.Point(79, 90);
            this.button_gendb.Name = "button_gendb";
            this.button_gendb.Size = new System.Drawing.Size(131, 34);
            this.button_gendb.TabIndex = 14;
            this.button_gendb.Text = "Create new record";
            this.button_gendb.UseVisualStyleBackColor = false;
            this.button_gendb.Click += new System.EventHandler(this.button_gendb_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Transparent;
            this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.button_cancel.ForeColor = System.Drawing.Color.Black;
            this.button_cancel.Location = new System.Drawing.Point(284, 330);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(103, 28);
            this.button_cancel.TabIndex = 16;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(399, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "About MySQL";
            // 
            // sqlver
            // 
            this.sqlver.AutoSize = true;
            this.sqlver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlver.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.sqlver.Location = new System.Drawing.Point(399, 231);
            this.sqlver.Name = "sqlver";
            this.sqlver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sqlver.Size = new System.Drawing.Size(85, 17);
            this.sqlver.TabIndex = 18;
            this.sqlver.Text = "Not available";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(399, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Version:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(399, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Version compile machine:";
            // 
            // sqlcompile
            // 
            this.sqlcompile.AutoSize = true;
            this.sqlcompile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlcompile.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.sqlcompile.Location = new System.Drawing.Point(399, 275);
            this.sqlcompile.Name = "sqlcompile";
            this.sqlcompile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sqlcompile.Size = new System.Drawing.Size(85, 17);
            this.sqlcompile.TabIndex = 20;
            this.sqlcompile.Text = "Not available";
            // 
            // Login_ConfigureSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 382);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sqlcompile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sqlver);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_save);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 374);
            this.Name = "Login_ConfigureSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure MySQL Connection";
            this.Load += new System.EventHandler(this.Login_ConfigureSQL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save;
        public System.Windows.Forms.ComboBox ConfigureSQL_SelectDatabase;
        private System.Windows.Forms.Button button_testconnection;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox ConfigureSQL_IP;
        private System.Windows.Forms.Button btn_help;
        public System.Windows.Forms.TextBox ConfigureSQL_Port;
        public System.Windows.Forms.TextBox ConfigureSQL_User;
        public System.Windows.Forms.TextBox ConfigureSQL_Pass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_gendb;
        private System.Windows.Forms.CheckBox checkbox_showpass;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label sqlver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label sqlcompile;
    }
}