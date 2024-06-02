using FirebaseAdmin.Auth;
using Google.Type;
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
using System.Timers;
using System.Windows.Forms;

namespace GameProject
{
    public partial class RoomForm : Form
    {
        #region Properties

        private static readonly HttpClient client = new HttpClient();
        private const string firebaseUrl = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string firebaseAuth = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i";
        private string roomName;


        public delegate void RoomDeletedHandler(string roomName);
        public event RoomDeletedHandler RoomDeleted;

        private System.Timers.Timer updateTimer;
        #endregion

        public RoomForm()
        {
            InitializeComponent();
            this.roomName = Room.CurRoomName;
            this.Text = $"{roomName}"; // Đặt tiêu đề form là tên phòng

            // Khởi tạo và chạy timer
            updateTimer = new System.Timers.Timer(5000); // Cập nhật mỗi 5s
            updateTimer.Elapsed += async (sender, e) => await UpdateTimer_Elapsed(sender, e);
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;

            LoadRoomDetails();
        }

        #region Function

        private async Task LoadRoomDetails()
        {
            // Tải thông tin chi tiết của phòng từ Firebase và hiển thị
            try
            {
                var responseRoom = await client.GetStringAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                var room = JsonSerializer.Deserialize<Room>(responseRoom);
                
                if (room != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtCurrentPlay.Texts = room.CurrentPlayers.ToString();
                        txtPlayer1.Texts = room.Player1?.Username ?? "";
                        txtPlayer2.Texts = room.Player2?.Username ?? "";
                        txtPlayer3.Texts = room.Player3?.Username ?? "";
                        txtPlayer4.Texts = room.Player4?.Username ?? "";
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phòng: " + ex.Message);
            }
        }

        private async Task UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await LoadRoomDetails();
        }

        public void TriggerRoomDeleted(string roomName)
        {
            RoomDeleted?.Invoke(roomName);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Dừng timer khi form đóng     
            if (updateTimer != null)
            {
                updateTimer.Stop();
                updateTimer.Dispose();
            }
        }
        #endregion

        #region Event

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
                            // Xóa dữ liệu người chơi hiện tại khỏi phòng
                            if (room.Player1?.Username == User.CurrentUser.Username)
                            {
                                room.Player1 = null;
                            }
                            else if (room.Player2?.Username == User.CurrentUser.Username)
                            {
                                room.Player2 = null;
                            }
                            else if (room.Player3?.Username == User.CurrentUser.Username)
                            {
                                room.Player3 = null;
                            }
                            else if (room.Player4?.Username == User.CurrentUser.Username)
                            {
                                room.Player4 = null;
                            }

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
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("Lỗi khi xóa phòng.");
                                    });
                                }
                            }
                            else
                            {
                                var json = JsonSerializer.Serialize(room);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                var updateResponse = await client.PutAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}", content);

                                if (!updateResponse.IsSuccessStatusCode)
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("Lỗi khi cập nhật số người chơi.");
                                    });
                                }
                            }
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Phòng không tồn tại.");
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Lỗi khi thoát phòng: " + ex.Message);
                        });
                    }
                    finally
                    {
                        this.Invoke((Action)this.Dispose);
                    }
                });
            }
        }


        #endregion
    }
}
