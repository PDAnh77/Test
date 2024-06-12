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

namespace GameProject
{
    public partial class GameLobby : Form
    {
        #region Properties

        PrivateFontCollection privateFonts = new PrivateFontCollection();
        private static readonly HttpClient client = new HttpClient();
        private const string firebaseUrl = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string firebaseAuth = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"; // Khóa bí mật
        public static readonly DialogResult ContinueToRoomForm = DialogResult.OK;

        #endregion


        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();
            BodyConfig();

            LoadRooms();
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

        private async Task LoadRooms()
        {
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}Rooms.json?auth={firebaseAuth}");
                var rooms = JsonSerializer.Deserialize<Dictionary<string, Room>>(response);

                flowLayoutPanelRooms.Controls.Clear();
                if (rooms != null)
                {
                    foreach (var room in rooms)
                    {
                        var roomName = room.Key;
                        var roomData = room.Value;

                        // Tạo panel lưu trữ thông tin phòng
                        Panel roomPanel = new Panel
                        {
                            Width = 280,
                            Height = 70,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10),
                            Tag = roomName // Set Tag để dùng cho các hàm ở dưới
                        };

                        // Thêm sự kiện MouseEnter and MouseLeave vào Panel
                        roomPanel.MouseEnter += RoomPanel_MouseEnter;
                        roomPanel.MouseLeave += RoomPanel_MouseLeave;

                        // Tạo Label để hiển thị tên phòng
                        Label roomNameLabel = new Label
                        {
                            Text = $"{roomName}",
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            Location = new Point(10, 10),
                            AutoSize = true
                        };

                        // Tạo Label hiển thị số người chơi trong phòng
                        Label playerCountLabel = new Label
                        {
                            Text = $"Players: {roomData.CurrentPlayers}/4",
                            Font = new Font("Arial", 10),
                            Location = new Point(10, 40),
                            AutoSize = true
                        };

                        Label RankRoom = new Label
                        {
                            Text = $"Rank: {roomData.RankRoom}",
                            Font = new Font("Arial", 10),
                            Location = new Point(120, 40),
                            AutoSize = true
                        };

                        // Thêm label vào panel
                        roomPanel.Controls.Add(roomNameLabel);
                        roomPanel.Controls.Add(playerCountLabel);
                        roomPanel.Controls.Add(RankRoom);

                        // Thêm event vào panel
                        roomPanel.Click += (s, e) => RoomPanel_Click(roomName);

                        // Thêm panel vào flowLayoutPanel
                        flowLayoutPanelRooms.Controls.Add(roomPanel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải phòng: " + ex.Message);
            }
        }

        private void RoomPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BorderStyle = BorderStyle.Fixed3D; // Border được in đậm khi di chuyển chuột vào Panel
        }

        private void RoomPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BorderStyle = BorderStyle.FixedSingle; // Border về ban đầu khi di chuyển chuột ra khỏi Panel
        }

        private void OnRoomDeleted(string roomName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnRoomDeleted), roomName);
                return;
            }

            // Tìm và xóa Panel tương ứng với phòng bị xóa
            foreach (Control control in flowLayoutPanelRooms.Controls)
            {
                if (control is Panel panel && panel.Tag.ToString() == roomName)
                {
                    flowLayoutPanelRooms.Controls.Remove(panel);
                    break;
                }
            }

            LoadRooms();
        }

        private void GameLobby_Load(object sender, EventArgs e)
        {
            OnRoomDeleted(Room.CurRoomName);
            Room.CurRoomName = null;
        }

        private async void JoinRoom(string roomName)
        {
            // Thêm người dùng vào phòng
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                var room = JsonSerializer.Deserialize<Room>(response);

                if (room != null)
                {
                    if (room.CurrentPlayers >= 4)
                    {
                        Notification.Text = "Phòng đã đầy";
                        return;
                    }

                    if (room.RankRoom != User.CurrentUser.Rank)
                    {
                        Notification.Text = "Phòng khác bậc hạng của bạn!";
                        return;
                    }

                    if (room.Player2 == null)
                    {
                        room.Player2 = User.CurrentUser;
                    }
                    else if (room.Player3 == null)
                    {
                        room.Player3 = User.CurrentUser;
                    }
                    else if (room.Player4 == null)
                    {
                        room.Player4 = User.CurrentUser;
                    }

                    room.CurrentPlayers++;

                    var json = JsonSerializer.Serialize(room);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var updateResponse = await client.PutAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}", content);

                    if (updateResponse.IsSuccessStatusCode)
                    {
                        txtRoomName.Texts = "";
                        Notification.Text = "";
                        Room.CurRoomName = roomName;
                        DialogResult = ContinueToRoomForm;
                    }
                        else
                        {
                            Notification.Text = "Không thể tham gia phòng";
                        }
                    }
                    else
                    {
                        Notification.Text = "Phòng không tồn tại";
                    }
                }
                catch (Exception ex)
                {
                    Notification.Text = $"Lỗi khi tham gia phòng: {ex.Message}";
                }
            }

        private async Task<bool> CheckRoomNameExists(string name)
        {
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}Rooms.json?auth={firebaseAuth}");
                var allRooms = JsonSerializer.Deserialize<Dictionary<string, Room>>(response);

                if (allRooms != null)
                {
                    if (allRooms.ContainsKey(name))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Notification.Text = $"Lỗi khi kiểm tra tên phòng: {ex.Message}";
            }

            return false;
        }

        #endregion

        #region Event

        private void RoomPanel_Click(string roomName)
        {
            JoinRoom(roomName);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            DialogResult = DialogResult.Cancel; // Quay về Menu
            this.Close();
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnCreateRoom);
            var roomName = txtRoomName.Texts;
            if (!string.IsNullOrWhiteSpace(roomName))
            {
                bool Exist = await CheckRoomNameExists(roomName);
                if (Exist)
                {
                    Notification.Text = "Tên phòng đã tồn tại";
                    return;
                }

                var roomData = new Room
                {
                    Name = roomName,
                    CurrentPlayers = 1,
                    CurrentReady = 1,
                    RankRoom = User.CurrentUser.Rank,
                    Owner = User.CurrentUser
                };

                try
                {
                    var json = JsonSerializer.Serialize(roomData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        txtRoomName.Texts = "";
                        Notification.Text = "";
                        await LoadRooms(); // Tải lại danh sách phòng
                        Room.CurRoomName = roomName;
                        DialogResult = ContinueToRoomForm;
                    }
                    else
                    {
                        Notification.Text = "Không thể tạo phòng";
                    }
                }
                catch (Exception ex)
                {
                    Notification.Text = $"Lỗi khi tạo phòng: {ex.Message}";
                }
            }
            else
            {
                Notification.Text = "Vui lòng nhập tên phòng muốn tạo";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnRefresh);
            LoadRooms();
        }

        #endregion
    }
}
