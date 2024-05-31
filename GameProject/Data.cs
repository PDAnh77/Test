using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Data
    {
        public static Data CurrentUser { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        
        public string Gender { get; set; }

        public string Age { get; set; }

        public Data()
        {
            Username = "None";
            Password = "None";
            Email = "None";
            Gender = "None";
            Age = "None";
        }

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
