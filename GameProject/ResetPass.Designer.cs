using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    partial class ResetPass
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
            this.Notification = new System.Windows.Forms.Label();
            this.btnReturn = new GameProject.CustomControls.ButtonDesign();
            this.Header = new System.Windows.Forms.Label();
            this.btnReset = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign3 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Notification
            // 
            Notification.AutoSize = true;
            Notification.ForeColor = Color.Black;
            Notification.Location = new Point(44, 124);
            Notification.Name = "Notification";
            Notification.Size = new Size(50, 20);
            Notification.TabIndex = 21;
            Notification.Text = "label2";
            Notification.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.MediumSlateBlue;
            btnReturn.BackgroundColor = Color.MediumSlateBlue;
            btnReturn.BackgroundImageLayout = ImageLayout.Stretch;
            btnReturn.BorderColor = Color.PaleVioletRed;
            btnReturn.BorderRadius = 0;
            btnReturn.BorderSize = 0;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(92, 561);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(252, 50);
            btnReturn.TabIndex = 20;
            btnReturn.Text = "Return";
            btnReturn.TextColor = Color.White;
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.BackColor = Color.Transparent;
            Header.Location = new Point(184, 72);
            Header.Name = "Header";
            Header.Size = new Size(132, 20);
            Header.TabIndex = 15;
            Header.Text = "RESET PASSWORD";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.MediumSlateBlue;
            btnReset.BackgroundColor = Color.MediumSlateBlue;
            btnReset.BackgroundImageLayout = ImageLayout.Stretch;
            btnReset.BorderColor = Color.PaleVioletRed;
            btnReset.BorderRadius = 0;
            btnReset.BorderSize = 0;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(92, 501);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(252, 50);
            btnReset.TabIndex = 14;
            btnReset.Text = "Reset password";
            btnReset.TextColor = Color.White;
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
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
            textBoxDesign3.Location = new Point(57, 410);
            textBoxDesign3.Margin = new Padding(4);
            textBoxDesign3.Multiline = false;
            textBoxDesign3.Name = "textBoxDesign3";
            textBoxDesign3.Padding = new Padding(7);
            textBoxDesign3.PasswordChar = true;
            textBoxDesign3.PlaceholderColor = Color.DarkGray;
            textBoxDesign3.PlaceholderText = "Nhập lại mật khẩu";
            textBoxDesign3.Size = new Size(286, 36);
            textBoxDesign3.TabIndex = 27;
            textBoxDesign3.Texts = "";
            textBoxDesign3.UnderlinedStyle = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(44, 391);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(344, 95);
            pictureBox3.TabIndex = 26;
            pictureBox3.TabStop = false;
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
            textBoxDesign1.Location = new Point(58, 208);
            textBoxDesign1.Margin = new Padding(4);
            textBoxDesign1.Multiline = false;
            textBoxDesign1.Name = "textBoxDesign1";
            textBoxDesign1.Padding = new Padding(7);
            textBoxDesign1.PasswordChar = false;
            textBoxDesign1.PlaceholderColor = Color.DarkGray;
            textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            textBoxDesign1.Size = new Size(286, 36);
            textBoxDesign1.TabIndex = 25;
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
            textBoxDesign2.Location = new Point(58, 309);
            textBoxDesign2.Margin = new Padding(4);
            textBoxDesign2.Multiline = false;
            textBoxDesign2.Name = "textBoxDesign2";
            textBoxDesign2.Padding = new Padding(7);
            textBoxDesign2.PasswordChar = true;
            textBoxDesign2.PlaceholderColor = Color.DarkGray;
            textBoxDesign2.PlaceholderText = "Mật khẩu mới";
            textBoxDesign2.Size = new Size(286, 36);
            textBoxDesign2.TabIndex = 24;
            textBoxDesign2.Texts = "";
            textBoxDesign2.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(45, 189);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(344, 95);
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(44, 290);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 95);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // ResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 673);
            this.Controls.Add(this.textBoxDesign3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.textBoxDesign2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.btnReset);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResetPass";
            this.Text = "ResetPass";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            Load += ResetPass_Load;
        }

        #endregion
        private Label Notification;
        private CustomControls.ButtonDesign btnReturn;
        private Label Header;
        private CustomControls.ButtonDesign btnReset;
        private CustomControls.TextBoxDesign textBoxDesign3;
        private PictureBox pictureBox3;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.TextBoxDesign textBoxDesign2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}