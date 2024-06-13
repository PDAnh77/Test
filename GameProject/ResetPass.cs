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
    public partial class ResetPass : Form
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;

        private void ResetPass_Load(object sender, EventArgs e)
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
                        control.Font = new Font(privateFonts.Families[2], 24f, FontStyle.Bold);
                    }
                }
            }
        }

        public ResetPass()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_02);
            ButtonConfig();
            CenterControl(Header);
            BodyConfig();
        }

        private void ResetPass_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReset);

            string usrname = User.ResetpassUser.Username;
            string pass = textBoxDesign1.Texts;
            string passconf = textBoxDesign2.Texts;

            foreach (Control x in Controls)
            {
                if (x is TextBoxDesign && string.IsNullOrWhiteSpace(((TextBoxDesign)x).Texts.Trim()))
                {
                    ShowNotification("Vui lòng nhập đầy đủ thông tin!");
                    CenterControl(Notification);
                    return;
                }
            }

            try
            {
                FirebaseResponse response1 = client.Get(@"Information/" + usrname);
                if (response1.Body != "null")
                {
                if (pass == passconf)
                {
                    User.ResetpassUser.Password = pass;
                    User data = User.ResetpassUser;

                    SetResponse response = await client.SetAsync("Information/" + usrname, data);
                    ShowNotification("Cập nhật mật khẩu thành công!");

                    var wait = new System.Windows.Forms.Timer();
                    wait.Tick += delegate
                    {
                            remainingSeconds--;
                            Notification.Text = $"Cập nhật mật khẩu mới thành công!\n Tự động đóng cửa sổ sau: {remainingSeconds}";
                            CenterControl(Notification);

                            if (remainingSeconds <= 0)
                            {
                        Login login = new Login();
                        login.Show();
                        wait.Stop();
                        this.Close();
                            }
                    };
                    wait.Interval = (int)TimeSpan.FromSeconds(2).TotalMilliseconds;
                    wait.Start();
                }
                    else
                    {
                        Notification.Text = "Mật khẩu nhập lại không chính xác!";
                    }
                }
                else
                {
                    ShowNotification("Mật khẩu nhập lại không chính xác!");
                }
                CenterControl(Notification);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            Login login = new Login();
            login.Show();
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
            CenterControl(textBoxDesign3);

            SetControlImage(pictureBox1, Animation.UI_Textbox_02);
            SetControlImage(pictureBox2, Animation.UI_Textbox_02);
            SetControlImage(pictureBox3, Animation.UI_Textbox_02);

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
