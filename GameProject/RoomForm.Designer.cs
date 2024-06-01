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
            this.txtCurrentPlayer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new GameProject.CustomControls.ButtonDesign();
            this.btnLeaveRoom = new GameProject.CustomControls.ButtonDesign();
            this.txtOwner = new GameProject.CustomControls.TextBoxDesign();
            this.SuspendLayout();
            // 
            // txtCurrentPlayer
            // 
            this.txtCurrentPlayer.Location = new System.Drawing.Point(16, 38);
            this.txtCurrentPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrentPlayer.Name = "txtCurrentPlayer";
            this.txtCurrentPlayer.Size = new System.Drawing.Size(132, 22);
            this.txtCurrentPlayer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
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
            this.btnStart.Location = new System.Drawing.Point(851, 490);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 49);
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
            this.btnLeaveRoom.Location = new System.Drawing.Point(643, 490);
            this.btnLeaveRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeaveRoom.Name = "btnLeaveRoom";
            this.btnLeaveRoom.Size = new System.Drawing.Size(200, 49);
            this.btnLeaveRoom.TabIndex = 6;
            this.btnLeaveRoom.Text = "Leave";
            this.btnLeaveRoom.TextColor = System.Drawing.Color.White;
            this.btnLeaveRoom.UseVisualStyleBackColor = false;
            this.btnLeaveRoom.Click += new System.EventHandler(this.btnLeaveRoom_Click);
            // 
            // txtOwner
            // 
            this.txtOwner.BackColor = System.Drawing.SystemColors.Window;
            this.txtOwner.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtOwner.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtOwner.BorderRadius = 0;
            this.txtOwner.BorderSize = 2;
            this.txtOwner.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtOwner.ForeColor = System.Drawing.Color.DimGray;
            this.txtOwner.Location = new System.Drawing.Point(221, 23);
            this.txtOwner.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtOwner.Multiline = false;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txtOwner.PasswordChar = false;
            this.txtOwner.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOwner.PlaceholderText = "";
            this.txtOwner.ReadOnly = false;
            this.txtOwner.Size = new System.Drawing.Size(333, 40);
            this.txtOwner.TabIndex = 7;
            this.txtOwner.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOwner.Texts = "";
            this.txtOwner.UnderlinedStyle = false;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.btnLeaveRoom);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentPlayer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCurrentPlayer;
        private System.Windows.Forms.Label label2;
        private CustomControls.ButtonDesign btnStart;
        private CustomControls.ButtonDesign btnLeaveRoom;
        private CustomControls.TextBoxDesign txtOwner;
    }
}