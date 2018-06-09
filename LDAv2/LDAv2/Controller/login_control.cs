﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Controller
{
    class login_control
    {
        Session session = new Session();
        dbEntities dbE = new dbEntities();


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
        public string GetRememberedUser()
        {
            string user = "";
            try
            {
                user = dbE.SqliteReaderExecute("select username from app");
            }
            catch (Exception)
            {
                dbE.SqliteQueryExecute("CREATE TABLE IF NOT EXISTS 'app' ('username' TEXT);");
                user = dbE.SqliteReaderExecute("SELECT 'username' FROM 'app';");
            }
            return user;
        }
        public void WriteRememberedUser(string username)
        {
            dbE.SqliteQueryExecute("DELETE FROM 'app';");
            dbE.SqliteQueryExecute("INSERT INTO 'app' (username) VALUES ('" + username + "');");
        }
        public void DeleteRememberedUser()
        {
            dbE.SqliteQueryExecute("DELETE FROM 'app';");
        }
        public bool UserValider_MySql(string user)
        {
            string query = "SELECT count(id) FROM users WHERE username='" + user + "'";
            return dbE.SimpleValider_MySQL(query);
        }
        public List<UserSessData> UserSessionDataList(string username)
        {
            string query = "SELECT * FROM users WHERE username='" + username + "'";

            List<UserSessData> list = dbE.UserSession(query);

            return list;
        }
    }
}
