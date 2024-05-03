using System.Drawing;
using System.Windows.Forms;

namespace GameProject
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
            this.btnLogin = new GameProject.CustomControls.ButtonDesign();
            this.Header = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.btnReturnHome = new GameProject.CustomControls.ButtonDesign();
            this.Notification = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(78, 488);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(252, 50);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.BackColor = System.Drawing.Color.Transparent;
            this.Header.Location = new System.Drawing.Point(167, 61);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(47, 16);
            this.Header.TabIndex = 4;
            this.Header.Text = "LOGIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(30, 329);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 95);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(31, 218);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 95);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxDesign2
            // 
            this.textBoxDesign2.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign2.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign2.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign2.BorderRadius = 0;
            this.textBoxDesign2.BorderSize = 1;
            this.textBoxDesign2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign2.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign2.Location = new System.Drawing.Point(44, 348);
            this.textBoxDesign2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign2.Multiline = false;
            this.textBoxDesign2.Name = "textBoxDesign2";
            this.textBoxDesign2.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign2.PasswordChar = true;
            this.textBoxDesign2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign2.PlaceholderText = "Mật khẩu";
            this.textBoxDesign2.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign2.TabIndex = 9;
            this.textBoxDesign2.Texts = "";
            this.textBoxDesign2.UnderlinedStyle = false;
            // 
            // textBoxDesign1
            // 
            this.textBoxDesign1.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign1.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign1.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign1.BorderRadius = 0;
            this.textBoxDesign1.BorderSize = 1;
            this.textBoxDesign1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign1.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign1.Location = new System.Drawing.Point(44, 237);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            this.textBoxDesign1.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign1.TabIndex = 10;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReturnHome.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReturnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturnHome.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReturnHome.BorderRadius = 0;
            this.btnReturnHome.BorderSize = 0;
            this.btnReturnHome.FlatAppearance.BorderSize = 0;
            this.btnReturnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnHome.ForeColor = System.Drawing.Color.White;
            this.btnReturnHome.Location = new System.Drawing.Point(78, 548);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(252, 50);
            this.btnReturnHome.TabIndex = 11;
            this.btnReturnHome.Text = "Return home";
            this.btnReturnHome.TextColor = System.Drawing.Color.White;
            this.btnReturnHome.UseVisualStyleBackColor = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.ForeColor = System.Drawing.Color.Black;
            this.Notification.Location = new System.Drawing.Point(30, 154);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(44, 16);
            this.Notification.TabIndex = 12;
            this.Notification.Text = "label2";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkLabel1.Location = new System.Drawing.Point(44, 436);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 16);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forget password?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 673);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.textBoxDesign2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private CustomControls.ButtonDesign btnLogin;
        private Label Header;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private CustomControls.TextBoxDesign textBoxDesign2;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.ButtonDesign btnReturnHome;
        private Label Notification;
        private LinkLabel linkLabel1;
    }
}