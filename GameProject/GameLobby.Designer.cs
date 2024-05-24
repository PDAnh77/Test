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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnFindRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.btnReturn = new GameProject.CustomControls.ButtonDesign();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(707, 402);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(152, 20);
            this.txtIP.TabIndex = 3;
            // 
            // btnFindRoom
            // 
            this.btnFindRoom.Location = new System.Drawing.Point(707, 428);
            this.btnFindRoom.Name = "btnFindRoom";
            this.btnFindRoom.Size = new System.Drawing.Size(152, 40);
            this.btnFindRoom.TabIndex = 4;
            this.btnFindRoom.Text = "Tìm phòng";
            this.btnFindRoom.UseVisualStyleBackColor = true;
            this.btnFindRoom.Click += new System.EventHandler(this.btnFindRoom_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(555, 428);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(136, 40);
            this.btnCreateRoom.TabIndex = 5;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
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
            this.btnReturn.Location = new System.Drawing.Point(9, 488);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(52, 49);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.TextColor = System.Drawing.Color.White;
            this.btnReturn.UseVisualStyleBackColor = false;
            // 
            // GameLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.btnFindRoom);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnReturn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GameLobby";
            this.Text = "GameLobby";
            this.Shown += new System.EventHandler(this.GameLobby_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.ButtonDesign btnReturn;
        private TextBox txtIP;
        private Button btnFindRoom;
        private Button btnCreateRoom;
    }
}