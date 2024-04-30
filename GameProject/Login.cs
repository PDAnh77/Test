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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            /*ResizeScreenEvent(); */ // Can't auto resize label
        }

        private void Login_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLogin);

            string usrname = textBoxDesign1.Texts.Trim();
            string pass = textBoxDesign2.Texts;

            if (string.IsNullOrWhiteSpace(usrname) || string.IsNullOrWhiteSpace(pass.Trim()))
            {
                Notification.Text = "Vui lòng nhập thông tin đăng nhập!";
                CenterControl(Notification);
                return;
            }

            try
            {
                FirebaseResponse response = client.Get(@"Information/" + usrname);
                if (response.Body != "null")
                {
                    Data ResUser = response.ResultAs<Data>(); // User data retrieved from database

                    Data CurUser = new Data()
                    {
                        Username = usrname,
                        Password = pass
                    };

                    int timerSeconds = 6;
                    int remainingSeconds = timerSeconds;

                    if (Data.IsEqual(ResUser, CurUser))
                    {
                        Notification.Text = "Đăng nhập thành công!";
                        Data.CurrentUser = new Data()
                        {
                            Username = usrname,
                            Password = pass
                        };
                        DialogResult = DialogResult.OK;

                        var wait = new System.Windows.Forms.Timer();
                        wait.Tick += delegate
                        {
                            remainingSeconds--;
                            Notification.Text = $"Đăng nhập thành công!\n Tự động đóng cửa sổ sau: {remainingSeconds}";
                            CenterControl(Notification);

                            if (remainingSeconds <= 0)
                            {
                                this.Close();
                            }
                        };
                        wait.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
                        wait.Start();
                    }
                    else
                    {
                        Notification.Text = "Mật khẩu không chính xác!";
                    }
                }
                else
                {
                    Notification.Text = "Tên đăng nhập không tồn tại!";
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

// Resize Event
/*Size formOriginalSize;
Rectangle recLabel1;
Rectangle recButton1;
Rectangle recButton2;
Rectangle recPicture1;
Rectangle recPicture2;
Rectangle recTextbox1;
Rectangle recTextbox2;

private void ResizeScreenEvent()
{
    formOriginalSize = this.Size;
    this.Resize += Login_Resize;
    recLabel1 = new Rectangle(label1.Location, label1.Size);
    recButton1 = new Rectangle(btnLogin.Location, btnLogin.Size);
    recButton2 = new Rectangle(btnReturnHome.Location, btnReturnHome.Size);
    recTextbox1 = new Rectangle(textBoxDesign1.Location, textBoxDesign1.Size);
    recTextbox2 = new Rectangle(textBoxDesign2.Location, textBoxDesign2.Size);
    recPicture1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
    recPicture2 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
    *//*textBoxDesign1.Multiline = true;
    textBoxDesign2.Multiline = true;*//*
}

private void Login_Resize(object sender, EventArgs e)
{
    resize_Control(btnLogin, recButton1);
    resize_Control(btnReturnHome, recButton2);

    resize_Control(textBoxDesign1, recTextbox1);
    resize_Control(textBoxDesign2, recTextbox2);

    resize_Control(label1, recLabel1);

    resize_Control(pictureBox1, recPicture1);
    resize_Control(pictureBox2, recPicture2);
}

private void resize_Control(Control control, Rectangle r)
{
    float xRatio = (float)this.Width / (float)formOriginalSize.Width;
    float yRatio = (float)this.Height / (float)formOriginalSize.Height;
    int newX = (int)(r.X * xRatio);
    int newY = (int)(r.Y * yRatio);
    int newWidth = (int)(r.Width * xRatio);
    int newHeight = (int)(r.Height * yRatio);

    control.Location = new Point(newX, newY);
    control.Size = new Size(newWidth, newHeight);

    if (control is Label)
    {
        float currentFontSize = ((Label)control).Font.Size;
        float newFontSize = currentFontSize * Math.Min(xRatio, yRatio);
        ((Label)control).Font = new Font(((Label)control).Font.FontFamily, newFontSize, ((Label)control).Font.Style);
    }
}*/