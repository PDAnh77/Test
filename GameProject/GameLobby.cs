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

namespace GameProject
{
    public partial class GameLobby : Form
    {
        #region Properties
        PrivateFontCollection privateFonts = new PrivateFontCollection();
        private static readonly HttpClient client = new HttpClient();
        private const string firebaseUrl = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string firebaseAuth = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"; // Khóa bí mật
        #endregion

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
                    control.Font = new Font(privateFonts.Families[0], 18f, FontStyle.Bold);
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
        private async Task LoadRooms()
        {
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}rooms.json?auth={firebaseAuth}");
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
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            var roomName = txtRoomName.Text;
            if (!string.IsNullOrWhiteSpace(roomName))
            {
                var roomData = new Room
                {
                    Name = roomName,
                    MaxPlayers = 4,
                    CurrentPlayers = 0
                };

                try
                {
                    var json = JsonSerializer.Serialize(roomData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{firebaseUrl}rooms/{roomName}.json?auth={firebaseAuth}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Room created successfully.");
                        await LoadRooms(); // Refresh the room list

                        RoomForm roomForm = new RoomForm(roomName);
                        roomForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create room.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo phòng: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Room name cannot be empty.");
            }
        }
        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            
        }
    }
}
