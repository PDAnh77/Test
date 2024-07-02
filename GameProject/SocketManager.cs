using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public class SocketManager
    {
        #region Client 
        Socket client;
        public bool ConnectServer() //bên Client sẽ connect server
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Server
        Socket server;
        public List<Socket> clientSockets = new List<Socket>(); // Danh sách các socket client
        public List<Socket> viewSockets = new List<Socket>();
        private Thread acceptClient;
        private Thread checkClients;
        int Player = 4;
        public void CreateServer() //bên Server sẽ tạo server để Client connect tới
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep); //gán Socket server với 1 địa chỉ cụ thể
            server.Listen(10); //lắng nghe kết nối từ Client tới 

            acceptClient = new Thread(() =>
            {
                while (isServerRun)
                {
                    try
                    {
                        client = server.Accept();
                        if (clientSockets.Count >= Player) // Phòng đã có đủ người chơi hoặc đã bắt đầu 
                        {
                            viewSockets.Add(client);
                        }
                        else
                        {
                            clientSockets.Add(client);
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            });
            acceptClient.IsBackground = true; //tự ngắt luồng khi ctrinh tắt
            acceptClient.Start();

            checkClients = new Thread(CheckClientConnections);
            checkClients.IsBackground = true;
            checkClients.Start();
        }

        private void CheckClientConnections()
        {
            while (isServerRun)
            {
                lock (clientSockets)
                {
                    for (int i = clientSockets.Count - 1; i >= 0; i--)
                    {
                        Socket client = clientSockets[i];
                        if (client.Poll(1000, SelectMode.SelectRead) && client.Available == 0)
                        {
                            // Client has disconnected
                            clientSockets.RemoveAt(i);
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                    }
                }
                Thread.Sleep(1000); // Check every 1 seconds
            }
        }

        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int port = 1999;
        public const int buffer = 1024;
        public bool isServer = true;
        public bool isPlayer = true;
        public bool isServerRun = true;

        public bool ClientAlive() // Kiểm tra client có còn tồn tại không
        {
            if (client != null)
            {
                return true;
            }
            return false;
        }

        public bool ServerAlive() // Kiểm tra server có còn tồn tại không
        {
            if (server != null)
            {
                return true;
            }
            return false;
        }

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        public object Receive()
        {
            byte[] receiveData = new byte[buffer];
            bool isOk = ReceiveData(client, receiveData);
            if (isOk)
            {
                return DeserializeData(receiveData);
            }
            else
            {
                // Xử lý khi không nhận được dữ liệu hoặc lỗi xảy ra
                return null;
            }
        }

        public bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) > 0 ? true : false;
        }

        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) > 0 ? true : false;
        }

        // Nén Object ob thành 1 mảng byte[]
        public byte[] SerializeData(Object ob)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, ob);
            return ms.ToArray();
        }

        // Giải nén mảng byte[] thành đối tượng Object
        public object DeserializeData(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            BinaryFormatter bf = new BinaryFormatter();
            ms.Position = 0; // vị trí đầu dãy
            return bf.Deserialize(ms);
        }

        public void Broadcast(object data)
        {
            byte[] sendData = SerializeData(data);
            foreach (Socket socket in clientSockets)
            {
                SendData(socket, sendData);
            }
        }

        public void CloseClient()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        public void CloseConnect()
        {
            if (server != null)
            {
                server.Close();
                isServerRun = false;                
            }
        }

        //lấy IPv4 của card mạng đang dùng
        public string GetLocalIPv4(NetworkInterfaceType type)
        {
            string output = null;
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == type && item.OperationalStatus == OperationalStatus.Up) //nhận kiểu giao diện && bật giao diện mạng để truyền dữ liệu
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork) //so sánh với địa chỉ IPv4
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        #endregion
    }
}
