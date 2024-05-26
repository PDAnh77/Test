using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class GameLobby : Form
    {
        #region Properties
        PrivateFontCollection privateFonts = new PrivateFontCollection();
        LanManager socket;
        #endregion
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
                    control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                }
            }
        }

        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();
            ButtonConfig();
            socket = new LanManager();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            DialogResult = DialogResult.OK;
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
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    /*CenterControl(button);*/
                    SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
                    button.ForeColor = Color.Transparent;
                    button.BackColor = Color.Transparent;
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
        public void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try //tránh lỗi 1 bên thoát 
                {
                    SocketData data = (SocketData)socket.Receive();
                    //ProcessData(data);
                }
                catch (Exception e)
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();

        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            socket.CreateServer();
            MessageBox.Show("Tạo phòng thành công");
        }
        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            socket.ConnectServer();
            socket.Send("Đã tìm thấy đối thủ");
            //Listen();
        }
        private void GameLobby_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }    
        }

       
    }
}
