using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class UserDataModel
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

        public static List<UserDataModel> Get(string query)
        {
            List<UserDataModel> list = new List<UserDataModel>();

            Database db = new Database();

            if (db.dbOpen() == true)
            {
                db.cmd = new MySqlCommand(query, db.conn);
                db.sdr = db.cmd.ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new UserDataModel
                    {
                        user_id = Convert.ToInt32(db.sdr["user_id"]),
                        username = db.sdr["username"].ToString(),
                        real_name = db.sdr["real_name"].ToString(),
                        auth = Convert.ToInt32(db.sdr["auth"]),
                        email = db.sdr["email"].ToString(),
                        valid = Convert.ToInt32(db.sdr["valid"]),
                        admintag = Convert.ToInt32(db.sdr["admintag"]),
                        lastlogindate = db.sdr["lastlogindate"].ToString(),
                        language = Convert.ToInt32(db.sdr["language"]),
                    });
                }
                db.sdr.Close();
            }
            db.dbClose();
            
            return list;
        }

    }
}
