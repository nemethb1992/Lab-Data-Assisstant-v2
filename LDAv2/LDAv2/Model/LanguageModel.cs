using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class LanguageModel
    {
         public int id { get; set; }
         public string hu_HU { get; set; }
         public string de_DE { get; set; }
         public string en_EN { get; set; }

        public static List<LanguageModel> Get(string query)
        {
            Database db = new Database();

            List<LanguageModel> list = new List<LanguageModel>();

            if (db.dbOpen() == true)
            {
                db.cmd = new MySqlCommand(query, db.conn);
                db.sdr = db.cmd.ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new LanguageModel
                    {
                        id = Convert.ToInt32(db.sdr["id"]),
                        hu_HU = db.sdr["hu_HU"].ToString(),
                        de_DE = db.sdr["de_DE"].ToString(),
                        en_EN = db.sdr["en_EN"].ToString(),
                    });
                }
                db.sdr.Close();
            }
            db.dbClose();

            return list;
        }

    }
}
