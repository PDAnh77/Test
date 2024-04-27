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
using System.Linq;
using System.Text;
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

            foreach (Control control in Controls)
            {
                if (control is Button || control is TextBoxDesign)
                {
                    control.Font = new Font(privateFonts.Families[0], 20f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    control.Font = new Font(privateFonts.Families[1], 26f, FontStyle.Bold);
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
            CenterControl(label1);
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
            Thread animationThread = new Thread(() => PlayButtonAnimation(btnSignup));
            animationThread.Start();
            animationThread.Join();

            foreach (Control x in Controls)
            {
                if (x is TextBoxDesign && string.IsNullOrWhiteSpace(((TextBoxDesign)x).Texts.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi");
                    return;
                }
            }

            string usrname = textBoxDesign1.Texts.Trim();
            string pass = textBoxDesign2.Texts;
            string passConfirm = textBoxDesign3.Texts;
            FirebaseResponse response1 = client.Get(@"Information/" + usrname);
            if (response1.Body == "null")
            {
                if (pass == passConfirm)
                {
                    var data = new Data
                    {
                        Username = usrname,
                        Password = pass
                    };

                    SetResponse response2 = await client.SetTaskAsync("Information/" + usrname, data);
                    Data result = response2.ResultAs<Data>();

                    MessageBox.Show("Đăng ký tài khoản: " + result.Username + " thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng!", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản tồn tại!", "Lỗi");
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            Thread animationThread = new Thread(() => PlayButtonAnimation(btnReturnHome));
            animationThread.Start();
            animationThread.Join();
            this.Close();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is Button button && sender != btnSignup)
            {
                Thread animationThread = new Thread(() => PlayButtonAnimation(button));
                animationThread.Start();
            }
        }

        private void PlayButtonAnimation(Button button)
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
            CenterControl(textBoxDesign1);
            CenterControl(textBoxDesign2);
            CenterControl(textBoxDesign3);

            SetControlImage(pictureBox1, Animation.UI_Textbox_02);
            SetControlImage(pictureBox2, Animation.UI_Textbox_02);
            SetControlImage(pictureBox3, Animation.UI_Textbox_02);

            CenterControl(pictureBox1);
            CenterControl(pictureBox2);
            CenterControl(pictureBox3);
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
                    button.Click += Button_Click;
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
