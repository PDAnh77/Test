namespace GameProject
{
    partial class RoomForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new GameProject.CustomControls.ButtonDesign();
            this.btnLeaveRoom = new GameProject.CustomControls.ButtonDesign();
            this.txtPlayer1 = new GameProject.CustomControls.TextBoxDesign();
            this.txtCurrentPlay = new GameProject.CustomControls.TextBoxDesign();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.txtPlayer2 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign3 = new GameProject.CustomControls.TextBoxDesign();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số người chơi";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnStart.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStart.BorderRadius = 20;
            this.btnStart.BorderSize = 0;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(638, 398);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 40);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.TextColor = System.Drawing.Color.White;
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnLeaveRoom
            // 
            this.btnLeaveRoom.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLeaveRoom.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLeaveRoom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLeaveRoom.BorderRadius = 20;
            this.btnLeaveRoom.BorderSize = 0;
            this.btnLeaveRoom.FlatAppearance.BorderSize = 0;
            this.btnLeaveRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveRoom.ForeColor = System.Drawing.Color.White;
            this.btnLeaveRoom.Location = new System.Drawing.Point(482, 398);
            this.btnLeaveRoom.Name = "btnLeaveRoom";
            this.btnLeaveRoom.Size = new System.Drawing.Size(150, 40);
            this.btnLeaveRoom.TabIndex = 6;
            this.btnLeaveRoom.Text = "Leave";
            this.btnLeaveRoom.TextColor = System.Drawing.Color.White;
            this.btnLeaveRoom.UseVisualStyleBackColor = false;
            this.btnLeaveRoom.Click += new System.EventHandler(this.btnLeaveRoom_Click);
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlayer1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPlayer1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPlayer1.BorderRadius = 0;
            this.txtPlayer1.BorderSize = 2;
            this.txtPlayer1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPlayer1.ForeColor = System.Drawing.Color.DimGray;
            this.txtPlayer1.Location = new System.Drawing.Point(120, 31);
            this.txtPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer1.Multiline = false;
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer1.PasswordChar = false;
            this.txtPlayer1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer1.PlaceholderText = "";
            this.txtPlayer1.ReadOnly = false;
            this.txtPlayer1.Size = new System.Drawing.Size(92, 32);
            this.txtPlayer1.TabIndex = 7;
            this.txtPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer1.Texts = "";
            this.txtPlayer1.UnderlinedStyle = false;
            // 
            // txtCurrentPlay
            // 
            this.txtCurrentPlay.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentPlay.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCurrentPlay.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCurrentPlay.BorderRadius = 0;
            this.txtCurrentPlay.BorderSize = 2;
            this.txtCurrentPlay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCurrentPlay.ForeColor = System.Drawing.Color.DimGray;
            this.txtCurrentPlay.Location = new System.Drawing.Point(12, 31);
            this.txtCurrentPlay.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrentPlay.Multiline = false;
            this.txtCurrentPlay.Name = "txtCurrentPlay";
            this.txtCurrentPlay.Padding = new System.Windows.Forms.Padding(7);
            this.txtCurrentPlay.PasswordChar = false;
            this.txtCurrentPlay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentPlay.PlaceholderText = "";
            this.txtCurrentPlay.ReadOnly = false;
            this.txtCurrentPlay.Size = new System.Drawing.Size(69, 32);
            this.txtCurrentPlay.TabIndex = 8;
            this.txtCurrentPlay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCurrentPlay.Texts = "";
            this.txtCurrentPlay.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Người chơi 1";
            // 
            // textBoxDesign1
            // 
            this.textBoxDesign1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDesign1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxDesign1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxDesign1.BorderRadius = 0;
            this.textBoxDesign1.BorderSize = 2;
            this.textBoxDesign1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign1.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxDesign1.Location = new System.Drawing.Point(120, 278);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "";
            this.textBoxDesign1.ReadOnly = false;
            this.textBoxDesign1.Size = new System.Drawing.Size(92, 32);
            this.textBoxDesign1.TabIndex = 10;
            this.textBoxDesign1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlayer2.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPlayer2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPlayer2.BorderRadius = 0;
            this.txtPlayer2.BorderSize = 2;
            this.txtPlayer2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPlayer2.ForeColor = System.Drawing.Color.DimGray;
            this.txtPlayer2.Location = new System.Drawing.Point(120, 113);
            this.txtPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer2.Multiline = false;
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer2.PasswordChar = false;
            this.txtPlayer2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer2.PlaceholderText = "";
            this.txtPlayer2.ReadOnly = false;
            this.txtPlayer2.Size = new System.Drawing.Size(92, 32);
            this.txtPlayer2.TabIndex = 11;
            this.txtPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer2.Texts = "";
            this.txtPlayer2.UnderlinedStyle = false;
            // 
            // textBoxDesign3
            // 
            this.textBoxDesign3.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDesign3.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxDesign3.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxDesign3.BorderRadius = 0;
            this.textBoxDesign3.BorderSize = 2;
            this.textBoxDesign3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign3.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxDesign3.Location = new System.Drawing.Point(120, 193);
            this.textBoxDesign3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign3.Multiline = false;
            this.textBoxDesign3.Name = "textBoxDesign3";
            this.textBoxDesign3.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign3.PasswordChar = false;
            this.textBoxDesign3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign3.PlaceholderText = "";
            this.textBoxDesign3.ReadOnly = false;
            this.textBoxDesign3.Size = new System.Drawing.Size(92, 32);
            this.textBoxDesign3.TabIndex = 12;
            this.textBoxDesign3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign3.Texts = "";
            this.textBoxDesign3.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Người chơi 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Người chơi 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Người chơi 4";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDesign3);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentPlay);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.btnLeaveRoom);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private CustomControls.ButtonDesign btnStart;
        private CustomControls.ButtonDesign btnLeaveRoom;
        private CustomControls.TextBoxDesign txtPlayer1;
        private CustomControls.TextBoxDesign txtCurrentPlay;
        private System.Windows.Forms.Label label1;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.TextBoxDesign txtPlayer2;
        private CustomControls.TextBoxDesign textBoxDesign3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}