﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Player
    {
        public static User OwnerPlayer { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public bool isOwner { get; set; }
    }
}
