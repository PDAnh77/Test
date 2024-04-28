namespace GameProject
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            Header = new Label();
            pictureBox2 = new PictureBox();
            btnQuit = new CustomControls.ButtonDesign();
            btnSignup = new CustomControls.ButtonDesign();
            btnPlay = new CustomControls.ButtonDesign();
            btnLogin = new CustomControls.ButtonDesign();
            Notification = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(60, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(700, 202);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Header
            // 
            Header.BackColor = Color.Transparent;
            Header.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Header.Location = new Point(11, 12);
            Header.Name = "Header";
            Header.Size = new Size(700, 66);
            Header.TabIndex = 5;
            Header.Text = "CỜ CÁ NGỰA";
            Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(221, 281);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(440, 354);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.CornflowerBlue;
            btnQuit.BackgroundColor = Color.CornflowerBlue;
            btnQuit.BackgroundImageLayout = ImageLayout.Stretch;
            btnQuit.BorderColor = Color.Black;
            btnQuit.BorderRadius = 0;
            btnQuit.BorderSize = 0;
            btnQuit.FlatAppearance.BorderSize = 0;
            btnQuit.FlatStyle = FlatStyle.Flat;
            btnQuit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point(246, 543);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(336, 60);
            btnQuit.TabIndex = 11;
            btnQuit.Text = "QUIT";
            btnQuit.TextColor = Color.White;
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnSignup
            // 
            btnSignup.BackColor = Color.CornflowerBlue;
            btnSignup.BackgroundColor = Color.CornflowerBlue;
            btnSignup.BackgroundImageLayout = ImageLayout.Stretch;
            btnSignup.BorderColor = Color.Black;
            btnSignup.BorderRadius = 0;
            btnSignup.BorderSize = 0;
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignup.ForeColor = Color.White;
            btnSignup.Location = new Point(246, 391);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(336, 60);
            btnSignup.TabIndex = 10;
            btnSignup.Text = "SIGN UP";
            btnSignup.TextColor = Color.White;
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.CornflowerBlue;
            btnPlay.BackgroundColor = Color.CornflowerBlue;
            btnPlay.BackgroundImageLayout = ImageLayout.Stretch;
            btnPlay.BorderColor = Color.Black;
            btnPlay.BorderRadius = 0;
            btnPlay.BorderSize = 0;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(246, 467);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(336, 60);
            btnPlay.TabIndex = 9;
            btnPlay.Text = "PLAY";
            btnPlay.TextColor = Color.White;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.CornflowerBlue;
            btnLogin.BackgroundColor = Color.CornflowerBlue;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.BorderColor = Color.Black;
            btnLogin.BorderRadius = 0;
            btnLogin.BorderSize = 0;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(246, 315);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(336, 60);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOGIN";
            btnLogin.TextColor = Color.White;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Notification
            // 
            Notification.AutoSize = true;
            Notification.BackColor = Color.Transparent;
            Notification.Location = new Point(221, 217);
            Notification.Name = "Notification";
            Notification.Size = new Size(205, 20);
            Notification.TabIndex = 12;
            Notification.Text = "Chào mừng bạn quay trở lại, !";
            Notification.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(Notification);
            Controls.Add(btnQuit);
            Controls.Add(btnSignup);
            Controls.Add(btnPlay);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox2);
            Controls.Add(Header);
            Controls.Add(pictureBox1);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label Header;
        private PictureBox pictureBox2;
        private CustomControls.ButtonDesign btnQuit;
        private CustomControls.ButtonDesign btnSignup;
        private CustomControls.ButtonDesign btnPlay;
        private CustomControls.ButtonDesign btnLogin;
        private Label Notification;
    }
}
