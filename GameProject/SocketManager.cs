using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
        List<Socket> clientSockets = new List<Socket>(); // Danh sách các socket client
        public void CreateServer() //bên Server sẽ tạo server để Client connect tới
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep); //gán Socket server với 1 địa chỉ cụ thể
            server.Listen(10); //lắng nghe kết nối từ Client tới 

            for (int i = 0; i < 2; i++)
            {
                if (i == 1) ++i;
                Thread acceptClient = new Thread(() =>
                {
                    client = server.Accept();
                });
                acceptClient.IsBackground = true; //tự ngắt luồng khi ctrinh tắt
                acceptClient.Start();
            }
        }

        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int port = 1999;
        public const int buffer = 1024;
        public bool isServer = true;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        public object Receive()
        {
            byte[] receiveData = new byte[buffer];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);
        }

        public bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        public void CloseConnect()
        {
            server.Close();
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
        //lấy IPv4 của card mạng đang dùng
        public string GetLocalIPv4(NetworkInterfaceType type)
        {
            string output = "";
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
