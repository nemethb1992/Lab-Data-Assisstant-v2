using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.UserDataModel;

namespace LDAv2.Controller
{

    class Session
        {
            private static List<UserDataModel> UserDatas;
            public List<UserDataModel> UserData { get { return UserDatas; } set { UserDatas = value; } }

            private static string Tartomanyi;
            public string tartomanyi { get { return Tartomanyi; } set { Tartomanyi = value; } }
        }
    
}
