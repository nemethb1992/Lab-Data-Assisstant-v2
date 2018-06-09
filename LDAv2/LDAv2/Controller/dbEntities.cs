using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LDAv2.Controller
{
    class dbEntities
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader sdr;

        public static string innerDataSourceURL = "Data Source = innerDatabase.db";

        public dbEntities()
        {
            SetupDB();
        }

        //Initialize values
        private void SetupDB()
        {
            string connectionString = "Data Source = mysql.nethely.hu; Port = 3306; Initial Catalog = ldadatabase; User ID = ldadatabase; Password = lda2018";
            conn = new MySqlConnection(connectionString);
        }
        public bool dbOpen()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        private bool dbClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public bool SimpleValider_MySQL(string query)
        {
            bool valid = false;
            if (this.dbOpen() == true)
            {
                int seged = 0;
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    seged = Convert.ToInt32(sdr[0]);
                }
                sdr.Close();
                dbClose();
                if (seged != 0)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            return valid;
        }

        public List<UserSessData> UserSession(string query)
        {

            List<UserSessData> list = new List<UserSessData>();
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new UserSessData
                    {
                        user_id = Convert.ToInt32(sdr["user_id"]),
                        username = sdr["username"].ToString(),
                        real_name = sdr["real_name"].ToString(),
                        auth = Convert.ToInt32(sdr["auth"]),
                        email = sdr["email"].ToString(),
                        valid = Convert.ToInt32(sdr["valid"]),
                        admintag = Convert.ToInt32(sdr["admintag"]),
                        lastlogindate = sdr["lastlogindate"].ToString(),
                        language = Convert.ToInt32(sdr["language"]),
                    });
                }
                sdr.Close();
            }
            dbClose();


            //conn.Close();
            return list;
        }


        // SQLite


        public void SqliteQueryExecute(string query)
        {
            SQLiteConnection connSqlite = new SQLiteConnection(innerDataSourceURL);
            var command = connSqlite.CreateCommand();
            connSqlite.Open();
            //command.CommandText = "CREATE TABLE IF NOT EXISTS 'app' ('username' TEXT);";
            //command.ExecuteNonQuery();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connSqlite.Close();
        }
        public string SqliteReaderExecute(string query)
        {
            SQLiteConnection connSqlite = new SQLiteConnection(innerDataSourceURL);
            connSqlite.Open();
            var command = connSqlite.CreateCommand();
            command.CommandText = query;
            SQLiteDataReader sdr = command.ExecuteReader();
            string data = "";
            while (sdr.Read())
            {
                data = sdr.GetValue(0).ToString();
            }
            sdr.Close();
            connSqlite.Close();
            return data;
        }
    }
}
