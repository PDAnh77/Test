using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GameProject;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Net.Sockets;
using System.Timers;
using System.Net.NetworkInformation;
using FirebaseAdmin.Messaging;
using FireSharp;


namespace GameProject
{
    public partial class GamePlay : Form
    {
        #region Properties

        public IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://player-data-a58e3-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "YuoYsOBrBJXPMJzVMCTK3eZen1kA9ouzjZ0U616i"
        };

        IFirebaseClient client;
        SocketManager socket;
        private System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        public string username; // Tên người chơi
        public string IDphong; // Tên phòng
        public string IP;

        private List<string> DSUser = new List<string>(); // Danh sách người chơi trong phòng

        private string msg;
        private int counter = 30;
        private int time = 0;

        private System.Timers.Timer listenTimer;

        #endregion

        #region Initialize
        public GamePlay()
        {
            InitializeComponent();
        }

        public GamePlay(string name, string idPhong, string ip, bool server) 
        {
            InitializeComponent();
            InitializeTimer();
            client = new FirebaseClient(config);
            socket = new SocketManager();
            username = name;
            IDphong = idPhong;
            IP = ip;
            DSUser.Add(username); // Mỗi người chơi sẽ tự có danh sách người chơi của riêng mình, khi có thay đổi server sẽ thông báo để cập nhật
            CreateOrConnect(server);
        }

        private void GamePlay_Load(object sender, EventArgs e) //LoadForm chinh
        {
            client = new FireSharp.FirebaseClient(config);

            Setptbimage();
            BodyConfig();
            //SetControlImage(lbID, Animation.UI_Textbox_02);
            //Cập nhật ngay mã id phòng là IDphong
            Invoke(new System.Action(() =>
            {
                WriteTextSafe(lbID, IDphong);
            }));
            reloadForm();
            SetControlImage(this, Animation.UI_Menu);
        }
        private async void GamePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket.isServer)
            {
                await DeleteRoom(IDphong);
                socket.CloseConnect();
                DialogResult = DialogResult.Cancel; // Quay về GameLobby
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, new Point(), $"{username}"));
                }
                catch { }
                DialogResult = DialogResult.Cancel; // Quay về GameLobby
            }
        }
        private void InitializeTimer()
        {
            listenTimer = new System.Timers.Timer(2000); // (1000ms = 1 giây)
            listenTimer.Elapsed += OnTimedEvent; // Cứ cách 1.5s thì gọi Listen()
            listenTimer.AutoReset = true;
            listenTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) 
        {
            Listen();
        }
        private void timercd_Tick(object sender, EventArgs e)
        {
            pgb.PerformStep();
        }
        #endregion

        #region Function

        public async void CreateOrConnect(bool server)
        {
            if (server)
            {
                string roomName = IDphong;
                string roomId = IP;

                try
                {
                    var roomData = new RoomData
                    {
                        RoomName = roomName,
                        RoomId = roomId // IP tạo phòng
                    };
                    SetResponse response = await client.SetAsync($"Room/{roomName}", roomData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                socket.IP = roomId;
                socket.isServer = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                socket.IP = IP;
                if (!socket.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối");
                }
                else
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.JOIN_ROOM, new Point(), $"{username}"));
                    }
                    catch
                    {
                        MessageBox.Show("Lỏd");
                    }
                }
            }
        }
        public void Listen()
        {
            if (socket.isServer)
            {
                if (socket.ServerAlive()) // Kiểm tra server có đang bật chưa
                {
                    if (socket.clientSockets.Count > 0)
                    {
                        try
                        {
                            SocketData data = (SocketData)socket.Receive();
                            ProcessData(data);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            else
            {
                try
                {
                    if (socket.ClientAlive())
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);
                    }
                }
                catch
                {

                }
            }
        }

        public void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.SEND_MESSEGE:
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            rtbMSG.AppendText(data.Messege+Environment.NewLine);
                            rtbMSG.ScrollToCaret(); // Di chuyển con trỏ đến cuối văn bản
                        });

                        break;
                    }
                case (int)SocketCommand.START:
                    MessageBox.Show(data.Messege);
                    break;
                case (int)SocketCommand.CREATE_ROOM:
                    MessageBox.Show(data.Messege);
                    break;
                case (int)SocketCommand.JOIN_ROOM:
                    if (socket.isServer) // Trường hợp là server
                    {
                        DSUser.Add(data.Messege);
                        reloadForm();
                        string userString = string.Join("/", DSUser);
                        socket.Broadcast(new SocketData((int)SocketCommand.JOIN_ROOM, new Point(), userString)); // Xem chi tiết ở SocketData để hiểu
                    }
                    else // Trường hợp là client
                    {
                        string userString = data.Messege;
                        string[] userArray = userString.Split('/');
                        DSUser.Clear();
                        for (int i = 0; i < userArray.Length; i++)
                        {
                            DSUser.Add(userArray[i]);
                        }
                        reloadForm();
                        if (userArray.Length > 4)
                        {
                            MessageBox.Show("Có người vào xem");
                        }
                    }
                    break;
                case (int)SocketCommand.QUIT:
                    if (socket.isServer)
                    {
                        string name = data.Messege;
                        DSUser.Remove(name);
                        reloadForm();
                        string StringQuit = string.Join("/", DSUser);
                        socket.Broadcast(new SocketData((int)SocketCommand.QUIT, new Point(), StringQuit));
                    }
                    else
                    {
                        string userString = data.Messege;
                        string[] userArray = userString.Split('/');
                        DSUser.Clear();
                        for (int i = 0; i < userArray.Length; i++)
                        {
                            DSUser.Add(userArray[i]);
                        }
                        reloadForm();
                    }
                    break;
                default:
                    break;
            }
        }

        private async Task DeleteRoom(string roomName)
        {
            try
            {
                await client.DeleteAsync($"Room/{roomName}");
            }
            catch 
            {
                // Xử lý lỗi nếu cần thiết
            }
        }

        public void getNameOtheruser(string name)
        {
            DSUser.Add(name);
            if (DSUser.Count != 0)
            {
                addUsserInForm(name);
            }
        }

        //tương tự như hàm sendFrmPlay trong frmLogin.cs
        //public void sendFormLG(GameLogin frm)
        //{
        //    FrmLogin = frm;
        //}

        private void addUsserInForm(string name)// Hàm viết tên lên label của frmPlay
        {
            Invoke(new System.Action(() =>
            {
                string lbname = "lbun";
                Label lb = (Label)this.Controls.Find(lbname + DSUser.Count, false).FirstOrDefault() as Label;
                if (name == username)
                    WriteTextSafe(lb, name + " (you)");
                else
                    WriteTextSafe(lb, name);
            }
            ));
        }

        //Viết id phòng lên label của frmPlay
        public void ABC(string id)
        {
            this.IDphong = id;
            WriteTextSafe(lbID, IDphong);
        }
        public void ABC(string id, string name, string[] arrU)
        {
            this.IDphong = id;
            username = name;
            for (int i = 0; i < arrU.Length; i++)
            {
                DSUser.Add(arrU[i]);
            }
        }

        public void getUsername(string name, string idPhong)
        {
            string uname;
            uname = name;
            IDphong = idPhong;
            DSUser.Add(uname);
        }


        
        private void reloadForm()
        {
            //SetButtonEnabledSafe(btnXiNgau, false);//Khóa nút lắc xí ngầu
            int totalLabels = 4; // Số lượng nhãn tối đa (giả sử có lbun1, lbun2, lbun3, lbun4)
            for (int i = 0; i < totalLabels; i++)
            {
                string name = "lbun";
                Label lb = (Label)this.Controls.Find(name + (i + 1), false).FirstOrDefault() as Label;

                if (i < DSUser.Count)
                {
                    // Cập nhật nhãn với tên người chơi
                    if (DSUser[i] == username)
                        WriteTextSafe(lb, DSUser[i] + " (you)");
                    else
                        WriteTextSafe(lb, DSUser[i]);
                }
                else
                {
                    // Xóa bỏ nội dung của nhãn không còn cần thiết
                    WriteTextSafe(lb, "");
                }
            }
        }

        public void getMSG(string Msg)  //tạo tin nhắn gữi đi
        {
            //luotchoitimer.Stop();
            //counter = 30;                  
            string[] Do = Msg.Split(':');//chia Msg thành một mảng các phần tử dựa trên ký tự ':'

            if (Do[0] == "2")
            {
                WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[2]); /////Error
                WriteTextSafe(lbWork, "Thảy xí ngầu");

                if (Do[1] == username)
                {
                    SetButtonEnabledSafe(btnXiNgau, true);// bỏ khóa nút thảy xí ngầu
                }
                for (int i = 0; i < DSUser.Count; i++)//Duyệt qua danh sách các user để tạo cho mỗi 
                                                      //user một bộ cờ ngựa màu 4 con tương ứng
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (i == 0)
                        {
                            string nameCtrol = "b";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "xanhduong" + ".png");
                        }
                        else if (i == 1)
                        {
                            string nameCtrol = "r";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "do" + ".png");
                        }
                        else if (i == 2)
                        {
                            string nameCtrol = "y";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "vang" + ".png");
                        }
                        else if (i == 3)
                        {
                            string nameCtrol = "g";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "xanhla" + ".png");
                        }
                    }
                }
            }
            else if (Do[0] == "3")
            {
                string imagePath;
                switch (Do[2])
                {
                    case "1":
                        //imagePath =
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "1" + ".png");
                        break;
                    case "2":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "2" + ".png");
                        break;
                    case "3":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "3" + ".png");
                        break;
                    case "4":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "4" + ".png");
                        break;
                    case "5":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "5" + ".png");
                        break;
                    case "6":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "6" + ".png");
                        break;
                }
                if (Do[3] == "y")
                {
                    WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[1]);
                    WriteTextSafe(lbWork, "Đánh cờ");
                }
                else
                {
                    WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[3]);
                    WriteTextSafe(lbWork, "Thảy xí ngầu");
                    if (username == Do[1])
                        SetButtonEnabledSafe(btnXiNgau, false);
                    if (username == Do[3])
                    {
                        SetButtonEnabledSafe(btnXiNgau, true);
                    }
                }
                if (Do[2] != "6" && Do[1] != "1")
                {

                }
            }
            else if (Do[0] == "5")
            {
                string msg = "";
                if (Do[1] == username)
                    msg = username + " (you): " + Do[2];
                else
                    msg = Do[1] + ": " + Do[2];
                WriteTextSafe(rtbMSG, msg + "\n");
            }
            else if (Do[0] == "4")
            {
                if (Do[2] != "")
                {
                    string s = "";
                    switch (Do[2])
                    {
                        case "b1":
                        case "b2":
                        case "b3":
                        case "b4":
                            s = "29";
                            break;
                        case "r1":
                        case "r2":
                        case "r3":
                        case "r4":
                            s = "43";
                            break;
                        case "y1":
                        case "y2":
                        case "y3":
                        case "y4":
                            s = "1";
                            break;
                        case "g1":
                        case "g2":
                        case "g3":
                        case "g4":
                            s = "15";
                            break;
                    }
                    PictureBox ptb = (PictureBox)this.Controls.Find(Do[2], false).FirstOrDefault() as PictureBox;
                    PictureBox btn = (PictureBox)this.Controls.Find("btn" + s, false).FirstOrDefault() as PictureBox;
                    btn.Image = ptb.Image;
                    ptb.Image = null;
                    WriteTextSafe(lbWork, "Thảy xí ngầu");
                }
            }
            else if (Do[0] == "6")
            {
                if (Do[2] != "")
                {
                    if (Do[3] != "")
                    {
                        if (Do[2] == "dich")
                        {
                            string btnDich = "";
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            if (Do[3] == "b")
                            {
                                btnDich = "dichXD";
                            }
                            else if (Do[3] == "r")
                            {
                                btnDich = "dichD";
                            }
                            else if (Do[3] == "y")
                            {
                                btnDich = "dichV";
                            }
                            else if (Do[3] == "g")
                            {
                                btnDich = "dichXL";
                            }
                            PictureBox btnMau = (PictureBox)this.Controls.Find(btnDich + Do[5], false).FirstOrDefault() as PictureBox;
                            btnMau.Image = btn.Image;
                            btn.Image = null;
                        }
                        else if (Do[2] == "win")
                        {
                            string btnDich = "";
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            if (Do[3] == "b")
                            {
                                btnDich = "dichXD";
                            }
                            else if (Do[3] == "r")
                            {
                                btnDich = "dichD";
                            }
                            else if (Do[3] == "y")
                            {
                                btnDich = "dichV";
                            }
                            else if (Do[3] == "g")
                            {
                                btnDich = "dichXL";
                            }
                            PictureBox btnMau = (PictureBox)this.Controls.Find(btnDich + "4", false).FirstOrDefault() as PictureBox;
                            btnMau.Image = btn.Image;
                            btn.Image = null;
                            MessageBox.Show("Chúc mừng người chơi " + Do[5] + " thắng");
                        }
                        else
                        {
                            PictureBox ptb = (PictureBox)this.Controls.Find(Do[3], false).FirstOrDefault() as PictureBox;
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[2], false).FirstOrDefault() as PictureBox;
                            PictureBox btnl = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            ptb.Image = btn.Image;
                            btn.Image = btnl.Image;
                            btnl.Image = null;
                        }
                    }
                    else
                    {
                        PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[2], false).FirstOrDefault() as PictureBox;
                        PictureBox btnl = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                        btn.Image = btnl.Image;
                        btnl.Image = null;
                    }
                }
                if (Do[5] != "")
                {
                    if (Do[5] != "1" && Do[5] != "2" && Do[5] != "3" && Do[5] != "4")
                        WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[5]);
                    else
                        WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[6]);
                    WriteTextSafe(lbWork, "Thảy xí ngầu");

                    if (username == Do[5])
                    {
                        SetButtonEnabledSafe(btnXiNgau, true);
                    }
                    else
                        SetButtonEnabledSafe(btnXiNgau, false);
                }
            }

            else if (Do[0] == "7")
            {
                WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[2]);
                WriteTextSafe(lbWork, "Thảy xí ngầu");

                if (username == Do[2])
                {
                    SetButtonEnabledSafe(btnXiNgau, true);
                }
                else
                    SetButtonEnabledSafe(btnXiNgau, false);
                //counter = 30;              
            }
            try { luotchoitimer.Start(); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        private void SendBtnBox(int x)
        {
            PictureBox ptb = (PictureBox)this.Controls.Find("btn" + x, false).FirstOrDefault() as PictureBox;
            if (ptb.Image != null)// xét xem vị trí của ô có chứa con cờ cá ngựa hay ko
                SendMSGtoFB("6", username, IDphong, x.ToString());
        }
        #endregion

        #region Events
        private async void btnLeave_Click(object sender, EventArgs e) // Thoát phòng
        {
            PlayAnimation(btnLeave);
            if (socket.isServer)
            {
                await DeleteRoom(IDphong);
                socket.CloseConnect();
                DialogResult = DialogResult.Cancel; // Quay về GameLobby
                this.Close();
            }
            else
            {
                socket.Send(new SocketData((int)SocketCommand.QUIT, new Point(), $"{username}"));

                DialogResult = DialogResult.Cancel; // Quay về GameLobby
                this.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnStart);
            Listen();
        }

        private void btnXiNgau_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnXiNgau);
            SendMSGtoFB("3", username, IDphong, "");
            timercd.Start();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayAnimation(dichD1);
            senDoFrom("5", username, IDphong, txtSendMSG.Text);
        }

        #endregion

        private int timUser()
        {
            for (int i = 0; i < DSUser.Count; i++)
            {
                if (DSUser[i] == username)
                    return i;
            }
            return -1;
        }
        private void SendPTBox(string co)
        {
            PictureBox ptb = (PictureBox)this.Controls.Find(co, false).FirstOrDefault() as PictureBox;
            int numUser = timUser();

            switch (co)
            {
                case "b1":
                case "b2":
                case "b3":
                case "b4":
                    if (numUser == 0)
                    {
                        if (ptb.Image != null)
                            SendMSGtoFB("4", username, IDphong, co);
                    }
                    break;
                case "r1":
                case "r2":
                case "r3":
                case "r4":
                    if (numUser == 1)
                    {
                        if (ptb.Image != null)
                            SendMSGtoFB("4", username, IDphong, co);
                    }
                    break;
                case "y1":
                case "y2":
                case "y3":
                case "y4":
                    if (numUser == 2)
                    {
                        if (ptb.Image != null)
                            SendMSGtoFB("4", username, IDphong, co);
                    }
                    break;
                case "g1":
                case "g2":
                case "g3":
                case "g4":
                    if (numUser == 3)
                    {
                        if (ptb.Image != null)
                            SendMSGtoFB("4", username, IDphong, co);
                    }
                    break;

            }
        }
        private void btn_BoLuot_Click(object sender, EventArgs e)
        {
            PlayAnimation(btn_BoLuot);
            SendMSGtoFB("7", username, IDphong, "");
            pgb.Value = 0;
        }
        ///////////////////////////////////////////////////////////////////////
        private void b1_Click(object sender, EventArgs e)
        {
            SendPTBox("b1");
        }
        private void b2_Click(object sender, EventArgs e)
        {
            SendPTBox("b2");
        }
        private void b3_Click(object sender, EventArgs e)
        {
            SendPTBox("b3");
        }
        private void b4_Click(object sender, EventArgs e)
        {
            SendPTBox("b4");
        }
        private void r1_Click(object sender, EventArgs e)
        {
            SendPTBox("r1");
        }
        private void r2_Click(object sender, EventArgs e)
        {
            SendPTBox("r2");
        }
        private void r3_Click(object sender, EventArgs e)
        {
            SendPTBox("r3");
        }
        private void r4_Click(object sender, EventArgs e)
        {
            SendPTBox("r4");
        }
        private void y1_Click(object sender, EventArgs e)
        {
            SendPTBox("y1");
        }
        private void y2_Click(object sender, EventArgs e)
        {
            SendPTBox("y2");
        }
        private void y3_Click(object sender, EventArgs e)
        {
            SendPTBox("y3");
        }
        private void y4_Click(object sender, EventArgs e)
        {
            SendPTBox("y4");
        }
        private void g1_Click(object sender, EventArgs e)
        {
            SendPTBox("g1");
        }
        private void g2_Click(object sender, EventArgs e)
        {
            SendPTBox("g2");
        }
        private void g3_Click(object sender, EventArgs e)
        {
            SendPTBox("g3");
        }
        private void g4_Click(object sender, EventArgs e)
        {
            SendPTBox("g4");
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            SendBtnBox(29);
        }
        private void btn43_Click(object sender, EventArgs e)
        {
            SendBtnBox(43);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            SendBtnBox(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            SendBtnBox(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            SendBtnBox(3);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            SendBtnBox(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            SendBtnBox(5);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            SendBtnBox(6);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            SendBtnBox(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            SendBtnBox(8);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            SendBtnBox(9);
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            SendBtnBox(10);
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            SendBtnBox(11);
        }
        private void btn12_Click(object sender, EventArgs e)
        {
            SendBtnBox(12);
        }
        private void btn13_Click(object sender, EventArgs e)
        {
            SendBtnBox(13);
        }
        private void btn14_Click(object sender, EventArgs e)
        {
            SendBtnBox(14);
        }
        private void btn15_Click(object sender, EventArgs e)
        {
            SendBtnBox(15);
        }
        private void btn16_Click(object sender, EventArgs e)
        {
            SendBtnBox(16);
        }
        private void btn17_Click(object sender, EventArgs e)
        {
            SendBtnBox(17);
        }
        private void btn18_Click(object sender, EventArgs e)
        {
            SendBtnBox(18);
        }
        private void btn19_Click(object sender, EventArgs e)
        {
            SendBtnBox(19);
        }
        private void btn20_Click(object sender, EventArgs e)
        {
            SendBtnBox(20);
        }
        private void btn21_Click(object sender, EventArgs e)
        {
            SendBtnBox(21);
        }
        private void btn22_Click(object sender, EventArgs e)
        {
            SendBtnBox(22);
        }
        private void btn23_Click(object sender, EventArgs e)
        {
            SendBtnBox(23);
        }
        private void btn24_Click(object sender, EventArgs e)
        {
            SendBtnBox(24);
        }
        private void btn25_Click(object sender, EventArgs e)
        {
            SendBtnBox(25);
        }
        private void btn26_Click(object sender, EventArgs e)
        {
            SendBtnBox(26);
        }
        private void btn27_Click(object sender, EventArgs e)
        {
            SendBtnBox(27);
        }
        private void btn28_Click(object sender, EventArgs e)
        {
            SendBtnBox(28);
        }
        private void btn30_Click(object sender, EventArgs e)
        {
            SendBtnBox(30);
        }
        private void btn31_Click(object sender, EventArgs e)
        {
            SendBtnBox(31);
        }
        private void btn32_Click(object sender, EventArgs e)
        {
            SendBtnBox(32);
        }
        private void btn33_Click(object sender, EventArgs e)
        {
            SendBtnBox(33);
        }
        private void btn34_Click(object sender, EventArgs e)
        {
            SendBtnBox(34);
        }
        private void btn35_Click(object sender, EventArgs e)
        {
            SendBtnBox(35);
        }
        private void btn36_Click(object sender, EventArgs e)
        {
            SendBtnBox(36);
        }
        private void btn37_Click(object sender, EventArgs e)
        {
            SendBtnBox(37);
        }
        private void btn38_Click(object sender, EventArgs e)
        {
            SendBtnBox(38);
        }
        private void btn39_Click(object sender, EventArgs e)
        {
            SendBtnBox(39);
        }
        private void btn40_Click(object sender, EventArgs e)
        {
            SendBtnBox(40);
        }
        private void btn41_Click(object sender, EventArgs e)
        {
            SendBtnBox(41);
        }
        private void btn42_Click(object sender, EventArgs e)
        {
            SendBtnBox(42);
        }
        private void btn44_Click(object sender, EventArgs e)
        {
            SendBtnBox(44);
        }
        private void btn45_Click(object sender, EventArgs e)
        {
            SendBtnBox(45);
        }
        private void btn46_Click(object sender, EventArgs e)
        {
            SendBtnBox(46);
        }
        private void btn47_Click(object sender, EventArgs e)
        {
            SendBtnBox(47);
        }
        private void btn48_Click(object sender, EventArgs e)
        {
            SendBtnBox(48);
        }
        private void btn49_Click(object sender, EventArgs e)
        {
            SendBtnBox(49);
        }
        private void btn50_Click(object sender, EventArgs e)
        {
            SendBtnBox(50);
        }
        private void btn51_Click(object sender, EventArgs e)
        {
            SendBtnBox(51);
        }
        private void btn52_Click(object sender, EventArgs e)
        {
            SendBtnBox(52);
        }
        private void btn53_Click(object sender, EventArgs e)
        {
            SendBtnBox(53);
        }
        private void btn54_Click(object sender, EventArgs e)
        {
            SendBtnBox(54);
        }
        private void btn55_Click(object sender, EventArgs e)
        {
            SendBtnBox(55);
        }
        private void btn56_Click(object sender, EventArgs e)
        {
            SendBtnBox(56);
        }
        private void luotchoitimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                luotchoitimer.Stop();
                SendMSGtoFB("7", username, IDphong, "");
            }
        }

        public delegate void SafeCallDelegate(Control control, string text);

        private void WriteTextSafe(Control control, string text)
        {
            if (control is Label lb)
            {
                if (lb.InvokeRequired)
                {
                    var d = new SafeCallDelegate(WriteTextSafe);
                    this.Invoke(d, new object[] { control, text });
                }
                else
                {
                    lb.Text = text;
                }
            }
            if (control is RichTextBox rtxtbox)
            {
                if (rtxtbox.InvokeRequired)
                {
                    var d = new SafeCallDelegate(WriteTextSafe);
                    this.Invoke(d, new object[] { control, text });
                }
                else
                {
                    rtxtbox.Text += text;
                }
            }
        }

        private delegate void SetButtonEnabledDelegate(Button button, bool status);

        private void SetButtonEnabledSafe(Button button, bool status)
        {
            if (button.InvokeRequired)
            {
                var d = new SetButtonEnabledDelegate(SetButtonEnabledSafe);
                this.Invoke(d, new object[] { button, status });
            }
            else
            {
                button.Enabled = status;
            }
        }
        private void btnSendMSG_Click(object sender, EventArgs e)
        {
            rtbMSG.AppendText(User.CurrentUser.Username+": "+txtSendMSG.Text+"\n");
            rtbMSG.ScrollToCaret();
            socket.Send(new SocketData((int)SocketCommand.SEND_MESSEGE, new Point(),$"{User.CurrentUser.Username}: {txtSendMSG.Text}"));
            txtSendMSG.Text = "";
        }

        private void txtSendMSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbMSG.AppendText(User.CurrentUser.Username + ": " + txtSendMSG.Text + "\n");
                rtbMSG.ScrollToCaret();
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSEGE, new Point(), $"{User.CurrentUser.Username}: {txtSendMSG.Text}"));
                txtSendMSG.Text = "";
            }
        }
        ///////////////////////////////////////////////////////////////////////
        #region UI

        private void BodyConfig()
        {
            ButtonConfig();

            SetControlImage(pictureBox2, Animation.UI_Chatlog);
            SetControlImage(pictureBox1, Animation.UI_Table);
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
            if (button.Name == "btnLeave")
            {
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_03a2);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_03a3);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_03a4);
                Thread.Sleep(delay);
                SetControlImage(button, Animation.UI_Flat_Button_Small_Press_03a1);
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

        Color customColor = Color.FromArgb(181, 119, 94); // Background form

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    if (button.Name == "btnLeave")
                    {
                        SetControlImage(button, Animation.UI_Flat_Button_Small_Press_03a1);
                    }
                    else
                    {
                        SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    }
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

        private void Setptbimage()
        {
            for (int i = 1; i <= 56; i++)
            {
                string controlName = $"btn{i}";
                Control[] foundControls = this.Controls.Find(controlName, true);

                if (foundControls.Length > 0 && foundControls[0] is PictureBox)
                {
                    SetControlImage(foundControls[0], Animation.UI_Square);
                }
            }
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        #region CopyTuGameLogin

        private async void SendMSGtoFB (string code, string username, string idphong, string MSG)
        {
            
            string data = code + "/" + username + "/" + idphong + "/" + MSG;
            SetResponse response = await client.SetAsync("Messages/" , data);
        }

        public void senDoFrom(string code, string username, string idphong, string MSG)
        {
            if (string.IsNullOrEmpty(MSG))
            {
                return;
            }
            SendMSGtoFB(code, username, idphong, MSG);
        }

        //private void check(string data)
        //{
        //    string[] arr = data.Split('/');
        //    Console.WriteLine(data);

        //    //bằng 0 khi cần tạo phòng mới
        //    if (arr[0] == "0")
        //    {
        //        //kiểm tra xem có phải đang là tên người dùng hiện tại k
        //        if (arr[1] == username)
        //        {
        //            idPhong = arr[2];

        //            //FrmMenu.showFrmChoiaddphong(arr[2]);
        //        }
        //    }

        //    //bằng 1 khi ng chơi tham gia vào phòng có sẵn
        //    else if (arr[0] == "1")
        //    {
        //        //arrU được chia từ arr[3] theo dấu ":"
        //        arrU = arr[3].Split(':');

        //        if (arr[1] == username)
        //        {
        //            // FrmMenu.getAllUserinRoom(idPhong,arrU);
        //            idPhong = arr[2];
        //        }
        //        else
        //        {
        //            if (arr[2] == idPhong)
        //            {
        //                FrmMenu.getNameuserother(arr[1]);
        //            }
        //        }
        //    }

        //    else if (arr[0] == "2")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {
        //            msgToForm = "2" + ":" + arr[1] + ":" + arr[3];
        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //    else if (arr[0] == "3")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {
        //            msgToForm = "3" + ":" + arr[1] + ":" + arr[3] + ":" + arr[4];
        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //    else if (arr[0] == "5")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {
        //            msgToForm = "5" + ":" + arr[1] + ":" + arr[3];

        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //    else if (arr[0] == "4")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {
        //            msgToForm = "4" + ":" + arr[1] + ":" + arr[3];

        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //    else if (arr[0] == "6")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {

        //            msgToForm = "6" + ":" + arr[1] + ":" + arr[3];

        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //    else if (arr[0] == "7")
        //    {
        //        string msgToForm = "";
        //        if (idPhong == arr[2])
        //        {
        //            msgToForm = "7" + ":" + arr[1] + ":" + arr[3];
        //            FrmMenu.sendMSG(msgToForm);
        //        }
        //    }
        //}
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        #region CopyTuGameMenu

        public void getAllUserinRoom()
        {
            //ABC(FrmLogin.sendIDtoForm(), userName, FrmLogin.sendAllnameOtheruser());
        }

        //public string getUsername(string s)
        //{
        //    //userName = s;
        //    //return userName;
        //}
        //public void getfmrlg(GameLogin frm)
        //{
        //    //FrmLogin = frm;
        //}
        public void showFrmPlayaddphong()
        {
            //Frm1 = new GamePlay(userName, FrmLogin.sendIDtoForm());//tạo frmplay mới vs tên và id
           // Frm1.ABC(FrmLogin.sendIDtoForm());
           // Frm1.Show();
            //FrmLogin.sendFrmPlay(Frm1);

           // Frm1.sendFormLG(FrmLogin);
        }










        #endregion


        //FirebaseResponse response = await client.GetAsync("Messages/" );
        //string msg = response.ResultAs<string>();
    }
}

