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

namespace GameProject
{
    public partial class SendCode : Form
    {
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
                Notification.Text = "Vui lòng nhập email";
                /*textBoxDesign2.Texts = randCode;*/
            }
            else
            {
                to = (textBoxDesign1.Texts).ToString();
                from = "22520067@gm.uit.edu.vn";
                pass = "1267199463";
                content = "Mã xác minh để đặt lại mật khẩu của bạn là: " + randCode;
                try
                {
                    mess.To.Add(to);
                }
                catch
                {
                    Notification.Text = "Email không tồn tại";
                    CenterControl(Notification);
                    return;
                }
                mess.From = new MailAddress(from);
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
                    Notification.Text = $"Gửi mã xác minh thành công!";
                }
                catch (Exception ex)
                {
                    Notification.Text = ex.Message;
                }
            }
            CenterControl(Notification);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnVerify);
            if (randCode == (textBoxDesign2.Texts.Trim()))
            {
                Notification.Text = "Xác thực thành công!";

                /*int timerSeconds = 6;
                int remainingSeconds = timerSeconds;*/

                var wait = new System.Windows.Forms.Timer();
                wait.Tick += delegate
                {
                    /*remainingSeconds--;
                    Notification.Text = $"Đăng nhập thành công!\n Tự động đóng cửa sổ sau: {remainingSeconds}";
                    CenterControl(Notification);

                    if (remainingSeconds <= 0)
                    {
                        this.Close();
                    }*/

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
                Notification.Text = "Mã đặt lại không chính xác!";
            }
            CenterControl(Notification);
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

        private void BodyConfig()
        {

            Notification.Text = "";
            Notification.BackColor = Color.Transparent;

            CenterControl(textBoxDesign1);
            CenterControl(textBoxDesign2);

            SetControlImage(pictureBox1, Animation.UI_Textbox_02);
            SetControlImage(pictureBox2, Animation.UI_Textbox_02);

            CenterControl(pictureBox1);
            CenterControl(pictureBox2);
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
                    button.BackColor = Color.SandyBrown;
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
        }
    }
}
