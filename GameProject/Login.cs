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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Login : Form
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

        public Login()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_02);
            ButtonConfig();
            CenterControl(Header);
            BodyConfig();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLogin);

            string usrname = textBoxDesign1.Texts.Trim();
            string pass = textBoxDesign2.Texts;

            if (string.IsNullOrWhiteSpace(usrname) || string.IsNullOrWhiteSpace(pass.Trim()))
            {
                ShowNotification("Vui lòng nhập thông tin đăng nhập!");
                CenterControl(Notification);
                return;
            }

            try
            {
                FirebaseResponse response = await client.GetAsync("Information/" + usrname);
                if (response.Body != "null")
                {
                    User ResUser = response.ResultAs<User>(); // User data retrieved from database

                    User CurUser = new User()
                    {
                        Username = usrname,
                        Password = pass
                    };

                    //if (ResUser.isLogin == true)
                    //{
                    //    ShowNotification("Tài khoản đã đăng nhập ở nơi khác!");
                    //    return;
                    //}

                    if (User.IsEqual(ResUser, CurUser))
                    {
                        ShowNotification("Đăng nhập thành công!");
                        CenterControl(Notification);
                        ResUser.isLogin = true;
                        SetResponse request = await client.SetAsync("Information/" + usrname, ResUser);
                        User.CurrentUser = ResUser;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowNotification("Mật khẩu không chính xác!");
                    }
                }
                else
                {
                    ShowNotification("Tên đăng nhập không tồn tại!");
                }
                CenterControl(Notification);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturnHome);
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendCode sendCode = new SendCode();
            sendCode.Show();
            this.Close();
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

            ShowNotification("");
            Notification.BackColor = Color.Transparent;

            CenterControl(textBoxDesign1);
            CenterControl(textBoxDesign2);

            SetControlImage(pictureBox1, Animation.UI_Textbox_02);
            SetControlImage(pictureBox2, Animation.UI_Textbox_02);

            CenterControl(pictureBox1);
            CenterControl(pictureBox2);

            textBoxDesign1.BackColor = customColor;
            textBoxDesign2.BackColor = customColor;
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