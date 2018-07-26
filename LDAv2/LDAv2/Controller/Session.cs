using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.admin_model;

namespace LDAv2.Controller
{

    class Session
        {
            private static List<UserSessData> UserDatas;
            public List<UserSessData> UserData { get { return UserDatas; } set { UserDatas = value; } }

            private static string Tartomanyi;
            public string tartomanyi { get { return Tartomanyi; } set { Tartomanyi = value; } }
        }
    
}
