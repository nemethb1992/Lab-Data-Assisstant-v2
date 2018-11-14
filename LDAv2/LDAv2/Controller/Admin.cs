using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LDAv2.Model.UserData;

namespace LDAv2.Controller
{
    class Admin
    {


        private static int User_id;
        public int User_ID { get { return User_id; } set { User_id = value; } }

        Database dbE = new Database();
        public List<Activity> GetActivityList(List<string> list)
        {
            string query = "SELECT * FROM userActivity WHERE allapot = "+list[0]+" ";
            if (list[1].Length > 0)
                query += " AND userActivity.username LIKE '%" + list[1] + "%'";
            if (list[2].Length > 0)
                query += " AND userActivity.activity LIKE '%" + list[2] + "%'";
            if (list[3].Length > 0)
                query += " AND userActivity.cikk LIKE '%" + list[3] + "%'";
            if (list[4].Length > 0)
                query += " AND userActivity.charge LIKE '%" + list[4] + "%'";
            if (list[5].Length > 0)
                query += " AND userActivity.beerk LIKE '%" + list[5] + "%'";
            if (list[6].Length > 0)
                query += " AND userActivity.date LIKE '%" + list[6] + "%'";

            query += " ORDER BY date DESC LIMIT 50";
            return Activity.Get(query);
        }
        public List<UserData> GetUserData()
        {
            string query = "SELECT user_id, `username`, `real_name`, `auth`, `email`, `valid`, `admintag`, `lastlogindate`, `language` FROM users";

            List<UserData> list = UserData.Get(query);

            return list;
        }
        public List<UserData> GetUser(int id)
        {
            string query = "SELECT * FROM users WHERE user_id='" + id + "'";

            List<UserData> list = UserData.Get(query);

            return list;
        }

        public void Delete_User(int id)
        {
            string query = "DELETE FROM `users` WHERE `users`.`user_id` = " + id + ";";
            dbE.Execute(query);
        }
    }
}
