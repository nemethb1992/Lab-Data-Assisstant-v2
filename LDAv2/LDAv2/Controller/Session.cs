using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.UserData;

namespace LDAv2.Controller
{

    class Session
        {
            private static List<UserData> UserDatas;
            public static List<UserData> UserData { get { return UserDatas; } set { UserDatas = value; } }

        private static List<Search> SearchParams;
        public static List<Search> SearchParam { get { return SearchParams; } set { SearchParams = value; } }


        private static string Tartomanyi;
            public static string tartomanyi { get { return Tartomanyi; } set { Tartomanyi = value; } }


        private static int CikkszamIDs;
        public static int CikkszamID { get { return CikkszamIDs; } set { CikkszamIDs = value; } }

        private static int ChargeIDs;
        public static int ChargeID { get { return ChargeIDs; } set { ChargeIDs = value; } }

        private static string BedatumIDs;
        public static string BedatumID { get { return BedatumIDs; } set { BedatumIDs = value; } }
    }
    
}
