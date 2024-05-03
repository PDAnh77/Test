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
            this.Notification.AutoSize = true;
            this.Notification.ForeColor = System.Drawing.Color.Black;
            this.Notification.Location = new System.Drawing.Point(44, 124);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(44, 16);
            this.Notification.TabIndex = 21;
            this.Notification.Text = "label2";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReturn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReturn.BorderRadius = 0;
            this.btnReturn.BorderSize = 0;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(92, 561);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(252, 50);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextColor = System.Drawing.Color.White;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.BackColor = System.Drawing.Color.Transparent;
            this.Header.Location = new System.Drawing.Point(184, 72);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(135, 16);
            this.Header.TabIndex = 15;
            this.Header.Text = "RESET PASSWORD";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReset.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReset.BorderRadius = 0;
            this.btnReset.BorderSize = 0;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(92, 501);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(252, 50);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset password";
            this.btnReset.TextColor = System.Drawing.Color.White;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.textBoxDesign3.Location = new System.Drawing.Point(57, 410);
            this.textBoxDesign3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign3.Multiline = false;
            this.textBoxDesign3.Name = "textBoxDesign3";
            this.textBoxDesign3.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign3.PasswordChar = true;
            this.textBoxDesign3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign3.PlaceholderText = "Nhập lại mật khẩu";
            this.textBoxDesign3.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign3.TabIndex = 27;
            this.textBoxDesign3.Texts = "";
            this.textBoxDesign3.UnderlinedStyle = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(44, 391);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(344, 95);
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
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
            this.textBoxDesign1.Location = new System.Drawing.Point(58, 208);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            this.textBoxDesign1.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign1.TabIndex = 25;
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
            this.textBoxDesign2.Location = new System.Drawing.Point(58, 309);
            this.textBoxDesign2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign2.Multiline = false;
            this.textBoxDesign2.Name = "textBoxDesign2";
            this.textBoxDesign2.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign2.PasswordChar = true;
            this.textBoxDesign2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign2.PlaceholderText = "Mật khẩu mới";
            this.textBoxDesign2.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign2.TabIndex = 24;
            this.textBoxDesign2.Texts = "";
            this.textBoxDesign2.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(45, 189);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 95);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(44, 290);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 95);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
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
            this.Load += new System.EventHandler(this.ResetPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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