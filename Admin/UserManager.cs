using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GameProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class UserManager : UserControl
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;

        public UserManager()
        {
            InitializeComponent();
            InitializeFirebase();
            FetchData();
            dgvShow.CellClick += new DataGridViewCellEventHandler(dgvShow_CellClick); // Thêm sự kiện khi nhấn vào hàng của dgvShow
        }

        void InitializeFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("Kết nối Firebase thất bại");
            }
        }

        async void FetchData() // Lấy dữ liệu firebase và hiển thị thông tin tất cả người chơi trong database
        {
            FirebaseResponse response = await client.GetAsync("Information");
            Dictionary<string, DSUser> users = response.ResultAs<Dictionary<string, DSUser>>();

            dgvShow.Rows.Clear();

            foreach (var user in users)
            {
                dgvShow.Rows.Add(
                    user.Value.Username,
                    user.Value.Email,
                    user.Value.Age,
                    user.Value.Gender,
                    user.Value.Rank,
                    user.Value.Password
                );
            }
        }

        private async void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e) // Định nghĩa khi nhấn vào hàng sẽ làm gì
        {
            try
            {
                if (e.RowIndex >= 0) // Đảm bảo các hàng có giá trị hợp lệ
                {
                    DataGridViewRow row = dgvShow.Rows[e.RowIndex];
                    try
                    {
                        string username = row.Cells["Username"].Value.ToString();
                        await FetchUserData(username);
                    }
                    catch { }   
                }
            }
            catch
            {

            }
        }

        private async Task FetchUserData(string username) // Lấy dữ liệu tương ứng với username được truyền vào
        {
            FirebaseResponse response = await client.GetAsync($"Information/{username}");
            DSUser user = response.ResultAs<DSUser>();

            if (user != null) 
            {
                txtName.Text = user.Username;
                txtPass.Text = user.Password;
                txtEmail.Text = user.Email;
                txtAge.Text = user.Age.ToString();
                txtGender.Text = user.Gender;
                txtRank.Text = user.Rank;
                txtWin.Text = user.Win.ToString();
                txtLose.Text = user.Lose.ToString();
            }
            else
            {
                MessageBox.Show("Không có thông tin người chơi");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e) // Khi nhấn save sẽ lưu thông tin mới của người dùng vào database
        {
            DSUser user = new DSUser
            {
                Username = txtName.Text,
                Password = txtPass.Text,
                Email = txtEmail.Text,
                Age = int.Parse(txtAge.Text),
                Gender = txtGender.Text,
                Rank = txtRank.Text,
                Win = int.Parse(txtWin.Text),
                Lose = int.Parse(txtLose.Text)
            };

            // Cập nhật lên firebase
            SetResponse response = await client.SetAsync($"Information/{user.Username}", user);
            DSUser result = response.ResultAs<DSUser>();

            if (result != null)
            {
                MessageBox.Show("Cập nhật dữ liệu người chơi thành công");
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu");
            }
        }
    }
}


