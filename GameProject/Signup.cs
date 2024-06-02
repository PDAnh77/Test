using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GameProject.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Signup : Form
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

            // Load the smolExtended.ttf font
            string smolExtendedFontPath = Path.Combine(Application.StartupPath, "Font/smolExtended.ttf");
            privateFonts.AddFontFile(smolExtendedFontPath);

            // Load the FVFFernando08.ttf font
            string FVFFernando08FontPath = Path.Combine(Application.StartupPath, "Font/FVFFernando08.ttf");
            privateFonts.AddFontFile(FVFFernando08FontPath);

            foreach (Control control in Controls)
            {
                if (control is Button || control is TextBoxDesign)
                {
                    control.Font = new Font(privateFonts.Families[1], 20f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    if (control.Name == "Notification")
                    {
                        control.Font = new Font(privateFonts.Families[0], 8f, FontStyle.Bold);
                    }
                    else if (control.Name == "linkLabel1")
                    {
                        control.Font = new Font(privateFonts.Families[2], 12f, FontStyle.Bold);
                    }
                    else // Header
                    {
                        control.Font = new Font(privateFonts.Families[2], 26f, FontStyle.Bold);
                    }
                }
            }
        }

        public Signup()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_02);
            ButtonConfig();
            CenterControl(Header);
            BodyConfig();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

        private async void btnSignup_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnSignup);

            foreach (Control x in Controls)
            {
                if (x is TextBoxDesign && string.IsNullOrWhiteSpace(((TextBoxDesign)x).Texts.Trim()))
                {
                    Notification.Text = "Vui lòng nhập đầy đủ thông tin!";
                    CenterControl(Notification);
                    return;
                }
            }

            string usrname = textBoxDesign1.Texts.Trim();
            string email = textBoxDesign2.Texts.Trim();
            string pass = textBoxDesign3.Texts;
            string passConfirm = textBoxDesign4.Texts;

            if (!IsValidEmail(email))
            {
                Notification.Text = "Email không hợp lệ!";
                CenterControl(Notification);
                return;
            }

            if (CheckAccountExists(usrname, email) == false)
            {
                if (pass == passConfirm)
                {
                    var data = new User
                    {
                        Username = usrname,
                        Email = email,
                        Password = pass
                    };

                    SetResponse response = await client.SetAsync("Information/" + usrname, data);
                    User result = response.ResultAs<User>();

                    Notification.Text = $"Đăng ký tài khoản: {result.Username} thành công!";

                    int timerSeconds = 3; // Countdown timer
                    int remainingSeconds = timerSeconds;
                    var wait = new System.Windows.Forms.Timer();

                    wait.Tick += delegate
                    {                      
                        if (remainingSeconds == 0)
                        {
                            this.Close();
                        }
                        else
                        {
                            Notification.Text = $"Đăng ký tài khoản: {result.Username} thành công!\n Tự động đóng cửa sổ sau: {remainingSeconds}";
                            remainingSeconds--;
                            CenterControl(Notification);
                        }
                    };
                    wait.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
                    wait.Start();
                }
                else
                {
                    Notification.Text = "Mật khẩu nhập lại không chính xác!";
                }
            }
            CenterControl(Notification);
        }

        private bool CheckAccountExists(string usrname, string email) // Check if account exists
        {
            FirebaseResponse response = client.Get(@"Information");
            var allUsers = response.ResultAs<Dictionary<string, User>>();
            if(allUsers != null)
            {
                foreach(var user in allUsers.Values)
                {
                    if (user.Email.Equals(email))
                    {
                        Notification.Text = "Email đã tồn tại!";
                        return true;
                    }
                    if (user.Username.Equals(usrname))
                    {
                        Notification.Text = "Tên đăng nhập đã tồn tại!";
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturnHome);
            this.Close();
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

        Color customColor = Color.FromArgb(234, 212, 172);

        private void BodyConfig()
        {
            Notification.Text = "";
            Notification.BackColor = Color.Transparent;

            CenterControl(textBoxDesign1);
            CenterControl(textBoxDesign2);
            CenterControl(textBoxDesign3);
            CenterControl(textBoxDesign4);

            SetControlImage(pictureBox1, Animation.UI_Textbox_02);
            SetControlImage(pictureBox2, Animation.UI_Textbox_02);
            SetControlImage(pictureBox3, Animation.UI_Textbox_02);
            SetControlImage(pictureBox4, Animation.UI_Textbox_02);

            CenterControl(pictureBox1);
            CenterControl(pictureBox2);
            CenterControl(pictureBox3);
            CenterControl(pictureBox4);

            textBoxDesign1.BackColor = customColor;
            textBoxDesign2.BackColor = customColor;
            textBoxDesign3.BackColor = customColor;
            textBoxDesign4.BackColor = customColor;
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
                    button.BackColor = customColor;
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
