using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class DSUser
    {
        public static DSUser CurrentUser { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        
        public string Gender { get; set; }

        public int Age { get; set; }

        public string Rank { get; set; } 

        public int Win { get; set; }

        public int Lose { get; set; }

        public DSUser()
        {
            Username = "None";
            Password = "None";
            Email = "None";
            Gender = "None";
            Age = 0;
            Rank = "None";
            Win = 0;
            Lose = 0; 
        }
    }
}
