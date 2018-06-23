﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Controller
{
    public class UserSessData
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string real_name { get; set; }
        public int auth { get; set; }
        public string email { get; set; }
        public int valid { get; set; }
        public int admintag { get; set; }
        public string lastlogindate { get; set; }
        public int language { get; set; }
    }

    class Session
        {
            private static List<UserSessData> UserDatas;
            public List<UserSessData> UserData { get { return UserDatas; } set { UserDatas = value; } }

            private static string Tartomanyi;
            public string tartomanyi { get { return Tartomanyi; } set { Tartomanyi = value; } }
        }
    
}
