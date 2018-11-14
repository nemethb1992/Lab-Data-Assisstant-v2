using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class ActivityModel
    {
        public string username { get; set; }
        public string activity { get; set; }
        public string allapot { get; set; }
        public string cikk { get; set; }
        public string charge { get; set; }
        public string beerk { get; set; }
        public string date { get; set; }

        public static List<ActivityModel> Get(string query)
        {
            Database db = new Database();

            List<ActivityModel> list = new List<ActivityModel>();

            if (db.dbOpen() == true)
            {
                db.cmd = new MySqlCommand(query, db.conn);
                db.sdr = db.cmd.ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new ActivityModel
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
