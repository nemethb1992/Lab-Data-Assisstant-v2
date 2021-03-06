﻿using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class UserData
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

        public static List<UserData> Get(string command)
        {
            List<UserData> list = new List<UserData>();

            Database db = new Database();

            if (db.dbOpen() == true)
            {
                //db.command = new MySqlCommand(query, db.connection);
                db.sdr = (new MySqlCommand(command, db.connection)).ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new UserData
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

        public static List<UserData> GetActual(string username, string pass)
        {
            string command = "SELECT * FROM users WHERE username='" + username + "' AND pass = '" + pass + "'";

            List<UserData> list = Get(command);

            return list;
        }

        public static void Modify(List<UserData> li)
        {
            string command = "UPDATE `users` " +
                "SET `username` = '" + li[0].username + "', " +
                "`real_name` = '" + li[0].real_name + "', " +
                "`auth` = '" + li[0].auth + "', " +
                "`email` = '" + li[0].email + "', " +
                "`valid` = '" + li[0].valid + "', " +
                "`admintag` = '" + li[0].admintag + "' " +
                "WHERE `users`.`user_id` = " + li[0].user_id + ";";
            new Database().Execute(command);
        }
    }
}
