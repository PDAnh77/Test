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
            this.Notification = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRoomName = new GameProject.CustomControls.TextBoxDesign();
            this.btnCreateRoom = new GameProject.CustomControls.ButtonDesign();
            this.btnReturn = new GameProject.CustomControls.ButtonDesign();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new GameProject.CustomControls.ButtonDesign();
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.ForeColor = System.Drawing.Color.Black;
            this.Notification.Location = new System.Drawing.Point(821, 487);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(44, 16);
            this.Notification.TabIndex = 13;
            this.Notification.Text = "label2";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(824, 523);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 69);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // txtRoomName
            // 
            this.txtRoomName.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomName.BorderColor = System.Drawing.Color.Transparent;
            this.txtRoomName.BorderFocusColor = System.Drawing.Color.Black;
            this.txtRoomName.BorderRadius = 0;
            this.txtRoomName.BorderSize = 2;
            this.txtRoomName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRoomName.ForeColor = System.Drawing.Color.Black;
            this.txtRoomName.Location = new System.Drawing.Point(856, 535);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(5);
            this.txtRoomName.Multiline = false;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Padding = new System.Windows.Forms.Padding(9);
            this.txtRoomName.PasswordChar = false;
            this.txtRoomName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRoomName.PlaceholderText = "Tên phòng";
            this.txtRoomName.ReadOnly = false;
            this.txtRoomName.Size = new System.Drawing.Size(353, 40);
            this.txtRoomName.TabIndex = 15;
            this.txtRoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRoomName.Texts = "";
            this.txtRoomName.UnderlinedStyle = false;
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
            this.btnCreateRoom.Location = new System.Drawing.Point(1045, 598);
            this.btnCreateRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(200, 49);
            this.btnCreateRoom.TabIndex = 10;
            this.btnCreateRoom.Text = "Create Room";
            this.btnCreateRoom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateRoom.TextColor = System.Drawing.Color.White;
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(12, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1237, 443);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRefresh.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRefresh.BorderRadius = 0;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(29, 454);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(145, 49);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(29, 30);
            this.flowLayoutPanelRooms.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(1200, 407);
            this.flowLayoutPanelRooms.TabIndex = 19;
            // 
            // GameLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.btnReturn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameLobby";
            this.Text = "GameLobby";
            this.Load += new System.EventHandler(this.GameLobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.ButtonDesign btnReturn;
        private CustomControls.ButtonDesign btnCreateRoom;
        private Label Notification;
        private PictureBox pictureBox1;
        private CustomControls.TextBoxDesign txtRoomName;
        private PictureBox pictureBox2;
        private CustomControls.ButtonDesign btnRefresh;
        private FlowLayoutPanel flowLayoutPanelRooms;
    }
}