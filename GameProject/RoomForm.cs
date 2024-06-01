using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class RoomForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string firebaseUrl = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string firebaseAuth = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i";
        private string roomName, usrname;


        public delegate void RoomDeletedHandler(string roomName);
        public event RoomDeletedHandler RoomDeleted;
        public RoomForm()
        {
            InitializeComponent();
            this.roomName = Room.CurRoomName;
            this.Text = $"Room: {roomName}"; // Đặt tiêu đề form là tên phòng
            LoadRoomDetails();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            // Connect the button click event to the event handler
            btnLeaveRoom.Click += new EventHandler(btnLeaveRoom_Click);
        }

        private async void LoadRoomDetails()
        {
            // Tải thông tin chi tiết của phòng từ Firebase và hiển thị
            try
            {
                var responseRoom = await client.GetStringAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                var room = JsonSerializer.Deserialize<Room>(responseRoom);

                if (room != null)
                {
                    txtCurrentPlayer.Text = room.CurrentPlayers.ToString();
                    txtOwner.Texts = room.Owner.Username.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phòng: " + ex.Message);
            }
        }

        public void TriggerRoomDeleted(string roomName)
        {
            RoomDeleted?.Invoke(roomName);
        }

        private async void btnLeaveRoom_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát phòng không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await Task.Run(async () =>
                {
                    try
                    {
                        var response = await client.GetStringAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                        var room = JsonSerializer.Deserialize<Room>(response);

                        if (room != null)
                        {
                            room.CurrentPlayers--;
                            if (room.CurrentPlayers < 0) room.CurrentPlayers = 0;

                            if (room.CurrentPlayers == 0)
                            {
                                var deleteResponse = await client.DeleteAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                                if (deleteResponse.IsSuccessStatusCode)
                                {
                                    TriggerRoomDeleted(roomName);
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi khi xóa phòng.");
                                }
                            }
                            else
                            {
                                var json = JsonSerializer.Serialize(room);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                var updateResponse = await client.PutAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}", content);

                                if (!updateResponse.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Lỗi khi cập nhật số người chơi.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phòng không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thoát phòng: " + ex.Message);
                    }
                    finally
                    {
                        this.Invoke((Action)this.Dispose);
                    }
                });
            }
        }
    }
}
