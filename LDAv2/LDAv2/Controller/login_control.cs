using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.UserDataModel;

namespace LDAv2.Controller
{
    class Login
    {
        Session session = new Session();
        Database db = new Database();


        //public bool userValidation(string name, string pass)
        //{

        //    DateTime dateTime = DateTime.Now;
        //    bool valider = false;
        //    int found = dbE.MysqlReaderRowCount("SELECT count(id) FROM users WHERE username='" + name + "'");
        //    if (found == 1)
        //    {
        //        valider = true;
        //        dbE.SqliteQueryExecute("UPDATE users SET belepve = '" + dateTime.ToString("yyyy. MM. dd.") + "' WHERE username = '" + name + "';");
        //    }
        //    return valider;
        //}
        //public string GetRememberedUser()
        //{
        //    string user = "";
        //    try
        //    {
        //        user = dbE.SqliteReaderExecute("select username from app");
        //    }
        //    catch (Exception)
        //    {
        //        dbE.SqliteQueryExecute("CREATE TABLE IF NOT EXISTS 'app' ('username' TEXT);");
        //        user = dbE.SqliteReaderExecute("SELECT 'username' FROM 'app';");
        //    }
        //    return user;
        //}
        //public void WriteRememberedUser(string username)
        //{
        //    dbE.SqliteQueryExecute("DELETE FROM 'app';");
        //    dbE.SqliteQueryExecute("INSERT INTO 'app' (username) VALUES ('" + username + "');");
        //}
        //public void DeleteRememberedUser()
        //{
        //    dbE.SqliteQueryExecute("DELETE FROM 'app';");
        //}
        public bool UserValider_MySql(string username, string pass)
        {
            string query = "SELECT count(user_id) FROM users WHERE username='" + username + "' AND pass = '"+pass+"'";
            return db.SimpleValider_MySQL(query);
        }
        public List<UserDataModel> UserSessionDataList(string username, string pass)
        {
            string query = "SELECT * FROM users WHERE username='" + username + "' AND pass = '" + pass + "'";

            List<UserDataModel> list = Get(query);

            return list;
        }
        public bool Registration_Username_Checker(string username)
        {
            string query = "SELECT count(user_id) FROM users WHERE username='" + username + "'";
            return db.SimpleValider_MySQL(query);
        }
        public bool Registration_Email_Checker(string email)
        {
            string query = "SELECT count(user_id) FROM users WHERE email='" + email + "'";
            return db.SimpleValider_MySQL(query);
        }
        public void User_Registration_Write(List<UserDataModel> list)
        {
            db.MysqlQueryExecute("INSERT INTO ldadatabase.users (`username`, `pass`, `real_name`, `auth`, `email`, `valid`, `admintag`, `lastlogindate`, `language`) " +
                "VALUES ('"+list[0].username+"', '"+ list[0].pass + "', '"+ list[0].real_name + "', "+ list[0].auth + ", '"+ list[0].email + "', "+ list[0].valid + ", "+ list[0].admintag + ", '"+ list[0].lastlogindate + "', "+ list[0].language + ");");
        }

    }
}
