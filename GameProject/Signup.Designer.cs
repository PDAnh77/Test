using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Header = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Notification = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBoxDesign4 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign3 = new GameProject.CustomControls.TextBoxDesign();
            this.btnReturnHome = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.btnSignup = new GameProject.CustomControls.ButtonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(41, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 95);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(41, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 95);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.BackColor = System.Drawing.Color.Transparent;
            this.Header.Location = new System.Drawing.Point(161, 60);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(61, 16);
            this.Header.TabIndex = 13;
            this.Header.Text = "SIGN UP";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(41, 379);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(344, 95);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.ForeColor = System.Drawing.Color.Black;
            this.Notification.Location = new System.Drawing.Point(42, 110);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(44, 16);
            this.Notification.TabIndex = 22;
            this.Notification.Text = "label2";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(41, 480);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(344, 95);
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // textBoxDesign4
            // 
            this.textBoxDesign4.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign4.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign4.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign4.BorderRadius = 0;
            this.textBoxDesign4.BorderSize = 1;
            this.textBoxDesign4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign4.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign4.Location = new System.Drawing.Point(54, 499);
            this.textBoxDesign4.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign4.Multiline = false;
            this.textBoxDesign4.Name = "textBoxDesign4";
            this.textBoxDesign4.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign4.PasswordChar = true;
            this.textBoxDesign4.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign4.PlaceholderText = "Nhập lại mật khẩu";
            this.textBoxDesign4.ReadOnly = false;
            this.textBoxDesign4.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign4.TabIndex = 24;
            this.textBoxDesign4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign4.Texts = "";
            this.textBoxDesign4.UnderlinedStyle = false;
            // 
            // textBoxDesign3
            // 
            this.textBoxDesign3.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign3.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign3.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign3.BorderRadius = 0;
            this.textBoxDesign3.BorderSize = 1;
            this.textBoxDesign3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign3.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign3.Location = new System.Drawing.Point(54, 398);
            this.textBoxDesign3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign3.Multiline = false;
            this.textBoxDesign3.Name = "textBoxDesign3";
            this.textBoxDesign3.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign3.PasswordChar = true;
            this.textBoxDesign3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign3.PlaceholderText = "Mật khẩu";
            this.textBoxDesign3.ReadOnly = false;
            this.textBoxDesign3.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign3.TabIndex = 20;
            this.textBoxDesign3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign3.Texts = "";
            this.textBoxDesign3.UnderlinedStyle = false;
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
            this.btnReturnHome.Location = new System.Drawing.Point(88, 637);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(252, 50);
            this.btnReturnHome.TabIndex = 18;
            this.btnReturnHome.Text = "Return home";
            this.btnReturnHome.TextColor = System.Drawing.Color.White;
            this.btnReturnHome.UseVisualStyleBackColor = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
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
            this.textBoxDesign1.Location = new System.Drawing.Point(55, 196);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            this.textBoxDesign1.ReadOnly = false;
            this.textBoxDesign1.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign1.TabIndex = 17;
            this.textBoxDesign1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
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
            this.textBoxDesign2.Location = new System.Drawing.Point(55, 297);
            this.textBoxDesign2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign2.Multiline = false;
            this.textBoxDesign2.Name = "textBoxDesign2";
            this.textBoxDesign2.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign2.PasswordChar = false;
            this.textBoxDesign2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign2.PlaceholderText = "Email";
            this.textBoxDesign2.ReadOnly = false;
            this.textBoxDesign2.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign2.TabIndex = 16;
            this.textBoxDesign2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign2.Texts = "";
            this.textBoxDesign2.UnderlinedStyle = false;
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSignup.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSignup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSignup.BorderRadius = 0;
            this.btnSignup.BorderSize = 0;
            this.btnSignup.FlatAppearance.BorderSize = 0;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(88, 581);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(252, 50);
            this.btnSignup.TabIndex = 12;
            this.btnSignup.Text = "Sign up";
            this.btnSignup.TextColor = System.Drawing.Color.White;
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 753);
            this.Controls.Add(this.textBoxDesign4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.textBoxDesign3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.textBoxDesign2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.btnSignup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.ButtonDesign btnReturnHome;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.TextBoxDesign textBoxDesign2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label Header;
        private CustomControls.ButtonDesign btnSignup;
        private CustomControls.TextBoxDesign textBoxDesign3;
        private PictureBox pictureBox3;
        private Label Notification;
        private CustomControls.TextBoxDesign textBoxDesign4;
        private PictureBox pictureBox4;
    }
}