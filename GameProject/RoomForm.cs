﻿using FirebaseAdmin.Auth;
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
        private const string firebaseUrl = "https://your-database-url.firebaseio.com/";
        private const string firebaseAuth = "your-auth-secret"; // Thêm khóa bí mật Firebase của bạn nếu cần
        private string roomName;
        public RoomForm(string roomName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.Text = $"Room: {roomName}"; // Đặt tiêu đề form là tên phòng
            LoadRoomDetails();
        }

        private async void LoadRoomDetails()
        {
            // Tải thông tin chi tiết của phòng từ Firebase và hiển thị
            try
            {
                var response = await client.GetStringAsync($"{firebaseUrl}Rooms/{roomName}.json?auth={firebaseAuth}");
                var room = JsonSerializer.Deserialize<Room>(response);

                if (room != null)
                {
                    txtCurrentPlayer.Text = room.CurrentPlayers.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phòng: " + ex.Message);
            }
        }
        
        private void HamTaoLao()
        {
            // Hàm tạo lảo
            MessageBox.Show("Lào tạo thành công!");
        }

                        var json = JsonSerializer.Serialize(room);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var updateResponse = await client.PutAsync($"{firebaseUrl}rooms/{roomName}.json?auth={firebaseAuth}", content);

                        if (updateResponse.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Bạn đã thoát phòng.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật số người chơi.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thoát phòng: " + ex.Message);
                }
            }
        }
    }
}
