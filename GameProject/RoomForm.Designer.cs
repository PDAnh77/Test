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
            this.btnStart = new GameProject.CustomControls.ButtonDesign();
            this.btnLeaveRoom = new GameProject.CustomControls.ButtonDesign();
            this.txtPlayer1 = new GameProject.CustomControls.TextBoxDesign();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayer4 = new GameProject.CustomControls.TextBoxDesign();
            this.txtPlayer2 = new GameProject.CustomControls.TextBoxDesign();
            this.txtPlayer3 = new GameProject.CustomControls.TextBoxDesign();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.txtPlayer1.Location = new System.Drawing.Point(13, 47);
            this.txtPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer1.Multiline = false;
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer1.PasswordChar = false;
            this.txtPlayer1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer1.PlaceholderText = "";
            this.txtPlayer1.ReadOnly = false;
            this.txtPlayer1.Size = new System.Drawing.Size(416, 32);
            this.txtPlayer1.TabIndex = 7;
            this.txtPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer1.Texts = "";
            this.txtPlayer1.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Người chơi 1";
            // 
            // txtPlayer4
            // 
            this.txtPlayer4.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlayer4.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPlayer4.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPlayer4.BorderRadius = 0;
            this.txtPlayer4.BorderSize = 2;
            this.txtPlayer4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPlayer4.ForeColor = System.Drawing.Color.DimGray;
            this.txtPlayer4.Location = new System.Drawing.Point(13, 294);
            this.txtPlayer4.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer4.Multiline = false;
            this.txtPlayer4.Name = "txtPlayer4";
            this.txtPlayer4.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer4.PasswordChar = false;
            this.txtPlayer4.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer4.PlaceholderText = "";
            this.txtPlayer4.ReadOnly = false;
            this.txtPlayer4.Size = new System.Drawing.Size(416, 32);
            this.txtPlayer4.TabIndex = 10;
            this.txtPlayer4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer4.Texts = "";
            this.txtPlayer4.UnderlinedStyle = false;
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
            this.txtPlayer2.Location = new System.Drawing.Point(13, 129);
            this.txtPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer2.Multiline = false;
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer2.PasswordChar = false;
            this.txtPlayer2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer2.PlaceholderText = "";
            this.txtPlayer2.ReadOnly = false;
            this.txtPlayer2.Size = new System.Drawing.Size(416, 32);
            this.txtPlayer2.TabIndex = 11;
            this.txtPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer2.Texts = "";
            this.txtPlayer2.UnderlinedStyle = false;
            // 
            // txtPlayer3
            // 
            this.txtPlayer3.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlayer3.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPlayer3.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPlayer3.BorderRadius = 0;
            this.txtPlayer3.BorderSize = 2;
            this.txtPlayer3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPlayer3.ForeColor = System.Drawing.Color.DimGray;
            this.txtPlayer3.Location = new System.Drawing.Point(13, 209);
            this.txtPlayer3.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer3.Multiline = false;
            this.txtPlayer3.Name = "txtPlayer3";
            this.txtPlayer3.Padding = new System.Windows.Forms.Padding(7);
            this.txtPlayer3.PasswordChar = false;
            this.txtPlayer3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPlayer3.PlaceholderText = "";
            this.txtPlayer3.ReadOnly = false;
            this.txtPlayer3.Size = new System.Drawing.Size(416, 32);
            this.txtPlayer3.TabIndex = 12;
            this.txtPlayer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlayer3.Texts = "";
            this.txtPlayer3.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Người chơi 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Người chơi 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 277);
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
            this.Controls.Add(this.txtPlayer3);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.txtPlayer4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.btnLeaveRoom);
            this.Controls.Add(this.btnStart);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.ButtonDesign btnStart;
        private CustomControls.ButtonDesign btnLeaveRoom;
        private CustomControls.TextBoxDesign txtPlayer1;
        private System.Windows.Forms.Label label1;
        private CustomControls.TextBoxDesign txtPlayer4;
        private CustomControls.TextBoxDesign txtPlayer2;
        private CustomControls.TextBoxDesign txtPlayer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}