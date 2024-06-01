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
        public Data Owner { get; set; }
        public int CurrentPlayers { get; set; }
        public int ViewPlayers { get; set; }
        public string Status { get; set; }
    }
}
