using GameProject;
using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class frmLogin : Form
    {
        private TcpClient tcpClient;

        private frmLogin clientform;
        private string to;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private bool stopTcpClient = true;

        public frmMenu FrmMenu;

        private string username;
        private string idPhong = "";
        private string[] arrU;
        private delegate void SafeUpdateIncomeMsg(string user, int iCase);

        private frmPlay FrmPlay;

        public frmLogin()
        {
            InitializeComponent();
            ButtonConfig();
            SetControlImage(this, Animation.UI_Menu);
        }

        //DAnh Thêm vào (khi form menu hiện lên thì nút đăng nhập tự động click)
        private void frmLogin_Shown(Object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e) //kết nối tới sever
        {
            PlayAnimation(button1);
            try
            {
                stopTcpClient = false;
                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort));
                this.sWriter = new StreamWriter(tcpClient.GetStream());
                this.sWriter.AutoFlush = true;
                sWriter.WriteLine(User.CurrentUser.Username);
                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();
                username = User.CurrentUser.Username;
                FrmMenu = new frmMenu();
                FrmMenu.getUsername(User.CurrentUser.Username);
                FrmMenu.getfmrlg(this);
                FrmMenu.Show();
                this.Hide();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //gán frmplay vừa đc tạo vào frmplay được tạo trc đó ở frmLogin dòng 37
        //để từ frmLogin có thể gọi các phương thức hoặc thay đổi thuộc tính của frmplay
        public void sendFrmPlay(frmPlay frm)
        {
            FrmPlay = frm;
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {

        }

        //Hàm gửi thông điệp qua mạng
        public void SendMSG(string code, string username, string idphong, string MSG)
        {
            try
            {
                string msg = code + "/" + username + "/" + idphong + "/" + MSG;
                sWriter.WriteLine(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void sendformlg()
        {

        }

        //để kiểm tra xem có thông điệp để gửi không trước khi gọi hàm SendMSG để gửi thông điệp qua mạng
        public void senDoFrom(string code, string username, string idphong, string MSG)
        {
            if (string.IsNullOrEmpty(MSG))
            {
                return;
            }
            SendMSG(code, username, idphong, MSG);
        }
        public string sendIDtoForm()
        {
            return idPhong;
        }
        public string sendnameOtheruser(string name)
        {
            return name;
        }
        public string[] sendAllnameOtheruser()
        {
            return arrU;
        }

        //Hàm phân tách thông điệp
        private void check(string data)
        {
            string[] arr = data.Split('/');
            Console.WriteLine(data);

            //bằng 0 khi cần tạo phòng mới
            if (arr[0] == "0")
            {
                //kiểm tra xem có phải đang là tên người dùng hiện tại k
                if (arr[1] == username)
                {
                    idPhong = arr[2];

                    //FrmMenu.showFrmChoiaddphong(arr[2]);
                }
            }

            //bằng 1 khi ng chơi tham gia vào phòng có sẵn
            else if (arr[0] == "1")
            {
                //arrU được chia từ arr[3] theo dấu ":"
                arrU = arr[3].Split(':');

                if (arr[1] == username)
                {
                    // FrmMenu.getAllUserinRoom(idPhong,arrU);
                    idPhong = arr[2];
                }
                else
                {
                    if (arr[2] == idPhong)
                    {
                        FrmMenu.getNameuserother(arr[1]);
                    }
                }
            }

            else if (arr[0] == "2")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "2" + ":" + arr[1] + ":" + arr[3];
                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "3")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "3" + ":" + arr[1] + ":" + arr[3] + ":" + arr[4];
                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "5")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "5" + ":" + arr[1] + ":" + arr[3];

                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "4")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "4" + ":" + arr[1] + ":" + arr[3];

                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "6")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {

                    msgToForm = "6" + ":" + arr[1] + ":" + arr[3];

                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "7")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "7" + ":" + arr[1] + ":" + arr[3];
                    FrmMenu.sendMSG(msgToForm);
                }
            }
        }
        /*public void test(string s)
        {
            txbName.Text = s;
        }*/
        private void ClientRecv()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopTcpClient)
                {
                    Application.DoEvents();
                    string data = sr.ReadLine();

                    if (data == "")
                    {
                        continue;
                    }
                    check(data);
                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
                sr.Close();

            }
        }
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Thread animationThread = new Thread(() => PlayButtonAnimation(btnReturn));
            animationThread.Start();
            animationThread.Join();
            /*DialogResult = DialogResult.OK;
            this.Close();*/
        }

        private void PlayButtonAnimation(Button button)
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



        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                    /*CenterControl(button);*/
                    SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.SaddleBrown;

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
    }
}