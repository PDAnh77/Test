using FirebaseAdmin.Messaging;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Menu : Form
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;

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
                    if (control.Name == "Notification")
                    {
                        control.Font = new Font(privateFonts.Families[0], 12f, FontStyle.Bold);
                    }
                    else // Header
                    {
                        control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                    }
                }
            }
        }

        System.Windows.Forms.Timer userCheckTimer;

        private void InitializeUserCheckTimer()
        {
            userCheckTimer = new System.Windows.Forms.Timer();
            userCheckTimer.Interval = 1000; // Check every second
            userCheckTimer.Tick += UserCheckTimer_Tick; // Check if any user exists
            userCheckTimer.Start();
        }

        private bool CheckCurrentUser()
        {
            if (User.CurrentUser != null) { return true; }
            else { return false; }
        }

        private void UserCheckTimer_Tick(object sender, EventArgs e)
        {
            if (CheckCurrentUser())
            {
                if (User.CurrentUser != null)
                {
                    ShowNotification("Chào mừng bạn quay trở lại, " + User.CurrentUser.Username + "!");
                    CenterControl(Notification);
                    userCheckTimer.Stop();
                }
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

            InitializeUserCheckTimer();

            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

        Login loginForm;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLogin);
            if (User.CurrentUser != null)
            {
                ShowNotification("Vui lòng đăng xuất tài khoản trước!");
                CenterControl(Notification);
                return;
            }

            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new Login();
                loginForm.Show();
            }
            else // If login menu already opened
            {
                loginForm.BringToFront();
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
            if (CheckCurrentUser() == true)
            {
                // Create a list to store forms that need to be closed
                List<Form> formsToClose = new List<Form>();

                // Identify forms that need to be closed
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is Login || openForm is Signup || openForm is UserProfile)
                    {
                        formsToClose.Add(openForm);
                    }
                }

                // Close identified forms
                foreach (Form form in formsToClose)
                {
                    form.Close();
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                ShowNotification("Bạn cần đăng nhập vào tài khoản trước!");
            }
            CenterControl(Notification);
        }

        private async void btnQuit_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnQuit);
            if (User.CurrentUser != null)
            {
                User.CurrentUser.isLogin = false;
                SetResponse request = await client.SetAsync("Information/" + User.CurrentUser.Username, User.CurrentUser);
            }
            Application.Exit();
        }

        UserProfile userprofileForm;

        private void btnProfile_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnProfile);
            if (CheckCurrentUser() == true)
            {
                if (userprofileForm == null || userprofileForm.IsDisposed)
                {
                    userprofileForm = new UserProfile();
                    userprofileForm.Show();
                }
                else // If userprofile menu already opened
                {
                    userprofileForm.BringToFront();
                }
            }
            else
            {
                ShowNotification("Bạn cần đăng nhập vào tài khoản trước!");
            }
            CenterControl(Notification);
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLogout);
            if (User.CurrentUser != null)
            {
                User.CurrentUser.isLogin = false;
                //SetResponse request = await client.SetAsync("Information/" + User.CurrentUser.Username, User.CurrentUser);
                User.CurrentUser = null;
                ShowNotification("Đăng xuất tài khoản thành công!");
                CenterControl(Notification);
                userCheckTimer.Start();
            }
        }

        delegate void PrintDelegate(string text);

        private void ShowNotification(string text)
        {
            if (Notification.InvokeRequired)
            {
                PrintDelegate d = new PrintDelegate(ShowNotification);
                Notification.Invoke(d, new object[] { text });
            }
            else
            {
                Notification.Text = text;
            }
        }

        private void PlayAnimation(Control control) // Manage all control animation
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
            if (button.Name == "btnProfile")
            {
                SetControlImage(button, Animation.UI_Flat_Profile_Button_Press_01a2);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Profile_Button_Press_01a3);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Profile_Button_Press_01a4);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Profile_Button_Press_01a1);
            }
            else if (button.Name == "btnLogout")
            {
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_02a2);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_02a3);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_02a4);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_02a1);
            }
            else
            {
                SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a2);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a3);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a4);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
            }
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
                    Color customColor01 = Color.FromArgb(63, 40, 50);
                    Color customColor02 = Color.FromArgb(181, 119, 94);
                    if (button.Name == "btnProfile")
                    {
                        SetControlImage(button, Animation.UI_Flat_Profile_Button_Press_01a1);
                        button.BackColor = customColor02;
                    }
                    else if (button.Name == "btnLogout")
                    {
                        SetControlImage(button, Animation.UI_Flat_Button_Small_Press_02a1);
                        button.BackColor = customColor02;
                    }
                    else // other buttons
                    {
                        CenterControl(button);
                        SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                        button.BackColor = customColor01;
                    }
                    button.ForeColor = Color.Black;
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
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}