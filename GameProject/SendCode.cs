using GameProject.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Text.RegularExpressions;

namespace GameProject
{
    public partial class SendCode : Form
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;

        private void SendCode_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

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
                        control.Font = new Font(privateFonts.Families[2], 20f, FontStyle.Bold);
                    }
                }
            }
        }

        public SendCode()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_02);
            ButtonConfig();
            CenterControl(Header);
            BodyConfig();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            Login login = new Login();
            login.Show();
            this.Close();
        }

        string randCode;

        private void btnSend_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnSend);
            string from, pass, to, content;
            Random rand = new Random();
            randCode = rand.Next(999999).ToString();
            MailMessage mess = new MailMessage();
            if (string.IsNullOrEmpty(textBoxDesign1.Texts.Trim()))
            {
                ShowNotification("Vui lòng nhập email");
            }
            else
            {
                to = textBoxDesign1.Texts.Trim();
                from = "CoCaNguaVerify@gmail.com";
                pass = "gidd lexf uytb yrdb";
                content = "Mã xác minh để đặt lại mật khẩu của bạn là: " + randCode;

                if (!IsValidEmail(to))
                {
                    ShowNotification("Email không hợp lệ!");
                    CenterControl(Notification);
                    return;
                }

                if (FindAccount(to))
                {
                    mess.To.Add(to);
                    mess.From = new MailAddress(from, "CoCaNgua@gmail.com");
                    mess.Body = content;
                    mess.Subject = "Mã xác minh";

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(mess);
                        ShowNotification($"Gửi mã xác minh thành công!");
                    }
                    catch (Exception ex)
                    {
                        ShowNotification(ex.Message);
                    }
                    CenterControl(Notification);
                }
                else
                {
                    ShowNotification("Email này không tồn tại\nVui lòng đăng ký tài khoản!");
                    CenterControl(Notification);
                }
            }
        }

        private bool FindAccount(string email)
        {
            FirebaseResponse response = client.Get(@"Information");
            var allUsers = response.ResultAs<Dictionary<string, User>>();
            if (allUsers != null)
            {
                foreach (var user in allUsers.Values)
                {
                    if (user.Email.Equals(email))
                    {
                        User.ResetpassUser = user;
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

        private void btnVerify_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnVerify);
            if (randCode == textBoxDesign2.Texts.Trim())
            {
                ShowNotification("Xác thực thành công!");
                var wait = new System.Windows.Forms.Timer();
                wait.Tick += delegate
                {
                    ResetPass resetPass = new ResetPass();
                    resetPass.Show();
                    wait.Stop();
                    this.Close();
                };
                wait.Interval = (int)TimeSpan.FromSeconds(1.5).TotalMilliseconds;
                wait.Start();
            }
            else
            {
                ShowNotification("Mã đặt lại không chính xác!");
            }
            CenterControl(Notification);
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
            if (control.Name == "btnSend" || control.Name == "btnVerify")
            {
                return;
            }
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