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

        public GameLobby()
        {
            InitializeComponent();
            //InitializeFirestore();
            LoadCustomFont();
            ButtonConfig();
            LoadRooms();
        }


        //private void InitializeFirestore()
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + @"ltmgame-firebase-adminsdk-nxh4i-82f4327feb.json";
        //    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        //    db = FirestoreDb.Create("ltmgame");
        //    MessageBox.Show("Firestore Initialized");
        //}

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
            DialogResult = DialogResult.OK;
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

    
        private void RoomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Hiển thị lại form GameLobby khi RoomForm đã đóng
            this.Show();
        }

        private async void btnCreateRoom_Click_1(object sender, EventArgs e)
        {
            PlayAnimation(btnCreateRoom);
            var roomName = txtRoomName.Texts;
            if (!string.IsNullOrWhiteSpace(roomName))
            {
                var roomData = new Room
                {
                    Name = roomName,
                    CurrentPlayers = 1,
                    ViewPlayers = 0,
                    Owner = Data.CurrentUser
                };

                try
                {
                    var json = JsonSerializer.Serialize(roomData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        txtRoomName.Texts = "";
                        //MessageBox.Show("Room created successfully.");
                        await LoadRooms(); // Tải lại danh sách phòng

                        RoomForm roomForm = new RoomForm(roomName);
                        roomForm.RoomDeleted += OnRoomDeleted;
                        //roomForm.FormClosed += RoomForm_FormClosed; 
                        roomForm.TriggerRoomDeleted(roomName);
                        roomForm.Show();
                        //this.Hide();
                    }
                    else
                    {
                        //  MessageBox.Show("Không thể tạo phòng");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo phòng: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền tên phòng trước khi tạo!", "Lỗi");
            }
        }
    }
}
