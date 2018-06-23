using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class Registration_struct
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
    }
}
