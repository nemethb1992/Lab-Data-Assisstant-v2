using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class Activity
    {
        public string username { get; set; }
        public string activity { get; set; }
        public string allapot { get; set; }
        public string cikk { get; set; }
        public string charge { get; set; }
        public string beerk { get; set; }
        public string date { get; set; }

        public static List<Activity> Get(string command)
        {
            Database db = new Database();

            List<Activity> list = new List<Activity>();

            if (db.dbOpen() == true)
            {
                db.command = new MySqlCommand(command, db.connection);

                db.sdr = db.command.ExecuteReader();

                while (db.sdr.Read())
                {
                    list.Add(new Activity
                    {
                        username = db.sdr["username"].ToString(),
                        activity = db.sdr["activity"].ToString(),
                        allapot = db.sdr["allapot"].ToString(),
                        cikk = db.sdr["cikk"].ToString(),
                        charge = db.sdr["charge"].ToString(),
                        beerk = db.sdr["beerk"].ToString(),
                        date = db.sdr["date"].ToString(),
                    });
                }
                db.sdr.Close();
            }
            db.dbClose();

            return list;
        }

    }
}
