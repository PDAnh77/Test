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
            this.btnReturnHome = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Header = new System.Windows.Forms.Label();
            this.btnSignup = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign3 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Notification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnHome
            // 
            btnReturnHome.BackColor = Color.MediumSlateBlue;
            btnReturnHome.BackgroundColor = Color.MediumSlateBlue;
            btnReturnHome.BackgroundImageLayout = ImageLayout.Stretch;
            btnReturnHome.BorderColor = Color.PaleVioletRed;
            btnReturnHome.BorderRadius = 0;
            btnReturnHome.BorderSize = 0;
            btnReturnHome.FlatAppearance.BorderSize = 0;
            btnReturnHome.FlatStyle = FlatStyle.Flat;
            btnReturnHome.ForeColor = Color.White;
            btnReturnHome.Location = new Point(88, 561);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(252, 50);
            btnReturnHome.TabIndex = 18;
            btnReturnHome.Text = "Return home";
            btnReturnHome.TextColor = Color.White;
            btnReturnHome.UseVisualStyleBackColor = false;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // textBoxDesign1
            // 
            textBoxDesign1.BackColor = Color.Moccasin;
            textBoxDesign1.BackgroundImageLayout = ImageLayout.Stretch;
            textBoxDesign1.BorderColor = Color.Transparent;
            textBoxDesign1.BorderFocusColor = Color.Transparent;
            textBoxDesign1.BorderRadius = 0;
            textBoxDesign1.BorderSize = 1;
            textBoxDesign1.Font = new Font("Segoe UI", 9.5F);
            textBoxDesign1.ForeColor = Color.Black;
            textBoxDesign1.Location = new Point(54, 206);
            textBoxDesign1.Margin = new Padding(4);
            textBoxDesign1.Multiline = false;
            textBoxDesign1.Name = "textBoxDesign1";
            textBoxDesign1.Padding = new Padding(7);
            textBoxDesign1.PasswordChar = false;
            textBoxDesign1.PlaceholderColor = Color.DarkGray;
            textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            textBoxDesign1.Size = new Size(286, 36);
            textBoxDesign1.TabIndex = 17;
            textBoxDesign1.Texts = "";
            textBoxDesign1.UnderlinedStyle = false;
            // 
            // textBoxDesign2
            // 
            textBoxDesign2.BackColor = Color.Moccasin;
            textBoxDesign2.BackgroundImageLayout = ImageLayout.Stretch;
            textBoxDesign2.BorderColor = Color.Transparent;
            textBoxDesign2.BorderFocusColor = Color.Transparent;
            textBoxDesign2.BorderRadius = 0;
            textBoxDesign2.BorderSize = 1;
            textBoxDesign2.Font = new Font("Segoe UI", 9.5F);
            textBoxDesign2.ForeColor = Color.Black;
            textBoxDesign2.Location = new Point(54, 307);
            textBoxDesign2.Margin = new Padding(4);
            textBoxDesign2.Multiline = false;
            textBoxDesign2.Name = "textBoxDesign2";
            textBoxDesign2.Padding = new Padding(7);
            textBoxDesign2.PasswordChar = true;
            textBoxDesign2.PlaceholderColor = Color.DarkGray;
            textBoxDesign2.PlaceholderText = "Mật khẩu";
            textBoxDesign2.Size = new Size(286, 36);
            textBoxDesign2.TabIndex = 16;
            textBoxDesign2.Texts = "";
            textBoxDesign2.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(41, 187);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(344, 95);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(40, 288);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 95);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.BackColor = Color.Transparent;
            Header.Location = new Point(167, 61);
            Header.Name = "Header";
            Header.Size = new Size(64, 20);
            Header.TabIndex = 13;
            Header.Text = "SIGN UP";
            // 
            // btnSignup
            // 
            btnSignup.BackColor = Color.MediumSlateBlue;
            btnSignup.BackgroundColor = Color.MediumSlateBlue;
            btnSignup.BackgroundImageLayout = ImageLayout.Stretch;
            btnSignup.BorderColor = Color.PaleVioletRed;
            btnSignup.BorderRadius = 0;
            btnSignup.BorderSize = 0;
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.ForeColor = Color.White;
            btnSignup.Location = new Point(88, 501);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(252, 50);
            btnSignup.TabIndex = 12;
            btnSignup.Text = "Sign up";
            btnSignup.TextColor = Color.White;
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // textBoxDesign3
            // 
            textBoxDesign3.BackColor = Color.Moccasin;
            textBoxDesign3.BackgroundImageLayout = ImageLayout.Stretch;
            textBoxDesign3.BorderColor = Color.Transparent;
            textBoxDesign3.BorderFocusColor = Color.Transparent;
            textBoxDesign3.BorderRadius = 0;
            textBoxDesign3.BorderSize = 1;
            textBoxDesign3.Font = new Font("Segoe UI", 9.5F);
            textBoxDesign3.ForeColor = Color.Black;
            textBoxDesign3.Location = new Point(53, 408);
            textBoxDesign3.Margin = new Padding(4);
            textBoxDesign3.Multiline = false;
            textBoxDesign3.Name = "textBoxDesign3";
            textBoxDesign3.Padding = new Padding(7);
            textBoxDesign3.PasswordChar = true;
            textBoxDesign3.PlaceholderColor = Color.DarkGray;
            textBoxDesign3.PlaceholderText = "Nhập lại mật khẩu";
            textBoxDesign3.Size = new Size(286, 36);
            textBoxDesign3.TabIndex = 20;
            textBoxDesign3.Texts = "";
            textBoxDesign3.UnderlinedStyle = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(40, 389);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(344, 95);
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // Notification
            // 
            Notification.AutoSize = true;
            Notification.ForeColor = Color.Black;
            Notification.Location = new Point(40, 124);
            Notification.Name = "Notification";
            Notification.Size = new Size(50, 20);
            Notification.TabIndex = 22;
            Notification.Text = "label2";
            Notification.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 673);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Signup";
            this.Text = "Signup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            Load += Signup_Load;
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
    }
}