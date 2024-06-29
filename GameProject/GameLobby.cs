using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using GameProject.CustomControls;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;

namespace GameProject
{
    public partial class GameLobby : Form
    {
        #region Properties

        PrivateFontCollection privateFonts = new PrivateFontCollection();
        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;
        public static readonly DialogResult ContinueToRoomForm = DialogResult.OK;

        SocketManager socket;
        private GamePlay game;
        string NameUser = User.CurrentUser.Username;
        List<string> ListUser;
        #endregion


        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();
            BodyConfig();
            socket = new SocketManager();           
        }

        #region UI

        Color customColor01 = Color.FromArgb(234, 212, 172); // Background textbox
        Color customColor02 = Color.FromArgb(181, 119, 94); // Background form

        private void BodyConfig()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            SetControlImage(this, Animation.UI_Menu);
            ButtonConfig();
            Notification.Text = "";
            Notification.ForeColor = Color.White;
            Notification.BackColor = Color.Transparent;

            SetControlImage(pictureBox2, Animation.UI_Menu_Border);
            SetControlImage(pictureBox1, Animation.UI_Textbox_02);

            txtRoomName.BackColor = customColor01;
            txtRoomName.BorderFocusColor = customColor01;
            flowLayoutPanelRooms.BackColor = customColor01;
        }

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
                    control.Font = new Font(privateFonts.Families[0], 8f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    if (control.Name == "Notification") // Chỉnh thông số của Control Notification
                    {
                        control.Font = new Font(privateFonts.Families[0], 8f, FontStyle.Bold);
                    }
                    else
                    {
                        control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                    }
                }
                else if (control is TextBoxDesign)
                {
                    control.Font = new Font(privateFonts.Families[1], 15f, FontStyle.Bold);
                }
                else if (control is ListBox)
                {
                    control.Font = new Font(privateFonts.Families[0], 7f, FontStyle.Bold);
                }
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
                    button.BackColor = customColor02;
                }
            }
        }

        private void SetControlImage(Control control, Image image)
        {
            control.BackgroundImage = new Bitmap(image, control.Size);
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }

        #endregion

        #region Function

 


        #endregion

        #region Event


        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            DialogResult = DialogResult.Cancel; // Quay về Menu
            this.Close();
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnCreateRoom);
            if (!string.IsNullOrEmpty(txtRoomName.Texts))
            {
                string roomName = txtRoomName.Texts;
                string roomId;
                try // tự động lấy địa chỉ IP
                {
                    roomId = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                }
                catch
                {
                    roomId = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }
                socket.IP = roomId;
                socket.isServer = true;
                socket.CreateServer();
                //try
                //{
                //    var roomData = new RoomData
                //    {
                //        RoomName = roomName,
                //        RoomId = socket.IP // Sử dụng IP làm RoomId, bạn có thể thay đổi nếu cần
                //    };
                //    SetResponse response = await client.SetAsync($"Room/{roomId}", roomData);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                game = new GamePlay(NameUser, roomId, socket);
                game.Show();
                txtRoomName.Texts = "";

            }
            else
            {
                Notification.Text = "Vui lòng nhập IP muốn tạo phòng";
            }
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnJoinRoom);
            socket.IP = txtRoomName.Texts; //lấy địa chỉ IP ở textbox
            if (!string.IsNullOrEmpty(txtRoomName.Texts))
            {
                socket.isServer = false;
                if (!socket.ConnectServer())
                {
                    MessageBox.Show("Phòng đã đầy");
                }
                else
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.JOIN_ROOM, new Point(), $"{NameUser}"));
                        game = new GamePlay(NameUser, txtRoomName.Texts, socket);
                        game.Show();
                        txtRoomName.Texts = "";
                    }
                    catch
                    {
                        MessageBox.Show("Lỏd");
                    }   
                }
            }
            else
            {
                Notification.Text = "Vui lòng nhập IP phòng muốn tham gia";
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnRefresh);

        }

        #endregion
    }
}