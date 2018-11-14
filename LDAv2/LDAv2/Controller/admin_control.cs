using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LDAv2.Model.UserDataModel;

namespace LDAv2.Controller
{
    class admin_control
    {


        private static int User_id;
        public int User_ID { get { return User_id; } set { User_id = value; } }

        Database dbE = new Database();
        public List<ActivityModel> Aktivitas_List(List<string> list)
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
            return ActivityModel.Get(query);
        }
        public List<UserDataModel> Admin_User_Datasource()
        {
            string query = "SELECT user_id, `username`, `real_name`, `auth`, `email`, `valid`, `admintag`, `lastlogindate`, `language` FROM users";

            List<UserDataModel> list = UserDataModel.Get(query);

            return list;
        }
        public List<UserDataModel> SelectedUserDataSource(int id)
        {
            string query = "SELECT * FROM users WHERE user_id='" + id + "'";

            List<UserDataModel> list = UserDataModel.Get(query);

            return list;
        }
        public void SelectedUserModification(List<UserDataModel> li)
        {
            string query = "UPDATE `users` " +
                "SET `username` = '" + li[0].username+ "', " +
                "`real_name` = '" + li[0].real_name+ "', " +
                "`auth` = '" + li[0].auth+ "', " +
                "`email` = '" + li[0].email+ "', " +
                "`valid` = '" + li[0].valid+ "', " +
                "`admintag` = '" + li[0].admintag+ "' " +
                "WHERE `users`.`user_id` = "+li[0].user_id+";";
            dbE.MysqlQueryExecute(query);
        }
        public void Delete_User(int id)
        {
            string query = "DELETE FROM `users` WHERE `users`.`user_id` = " + id + ";";
            dbE.MysqlQueryExecute(query);
        }
    }
}
