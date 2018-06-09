using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Controller
{
    public struct UserSessData
    {
        public int user_id;
        public string username;
        public string real_name;
        public int auth;
        public string email;
        public int valid;
        public int admintag;
        public string lastlogindate;
        public int language;
    }

    class Session
        {
            private static List<UserSessData> UserDatas;
            public List<UserSessData> UserData { get { return UserDatas; } set { UserDatas = value; } }

            private static string Tartomanyi;
            public string tartomanyi { get { return Tartomanyi; } set { Tartomanyi = value; } }
        }
    
}
