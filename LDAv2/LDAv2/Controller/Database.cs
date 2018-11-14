using LDAv2.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LDAv2.Controller
{
    class Database
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataReader sdr;

        private const string CONNECTION_URL_1 = "Data Source = 192.168.144.189; Port=3306; Initial Catalog = ldadatabase; User ID=hr-admin; Password=pmhr2018";
        private const string CONNECTION_URL_2 = "Data Source = mysql.nethely.hu; Port = 3306; Initial Catalog = ldadatabase; User ID = ldadatabase; Password = lda2018";
        private const string CONNECTION_URL_3 = "Data Source = vpn.phoenix-mecano.hu; Port=29920; Initial Catalog = ldadatabase; User ID=hr-admin; Password=pmhr2018";

        public static string innerDataSourceURL = "Data Source = innerDatabase.db";

        public Database()
        {
            SetupDB();
        }

        //Initialize values
        private void SetupDB()
        {
            connection = new MySqlConnection(CONNECTION_URL_2);
        }
        public bool dbOpen()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public bool dbClose()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public void Execute(string query)
        {
            if (this.dbOpen() == true)
            {
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            dbClose();
        }
        public bool SimpleValider_MySQL(string query)
        {
            bool valid = false;
            if (this.dbOpen() == true)
            {
                int seged = 0;
                command = new MySqlCommand(query, connection);
                sdr = command.ExecuteReader();
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


        //public void UserActivityLogger(string username, string activity, int allapot, string cikk, string charge, string beerk, string date)
        //{
        //    SQLiteConnection conn = new SQLiteConnection(sess.databaseUrl);
        //    conn.Open();
        //    var command = conn.CreateCommand();
        //    command.CommandText = "CREATE TABLE IF NOT EXISTS userActivity (username TEXT,activity TEXT, allapot INT,cikk TEXT,charge TEXT,beerk TEXT,date TEXT) ";
        //    command.ExecuteNonQuery();
        //    command.CommandText = "INSERT INTO userActivity (username,activity,allapot,cikk,charge,beerk,date) VALUES ('" + username + "','" + activity + "'," + allapot + ",'" + cikk + "','" + charge + "','" + beerk + "','" + date + "')";
        //    command.ExecuteNonQuery();
        //    conn.Close();
        //}




        public List<Beszallito> Beszallitok_Query_MySQL(string query)
        {
            List<Beszallito> list = new List<Beszallito>();
            if (this.dbOpen() == true)
            {
                command = new MySqlCommand(query, connection);
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Beszallito
                    {
                        beszallito_id = Convert.ToInt32(sdr["beszallito_id"]),
                        nev = sdr["nev"].ToString(),
                    });
                }
                sdr.Close();
            }
            dbClose();
            return list;
        }


        // SQLite


        //public void SqliteQueryExecute(string query)
        //{
        //    SQLiteConnection connSqlite = new SQLiteConnection(innerDataSourceURL);
        //    var command = connSqlite.CreateCommand();
        //    connSqlite.Open();
        //    command.CommandText = "CREATE TABLE IF NOT EXISTS 'app' ('username' TEXT);";
        //    command.ExecuteNonQuery();
        //    command.CommandText = query;
        //    command.ExecuteNonQuery();
        //    connSqlite.Close();
        //}
        //public string SqliteReaderExecute(string query)
        //{
        //    SQLiteConnection connSqlite = new SQLiteConnection(innerDataSourceURL);
        //    connSqlite.Open();
        //    var command = connSqlite.CreateCommand();
        //    command.CommandText = query;
        //    SQLiteDataReader sdr = command.ExecuteReader();
        //    string data = "";
        //    while (sdr.Read())
        //    {
        //        data = sdr.GetValue(0).ToString();
        //    }
        //    sdr.Close();
        //    connSqlite.Close();
        //    return data;
        //}
    }
}
