namespace GameProject
{
    partial class SendCode
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
            Notification = new Label();
            btnReturnHome = new CustomControls.ButtonDesign();
            textBoxDesign1 = new CustomControls.TextBoxDesign();
            textBoxDesign2 = new CustomControls.TextBoxDesign();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Header = new Label();
            btnVerify = new CustomControls.ButtonDesign();
            btnSend = new CustomControls.ButtonDesign();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Notification
            // 
            Notification.AutoSize = true;
            Notification.ForeColor = Color.Black;
            Notification.Location = new Point(32, 142);
            Notification.Name = "Notification";
            Notification.Size = new Size(50, 20);
            Notification.TabIndex = 20;
            Notification.Text = "label2";
            Notification.TextAlign = ContentAlignment.MiddleCenter;
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
            btnReturnHome.Location = new Point(77, 557);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(252, 50);
            btnReturnHome.TabIndex = 19;
            btnReturnHome.Text = "Return";
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
            textBoxDesign1.Location = new Point(46, 217);
            textBoxDesign1.Margin = new Padding(4);
            textBoxDesign1.Multiline = false;
            textBoxDesign1.Name = "textBoxDesign1";
            textBoxDesign1.Padding = new Padding(7);
            textBoxDesign1.PasswordChar = false;
            textBoxDesign1.PlaceholderColor = Color.DarkGray;
            textBoxDesign1.PlaceholderText = "Nhập email";
            textBoxDesign1.Size = new Size(287, 36);
            textBoxDesign1.TabIndex = 18;
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
            textBoxDesign2.Location = new Point(47, 388);
            textBoxDesign2.Margin = new Padding(4);
            textBoxDesign2.Multiline = false;
            textBoxDesign2.Name = "textBoxDesign2";
            textBoxDesign2.Padding = new Padding(7);
            textBoxDesign2.PasswordChar = true;
            textBoxDesign2.PlaceholderColor = Color.DarkGray;
            textBoxDesign2.PlaceholderText = "Nhập mã";
            textBoxDesign2.Size = new Size(286, 36);
            textBoxDesign2.TabIndex = 17;
            textBoxDesign2.Texts = "";
            textBoxDesign2.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(33, 198);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(345, 95);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(33, 369);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 95);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.BackColor = Color.Transparent;
            Header.Location = new Point(176, 70);
            Header.Name = "Header";
            Header.Size = new Size(152, 20);
            Header.TabIndex = 14;
            Header.Text = "ACCOUNT RECOVERY";
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.MediumSlateBlue;
            btnVerify.BackgroundColor = Color.MediumSlateBlue;
            btnVerify.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerify.BorderColor = Color.PaleVioletRed;
            btnVerify.BorderRadius = 0;
            btnVerify.BorderSize = 0;
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(253, 470);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(125, 45);
            btnVerify.TabIndex = 13;
            btnVerify.Text = "Verify";
            btnVerify.TextColor = Color.White;
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.MediumSlateBlue;
            btnSend.BackgroundColor = Color.MediumSlateBlue;
            btnSend.BackgroundImageLayout = ImageLayout.Stretch;
            btnSend.BorderColor = Color.PaleVioletRed;
            btnSend.BorderRadius = 0;
            btnSend.BorderSize = 0;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(253, 299);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(125, 45);
            btnSend.TabIndex = 21;
            btnSend.Text = "Send";
            btnSend.TextColor = Color.White;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // SendCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(432, 673);
            Controls.Add(btnSend);
            Controls.Add(Notification);
            Controls.Add(btnReturnHome);
            Controls.Add(textBoxDesign1);
            Controls.Add(textBoxDesign2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Header);
            Controls.Add(btnVerify);
            Name = "SendCode";
            Text = "SendCode";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Notification;
        private CustomControls.ButtonDesign btnReturnHome;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.TextBoxDesign textBoxDesign2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label Header;
        private CustomControls.ButtonDesign btnVerify;
        private CustomControls.ButtonDesign btnSend;
    }
}