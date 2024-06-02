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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class UserProfile : Form
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
                if (control is TextBoxDesign || control is DatePickerDesign || control is ComboBoxDesign)
                {
                    control.Font = new Font(privateFonts.Families[1], 20f, FontStyle.Bold);
                }
                else if (control is Button)
                {
                    control.Font = new Font(privateFonts.Families[1], 20f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    if(control.Name == "Notification")
                    {
                        control.Font = new Font(privateFonts.Families[0], 9f, FontStyle.Bold);
                    }
                    else if (control.Name == "linkLabel1")
                    {
                        control.Font = new Font(privateFonts.Families[2], 12f, FontStyle.Bold);
                    }
                    else
                    {
                        control.Font = new Font(privateFonts.Families[0], 8f, FontStyle.Bold);
                    }
                }
            }
        }

        public UserProfile()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LoadCustomFont();
            SetControlImage(this, Animation.UI_Login_Menu_01);
            SetControlImage(Header, Animation.UI_Profile_Banner);
            CenterControl(Header);
            ButtonConfig();
            BodyConfig();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                /*MessageBox.Show("Kết nối thành công!");*/
            }

            User CurUser = User.CurrentUser;
            textBoxDesign1.Texts = CurUser.Username;
            textBoxDesign2.Texts = CurUser.Email;
            textBoxDesign3.Texts = CurUser.Age;
            comboBoxDesign1.Texts = CurUser.Gender;

            LockAllControls();
        }

        private void LockAllControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                // Check if the control is a TextBoxDesign
                if (ctrl is TextBoxDesign txb)
                {
                    txb.ReadOnly = true;
                }
                // Check if the control is a ComboBox
                if (ctrl is ComboBoxDesign cbb)
                {
                    cbb.DropDownStyle = ComboBoxStyle.Simple;
                }
                // Check if the control is a Datepicker
                if (ctrl is DatePickerDesign dp)
                {
                    dp.Enabled = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnEdit);
            foreach (Control ctrl in this.Controls)
            {
                // Check if the control is a TextBoxDesign
                if (ctrl is TextBoxDesign txb && ctrl.Name == "textBoxDesign2")
                {
                    txb.ReadOnly = false;
                }
                // Check if the control is a ComboBox
                if(ctrl is ComboBoxDesign cbb)
                {
                    cbb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                // Check if the control is a Datepicker
                if (ctrl is DatePickerDesign dp)
                {
                    dp.Enabled = true;
                }
            }
            Notification.Text = "Vui lòng nhập thông tin";
            CenterControl(Notification);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnUpdate);

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
            string age = textBoxDesign3.Texts.Trim();
            string gender = comboBoxDesign1.Texts.Trim();

            if (!int.TryParse(age, out int result) || result <= 0)
            {
                Notification.Text = "Tuổi không hợp lệ!";
                CenterControl(Notification);
                return;
            }

            if (!IsValidEmail(email))
            {
                Notification.Text = "Email không hợp lệ!";
                CenterControl(Notification);
                return;
            }

            try
            {
                User.CurrentUser.Email = email;
                User.CurrentUser.Age = age;
                User.CurrentUser.Gender = gender;
                User data = User.CurrentUser;

                SetResponse response = await client.SetAsync("Information/" + usrname, data);

                Notification.Text = "Cập nhật thông tin thành công!";
                CenterControl(Notification);
                LockAllControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            this.Close();
        }

        private void datePickerDesign1_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime birthday = datePickerDesign1.Value;
            int age = today.Year - birthday.Year;
            textBoxDesign3.Texts = age.ToString();
        }

        private static bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
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
            if (button.Name == "btnReturn")
            {
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a2);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a3);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a4);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
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

        Color customColor = Color.FromArgb(236, 221, 192);

        private void BodyConfig()
        {
            Notification.Text = "";
            label1.Text = "Username:";
            label2.Text = "Email:";
            label3.Text = "Age:";
            label4.Text = "Gender:";

            SetControlImage(InfoBox, Animation.UI_InfoBox);
            SetControlImage(ProfilePic, Animation.UI_Avatar);
            SetControlImage(TextHolder01, Animation.UI_Text_Holder_01);
            SetControlImage(TextHolder02, Animation.UI_Text_Holder);
            SetControlImage(TextHolder03, Animation.UI_Text_Holder);
            SetControlImage(TextHolder04, Animation.UI_Text_Holder);

            CenterControl(InfoBox);
            CenterControl(ProfilePic);
            CenterControl(Notification);
            ProfilePic.BringToFront();

            TextHolder01.BringToFront();
            TextHolder02.BringToFront();
            TextHolder03.BringToFront();
            TextHolder04.BringToFront();

            textBoxDesign1.BackColor = customColor;
            textBoxDesign2.BackColor = customColor;
            textBoxDesign3.BackColor = customColor;

            int textLength = textBoxDesign1.Texts.Length;
            int newWidth = 50 + textLength * 10;
            TextHolder01.Size = new Size(newWidth, TextHolder01.Height);
            /*textBoxDesign1.TextAlign = HorizontalAlignment.Center;*/

            datePickerDesign1.SkinColor = customColor;
            datePickerDesign1.BorderColor = customColor;
            comboBoxDesign1.BackColor = customColor;
            comboBoxDesign1.ListBackColor = customColor;
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    if (button.Name == "btnReturn")
                    {
                        SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
                    }
                    else
                    {
                        SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    }
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
