using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Data
    {
        public static Data CurrentUser { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public static bool IsEqual(Data user1, Data user2)
        {
            if (user1 == null || user2 == null) { return false; }
            if (user1.Password != user2.Password)
            {
                return false;
            }

            return true;
        }
    }
}
