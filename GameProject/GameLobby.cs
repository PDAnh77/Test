using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class GameLobby : Form
    {
        PrivateFontCollection privateFonts = new PrivateFontCollection();

        private void LoadCustomFont()
        {
            // Load the Silver.ttf font
            string silverFontPath = Path.Combine(Application.StartupPath, "Font/Silver.ttf");
            privateFonts.AddFontFile(silverFontPath);

            // Load the FVFFernando08.ttf font
            string FVFFernando08FontPath = Path.Combine(Application.StartupPath, "Font/FVFFernando08.ttf");
            privateFonts.AddFontFile(FVFFernando08FontPath);

            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    control.Font = new Font(privateFonts.Families[1], 20f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                }
            }
        }

        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();

            ButtonConfig();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Thread animationThread = new Thread(() => PlayButtonAnimation(btnReturn));
            animationThread.Start();
            animationThread.Join();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Thread animationThread = new Thread(() => PlayButtonAnimation(button));
                animationThread.Start();
            }
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    /*CenterControl(button);*/
                    SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
                    button.ForeColor = Color.Transparent;
                    button.BackColor = Color.Transparent;
                    button.Click += Button_Click;
                }
            }
        }

        private void PlayButtonAnimation(Button button)
        {
            int delay = 70;
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
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
        }
    }
}
