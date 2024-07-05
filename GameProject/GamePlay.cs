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
using System.Xml.Linq;
using System.Diagnostics.SymbolStore;



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
        private System.Timers.Timer listenTimer;
        
        // Các thành phần cơ bản nhất của GamePlay
        private List<string> DSUser = new List<string>();   // Danh sách người chơi trong phòng
        private string username;                             // Tên người chơi
        private string IDphong;                              // Tên phòng
        public int num_Ready = 0;                           // Số lượng người chơi đã sẵn sàng
        private int xingau;                                 // Số xí ngầu đỗ ra được
        private int ThuTuLuotChoi = 0;                      // Đại diện cho chỉ số lượt  của người chơi
                                                            //Người chơi tạo phòng sẽ có lượt chơi đầu tiên
        private bool TrangThaiChoi = false;
        private bool NguoiXem = false;

        //mau cho chat
        private Color blue = Color.Cyan;
        private Color red = Color.Red;
        private Color yellow = Color.Gold;
        private Color green = Color.Green;
        private Color mau = new Color();

        //cooldown
        private int cd = 30;


        //líchsu
        private string History;



        private string msg;
        private int counter = 30;
        private int time = 0;


        Dictionary<string, string> dsViTri = new Dictionary<string, string>();

        #endregion

        #region Initialize

        public GamePlay()
        {
            InitializeComponent();
        }

        public GamePlay(string name, string idPhong, bool server) 
        {
            InitializeComponent();
            InitializeTimer();
            client = new FirebaseClient(config);
            socket = new SocketManager();
            username = name;
            IDphong = idPhong;
            DSUser.Add(username); // Mỗi người chơi sẽ tự có danh sách người chơi của riêng mình, khi có thay đổi server sẽ thông báo để cập nhật
            CreateOrConnect(server);
            lbCD.Text=cd.ToString();


            dsViTri.Add("b1", null);
            dsViTri.Add("b2", null);
            dsViTri.Add("b3", null);
            dsViTri.Add("b4", null);
            dsViTri.Add("r1", null);
            dsViTri.Add("r2", null);
            dsViTri.Add("r3", null);
            dsViTri.Add("r4", null);
            dsViTri.Add("g1", null);
            dsViTri.Add("g2", null);
            dsViTri.Add("g3", null);
            dsViTri.Add("g4", null);
            dsViTri.Add("y1", null);
            dsViTri.Add("y2", null);
            dsViTri.Add("y3", null);
            dsViTri.Add("y4", null);
        }

        private void GamePlay_Load(object sender, EventArgs e) //LoadForm chinh
        {
            client = new FireSharp.FirebaseClient(config);

            Setptbimage();
            BodyConfig();

            //Cập nhật ngay mã id phòng là IDphong
            Invoke(new System.Action(() =>
            {
                WriteTextSafe(lbID, IDphong);
            }));
            reloadForm();
            SetControlImage(this, Animation.UI_Menu);
            SetControlImage(imgXiNgau, Animation.XiNgau_1);
            LockCacNut();

            this.AcceptButton = btnSendMSG;
        }

        private async void GamePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket.isServer)
            {
                await DeleteRoom(IDphong);
                socket.CloseConnect();
                SetResponse setResponse = await client.SetAsync("History/", History);
                timercd.Stop();
                DialogResult = DialogResult.Cancel; // Quay về GameLobby
            }
            else
            {
                socket.Send(new SocketData((int)SocketCommand.QUIT, new Point(), $"{username}"));
                if (!NguoiXem)
                {
                    UpdateRoomPlayer(IDphong, false);
                }
                else
                {
                    UpdateRoomViewer(IDphong, false);
                }
                socket.CloseClient();
                timercd.Stop();
                DialogResult = DialogResult.Cancel; // Quay về GameLobby
            }
        }

        private void InitializeTimer()
        {
            listenTimer = new System.Timers.Timer(500); // (1000ms = 1 giây)
            listenTimer.Elapsed += OnTimedEvent; // Cứ cách 0.5s thì gọi Listen()
            listenTimer.AutoReset = true;
            listenTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) 
        {
            Listen();
        }

        private void timercd_Tick(object sender, EventArgs e)
        {
            if (cd > 0)
            {
                cd--;
                lbCD.Text= cd.ToString();
            }
            else
            {
                if (User.CurrentUser.Username == DSUser[ThuTuLuotChoi])
                {
                    int ThuTuTiepTheo = (ThuTuLuotChoi + 1) % DSUser.Count; //Tính lượt chơi của ng tiếp theo 
                    if (socket.isServer)
                    {
                        ThuTuLuotChoi = ThuTuTiepTheo;
                        socket.Broadcast(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuLuotChoi}"));
                        for (int i = 1; i <= 4; i++)
                        {
                            string labelName = "lbun" + i;
                            Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                            if (lb.Text == DSUser[ThuTuLuotChoi])
                            {
                                SetKhungLuot(lb);
                            }
                            else
                            {
                                ResetKhungLuot(lb);
                            }
                        }
                       
                        SetButtonEnabledSafe(btnXiNgau, false);
                    }
                    else
                    {
                        socket.Send(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuTiepTheo}"));
                        SetButtonEnabledSafe(btnXiNgau, false);
                    }
                }
                cd = 30;
                lbCD.Text = cd.ToString();
                
            }
        }

        #endregion

        #region Function
        private async void UpdateTrangThaiRoom(string roomName)
        {
            FirebaseResponse response = await client.GetAsync("Room/" + roomName);
            RoomData roomData = response.ResultAs<RoomData>();

            if (roomData != null)
            {
                roomData.isPlaying = true;
                // Đẩy dữ liệu cập nhật lên Firebase
                SetResponse setResponse = await client.SetAsync("Room/" + roomName, roomData);
            }
        }

        private async void UpdateRoomViewer(string roomName, bool join)
        {
            // Lấy dữ liệu hiện tại của phòng
            FirebaseResponse response = await client.GetAsync("Room/" + roomName);
            RoomData roomData = response.ResultAs<RoomData>();

            if (roomData != null)
            {
                if (join)
                {
                    // Cập nhật RoomViewer
                    roomData.RoomViewer++;
                }
                else
                {
                    roomData.RoomViewer--;
                }
                // Đẩy dữ liệu cập nhật lên Firebase
                SetResponse setResponse = await client.SetAsync("Room/" + roomName, roomData);
            }
        }
        private async void UpdateRoomPlayer(string roomName, bool join)
        {
            // Lấy dữ liệu hiện tại của phòng
            FirebaseResponse response = await client.GetAsync("Room/" + roomName);
            RoomData roomData = response.ResultAs<RoomData>();

            if (roomData != null)
            {
                if (join)
                {
                    // Cập nhật RoomPlayer
                    roomData.RoomPlayer++;
                }
                else
                {
                    roomData.RoomPlayer--;
                }
                // Đẩy dữ liệu cập nhật lên Firebase
                SetResponse setResponse = await client.SetAsync("Room/" + roomName, roomData);
            }
        }
       
        private async Task<string> GetRoomIP(string roomName)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync($"Room/{roomName}");
                RoomData roomData = response.ResultAs<RoomData>();

                if (roomData != null)
                {
                    return roomData.RoomId;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy IP phòng: {ex.Message}");
                return null;
            }
        }
        private async Task<bool> GetTrangThaiRoom(string roomName)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync($"Room/{roomName}");
                RoomData roomData = response.ResultAs<RoomData>();

                if (roomData != null)
                {
                    if (roomData.isPlaying)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy IP phòng: {ex.Message}");
                return false;
            }
        }
        public async void CreateOrConnect(bool server)
        {
            if (server)                         // Tạo phòng
            {
                string roomName = IDphong;
                string roomIP = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                string rank = User.CurrentUser.Rank;
                
                if (roomIP == null)
                {
                    roomIP = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }

                btnStart.Visible = true;

                try
                {
                    var roomData = new RoomData
                    {
                        RoomName = roomName,
                        RoomId = roomIP,        // IP tạo phòng
                        RoomRank = rank,
                        RoomPlayer = 1,
                        RoomViewer = 0,
                        isPlaying = false
                    };
                    SetResponse response = await client.SetAsync($"Room/{roomName}", roomData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                socket.IP = roomIP;
                socket.isServer = true;
                socket.CreateServer();

            }
            else                                // Tham gia phòng
            {
                bool Choi = await GetTrangThaiRoom(IDphong);
                string ip = await GetRoomIP(IDphong);
                socket.isServer = false;
                socket.IP = ip;

                if (!socket.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối");
                }
                else
                {
                    try
                    {
                        if (Choi)
                        {
                            NguoiXem = true;
                            UpdateRoomViewer(IDphong, true);
                        }
                        else
                        {

                            UpdateRoomPlayer(IDphong, true);
                        }
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
                case (int)SocketCommand.STARTTIMER:
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                        if (socket.isServer)
                        {
                            socket.Broadcast(new SocketData((int)SocketCommand.STARTTIMER, new Point(), data.Message));
                        }

                        });
                        break;
                    }
                case (int)SocketCommand.XUC_XAC:
                    {
                        Invoke(new System.Action(() =>
                        {
                            if (Int32.TryParse(data.Message, out xingau))
                            {
                                if (socket.isServer)
                                {
                                    string curuser="";
                                    for(int i = 0; i < DSUser.Count;i++)
                                    {
                                        if (i==ThuTuLuotChoi)
                                        {
                                            curuser = DSUser[i];
                                            break;
                                        }
                                    }
                                    History += $"{curuser} tung ra {xingau}/";
                                    diceimg(xingau);
                                    socket.Broadcast(new SocketData((int)SocketCommand.XUC_XAC, new Point(), data.Message));
                                }
                                else
                                {
                                    diceimg(xingau);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error receiving dice value");
                            }                           
                        }));
                    }
                    break;
                case (int)SocketCommand.LUOT_CHOI: ///CHUA CHINH LAI THEO LUOT CHOI DUNG
                    {
                        Invoke(new System.Action(() =>
                        {
                            if (Int32.TryParse(data.Message, out ThuTuLuotChoi))
                            {
                                string name = "lbun";
                                if (socket.isServer)                                // Trường hợp server
                                { 
                                    if (ThuTuLuotChoi == 0)
                                    {
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            string labelName = name + i;
                                            Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                            if (lb.Text == username + " (you)")
                                            {
                                                SetKhungLuot(lb);
                                            }
                                            else
                                            {
                                                ResetKhungLuot(lb);
                                            }
                                        }
                                        UnlockCacNut();
                                    }
                                    else
                                    {
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            string labelName = name + i;
                                            Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                            if (lb.Text == DSUser[ThuTuLuotChoi])
                                            {
                                                SetKhungLuot(lb);
                                            }
                                            else
                                            {
                                                ResetKhungLuot(lb);
                                            }
                                        }
                                    }
                                    socket.Broadcast(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), data.Message));
                                }
                                else                        // Trường hợp là client
                                {
                                    if (username == DSUser[ThuTuLuotChoi])
                                    {
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            string labelName = name + i;
                                            Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                            if (lb.Text == username + " (you)")
                                            {
                                                SetKhungLuot(lb);
                                            }
                                            else
                                            {
                                                ResetKhungLuot(lb);
                                            }
                                        }
                                        UnlockCacNut();
                                    }
                                    else
                                    {
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            string labelName = name + i;
                                            Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                            if (lb.Text == DSUser[ThuTuLuotChoi])
                                            {
                                                SetKhungLuot(lb);
                                            }
                                            else
                                            {
                                                ResetKhungLuot(lb);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error receiving player turn");
                            }
                            cd = 30;
                            lbCD.Text = cd.ToString();
                        }));
                    }
                    break;
                case (int)SocketCommand.SEND_MESSAGE:
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (socket.isServer)
                            {
                                socket.Broadcast(new SocketData((int)SocketCommand.SEND_MESSAGE, new Point(), data.Message));
                            }
                            string[] mes=data.Message.Split('/');
                            for (int i = 0; i < DSUser.Count; i++) 
                            {
                                if (mes[0] == DSUser[i]) 
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            {
                                                mau = blue;
                                                break;
                                            }
                                        case 1:
                                            {
                                                mau = red;
                                                break;
                                            }
                                        case 2:
                                            {
                                                mau = yellow;
                                                break;
                                            }
                                        case 3:
                                            {
                                                mau = green;
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            }
                            rtbMSG.SelectionColor = mau;
                            rtbMSG.AppendText(" ");
                            rtbMSG.SelectedText = mes[0];
                            rtbMSG.SelectionColor = Color.Black;
                            rtbMSG.AppendText($": {mes[1]}" + Environment.NewLine);
                            rtbMSG.ScrollToCaret(); // Di chuyển con trỏ đến cuối văn bản
                        });

                        break;
                    }
                case (int)SocketCommand.CREATE_ROOM:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.JOIN_ROOM:
                    if (socket.isServer)            // Trường hợp là server
                    {
                        if (!TrangThaiChoi)         // Trường hợp phòng chưa vào chế độ chơi
                        {
                            DSUser.Add(data.Message);
                            reloadForm();
                            string userString = string.Join("/", DSUser);
                            socket.Broadcast(new SocketData((int)SocketCommand.JOIN_ROOM, new Point(), userString)); // Xem chi tiết ở SocketData để hiểu
                        }
                        else
                        {
                            string userStringPlay = string.Join("/", DSUser);
                            socket.Broadcast(new SocketData((int)SocketCommand.JOIN_ROOM, new Point(), userStringPlay));
                        }
                    }
                    else                            // Trường hợp là client
                    {
                        string userString = data.Message;
                        string[] userArray = userString.Split('/');
                        DSUser.Clear();
                        for (int i = 0; i < userArray.Length; i++)
                        {
                            DSUser.Add(userArray[i]);
                        }
                        reloadForm();
                        if (NguoiXem)
                        {
                            num_Ready = DSUser.Count;
                        }
                    }
                    break;
                case (int)SocketCommand.QUIT:
                    if (socket.isServer)
                    {
                        string name = data.Message;
                        DSUser.Remove(name);
                        reloadForm();
                        string StringQuit = string.Join("/", DSUser);
                        socket.Broadcast(new SocketData((int)SocketCommand.QUIT, new Point(), data.Message));
                    }
                    else
                    {
                        string userString = data.Message;
                        DSUser.Remove(data.Message);
                        reloadForm();
                    }
                    break;

                case (int)SocketCommand.XUAT_QUAN: 
                    if (socket.isServer)
                    {
                        string NuocDi = data.Message;
                        socket.Broadcast(new SocketData((int)SocketCommand.XUAT_QUAN, new Point(), data.Message));

                        string[] temp = NuocDi.Split('/');
                        string QuanCo = temp[0];
                        string Dich = "btn" + temp[1];

                        if (QuanCo[0] == 'b')
                        {
                            dsViTri[$"{QuanCo}"] = "btn29";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_04);
                        }
                        else if (QuanCo[0] == 'r')
                        {
                            dsViTri[$"{QuanCo}"] = "btn43";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_01);
                        }
                        else if (QuanCo[0] == 'y')
                        {
                            dsViTri[$"{QuanCo}"] = "btn1";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_02);
                        }
                        else if (QuanCo[0] == 'g')
                        {
                            dsViTri[$"{QuanCo}"] = "btn15";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_03);
                        }
                        PictureBox ptb_BatDau = (PictureBox)this.Controls.Find(QuanCo, false).FirstOrDefault() as PictureBox;
                        Invoke(new System.Action(() => { ptb_BatDau.BackgroundImage = null; }));
                    }
                    else
                    {
                        string NuocDi = data.Message;
                        string[] temp = NuocDi.Split('/');
                        string QuanCo = temp[0];
                        string Dich = "btn" + temp[1];

                        if (QuanCo[0] == 'b')
                        {
                            dsViTri[$"{QuanCo}"] = "btn29";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_04);
                        }
                        else if (QuanCo[0] == 'r')
                        {
                            dsViTri[$"{QuanCo}"] = "btn43";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_01);
                        }
                        else if (QuanCo[0] == 'y')
                        {
                            dsViTri[$"{QuanCo}"] = "btn1";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_02);
                        }
                        else if (QuanCo[0] == 'g')
                        {
                            dsViTri[$"{QuanCo}"] = "btn15";
                            PictureBox ptb_KetThuc = (PictureBox)this.Controls.Find(Dich, false).FirstOrDefault() as PictureBox;
                            SetControlImage(ptb_KetThuc, Animation.UI_Horse_Select_03);
                        }
                        PictureBox ptb_BatDau = (PictureBox)this.Controls.Find(QuanCo, false).FirstOrDefault() as PictureBox;
                        Invoke(new System.Action(() => { ptb_BatDau.BackgroundImage = null; }));
                    }
                    cd = 30;
                    lbCD.Text = cd.ToString();
                    break;

                case (int)SocketCommand.SAN_SANG:
                    this.Invoke((MethodInvoker)delegate
                    {
                        timercd.Start();
                    });
                    string Luot = data.Message;

                    ThuTuLuotChoi = Int32.Parse(Luot);

                    string nameSanSang = "lbun";
                    timercd.Start();
                    for (int i = 1; i <= 4; i++)
                    {
                        string labelName = nameSanSang + i;
                        Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                        if (lb.Text == DSUser[ThuTuLuotChoi])
                        {
                            SetKhungLuot(lb);
                        }
                        else
                        {
                            ResetKhungLuot(lb);
                        }
                    }
                    
                    ChuanBiCacQuanCo();
                    UnlockCacNut();
                    
                    break;
                case (int)SocketCommand.DI_CHUYEN:
                    int from = data.Point.X;
                    int to = data.Point.Y;

                    if (socket.isServer)
                    {
                        Point point = new Point(from, to);
                        socket.Broadcast(new SocketData((int)SocketCommand.DI_CHUYEN, point, null));
                    }
                    string quanco = dsViTri.FirstOrDefault(source => source.Value == "btn" + from).Key;
                    PictureBox ptb_co = (PictureBox)this.Controls.Find("btn" + from, false).FirstOrDefault();
                    PictureBox ptb_dich = (PictureBox)this.Controls.Find("btn" + to, false).FirstOrDefault();

                    SetControlImage(ptb_dich, ptb_co.BackgroundImage);
                    SetControlImage(ptb_co, Animation.UI_Square);
                    dsViTri[$"{quanco}"] = $"btn" + to;
                    break;

                case (int)SocketCommand.DA_QUAN:
                    string quancobida = data.Message;
                    if (socket.isServer)
                    {
                        socket.Broadcast(new SocketData((int)SocketCommand.DA_QUAN, new Point(), data.Message));
                    }
                    dsViTri[$"{quancobida}"] = null;

                    Invoke(new System.Action(() => {
                        switch (quancobida[0])
                        {
                            case 'b':
                                SetControlImage((PictureBox)this.Controls.Find(quancobida, false).FirstOrDefault(), Animation.UI_Horse_Select_04);
                                break;
                            case 'r':
                                SetControlImage((PictureBox)this.Controls.Find(quancobida, false).FirstOrDefault(), Animation.UI_Horse_Select_01);
                                break;
                            case 'y':
                                SetControlImage((PictureBox)this.Controls.Find(quancobida, false).FirstOrDefault(), Animation.UI_Horse_Select_02);
                                break;
                            case 'g':
                                SetControlImage((PictureBox)this.Controls.Find(quancobida, false).FirstOrDefault(), Animation.UI_Horse_Select_03);
                                break;
                        }
                    }));               
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

        private delegate void SetKhungDelegate(Label label);

        private void SetKhungLuot(Label label)                          // Khi là lượt của mình thì thay đổi khung hiển thị
        {
            if (label.InvokeRequired)                                   // Kiểm tra thực hiện thay đổi có cần gọi invoke không, có thì gọi, không thì thực hiện trực tiếp
            {
                label.Invoke(new SetKhungDelegate(SetKhungLuot), label);
            }
            else
            {
                if (label.Name == "lbun1")
                {
                    pictureBox3.Location = new Point(pictureBox3.Location.X - 30, pictureBox3.Location.Y);
                    pictureBox3.Size = new Size(pictureBox3.Width + 29, pictureBox3.Height);
                    SetControlImage(pictureBox3, Animation.UI_PlayerB_Icon_Turn);
                }
                if (label.Name == "lbun2")
                {
                    pictureBox4.Location = new Point(pictureBox4.Location.X - 30, pictureBox4.Location.Y);
                    pictureBox4.Size = new Size(pictureBox4.Width + 29, pictureBox4.Height);
                    SetControlImage(pictureBox4, Animation.UI_PlayerR_Icon_Turn);
                }
                if (label.Name == "lbun3")
                {
                    pictureBox5.Location = new Point(pictureBox5.Location.X - 30, pictureBox5.Location.Y);
                    pictureBox5.Size = new Size(pictureBox5.Width + 29, pictureBox5.Height);
                    SetControlImage(pictureBox5, Animation.UI_PlayerY_Icon_Turn);
                }
                if (label.Name == "lbun4")
                {
                    pictureBox6.Location = new Point(pictureBox6.Location.X - 30, pictureBox6.Location.Y);
                    pictureBox6.Size = new Size(pictureBox6.Width + 29, pictureBox6.Height);
                    SetControlImage(pictureBox6, Animation.UI_PlayerG_Icon_Turn);
                }
                label.ForeColor = Color.Red;
            }
        }

        private void ResetKhungLuot(Label label)                        // Đặt lại khung hiển thị về mặc định
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new System.Action(() => label.ForeColor = Color.Black));
            }
            else
            {
                if (label.ForeColor != Color.Red) return;
                if (label.Name == "lbun1")
                {
                    pictureBox3.Size = new Size(pictureBox3.Width - 29, pictureBox3.Height);
                    pictureBox3.Location = new Point(pictureBox3.Location.X + 30, pictureBox3.Location.Y);
                    SetControlImage(pictureBox3, Animation.UI_PlayerB_Icon);
                }
                if (label.Name == "lbun2")
                {
                    pictureBox4.Size = new Size(pictureBox4.Width - 29, pictureBox4.Height);
                    pictureBox4.Location = new Point(pictureBox4.Location.X + 30, pictureBox4.Location.Y);
                    SetControlImage(pictureBox4, Animation.UI_PlayerR_Icon);
                }
                if (label.Name == "lbun3")
                {
                    pictureBox5.Size = new Size(pictureBox5.Width - 29, pictureBox5.Height);
                    pictureBox5.Location = new Point(pictureBox5.Location.X + 30, pictureBox5.Location.Y);
                    SetControlImage(pictureBox5, Animation.UI_PlayerY_Icon);
                }
                if (label.Name == "lbun4")
                {
                    pictureBox6.Size = new Size(pictureBox6.Width - 29, pictureBox6.Height);
                    pictureBox6.Location = new Point(pictureBox6.Location.X + 30, pictureBox6.Location.Y);
                    SetControlImage(pictureBox6, Animation.UI_PlayerG_Icon);
                }
                label.ForeColor = Color.Black;
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

        private void addUsserInForm(string name)// Hàm viết tên lên label của GamePlay
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

        private void SendBtnBox(int vitriHienTai)
        {
            //dành cho việc việc thay đổi hình ảnh
            PictureBox ptb_co = (PictureBox)this.Controls.Find("btn" + vitriHienTai, false).FirstOrDefault() as PictureBox; 


            if (username == DSUser[ThuTuLuotChoi])
            {
                //////Kiểm tra xem ô đó có chứa quân cờ của người chơi đó không 

                string CheckONhan = null;
                CheckONhan = dsViTri.FirstOrDefault(source => source.Value == "btn" + vitriHienTai).Key;
                if (CheckONhan == null)// xét xem vị trí của ô có chứa con cờ cá ngựa hay ko
                {
                    return;
                }
                int vitriDen = vitriHienTai + xingau;

                int solanCheck = 1;
                int oCheck = vitriHienTai + 1;

                //Check bị chặn ở giữa nước đi
                while (true) 
                {
                    if (xingau == 1)
                    {
                        break;
                    }
                    if (oCheck > 56)
                    {
                        oCheck -= 56;
                    }
                    string quan_o_vitriCheck = null;
                    quan_o_vitriCheck = dsViTri.FirstOrDefault(source => source.Value == "btn" + oCheck).Key;
                    if (quan_o_vitriCheck != null)
                    {
                        return;
                    }
                    if (solanCheck == xingau - 1)
                    {
                        break;
                    }
                    solanCheck++;
                    oCheck++;
                }

                //Đá quân cờ về chuồng của nó
                string quan_o_vitriDich = null;
                quan_o_vitriDich = dsViTri.FirstOrDefault(source => source.Value == "btn" + vitriDen).Key;
                string quan_o_vitriHienTai = null;
                quan_o_vitriHienTai = dsViTri.FirstOrDefault(source => source.Value == "btn" + vitriHienTai).Key;
                if ( quan_o_vitriDich != null)
                {
                    if (quan_o_vitriDich[0] != quan_o_vitriHienTai[0])
                    {
                        switch (quan_o_vitriDich[0])
                        {
                            case 'b':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriDich, false).FirstOrDefault(), Animation.UI_Horse_Select_04);
                                break;
                            case 'r':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriDich, false).FirstOrDefault(), Animation.UI_Horse_Select_01);
                                break;
                            case 'y':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriDich, false).FirstOrDefault(), Animation.UI_Horse_Select_02);
                                break;
                            case 'g':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriDich, false).FirstOrDefault(), Animation.UI_Horse_Select_03);
                                break;
                        }

                        //Đá được thì đồng bộ quân cờ 
                        dsViTri[$"{quan_o_vitriDich}"] = null;
                        if (socket.isServer)
                        {
                            socket.Broadcast(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriDich}"));
                        }
                        else
                        {
                            socket.Send(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriDich}"));
                        }
                    }
                    else
                        return;
                }

                if (vitriDen > 56)
                {
                    vitriDen -= 56;
                }
                string co = "btn" + vitriHienTai;
                string dich = "btn" + vitriDen;

                Point point = new Point(vitriHienTai, vitriDen);
                if (socket.isServer)
                {
                    string quanco = dsViTri.FirstOrDefault(source => source.Value == co).Key;
                    string tmp2 = vitriDen.ToString();
                    PictureBox ptb_dich = (PictureBox)this.Controls.Find("btn" + tmp2, false).FirstOrDefault() as PictureBox;

                    SetControlImage(ptb_dich, ptb_co.BackgroundImage);
                    SetControlImage(ptb_co, Animation.UI_Square);
                    dsViTri[$"{quanco}"] = $"{dich}";
                    socket.Broadcast(new SocketData((int)SocketCommand.DI_CHUYEN, point, null));
                }
                else
                {
                    socket.Send(new SocketData((int)SocketCommand.DI_CHUYEN, point, null));
                }

                if (xingau != 1)                // Kiểm tra xem xí ngầu lắc ra được có phải 1 hay 6 không, nếu không thì kết thúc lượt 
                {
                    if (xingau != 6)
                    {
                        int ThuTuTiepTheo = (ThuTuLuotChoi + 1) % DSUser.Count;
                        if (socket.isServer)
                        {
                            ThuTuLuotChoi = ThuTuTiepTheo;
                            string name = "lbun";

                            if (ThuTuLuotChoi == 0)
                            {
                                for (int i = 1; i <= 4; i++)
                                {
                                    string labelName = name + i;
                                    Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                    if (lb.Text == username + " (you)")
                                    {
                                        SetKhungLuot(lb);
                                    }
                                    else
                                    {
                                        ResetKhungLuot(lb);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 1; i <= 4; i++)
                                {
                                    string labelName = name + i;
                                    Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                    if (lb.Text == DSUser[ThuTuLuotChoi])
                                    {
                                        SetKhungLuot(lb);
                                    }
                                    else
                                    {
                                        ResetKhungLuot(lb);
                                    }
                                }
                            }

                            socket.Broadcast(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuLuotChoi}"));
                            cd = 30;
                            lbCD.Text = cd.ToString();
                        }
                        else
                        {
                            socket.Send(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuTiepTheo}"));
                        }
                        SetButtonEnabledSafe(btnXiNgau, false);

                    }
                    else
                    {
                        SetButtonEnabledSafe(btnXiNgau, true);
                    }
                }
                else
                {
                    SetButtonEnabledSafe(btnXiNgau, true);
                }
            }
        }

        #endregion

        #region Events
        private void btnLeave_Click(object sender, EventArgs e) // Thoát phòng
        {
            PlayAnimation(btnLeave);
            timercd.Stop();
            this.Close();
        }
        
        private void btnStart_Click(object sender, EventArgs e)     // Button sẵn sàng
        {
            PlayAnimation(btnStart);
            btnStart.Visible = false;
            
            socket.Broadcast(new SocketData((int)SocketCommand.SAN_SANG, new Point(), "0"));
            timercd.Start();
            ChuanBiCacQuanCo();
            UnlockCacNut();

            UpdateTrangThaiRoom(IDphong);
            TrangThaiChoi = true;

            string name = "lbun";
            for (int i = 1; i <= 4; i++)
            {
                string labelName = name + i;
                Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                if (lb.Text == username + " (you)")
                {
                    SetKhungLuot(lb);
                }
                else
                {
                    ResetKhungLuot(lb);
                }
            }
        }

        void ChuanBiCacQuanCo()
        {
            for (int j = 0; j < DSUser.Count; j++)//Duyệt qua danh sách các user để tạo cho mỗi 
                                                  //user một bộ cờ ngựa màu 4 con tương ứng
            {
                for (int m = 0; m < 4; m++)
                {
                    if (j == 0)
                    {
                        string nameCtrol = "b";
                        PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                        SetControlImage(ptb, Animation.UI_Horse_Select_04);
                    }
                    else if (j == 1)
                    {
                        string nameCtrol = "r";
                        PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                        SetControlImage(ptb, Animation.UI_Horse_Select_01);
                    }
                    else if (j == 2)
                    {
                        string nameCtrol = "y";
                        PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                        SetControlImage(ptb, Animation.UI_Horse_Select_02);
                    }
                    else if (j == 3)
                    {
                        string nameCtrol = "g";
                        PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                        SetControlImage(ptb, Animation.UI_Horse_Select_03);
                    }
                }
            }
        }

        public void UnlockCacNut()
        {
            SetButtonEnabledSafe(btnBoLuot, true);
            SetButtonEnabledSafe(btnXiNgau, true);

            int i = 1;
            int j = 1;
            foreach (Control c in Controls)
            {
                if (i <= 56)
                {
                    if (c is PictureBox && c.Name.Contains($"btn{i}"))
                    {
                        Invoke(new System.Action(() => { c.Enabled = true; }));
                        i++;
                    }
                }
                if (j <= 6)
                {
                    if (c is PictureBox && c.Name.Contains($"dichXD{j}"))
                    {
                        Invoke(new System.Action(() => { c.Enabled = true; }));
                    }
                    if (c is PictureBox && c.Name.Contains($"dichD{j}"))
                    {
                        Invoke(new System.Action(() => { c.Enabled = true; }));
                    }
                    if (c is PictureBox && c.Name.Contains($"dichV{j}"))
                    {
                        Invoke(new System.Action(() => { c.Enabled = true; }));
                    }
                    if (c is PictureBox && c.Name.Contains($"dichXL{j}"))
                    {
                        Invoke(new System.Action(() => { c.Enabled = true; }));
                    }
                    j++;
                }
            }
        }

        private void MoChuong(int Luot)
        {
            if (Luot == 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    PictureBox ptb = (PictureBox)this.Controls.Find("b" + i, false).FirstOrDefault() as PictureBox;
                    SetPictureBoxEnabledSafe(ptb, true);
                }
            }
            else if (Luot == 1)
            {
                for (int i = 1; i <= 4; i++)
                {
                    PictureBox ptb = (PictureBox)this.Controls.Find("r" + i, false).FirstOrDefault() as PictureBox;
                    SetPictureBoxEnabledSafe(ptb, true);
                }
            }
            else if (Luot == 2)
            {
                for (int i = 1; i <= 4; i++)
                {
                    PictureBox ptb = (PictureBox)this.Controls.Find("y" + i, false).FirstOrDefault() as PictureBox;
                    SetPictureBoxEnabledSafe(ptb, true);
                }
            }
            else if (Luot == 3)
            {
                for (int i = 1; i <= 4; i++)
                {
                    PictureBox ptb = (PictureBox)this.Controls.Find("g" + i, false).FirstOrDefault() as PictureBox;
                    SetPictureBoxEnabledSafe(ptb, true);
                }
            }
        }

        private void KhoaChuong()
        {
            for (int i = 1; i <= 4; i++)
            {
                PictureBox ptb = (PictureBox)this.Controls.Find("b" + i, false).FirstOrDefault() as PictureBox;
                SetPictureBoxEnabledSafe(ptb, false);
            }
            for (int i = 1; i <= 4; i++)
            {
                PictureBox ptb = (PictureBox)this.Controls.Find("r" + i, false).FirstOrDefault() as PictureBox;
                SetPictureBoxEnabledSafe(ptb, false);
            }
            for(int i = 1; i <= 4; i++)
            {
                PictureBox ptb = (PictureBox)this.Controls.Find("y" + i, false).FirstOrDefault() as PictureBox;
                SetPictureBoxEnabledSafe(ptb, false);
            }
            for (int i = 1; i <= 4; i++)
            {
                PictureBox ptb = (PictureBox)this.Controls.Find("g" + i, false).FirstOrDefault() as PictureBox;
                SetPictureBoxEnabledSafe(ptb, false);
            }
        }

        public void LockCacNut()
        {
            SetButtonEnabledSafe(btnBoLuot, false);
            SetButtonEnabledSafe(btnXiNgau, false);  

            int i = 1;
            int j = 1;
            foreach (Control c in Controls)
            {
                if (i <= 56)
                {
                    if (c is PictureBox && c.Name.Contains($"btn{i}"))
                    {
                        c.Enabled = false;
                        i++;
                    }
                }
                if (j <= 6)
                {
                    if (c is PictureBox && c.Name.Contains($"dichXD{j}"))
                    {
                        c.Enabled = false;
                    }
                    if (c is PictureBox && c.Name.Contains($"dichD{j}"))
                    {
                        c.Enabled = false;
                    }
                    if (c is PictureBox && c.Name.Contains($"dichV{j}"))
                    {
                        c.Enabled = false;
                    }
                    if (c is PictureBox && c.Name.Contains($"dichXL{j}"))
                    {
                        c.Enabled = false;
                    }
                    j++;
                }
            }
        }

        private void btnXiNgau_Click(object sender, EventArgs e)               // Button thảy xí ngầu
        {
            PlayAnimation(btnXiNgau);
            Random random = new Random();
            xingau = random.Next(1, 7);
            if (xingau == 1 || xingau == 6)
            {
                MoChuong(ThuTuLuotChoi);
            }

            SetButtonEnabledSafe(btnXiNgau, false);
            if (socket.isServer)
            {
                History += $"{User.CurrentUser.Username} tung ra {xingau}/";
                diceimg(xingau);
                socket.Broadcast(new SocketData((int)SocketCommand.XUC_XAC, new Point(), $"{xingau}"));
                if (xingau != 1)
                {
                    if (xingau != 6)
                    {
                        bool allNotNull = true;

                        for (int i = 1; i <= 4; i++)
                        {
                            PictureBox ptb = (PictureBox)this.Controls.Find("b" + i, false).FirstOrDefault() as PictureBox;
                            if (ptb.BackgroundImage == null)
                            {
                                allNotNull = false;
                                break;
                            }
                        }

                        if (allNotNull)
                        {
                            ThuTuLuotChoi = (ThuTuLuotChoi + 1) % DSUser.Count;
                            socket.Broadcast(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuLuotChoi}"));

                            for (int i = 1; i <= 4; i++)
                            {
                                string labelName = "lbun" + i;
                                Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                                if (lb.Text == DSUser[ThuTuLuotChoi])
                                {
                                    SetKhungLuot(lb);
                                }
                                else
                                {
                                    ResetKhungLuot(lb);
                                }
                            }

                            LockCacNut();
                        }

                    }
                }
            }
            else
            {
                socket.Send(new SocketData((int)SocketCommand.XUC_XAC, new Point(), $"{xingau}"));
                if (xingau != 1)
                {
                    if (xingau != 6)
                    {
                        bool allNotNull = true;

                        if (ThuTuLuotChoi == 1)
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                PictureBox ptb = (PictureBox)this.Controls.Find("r" + i, false).FirstOrDefault() as PictureBox;
                                if (ptb.BackgroundImage == null)
                                {
                                    allNotNull = false;
                                    break;
                                }
                            }
                        }
                        else if (ThuTuLuotChoi == 2)
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                PictureBox ptb = (PictureBox)this.Controls.Find("y" + i, false).FirstOrDefault() as PictureBox;
                                if (ptb.BackgroundImage == null)
                                {
                                    allNotNull = false;
                                    break;
                                }
                            }
                        }
                        else if (ThuTuLuotChoi == 3)
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                PictureBox ptb = (PictureBox)this.Controls.Find("g" + i, false).FirstOrDefault() as PictureBox;
                                if (ptb.BackgroundImage == null)
                                {
                                    allNotNull = false;
                                    break;
                                }
                            }
                        }

                        if (allNotNull)
                        {
                            ThuTuLuotChoi = (ThuTuLuotChoi + 1) % DSUser.Count;
                            socket.Send(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuLuotChoi}"));
                            LockCacNut();
                        }
                    }
                }
            }
        }

        private void diceimg (int dice)
        { 
            switch (dice)
                {
                case 1:
                    {
                        SetControlImage(imgXiNgau,Animation.XiNgau_1);
                        break;
                    }
                case 2:
                    {
                        SetControlImage(imgXiNgau, Animation.XiNgau_2);
                        break;
                    }
                case 3:
                    {
                        SetControlImage(imgXiNgau, Animation.XiNgau_3);
                        break;
                    }
                case 4:
                    {
                        SetControlImage(imgXiNgau, Animation.XiNgau_4);
                        break;
                    }
                case 5:
                    {
                        SetControlImage(imgXiNgau, Animation.XiNgau_5);
                        break;
                    }
                case 6:
                    {
                        SetControlImage(imgXiNgau, Animation.XiNgau_6);
                        break;
                    }

                default:
                    break;
                }
        }
        #endregion

        private int Tim_User_ThucHien()
        {
            for (int i = 0; i < DSUser.Count; i++)
            {
                if (DSUser[i] == username)
                    return i;
            }
            return -1;
        }

        private void Send_XuatQuanCo(string co) //Gui thong diep xuat quan co 
        {
            PictureBox ptb = (PictureBox)this.Controls.Find(co, false).FirstOrDefault() as PictureBox;
            string quan_o_vitriSapDen;
            switch (co)
            {
                case "b1":
                case "b2":
                case "b3":
                case "b4":
                    quan_o_vitriSapDen = null;
                    quan_o_vitriSapDen = dsViTri.FirstOrDefault(source => source.Value == "btn29").Key;
                    if (quan_o_vitriSapDen == null)
                    {
                        dsViTri[$"{co}"] = "btn29";
                        cd = 30;
                        lbCD.Text = cd.ToString();
                    }
                    else if (quan_o_vitriSapDen[0] == 'b')
                        return;
                    else if (quan_o_vitriSapDen[0] == 'r' ||
                              quan_o_vitriSapDen[0] == 'y' ||
                              quan_o_vitriSapDen[0] == 'g')
                    {
                        switch (quan_o_vitriSapDen[0])
                        {
                            case 'r':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_01);
                                break;
                            case 'y':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_02);
                                break;
                            case 'g':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_03);
                                break;
                        }
                        //Đá được thì đồng bộ quân cờ 
                        dsViTri[$"{quan_o_vitriSapDen}"] = null;
                        socket.Broadcast(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriSapDen}"));
                    }
                    Invoke(new System.Action(() => { ptb.BackgroundImage = null; }));
                    socket.Broadcast(new SocketData((int)SocketCommand.XUAT_QUAN, new Point(), $"{co}/29"));
                    SetControlImage(btn29, Animation.UI_Horse_Select_04);
                    KhoaChuong();
                    break;

                case "r1":
                case "r2":
                case "r3":
                case "r4":
                    quan_o_vitriSapDen = null;
                    quan_o_vitriSapDen = dsViTri.FirstOrDefault(source => source.Value == "btn43").Key;
                    if (quan_o_vitriSapDen == null)
                    { }
                    else if (quan_o_vitriSapDen[0] == 'r')
                        return;
                    else if ( quan_o_vitriSapDen[0] == 'b' ||
                               quan_o_vitriSapDen[0] == 'y' ||
                               quan_o_vitriSapDen[0] == 'g')
                    {
                        switch (quan_o_vitriSapDen[0])
                        {
                            case 'b':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_04);
                                break;
                            case 'y':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_02);
                                break;
                            case 'g':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_03);
                                break;
                        }
                        //Đá được thì đồng bộ quân cờ 
                        dsViTri[$"{quan_o_vitriSapDen}"] = null; //Cập nhật trên danh sách vị trí
                        socket.Send(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriSapDen}"));
                    }
                    socket.Send(new SocketData((int)SocketCommand.XUAT_QUAN, new Point(), $"{co}/43"));
                    KhoaChuong();
                    break;
                case "y1":
                case "y2":
                case "y3":
                case "y4":
                    quan_o_vitriSapDen = null;
                    quan_o_vitriSapDen = dsViTri.FirstOrDefault(source => source.Value == "btn1").Key;
                    
                    if (quan_o_vitriSapDen == null )
                    { }
                    else if (quan_o_vitriSapDen[0] == 'y')
                        return;
                    else if  (quan_o_vitriSapDen[0] == 'b' ||
                               quan_o_vitriSapDen[0] == 'r' ||
                               quan_o_vitriSapDen[0] == 'g') 
                    {
                        switch (quan_o_vitriSapDen[0])
                        {
                            case 'b':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_04);
                                break;
                            case 'r':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_01);
                                break;
                            case 'g':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_03);
                                break;
                        }
                        //Đá được thì đồng bộ quân cờ 
                        dsViTri[$"{quan_o_vitriSapDen}"] = null; //Cập nhật trên danh sách vị trí
                        socket.Send(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriSapDen}"));
                    }
                    socket.Send(new SocketData((int)SocketCommand.XUAT_QUAN, new Point(), $"{co}/1"));
                    KhoaChuong();
                    break;

                case "g1":
                case "g2":
                case "g3":
                case "g4":
                    quan_o_vitriSapDen = null;
                    quan_o_vitriSapDen = dsViTri.FirstOrDefault(source => source.Value == "btn15").Key;
                    if (quan_o_vitriSapDen == null)
                    { }
                    else if (quan_o_vitriSapDen[0] == 'g')
                        return;
                    else if ( quan_o_vitriSapDen[0] == 'b' ||
                               quan_o_vitriSapDen[0] == 'r' ||
                               quan_o_vitriSapDen[0] == 'y')
                    {
                        switch (quan_o_vitriSapDen[0])
                        {
                            case 'b':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_04);
                                break;
                            case 'r':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_01);
                                break;
                            case 'y':
                                SetControlImage((PictureBox)this.Controls.Find(quan_o_vitriSapDen, false).FirstOrDefault(), Animation.UI_Horse_Select_02);
                                break;
                        }
                        //Đá được thì đồng bộ quân cờ 
                        dsViTri[$"{quan_o_vitriSapDen}"] = null; //Cập nhật trên danh sách vị trí
                        socket.Send(new SocketData((int)SocketCommand.DA_QUAN, new Point(), $"{quan_o_vitriSapDen}"));
                    }
                    socket.Send(new SocketData((int)SocketCommand.XUAT_QUAN, new Point(), $"{co}/1"));
                    KhoaChuong();
                    break;
            }
            SetButtonEnabledSafe(btnXiNgau, true);
        }

        private void btnBoLuot_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnBoLuot);

            if (username != DSUser[ThuTuLuotChoi])              // Không phải lượt của nó thì bỏ qua
            {
                return;
            }

            int ThuTuTiepTheo = (ThuTuLuotChoi + 1) % DSUser.Count; // Tính lượt chơi của ng tiếp theo 

            if (socket.isServer)
            {
                ThuTuLuotChoi = ThuTuTiepTheo;
                socket.Broadcast(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuLuotChoi}"));
                for (int i = 1; i <= 4; i++)
                {
                    string labelName = "lbun" + i;
                    Label lb = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

                    if (lb.Text == DSUser[ThuTuLuotChoi])
                    {
                        SetKhungLuot(lb);
                    }
                    else
                    {
                        ResetKhungLuot(lb);
                    }
                }
                cd = 30;
                lbCD.Text = cd.ToString();
            }
            else
            {
                socket.Send(new SocketData((int)SocketCommand.LUOT_CHOI, new Point(), $"{ThuTuTiepTheo}"));
            }
            LockCacNut();
        }
        ///////////////////////////////////////////////////////////////////////
        private void b1_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("b1");
        }
        private void b2_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("b2");
        }
        private void b3_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("b3");
        }
        private void b4_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("b4");
        }
        private void r1_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("r1");
        }
        private void r2_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("r2");
        }
        private void r3_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("r3");
        }
        private void r4_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("r4");
        }
        private void y1_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("y1");
        }
        private void y2_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("y2");
        }
        private void y3_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("y3");
        }
        private void y4_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("y4");
        }
        private void g1_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("g1");
        }
        private void g2_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("g2");
        }
        private void g3_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("g3");
        }
        private void g4_Click(object sender, EventArgs e)
        {
            Send_XuatQuanCo("g4");
        }
        
        /// ///////////////////////////////////////////////////////////////////////////////////
        
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

        ///////////////////////////////////////////////////
        private delegate void SetPictureBoxEnabledDelegate(PictureBox picturebox, bool status);
        private void SetPictureBoxEnabledSafe(PictureBox picturebox, bool status)
        {
            if (picturebox.InvokeRequired)
            {
                var d = new SetPictureBoxEnabledDelegate(SetPictureBoxEnabledSafe);
                this.Invoke(d, new object[] { picturebox, status });
            }
            else
            {
                picturebox.Enabled = status;
            }
        }

        private async  void btnSendMSG_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnSendMSG);
            if (txtSendMSG.Text == "")
            {
                return; 
            }
            if (socket.isServer)
            {
                rtbMSG.SelectionColor = Color.Cyan;
                rtbMSG.AppendText(" ");
                rtbMSG.SelectedText = User.CurrentUser.Username;
                rtbMSG.SelectionColor = Color.Black;
                rtbMSG.AppendText($": {txtSendMSG.Text}" + Environment.NewLine);
                socket.Broadcast(new SocketData((int)SocketCommand.SEND_MESSAGE, new Point(), $"{User.CurrentUser.Username}/{txtSendMSG.Text}"));
                txtSendMSG.Text = "";
                //rtbMSG.ScrollToCaret();
            }
            else
            {
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, new Point(), $"{User.CurrentUser.Username}/{txtSendMSG.Text}"));
                txtSendMSG.Text = "";
            }
        }

        private void txtSendMSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //rtbMSG.AppendText(User.CurrentUser.Username + ": " + txtSendMSG.Text + "\n");
                //rtbMSG.ScrollToCaret();
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, new Point(), $"{User.CurrentUser.Username}: {txtSendMSG.Text}"));
                txtSendMSG.Text = "";
            }
        }
        ///////////////////////////////////////////////////////////////////////
        #region UI

        readonly List<string> ptbStable = new List<string> // Các ô chuồng chứa quân cờ
        {
            "r1", "r2", "r3", "r4",
            "g1", "g2", "g3", "g4",
            "y1", "y2", "y3", "y4",
            "b1", "b2", "b3", "b4"
        };
        Color customColor01 = Color.FromArgb(181, 119, 94); // Background form
        Color customColor02 = Color.FromArgb(234, 212, 170); // Horse back color
        Color customColor03 = Color.FromArgb(255, 253, 245); // Button white color

        private void BodyConfig()
        {
            ButtonConfig();

            SetControlImage(pictureBox2, Animation.UI_Chatlog);
            SetControlImage(pictureBox1, Animation.UI_Table);
            SetControlImage(pictureBox3, Animation.UI_PlayerB_Icon);
            SetControlImage(pictureBox4, Animation.UI_PlayerR_Icon);
            SetControlImage(pictureBox5, Animation.UI_PlayerY_Icon);
            SetControlImage(pictureBox6, Animation.UI_PlayerG_Icon);

            lbun1.BringToFront();
            lbun2.BringToFront();
            lbun3.BringToFront();
            lbun4.BringToFront();

            lbun1.BackColor = customColor03;
            lbun2.BackColor = customColor03;
            lbun3.BackColor = customColor03;
            lbun4.BackColor = customColor03;

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox && ptbStable.Contains(pictureBox.Name))
                {
                    pictureBox.BackColor = customColor02;
                    pictureBox.Enabled = false;
                }

                if (control is PictureBox)
                {
                    if (control.Name.Contains("dichV"))
                    {
                        SetControlImage(control, Animation.UI_Square_Y);
                    }
                    if (control.Name.Contains("dichD"))
                    {
                        SetControlImage(control, Animation.UI_Square_R);
                    }
                    if (control.Name.Contains("dichXL"))
                    {
                        SetControlImage(control, Animation.UI_Square_G);
                    }
                    if (control.Name.Contains("dichXD"))
                    {
                        SetControlImage(control, Animation.UI_Square_B);
                    }
                }
            }

            rtbMSG.BackColor = customColor03;
            txtSendMSG.BackColor = customColor02;
            txtSendMSG.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BackColor = customColor03;
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

                    button.BackColor = customColor01;
                    if (button.Name == "btnSendMSG")
                    {
                        button.BackColor = customColor03;
                    }
                }
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

        private async void SendMSGtoFB (string code, string username, string idphong, string MSG)
        {
            string data = code + "/" + username + "/" + idphong + "/" + MSG;
            SetResponse response = await client.SetAsync("Messages/" , data);
        }

        private void btnLuatChoi_Click(object sender, EventArgs e)
        {
            PlayAnimation(btnLuatChoi);
            LuatChoi luatChoi = new LuatChoi();
            luatChoi.ShowDialog();
        }
    }
}

