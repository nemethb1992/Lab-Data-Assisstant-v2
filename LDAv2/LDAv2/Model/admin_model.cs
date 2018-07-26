using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    class admin_model
    {
        public class Activity_Struct
        {
            public string username { get; set; }
            public string activity { get; set; }
            public string allapot { get; set; }
            public string cikk { get; set; }
            public string charge { get; set; }
            public string beerk { get; set; }
            public string date { get; set; }
        }
        public class UserSessData
        {
            public int user_id { get; set; }
            public string username { get; set; }
            public string pass { get; set; }
            public string real_name { get; set; }
            public int auth { get; set; }
            public string email { get; set; }
            public int valid { get; set; }
            public int admintag { get; set; }
            public string lastlogindate { get; set; }
            public int language { get; set; }
            public string allapot_megnev { get; set; }
        }
    }
}
