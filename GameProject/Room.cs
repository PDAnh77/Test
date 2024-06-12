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
        public string Name { get; set; } // Tên phòng

        public string Chat {  get; set; }
        public string RankRoom { get; set; } // Rank của phòng, người chơi cùng rank với phòng mới được vào

        public User Owner { get; set; } // Chứa dữ liệu của người chơi chủ phòng

        public User Player2 { get; set; } // Chứa dữ liệu của người chơi thứ 2

        public User Player3 { get; set; } // Chứa dữ liệu của người chơi thứ 3

        public User Player4 { get; set; } // Chứa dữ liệu của người chơi thứ 4

        public int CurrentPlayers { get; set; } // Số lượng người chơi hiện tại trong phòng

        // Số lượng người chơi đã sẵn sàng trong phòng, khi số người sẵn sàng bằng số lượng người trong phòng thì mới được bắt đầu game
        public int CurrentReady { get; set; } 

        public bool GameStarted { get; set; }
    }
}
