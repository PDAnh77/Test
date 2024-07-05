using GameProject.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class LuatChoi : Form
    {
        PrivateFontCollection privateFonts = new PrivateFontCollection();

        private void LoadCustomFont()
        {
            // Load the Silver.ttf font [1]
            string silverFontPath = Path.Combine(Application.StartupPath, "Font/Silver.ttf");
            privateFonts.AddFontFile(silverFontPath);

            // Load the FVFFernando08.ttf font [0]
            string FVFFernando08FontPath = Path.Combine(Application.StartupPath, "Font/FVFFernando08.ttf");
            privateFonts.AddFontFile(FVFFernando08FontPath);

            foreach (Control control in Controls)
            {
                if (control is RichTextBox)
                {
                    control.Font = new Font(privateFonts.Families[1], 12f, FontStyle.Bold);
                }
                if (control is Label)
                {
                    control.Font = new Font(privateFonts.Families[0], 16f, FontStyle.Bold);
                }
            }
        }

        public LuatChoi()
        {
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_01);
            richTextBox1.ReadOnly = true;
            Color customColor = Color.FromArgb(236, 221, 192);

            richTextBox1.BackColor = customColor;
            CenterControl(pictureBox1);
            CenterControl(pictureBox2);
            CenterControl(richTextBox1);
            label1.Text = "RULE";
            SetControlImage(pictureBox1, Animation.UI_Flat_Banner_02);
            SetControlImage(pictureBox2, Animation.UI_InfoBox);
            pictureBox1.BackColor = customColor;
            pictureBox2.BackColor = customColor;
            label1.BackColor = customColor;

            label1.Parent = pictureBox1;
            label1.BringToFront();
        }

        private void CenterControl(Control control)
        {
            if (control.Parent != null)
            {
                int x = (control.Parent.ClientSize.Width - control.Width) / 2;
                control.Location = new Point(x, control.Location.Y);
            }
        }

        private void SetControlImage(Control control, Image image)
        {
            control.BackgroundImage = new Bitmap(image, control.Size);
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
