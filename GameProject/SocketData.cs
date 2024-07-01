using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    [Serializable]
    public class SocketData
    {
        private int command;
        public int Command { get => command; set => command = value; }

        private Point point;
        public Point Point { get => point; set => point = value; }


        private String message;
        public string Message { get => message; set => message = value; }

        public SocketData(int command, Point point, String messege)
        {
            this.Command = command;
            this.Point = point;
            this.Message = messege;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        QUIT,
        START,
        CREATE_ROOM,
        JOIN_ROOM,
        XUAT_QUAN,
        SAN_SANG,
        SEND_MESSEGE,
        SEND_DICE,
        STARTTIMER
    }
}
