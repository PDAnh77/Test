namespace GameProject
{
    partial class History
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonDesign1 = new GameProject.CustomControls.ButtonDesign();
            this.buttonDesign2 = new GameProject.CustomControls.ButtonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colTime,
            this.colResult,
            this.colPlayer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Diễn ra";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 125;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Thời gian";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 125;
            // 
            // colResult
            // 
            this.colResult.HeaderText = "Kết quả";
            this.colResult.MinimumWidth = 6;
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 125;
            // 
            // colPlayer
            // 
            this.colPlayer.HeaderText = "Người tham gia";
            this.colPlayer.MinimumWidth = 6;
            this.colPlayer.Name = "colPlayer";
            this.colPlayer.Width = 125;
            // 
            // buttonDesign1
            // 
            this.buttonDesign1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDesign1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDesign1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDesign1.BorderRadius = 20;
            this.buttonDesign1.BorderSize = 0;
            this.buttonDesign1.FlatAppearance.BorderSize = 0;
            this.buttonDesign1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesign1.ForeColor = System.Drawing.Color.White;
            this.buttonDesign1.Location = new System.Drawing.Point(12, 398);
            this.buttonDesign1.Name = "buttonDesign1";
            this.buttonDesign1.Size = new System.Drawing.Size(150, 40);
            this.buttonDesign1.TabIndex = 1;
            this.buttonDesign1.Text = "Quay lại";
            this.buttonDesign1.TextColor = System.Drawing.Color.White;
            this.buttonDesign1.UseVisualStyleBackColor = false;
            // 
            // buttonDesign2
            // 
            this.buttonDesign2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDesign2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDesign2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDesign2.BorderRadius = 20;
            this.buttonDesign2.BorderSize = 0;
            this.buttonDesign2.FlatAppearance.BorderSize = 0;
            this.buttonDesign2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesign2.ForeColor = System.Drawing.Color.White;
            this.buttonDesign2.Location = new System.Drawing.Point(638, 398);
            this.buttonDesign2.Name = "buttonDesign2";
            this.buttonDesign2.Size = new System.Drawing.Size(150, 40);
            this.buttonDesign2.TabIndex = 2;
            this.buttonDesign2.Text = "Tải lại";
            this.buttonDesign2.TextColor = System.Drawing.Color.White;
            this.buttonDesign2.UseVisualStyleBackColor = false;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDesign2);
            this.Controls.Add(this.buttonDesign1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.ButtonDesign buttonDesign1;
        private CustomControls.ButtonDesign buttonDesign2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPlayer;
    }
}