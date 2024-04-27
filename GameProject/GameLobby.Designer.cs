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
            btnReturn = new CustomControls.ButtonDesign();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.Transparent;
            btnReturn.BackgroundColor = Color.Transparent;
            btnReturn.BorderColor = Color.Transparent;
            btnReturn.BorderRadius = 0;
            btnReturn.BorderSize = 1;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(12, 601);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(69, 60);
            btnReturn.TabIndex = 2;
            btnReturn.TextColor = Color.White;
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // GameLobby
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(btnReturn);
            ForeColor = SystemColors.ControlText;
            Name = "GameLobby";
            Text = "GameLobby";
            ResumeLayout(false);
        }

        #endregion
        private CustomControls.ButtonDesign btnReturn;
    }
}