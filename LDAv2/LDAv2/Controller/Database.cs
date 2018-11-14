using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static LDAv2.Model.admin_model;
using static LDAv2.Model.language_model;
using static LDAv2.Model.workpanel_model;

namespace LDAv2.Controller
{
    class Database
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader sdr;

        //string connectionString = "Data Source = 192.168.144.189; Port=3306; Initial Catalog = ldadatabase; User ID=hr-admin; Password=pmhr2018";
        //string connectionString = "Data Source = vpn.phoenix-mecano.hu; Port=29920; Initial Catalog = ldadatabase; User ID=hr-admin; Password=pmhr2018";
        //string connectionString = "Data Source = mysql.nethely.hu; Port = 3306; Initial Catalog = ldadatabase; User ID = ldadatabase; Password = lda2018";
        public static string innerDataSourceURL = "Data Source = innerDatabase.db";

        public Database()
        {
            SetupDB();
        }

        //Initialize values
        private void SetupDB()
        {
            string connectionString = "Data Source = 192.168.144.189; Port=3306; Initial Catalog = ldadatabase; User ID=hr-admin; Password=pmhr2018";
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

        public void MysqlQueryExecute(string query)
        {
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            dbClose();
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
        public List<Measure_Full_Struct> Measure_Full_Query_MySQL(string query)
        {
            List<Measure_Full_Struct> list = new List<Measure_Full_Struct>();
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Measure_Full_Struct
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        cikkszam = sdr["cikkszam"].ToString(),
                        szallito = sdr["szallito"].ToString(),
                        anyag_nev = sdr["anyag_nev"].ToString(),
                        anyag_tipus = sdr["anyag_tipus"].ToString(),
                        profit_center = sdr["profit_center"].ToString(),
                        utomun_metszve = sdr["utomun_metszve"].ToString(),
                        folyokep_homerseklet = sdr["folyokep_homerseklet"].ToString(),
                        utokalapacs_meret_j = sdr["utokalapacs_meret_j"].ToString(),
                        folyokep_terheles_kg = sdr["folyokep_terheles_kg"].ToString(),
                        suruseg = sdr["suruseg"].ToString(),
                        szin = sdr["szin"].ToString(),
                        szakszig_min = sdr["szakszig_min"].ToString(),
                        szakszig_max = sdr["szakszig_max"].ToString(),
                        utesallosag_min = sdr["utesallosag_min"].ToString(),
                        utesallosag_max = sdr["utesallosag_max"].ToString(),
                        folyokep_min_g = sdr["folyokep_min_g"].ToString(),
                        folyokep_max_g = sdr["folyokep_max_g"].ToString(),
                        folyokep_min_cm = sdr["folyokep_min_cm"].ToString(),
                        folyokep_max_cm = sdr["folyokep_max_cm"].ToString(),
                        toltoanyag_min = sdr["toltoanyag_min"].ToString(),
                        toltoanyag_max = sdr["toltoanyag_max"].ToString(),
                        charge_id = Convert.ToInt32(sdr["charge_id"]),
                        charge = sdr["charge"].ToString(),
                        beerk_datum = sdr["beerk_datum"].ToString(),
                        ut_meres_datum = sdr["ut_meres_datum"].ToString(),
                        kw = sdr["kw"].ToString(),
                        allapot = sdr["allapot"].ToString(),
                        viztartalom = sdr["viztartalom"].ToString(),
                        szakszig = sdr["szakszig"].ToString(),
                        szakszig_gy = sdr["szakszig_gy"].ToString(),
                        utesallosag = sdr["utesallosag"].ToString(),
                        utesallosag_gy = sdr["utesallosag_gy"].ToString(),
                        folyokep_g = sdr["folyokep_g"].ToString(),
                        folyokep_g_gy = sdr["folyokep_g_gy"].ToString(),
                        folyokep_cm = sdr["folyokep_cm"].ToString(),
                        folyokep_cm_gy = sdr["folyokep_cm_gy"].ToString(),
                        toltoanyag = sdr["toltoanyag"].ToString(),
                        toltoanyag_gy = sdr["toltoanyag_gy"].ToString(),
                        megjegyzes = sdr["megjegyzes"].ToString(),
                    });
                }
                sdr.Close();
            }
            dbClose();
            return list;
        }
        public List<Measure_Compact_Struct> Measure_Compact_Query_MySQL(string query)
        {
            List<Measure_Compact_Struct> list = new List<Measure_Compact_Struct>();
            if (this.dbOpen() == true)
            {
                int i = 0;
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Measure_Compact_Struct
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        charge_id = Convert.ToInt32(sdr["charge_id"]),
                        cikkszam = sdr["cikkszam"].ToString(),
                        szallito = sdr["szallito"].ToString(),
                        anyag_nev = sdr["anyag_nev"].ToString(),
                        anyag_tipus = sdr["anyag_tipus"].ToString(),
                        charge = sdr["charge"].ToString(),
                        beerk_datum = sdr["beerk_datum"].ToString(),
                        kw = "kw " + sdr["kw"].ToString(),
                        allapot = sdr["allapot"].ToString(),
                    });
                    i++;
                }
                sdr.Close();
            }
            dbClose();
            return list;
        }

        public List<Beszallitok_Struct> Beszallitok_Query_MySQL(string query)
        {
            List<Beszallitok_Struct> list = new List<Beszallitok_Struct>();
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Beszallitok_Struct
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
        public List<Language_Struct> Language_Query_MySQL(string query)
        {
            List<Language_Struct> list = new List<Language_Struct>();
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Language_Struct
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        hu_HU = sdr["hu_HU"].ToString(),
                        de_DE = sdr["de_DE"].ToString(),
                        en_EN = sdr["en_EN"].ToString(),
                    });
                }
                sdr.Close();
            }
            dbClose();
            return list;
        }
        public List<Activity_Struct> Activity_Query_MySQL(string query)
        {
            List<Activity_Struct> list = new List<Activity_Struct>();
            if (this.dbOpen() == true)
            {
                cmd = new MySqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Activity_Struct
                    {
                        username = sdr["username"].ToString(),
                        activity = sdr["activity"].ToString(),
                        allapot = sdr["allapot"].ToString(),
                        cikk = sdr["cikk"].ToString(),
                        charge = sdr["charge"].ToString(),
                        beerk = sdr["beerk"].ToString(),
                        date = sdr["date"].ToString(),
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
