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
        public static readonly DialogResult ContinueToGamePlay = DialogResult.OK;

        SocketManager socket;
        private GamePlay game;
        string NameUser = User.CurrentUser.Username;

        #endregion

        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();
            BodyConfig();
            socket = new SocketManager();
            client = new FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("Không thể kết nối tới Firebase, vui lòng kiểm tra lại cấu hình.");
            }
            else
            {
                LoadRooms(); // Load danh sách phòng khi form được tải
            }
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

        private async Task<string> GetRoomRank(string roomName)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync($"Room/{roomName}");
                RoomData roomData = response.ResultAs<RoomData>();

                if (roomData != null)
                {
                    return roomData.RoomRank;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy hạng phòng: {ex.Message}");
                return null;
            }
        }

        private async Task<bool> CheckPhongTonTai(string name)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync($"Room/{name}");
                if (response.Body != "null")
                {
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }
       
        private async Task<List<RoomData>> GetRooms()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("Room");

                if (response.Body == "null")
                {
                    return new List<RoomData>();
                }

                Dictionary<string, RoomData> rooms = response.ResultAs<Dictionary<string, RoomData>>();
                return rooms?.Values.ToList() ?? new List<RoomData>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy danh sách phòng: {ex.Message}");
                return new List<RoomData>();
            }
        }

        private Panel CreateRoomPanel(RoomData room)
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Width = 290;
            panel.Height = 120;
            panel.Tag = room.RoomName; // Gán tên phòng vào thuộc tính Tag của Panel

            Label lblRoomName = new Label();
            lblRoomName.Font = new Font(lblRoomName.Font.FontFamily, 16, FontStyle.Bold);
            lblRoomName.Text = $"Tên phòng: {room.RoomName}";
            lblRoomName.Location = new Point(10, 10);
            lblRoomName.AutoSize = true;

            Label lblRoomRank = new Label();
            lblRoomRank.Font = new Font(lblRoomRank.Font.FontFamily, 10, FontStyle.Regular);
            lblRoomRank.Text = $"Hạng: {room.RoomRank}";
            lblRoomRank.Location = new Point(10, 50);
            lblRoomRank.AutoSize = true;

            Label lblRoomPlayer = new Label();
            lblRoomPlayer.Font = new Font(lblRoomPlayer.Font.FontFamily, 10, FontStyle.Regular);
            lblRoomPlayer.Text = $"Số người chơi: {room.RoomPlayer}";
            lblRoomPlayer.Location = new Point(10, 70);
            lblRoomPlayer .AutoSize = true;

            Label lblRoomViewer = new Label();
            lblRoomViewer.Font = new Font(lblRoomViewer.Font.FontFamily, 10, FontStyle.Regular);
            lblRoomViewer.Text = $"Số người xem: {room.RoomViewer}";
            lblRoomViewer.Location = new Point(10, 90);
            lblRoomViewer .AutoSize = true;

            // Thêm các sự kiện
            panel.MouseEnter += new EventHandler(Panel_MouseEnter);
            panel.MouseLeave += new EventHandler(Panel_MouseLeave);
            panel.MouseClick += new MouseEventHandler(Panel_MouseClick);

            panel.Controls.Add(lblRoomName);
            panel.Controls.Add(lblRoomRank);
            panel.Controls.Add(lblRoomPlayer);
            panel.Controls.Add(lblRoomViewer);

            return panel;
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.FixedSingle; // Thay đổi kiểu viền
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.Fixed3D; // Trả lại kiểu viền mặc định
            }
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                string roomName = panel.Tag as string;
                JoinRoom(roomName);
            }
        }
        private async void LoadRooms()
        {
            List<RoomData> rooms = await GetRooms();
            flowLayoutPanelRooms.Controls.Clear();
            foreach (var room in rooms)
            {
                Panel panel = CreateRoomPanel(room);
                flowLayoutPanelRooms.Controls.Add(panel);
            }
        }
        private async Task<bool> GetTrangThaiRoom(string roomName)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync($"Room/{roomName}");
                RoomData roomData = response.ResultAs<RoomData>();

                if (roomData != null)
                {
                    if (roomData.isPlaying)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy IP phòng: {ex.Message}");
                return false;
            }
        }
        private async void JoinRoom(string roomName)
        {
            if (!string.IsNullOrEmpty(roomName))
            {
                bool Exists = await CheckPhongTonTai(roomName); // Kiểm tra xem phòng có tồn tại chưa
                if (Exists)
                {
                    bool isPlay = await GetTrangThaiRoom(roomName);
                    if (isPlay)                                 // Phòng đang chơi thì không cần xét bậc hạng, cho vào luôn
                    {
                        game = new GamePlay(NameUser, roomName, false);
                        this.DialogResult = ContinueToGamePlay;
                    }
                    else
                    {
                        string rank = await GetRoomRank(roomName);
                        if (rank == User.CurrentUser.Rank)
                        {
                            game = new GamePlay(NameUser, roomName, false);
                            this.DialogResult = ContinueToGamePlay;
                        }
                        else
                        {
                            Notification.Text = "Bạn không cùng bậc hạng với phòng";
                        }
                    }
                }
                else
                {
                    Notification.Text = "Phòng không tồn tại";
                }
            }
            else
            {
                Notification.Text = "Vui lòng nhập IP phòng muốn tham gia";
            }
        }
        #endregion

        #region Event
        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            DialogResult = DialogResult.Cancel; // Quay về Menu
            this.Close();
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnCreateRoom);
            if (!string.IsNullOrEmpty(txtRoomName.Texts))
            {
                bool Exists = await CheckPhongTonTai(txtRoomName.Texts); // Kiểm tra xem phòng có tồn tại chưa
                if (!Exists)
                { 
                    game = new GamePlay(NameUser, txtRoomName.Texts, true); 
                    this.DialogResult = ContinueToGamePlay; // Mở GamePlay

                    txtRoomName.Texts = "";
                    Notification.Text = "";
                }
                else
                {
                    Notification.Text = "Tên phòng đã tồn tại";
                }
            }
            else
            {
                Notification.Text = "Vui lòng nhập IP muốn tạo phòng";
            }
        }

        public GamePlay GetGamePlay()
        {
            return game;
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnJoinRoom);
            JoinRoom(txtRoomName.Texts);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnRefresh);
            LoadRooms();
        }

        #endregion
    }
}