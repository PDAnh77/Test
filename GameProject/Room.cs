using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Room
    {
        public static string CurRoomName { get; set; }
        public string Name { get; set; }
        public Data Player1 { get; set; }
        public Data Player2 { get; set; }
        public Data Player3 { get; set; }
        public Data Player4 { get; set; }
        public int CurrentPlayers { get; set; }
        public int ViewPlayers { get; set; }
        public string Status { get; set; }
    }
}
