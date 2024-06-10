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
        public string RankRoom { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public User Player3 { get; set; }
        public User Player4 { get; set; }
        public int CurrentPlayers { get; set; }
    }
}
