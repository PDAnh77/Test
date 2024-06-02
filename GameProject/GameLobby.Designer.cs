using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    partial class GameLobby
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
            this.ListRoom = new System.Windows.Forms.ListBox();
            this.btnReturn = new GameProject.CustomControls.ButtonDesign();
            this.btnJoinRoom = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.btnCreateRoom = new GameProject.CustomControls.ButtonDesign();
            this.txtRoomName = new GameProject.CustomControls.TextBoxDesign();
            this.Notification = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListRoom
            // 
            this.ListRoom.FormattingEnabled = true;
            this.ListRoom.ItemHeight = 16;
            this.ListRoom.Location = new System.Drawing.Point(16, 16);
            this.ListRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListRoom.Name = "ListRoom";
            this.ListRoom.Size = new System.Drawing.Size(1228, 436);
            this.ListRoom.TabIndex = 6;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReturn.BorderColor = System.Drawing.Color.Transparent;
            this.btnReturn.BorderRadius = 0;
            this.btnReturn.BorderSize = 1;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(16, 599);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(69, 60);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.TextColor = System.Drawing.Color.White;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnJoinRoom.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnJoinRoom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnJoinRoom.BorderRadius = 0;
            this.btnJoinRoom.BorderSize = 0;
            this.btnJoinRoom.FlatAppearance.BorderSize = 0;
            this.btnJoinRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinRoom.ForeColor = System.Drawing.Color.White;
            this.btnJoinRoom.Location = new System.Drawing.Point(671, 606);
            this.btnJoinRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(200, 49);
            this.btnJoinRoom.TabIndex = 8;
            this.btnJoinRoom.Text = "Join Room";
            this.btnJoinRoom.TextColor = System.Drawing.Color.White;
            this.btnJoinRoom.UseVisualStyleBackColor = false;
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
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
            this.textBoxDesign1.Location = new System.Drawing.Point(912, 615);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "";
            this.textBoxDesign1.ReadOnly = false;
            this.textBoxDesign1.Size = new System.Drawing.Size(333, 40);
            this.textBoxDesign1.TabIndex = 9;
            this.textBoxDesign1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCreateRoom.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCreateRoom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreateRoom.BorderRadius = 0;
            this.btnCreateRoom.BorderSize = 0;
            this.btnCreateRoom.FlatAppearance.BorderSize = 0;
            this.btnCreateRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnCreateRoom.Location = new System.Drawing.Point(671, 529);
            this.btnCreateRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(200, 49);
            this.btnCreateRoom.TabIndex = 10;
            this.btnCreateRoom.Text = "Create Room";
            this.btnCreateRoom.TextColor = System.Drawing.Color.White;
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtRoomName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtRoomName.BorderRadius = 0;
            this.txtRoomName.BorderSize = 2;
            this.txtRoomName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRoomName.ForeColor = System.Drawing.Color.DimGray;
            this.txtRoomName.Location = new System.Drawing.Point(911, 539);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRoomName.Multiline = false;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txtRoomName.PasswordChar = false;
            this.txtRoomName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRoomName.PlaceholderText = "";
            this.txtRoomName.ReadOnly = false;
            this.txtRoomName.Size = new System.Drawing.Size(333, 40);
            this.txtRoomName.TabIndex = 11;
            this.txtRoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRoomName.Texts = "";
            this.txtRoomName.UnderlinedStyle = false;
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.ForeColor = System.Drawing.Color.Black;
            this.Notification.Location = new System.Drawing.Point(908, 502);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(44, 16);
            this.Notification.TabIndex = 13;
            this.Notification.Text = "label2";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 673);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.btnJoinRoom);
            this.Controls.Add(this.ListRoom);
            this.Controls.Add(this.btnReturn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameLobby";
            this.Text = "GameLobby";
            this.Load += new System.EventHandler(this.GameLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.ButtonDesign btnReturn;
        private ListBox ListRoom;
        private CustomControls.ButtonDesign btnJoinRoom;
        private CustomControls.TextBoxDesign textBoxDesign1;
        private CustomControls.ButtonDesign btnCreateRoom;
        private CustomControls.TextBoxDesign txtRoomName;
        private Label Notification;
    }
}