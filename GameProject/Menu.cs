using FireSharp.Config;
using FireSharp.Interfaces;
using System.Drawing.Text;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Menu : Form
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
                    if (control.Name == "Notification") // Check if the control is label1
                    {
                        control.Font = new Font(privateFonts.Families[0], 12f, FontStyle.Bold);
                    }
                    else
                    {
                        control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                    }
                }
            }
        }

        private bool WelcomeMessage()
        {
            if (Data.CurrentUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Menu()
        {
            InitializeComponent();
            // Set the form's border style to FixedSingle to make it not resizable
            FormBorderStyle = FormBorderStyle.FixedSingle;
            SetControlImage(this, Animation.UI_Menu);
            LoadCustomFont();

            HeaderConfig();
            BodyConfig();
        }

        Login loginForm;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLogin);
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new Login();
                loginForm.FormClosed += Login_FormClosed;
                loginForm.Show();
            }
            else // If login menu already opened
            {
                loginForm.BringToFront();
            }
        }

        private void Login_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (loginForm != null && loginForm.DialogResult == DialogResult.OK)
            {
                if (WelcomeMessage() == true)
                {
                    Notification.Text = "Chào mừng bạn quay trở lại, " + Data.CurrentUser.Username + "!";
                    CenterControl(Notification);
                }
            }
        }

        Signup signupForm;

        private void btnSignup_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnSignup);
            if (signupForm == null || signupForm.IsDisposed)
            {
                signupForm = new Signup();
                signupForm.Show();
            }
            else // If signup menu already opened
            {
                signupForm.BringToFront();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnPlay);
            if (WelcomeMessage() == true)
            {
                /*MessageBox.Show("Chào mừng bạn quay trở lại, " + Data.CurrentUser.Username + "!");*/
                DialogResult = DialogResult.OK;
            }
            else
            {
                Notification.Text = "Bạn cần đăng nhập vào tài khoản trước!";
            }
            CenterControl(Notification);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnQuit);
            Application.Exit();
        }

        private void PlayAnimation(Control control)
        {
            if (control is Button button)
            {
                Thread animationThread = new Thread(() => ButtonAnimation(button));
                animationThread.Start();
                animationThread.Join();
            }
        }

        private void ButtonAnimation(Button button)
        {
            int delay = 70;
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
        }

        private void HeaderConfig()
        {
            CenterControl(pictureBox1);
            Header.Parent = pictureBox1;
            Header.BringToFront();
            SetControlImage(pictureBox1, Animation.UI_Flat_Banner_03);
        }

        private void BodyConfig()
        {
            CenterControl(Notification);
            Notification.ForeColor = Color.White;

            SetControlImage(pictureBox2, Animation.UI_Menu_Border);
            CenterControl(pictureBox2);
            ButtonConfig();
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    CenterControl(button);
                    SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.SaddleBrown;
                }
            }
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
