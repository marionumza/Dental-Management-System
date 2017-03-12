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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGitHubRepo = new System.Windows.Forms.LinkLabel();
            this.lblappVersion = new System.Windows.Forms.Label();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.btn_Configure = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblWelcomeMessage);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtBoxPass);
            this.panel2.Controls.Add(this.txtBoxUser);
            this.panel2.Controls.Add(this.btn_Configure);
            this.panel2.Controls.Add(this.btnSignIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 400);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dental_Management_System.Properties.Resources.flat_padlock_icon;
            this.pictureBox2.Location = new System.Drawing.Point(72, 216);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dental_Management_System.Properties.Resources.profile_ico;
            this.pictureBox1.Location = new System.Drawing.Point(72, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblWelcomeMessage.Location = new System.Drawing.Point(102, 106);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(248, 21);
            this.lblWelcomeMessage.TabIndex = 12;
            this.lblWelcomeMessage.Text = "Please login to begin your session.";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblWelcome);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(446, 88);
            this.panel4.TabIndex = 13;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblWelcome.Location = new System.Drawing.Point(124, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(188, 51);
            this.lblWelcome.TabIndex = 11;
            this.lblWelcome.Text = "Welcome";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 32);
            this.panel1.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel3.Controls.Add(this.lblGitHubRepo);
            this.panel3.Controls.Add(this.lblappVersion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(446, 32);
            this.panel3.TabIndex = 12;
            // 
            // lblGitHubRepo
            // 
            this.lblGitHubRepo.AutoSize = true;
            this.lblGitHubRepo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGitHubRepo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblGitHubRepo.LinkColor = System.Drawing.Color.DimGray;
            this.lblGitHubRepo.LinkVisited = true;
            this.lblGitHubRepo.Location = new System.Drawing.Point(284, 9);
            this.lblGitHubRepo.Name = "lblGitHubRepo";
            this.lblGitHubRepo.Size = new System.Drawing.Size(162, 13);
            this.lblGitHubRepo.TabIndex = 9;
            this.lblGitHubRepo.TabStop = true;
            this.lblGitHubRepo.Text = "Click to see Github Repository";
            this.lblGitHubRepo.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.lblGitHubRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // lblappVersion
            // 
            this.lblappVersion.AutoSize = true;
            this.lblappVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblappVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblappVersion.ForeColor = System.Drawing.Color.White;
            this.lblappVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblappVersion.Location = new System.Drawing.Point(7, 6);
            this.lblappVersion.Name = "lblappVersion";
            this.lblappVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblappVersion.Size = new System.Drawing.Size(164, 19);
            this.lblappVersion.TabIndex = 7;
            this.lblappVersion.Text = "Client version: 1.0.351.64";
            this.lblappVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblappVersion.DoubleClick += new System.EventHandler(this.appVersion_DoubleClick);
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxPass.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPass.ForeColor = System.Drawing.Color.Black;
            this.txtBoxPass.Location = new System.Drawing.Point(101, 216);
            this.txtBoxPass.MaxLength = 8;
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(275, 22);
            this.txtBoxPass.TabIndex = 4;
            this.txtBoxPass.Text = "Password";
            this.txtBoxPass.UseSystemPasswordChar = true;
            this.txtBoxPass.Click += new System.EventHandler(this.txtBoxPass_Click);
            this.txtBoxPass.Enter += new System.EventHandler(this.txtBoxPass_Enter);
            this.txtBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPass_KeyDown);
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxUser.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUser.ForeColor = System.Drawing.Color.Black;
            this.txtBoxUser.Location = new System.Drawing.Point(101, 172);
            this.txtBoxUser.MaxLength = 16;
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(274, 22);
            this.txtBoxUser.TabIndex = 1;
            this.txtBoxUser.Text = "Username";
            this.txtBoxUser.Click += new System.EventHandler(this.txtBoxUser_Click);
            this.txtBoxUser.TextChanged += new System.EventHandler(this.txtBoxUser_TextChanged);
            // 
            // btn_Configure
            // 
            this.btn_Configure.BackColor = System.Drawing.Color.Transparent;
            this.btn_Configure.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_Configure.FlatAppearance.BorderSize = 0;
            this.btn_Configure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Configure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Configure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Configure.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Configure.Location = new System.Drawing.Point(187, 285);
            this.btn_Configure.Name = "btn_Configure";
            this.btn_Configure.Size = new System.Drawing.Size(93, 37);
            this.btn_Configure.TabIndex = 6;
            this.btn_Configure.Text = "Configure";
            this.btn_Configure.UseVisualStyleBackColor = false;
            this.btn_Configure.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(286, 285);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(90, 37);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Login";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 400);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dental Management System - Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.Button btn_Configure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblappVersion;
        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel lblGitHubRepo;
    }
}

