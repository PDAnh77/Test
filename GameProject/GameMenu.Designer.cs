namespace GameProject
{
    partial class GameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_TaoPhong = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbIDPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Vao = new System.Windows.Forms.Button();
            this.lbNameMN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // btn_TaoPhong
            // 
            this.btn_TaoPhong.Location = new System.Drawing.Point(612, 228);
            this.btn_TaoPhong.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TaoPhong.Name = "btn_TaoPhong";
            this.btn_TaoPhong.Size = new System.Drawing.Size(257, 38);
            this.btn_TaoPhong.TabIndex = 2;
            this.btn_TaoPhong.Text = "Tạo phòng";
            this.btn_TaoPhong.UseVisualStyleBackColor = true;
            this.btn_TaoPhong.Click += new System.EventHandler(this.btn_TaoPhong_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(612, 304);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Luật chơi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbIDPhong
            // 
            this.txbIDPhong.Location = new System.Drawing.Point(579, 453);
            this.txbIDPhong.Margin = new System.Windows.Forms.Padding(4);
            this.txbIDPhong.Multiline = true;
            this.txbIDPhong.Name = "txbIDPhong";
            this.txbIDPhong.Size = new System.Drawing.Size(212, 35);
            this.txbIDPhong.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Peru;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 453);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID Phòng:";
            // 
            // btn_Vao
            // 
            this.btn_Vao.Location = new System.Drawing.Point(829, 453);
            this.btn_Vao.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Vao.Name = "btn_Vao";
            this.btn_Vao.Size = new System.Drawing.Size(111, 36);
            this.btn_Vao.TabIndex = 6;
            this.btn_Vao.Text = "Vào";
            this.btn_Vao.UseVisualStyleBackColor = true;
            this.btn_Vao.VisibleChanged += new System.EventHandler(this.button3_VisibleChanged);
            this.btn_Vao.Click += new System.EventHandler(this.btn_Vao_Click);
            // 
            // lbNameMN
            // 
            this.lbNameMN.AutoSize = true;
            this.lbNameMN.BackColor = System.Drawing.Color.Peru;
            this.lbNameMN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameMN.Location = new System.Drawing.Point(617, 25);
            this.lbNameMN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNameMN.Name = "lbNameMN";
            this.lbNameMN.Size = new System.Drawing.Size(67, 29);
            this.lbNameMN.TabIndex = 7;
            this.lbNameMN.Text = "Tên:";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 523);
            this.Controls.Add(this.lbNameMN);
            this.Controls.Add(this.btn_Vao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbIDPhong);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_TaoPhong);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_TaoPhong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbIDPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Vao;
        private System.Windows.Forms.Label lbNameMN;
    }
}