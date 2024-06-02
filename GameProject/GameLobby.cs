using System;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
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

namespace GameProject
{
    public partial class GameLobby : Form
    {
        #region Properties

        PrivateFontCollection privateFonts = new PrivateFontCollection();
        private static readonly HttpClient client = new HttpClient();
        private FirestoreDb db;
        private const string firebaseUrl = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string firebaseAuth = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"; // Khóa bí mật

        #endregion

        public static readonly DialogResult ContinueToRoomForm = DialogResult.OK; 

        public GameLobby()
        {
            InitializeComponent();
            LoadCustomFont();
            ButtonConfig();
            LoadRooms();
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
                    control.Font = new Font(privateFonts.Families[1], 20f, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    if (control.Name == "Notification")
                    {
                        control.Font = new Font(privateFonts.Families[0], 10f, FontStyle.Regular);
                    }
                    else
                    {
                        control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
                    }
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
            Notification.Text = "";
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
                    button.BackColor = Color.Transparent;
                }
            }
        }

        private void SetControlImage(Control control, Image image)
        {
            control.BackgroundImage = new Bitmap(image, control.Size);
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private async Task LoadRooms()
        {
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}Rooms.json?auth={firebaseAuth}");
                var rooms = JsonSerializer.Deserialize<Dictionary<string, Room>>(response);

                ListRoom.Items.Clear();
                if (rooms != null)
                {
                    foreach (var room in rooms)
                    {
                        ListRoom.Items.Add(room.Key);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải phòng: " + ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnReturn);
            DialogResult = DialogResult.Cancel; // Go back to menu 
            this.Close();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void OnRoomDeleted(string roomName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnRoomDeleted), roomName);
                return;
            }

            ListRoom.Items.Remove(roomName);
            LoadRooms();
        }

        private void GameLobby_Load(object sender, EventArgs e)
        {
            OnRoomDeleted(Room.CurRoomName);
            Room.CurRoomName = null;
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
                        Notification.Text = "Tên phòng đã tồn tại";
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
                    ViewPlayers = 0,
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
                Notification.Text = "Vui lòng nhập tên phòng";
            }
        }

    }
}
