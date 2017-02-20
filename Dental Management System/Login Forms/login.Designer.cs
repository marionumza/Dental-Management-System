namespace Dental_Management_System
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.appVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Configure = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.txtBoxPass);
            this.panel2.Controls.Add(this.txtBoxUser);
            this.panel2.Controls.Add(this.appVersion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_Configure);
            this.panel2.Controls.Add(this.btnSignIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 409);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPass.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPass.Location = new System.Drawing.Point(72, 213);
            this.txtBoxPass.MaxLength = 8;
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(304, 29);
            this.txtBoxPass.TabIndex = 4;
            this.txtBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPass.UseSystemPasswordChar = true;
            this.txtBoxPass.Click += new System.EventHandler(this.txtBoxPass_Click);
            this.txtBoxPass.Enter += new System.EventHandler(this.txtBoxPass_Enter);
            this.txtBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPass_KeyDown);
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxUser.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUser.Location = new System.Drawing.Point(72, 178);
            this.txtBoxUser.MaxLength = 16;
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(304, 29);
            this.txtBoxUser.TabIndex = 1;
            this.txtBoxUser.Text = "Username";
            this.txtBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxUser.Click += new System.EventHandler(this.txtBoxUser_Click);
            this.txtBoxUser.TextChanged += new System.EventHandler(this.txtBoxUser_TextChanged);
            // 
            // appVersion
            // 
            this.appVersion.AutoSize = true;
            this.appVersion.BackColor = System.Drawing.Color.Transparent;
            this.appVersion.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appVersion.ForeColor = System.Drawing.Color.Black;
            this.appVersion.Location = new System.Drawing.Point(192, 352);
            this.appVersion.Name = "appVersion";
            this.appVersion.Size = new System.Drawing.Size(65, 13);
            this.appVersion.TabIndex = 7;
            this.appVersion.Text = "Version: N/A";
            this.appVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appVersion.DoubleClick += new System.EventHandler(this.appVersion_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(147, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 65);
            this.label2.TabIndex = 9;
            this.label2.Text = "Login";
            // 
            // btn_Configure
            // 
            this.btn_Configure.BackColor = System.Drawing.Color.Transparent;
            this.btn_Configure.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Configure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btn_Configure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Configure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Configure.ForeColor = System.Drawing.Color.White;
            this.btn_Configure.Location = new System.Drawing.Point(72, 259);
            this.btn_Configure.Name = "btn_Configure";
            this.btn_Configure.Size = new System.Drawing.Size(154, 37);
            this.btn_Configure.TabIndex = 6;
            this.btn_Configure.Text = "Server configuration";
            this.btn_Configure.UseVisualStyleBackColor = false;
            this.btn_Configure.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.Transparent;
            this.btnSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(232, 259);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(144, 37);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Login";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 409);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollment System - Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.Label appVersion;
        private System.Windows.Forms.Button btn_Configure;
        private System.Windows.Forms.Label label2;
    }
}

