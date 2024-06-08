using FirebaseAdmin.Auth;
using GameProject.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
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

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private System.Timers.Timer updateTimer;
        private delegate void PrintDelegate(string text);

        #endregion

        public RoomForm()
        {
            InitializeComponent();
            this.roomName = Room.CurRoomName;
            this.Text = $"{roomName}"; // Đặt tiêu đề form là tên phòng

            // Khởi tạo và chạy timer
            updateTimer = new System.Timers.Timer(2000); // Cập nhật mỗi 5s
            updateTimer.Elapsed += async (sender, e) => await UpdateTimer_Elapsed(sender, e);
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;

            BodyConfig();
            LoadCustomFont();
            LoadRoomDetails();
        }

        #region UI

        Color customColor = Color.FromArgb(234, 212, 172);

        private void BodyConfig()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            SetControlImage(this, Animation.UI_Menu_03);
            ButtonConfig();

            ShowNotification("");
            CenterControl(Notification);

            SetControlImage(pictureBox1, Animation.UI_Textbox_03);
            SetControlImage(pictureBox2, Animation.UI_Textbox_03);
            SetControlImage(pictureBox3, Animation.UI_Textbox_03);
            SetControlImage(pictureBox4, Animation.UI_Textbox_03);

            txtPlayer1.BackColor = customColor;
            txtPlayer2.BackColor = customColor;
            txtPlayer3.BackColor = customColor;
            txtPlayer4.BackColor = customColor;

            foreach (Control ctrl in this.Controls) // Lock all textbox
            {
                if (ctrl is TextBoxDesign txtPlayer)
                {
                    txtPlayer.ReadOnly = true;
                }
            }
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
                        control.Font = new Font(privateFonts.Families[0], 10f, FontStyle.Bold);
                    }
                }
                else if (control is TextBoxDesign)
                {
                    control.Font = new Font(privateFonts.Families[1], 16f, FontStyle.Bold);
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
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    button.ForeColor = Color.Black;
                    button.BackColor = customColor;
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

        #endregion

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
                        txtPlayer1.Texts = room.Player1?.Username ?? "";
                        txtPlayer2.Texts = room.Player2?.Username ?? "";
                        txtPlayer3.Texts = room.Player3?.Username ?? "";
                        txtPlayer4.Texts = room.Player4?.Username ?? "";

                        // Identify the logged-in user and move the Notification label
                        if (room.Player1?.Username == User.CurrentUser.Username)
                        {
                            MoveNotificationLabel(label1);
                        }
                        else if (room.Player2?.Username == User.CurrentUser.Username)
                        {
                            MoveNotificationLabel(label3);
                        }
                        else if (room.Player3?.Username == User.CurrentUser.Username)
                        {
                            MoveNotificationLabel(label4);
                        }
                        else if (room.Player4?.Username == User.CurrentUser.Username)
                        {
                            MoveNotificationLabel(label5);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phòng: " + ex.Message);
            }
        }

        private void MoveNotificationLabel(Control playerControl)
        {
            Notification.Text = "(Bạn)";
            Notification.ForeColor = Color.Red;
            Notification.Location = new Point(playerControl.Location.X + playerControl.Width + 3, playerControl.Location.Y);
        }

        private void ShowNotification(string text)
        {
            if (Notification.InvokeRequired)
            {
                PrintDelegate d = new PrintDelegate(ShowNotification);
                Notification.Invoke(d, new object[] { text });
            }
            else
            {
                Notification.Text = text;
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
            PlayAnimation(btnLeaveRoom);
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

        #endregion
    }
}
