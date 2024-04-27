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
            btnLogin = new CustomControls.ButtonDesign();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBoxDesign2 = new CustomControls.TextBoxDesign();
            textBoxDesign1 = new CustomControls.TextBoxDesign();
            btnReturnHome = new CustomControls.ButtonDesign();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumSlateBlue;
            btnLogin.BackgroundColor = Color.MediumSlateBlue;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.BorderColor = Color.PaleVioletRed;
            btnLogin.BorderRadius = 0;
            btnLogin.BorderSize = 0;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(74, 488);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(252, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.White;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(170, 70);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 4;
            label1.Text = "LOGIN";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(30, 360);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 95);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(31, 249);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(344, 95);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
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
            textBoxDesign2.Location = new Point(44, 379);
            textBoxDesign2.Margin = new Padding(4);
            textBoxDesign2.Multiline = false;
            textBoxDesign2.Name = "textBoxDesign2";
            textBoxDesign2.Padding = new Padding(7);
            textBoxDesign2.PasswordChar = true;
            textBoxDesign2.PlaceholderColor = Color.DarkGray;
            textBoxDesign2.PlaceholderText = "Mật khẩu";
            textBoxDesign2.Size = new Size(286, 36);
            textBoxDesign2.TabIndex = 9;
            textBoxDesign2.Texts = "";
            textBoxDesign2.UnderlinedStyle = false;
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
            textBoxDesign1.Location = new Point(44, 268);
            textBoxDesign1.Margin = new Padding(4);
            textBoxDesign1.Multiline = false;
            textBoxDesign1.Name = "textBoxDesign1";
            textBoxDesign1.Padding = new Padding(7);
            textBoxDesign1.PasswordChar = false;
            textBoxDesign1.PlaceholderColor = Color.DarkGray;
            textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            textBoxDesign1.Size = new Size(286, 36);
            textBoxDesign1.TabIndex = 10;
            textBoxDesign1.Texts = "";
            textBoxDesign1.UnderlinedStyle = false;
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
            btnReturnHome.Location = new Point(74, 548);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(252, 50);
            btnReturnHome.TabIndex = 11;
            btnReturnHome.Text = "Return home";
            btnReturnHome.TextColor = Color.White;
            btnReturnHome.UseVisualStyleBackColor = false;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(432, 673);
            Controls.Add(btnReturnHome);
            Controls.Add(textBoxDesign1);
            Controls.Add(textBoxDesign2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomControls.ButtonDesign btnLogin;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private CustomControls.TextBoxDesign textBoxDesign2;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.ButtonDesign btnReturnHome;
    }
}