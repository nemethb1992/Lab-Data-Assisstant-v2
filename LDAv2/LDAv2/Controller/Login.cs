using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.UserData;

namespace LDAv2.Controller
{
    class Login
    {
        Database db = new Database();

        public bool Validation(string username, string pass)
        {
            string query = "SELECT count(user_id) FROM users WHERE username='" + username + "' AND pass = '"+pass+"'";
            return db.SimpleValider_MySQL(query);
        }

        public bool IsExistsByUsername(string username)
        {
            string query = "SELECT count(user_id) FROM users WHERE username='" + username + "'";
            return db.SimpleValider_MySQL(query);
        }
        public bool IsExistsByEmail(string email)
        {
            string query = "SELECT count(user_id) FROM users WHERE email='" + email + "'";
            return db.SimpleValider_MySQL(query);
        }
        public void Insert(List<UserData> list)
        {
            db.Execute("INSERT INTO ldadatabase.users (`username`, `pass`, `real_name`, `auth`, `email`, `valid`, `admintag`, `lastlogindate`, `language`) " +
                "VALUES ('"+list[0].username+"', '"+ list[0].pass + "', '"+ list[0].real_name + "', "+ list[0].auth + ", '"+ list[0].email + "', "+ list[0].valid + ", "+ list[0].admintag + ", '"+ list[0].lastlogindate + "', "+ list[0].language + ");");
        }

    }
}
