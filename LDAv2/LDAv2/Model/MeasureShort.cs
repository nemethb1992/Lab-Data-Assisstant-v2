using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class MeasureShort
    {
        public int id { get; set; }
        public int charge_id { get; set; }
        public string cikkszam { get; set; }
        public string charge { get; set; }
        public string szallito { get; set; }
        public string anyag_nev { get; set; }
        public string anyag_tipus { get; set; }
        public string kw { get; set; }
        public string beerk_datum { get; set; }
        public string allapot { get; set; }

        public static List<MeasureShort> Get(string command)
        {
            List<MeasureShort> list = new List<MeasureShort>();

            Database db = new Database();

            if (db.dbOpen() == true)
            {
                db.command = new MySqlCommand(command, db.connection);
                db.sdr = db.command.ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new MeasureShort
                    {
                        id = Convert.ToInt32(db.sdr["id"]),
                        charge_id = Convert.ToInt32(db.sdr["charge_id"]),
                        cikkszam = db.sdr["cikkszam"].ToString(),
                        szallito = db.sdr["szallito"].ToString(),
                        anyag_nev = db.sdr["anyag_nev"].ToString(),
                        anyag_tipus = db.sdr["anyag_tipus"].ToString(),
                        charge = db.sdr["charge"].ToString(),
                        beerk_datum = db.sdr["beerk_datum"].ToString(),
                        kw = "kw " + db.sdr["kw"].ToString(),
                        allapot = db.sdr["allapot"].ToString(),
                    });
                }
                db.sdr.Close();
            }
            db.dbClose();

            return list;
        }

        public static List<MeasureShort> GetSearched(List<string> li)
        {
            string command = "SELECT cikk.id, charge.charge_id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam WHERE id IS NOT NULL AND allapot = " + li[5] + " ";
            if (li[0] != "")
            {
                command += " AND cikk.cikkszam LIKE '%" + li[0] + "%'";
            }
            if (li[1] != "")
            {
                command += " AND charge.charge LIKE '%" + li[1] + "%'";
            }
            if (li[2] != "")
            {
                command += " AND szallito LIKE '%" + li[2] + "%'";
            }
            if (li[3] != "")
            {
                command += " AND anyag_nev LIKE '%" + li[3] + "%'";
            }
            if (li[4] != "")
            {
                command += " AND beerk_datum LIKE '%" + li[4] + "%'";
            }
            command += " ORDER BY beerk_datum DESC LIMIT 25";
            return MeasureShort.Get(command);
        }

    }
}
