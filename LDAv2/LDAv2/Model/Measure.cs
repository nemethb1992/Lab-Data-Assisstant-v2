using LDAv2.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class Measure
    {
        public int id { get; set; }
        public string cikkszam { get; set; }
        public string szallito { get; set; }
        public string anyag_nev { get; set; }
        public string anyag_tipus { get; set; }
        public string profit_center { get; set; }
        public string utomun_metszve { get; set; }
        public string folyokep_homerseklet { get; set; }
        public string utokalapacs_meret_j { get; set; }
        public string folyokep_terheles_kg { get; set; }
        public string suruseg { get; set; }
        public string szin { get; set; }
        public string szakszig_min { get; set; }
        public string szakszig_max { get; set; }
        public string utesallosag_min { get; set; }
        public string utesallosag_max { get; set; }
        public string folyokep_min_g { get; set; }
        public string folyokep_max_g { get; set; }
        public string folyokep_min_cm { get; set; }
        public string folyokep_max_cm { get; set; }
        public string toltoanyag_min { get; set; }
        public string toltoanyag_max { get; set; }
        public int charge_id { get; set; }
        public string charge { get; set; }
        public string beerk_datum { get; set; }
        public string ut_meres_datum { get; set; }
        public string kw { get; set; }
        public string allapot { get; set; }
        public string viztartalom { get; set; }
        public string szakszig { get; set; }
        public string szakszig_gy { get; set; }
        public string utesallosag { get; set; }
        public string utesallosag_gy { get; set; }
        public string folyokep_g { get; set; }
        public string folyokep_g_gy { get; set; }
        public string folyokep_cm { get; set; }
        public string folyokep_cm_gy { get; set; }
        public string toltoanyag { get; set; }
        public string toltoanyag_gy { get; set; }
        public string megjegyzes { get; set; }

        public static List<Measure> Get(string command)
        {
            Database db = new Database();

            List<Measure> list = new List<Measure>();

            if (db.dbOpen() == true)
            {
                db.command = new MySqlCommand(command, db.connection);
                db.sdr = db.command.ExecuteReader();
                while (db.sdr.Read())
                {
                    list.Add(new Measure
                    {
                        id = Convert.ToInt32(db.sdr["id"]),
                        cikkszam = db.sdr["cikkszam"].ToString(),
                        szallito = db.sdr["szallito"].ToString(),
                        anyag_nev = db.sdr["anyag_nev"].ToString(),
                        anyag_tipus = db.sdr["anyag_tipus"].ToString(),
                        profit_center = db.sdr["profit_center"].ToString(),
                        utomun_metszve = db.sdr["utomun_metszve"].ToString(),
                        folyokep_homerseklet = db.sdr["folyokep_homerseklet"].ToString(),
                        utokalapacs_meret_j = db.sdr["utokalapacs_meret_j"].ToString(),
                        folyokep_terheles_kg = db.sdr["folyokep_terheles_kg"].ToString(),
                        suruseg = db.sdr["suruseg"].ToString(),
                        szin = db.sdr["szin"].ToString(),
                        szakszig_min = db.sdr["szakszig_min"].ToString(),
                        szakszig_max = db.sdr["szakszig_max"].ToString(),
                        utesallosag_min = db.sdr["utesallosag_min"].ToString(),
                        utesallosag_max = db.sdr["utesallosag_max"].ToString(),
                        folyokep_min_g = db.sdr["folyokep_min_g"].ToString(),
                        folyokep_max_g = db.sdr["folyokep_max_g"].ToString(),
                        folyokep_min_cm = db.sdr["folyokep_min_cm"].ToString(),
                        folyokep_max_cm = db.sdr["folyokep_max_cm"].ToString(),
                        toltoanyag_min = db.sdr["toltoanyag_min"].ToString(),
                        toltoanyag_max = db.sdr["toltoanyag_max"].ToString(),
                        charge_id = Convert.ToInt32(db.sdr["charge_id"]),
                        charge = db.sdr["charge"].ToString(),
                        beerk_datum = db.sdr["beerk_datum"].ToString(),
                        ut_meres_datum = db.sdr["ut_meres_datum"].ToString(),
                        kw = db.sdr["kw"].ToString(),
                        allapot = db.sdr["allapot"].ToString(),
                        viztartalom = db.sdr["viztartalom"].ToString(),
                        szakszig = db.sdr["szakszig"].ToString(),
                        szakszig_gy = db.sdr["szakszig_gy"].ToString(),
                        utesallosag = db.sdr["utesallosag"].ToString(),
                        utesallosag_gy = db.sdr["utesallosag_gy"].ToString(),
                        folyokep_g = db.sdr["folyokep_g"].ToString(),
                        folyokep_g_gy = db.sdr["folyokep_g_gy"].ToString(),
                        folyokep_cm = db.sdr["folyokep_cm"].ToString(),
                        folyokep_cm_gy = db.sdr["folyokep_cm_gy"].ToString(),
                        toltoanyag = db.sdr["toltoanyag"].ToString(),
                        toltoanyag_gy = db.sdr["toltoanyag_gy"].ToString(),
                        megjegyzes = db.sdr["megjegyzes"].ToString(),
                    });
                }
                db.sdr.Close();
            }
            db.dbClose();

            return list;
        }

        public static void Update(List<Measure> list)
        {
            Database db = new Database();

            string command = "UPDATE `charge` SET " +
                "`charge_cikkszam` = '" + list[0].cikkszam + "', " +
                "`charge` = '" + list[0].charge + "', " +
                "`beerk_datum` = '" + list[0].beerk_datum + "', " +
                "`ut_meres_datum` = '" + list[0].ut_meres_datum + "', " +
                "`kw` = '" + list[0].kw + "', " +
                "`allapot` = '" + list[0].allapot + "', " +
                "`viztartalom` = '" + list[0].viztartalom + "', " +
                "`szakszig` = '" + list[0].szakszig + "', " +
                "`szakszig_gy` = '" + list[0].szakszig_gy + "', " +
                "`utesallosag` = '" + list[0].utesallosag + "', " +
                "`utesallosag_gy` = '" + list[0].utesallosag_gy + "', " +
                "`folyokep_g` = '" + list[0].folyokep_g + "', " +
                "`folyokep_g_gy` = '" + list[0].folyokep_g_gy + "', " +
                "`folyokep_cm` = '" + list[0].folyokep_cm + "', " +
                "`folyokep_cm_gy` = '" + list[0].folyokep_cm_gy + "', " +
                "`toltoanyag` = '" + list[0].toltoanyag + "', " +
                "`toltoanyag_gy` = '" + list[0].toltoanyag_gy + "', " +
                "`megjegyzes` = '" + list[0].megjegyzes + "' " +
                "WHERE `charge`.`charge_id` = '" + Session.ChargeID + "'";

            db.Execute(command);
            command = "UPDATE `cikk` " +
                "SET `cikkszam` = '" + list[0].cikkszam + "', " +
                "`szallito` = '" + list[0].szallito + "', " +
                "`anyag_nev` = '" + list[0].anyag_nev + "', " +
                "`anyag_tipus` = '" + list[0].anyag_tipus + "', " +
                "`profit_center` = '" + list[0].profit_center + "', " +
                "`utomun_metszve` = '" + list[0].utomun_metszve + "', " +
                "`folyokep_homerseklet` = '" + list[0].folyokep_homerseklet + "', " +
                "`utokalapacs_meret_j` = '" + list[0].utokalapacs_meret_j + "', " +
                "`folyokep_terheles_kg` = '" + list[0].folyokep_terheles_kg + "', " +
                "`suruseg` = '" + list[0].suruseg + "', " +
                "`szin` = '" + list[0].szin + "', " +
                "`szakszig_min` = '" + list[0].szakszig_min + "', " +
                "`szakszig_max` = '" + list[0].szakszig_max + "', " +
                "`utesallosag_min` = '" + list[0].utesallosag_min + "', " +
                "`utesallosag_max` = '" + list[0].utesallosag_max + "', " +
                "`folyokep_min_g` = '" + list[0].folyokep_min_g + "', " +
                "`folyokep_max_g` = '" + list[0].folyokep_max_g + "', " +
                "`folyokep_min_cm` = '" + list[0].folyokep_min_cm + "', " +
                "`folyokep_max_cm` = '" + list[0].folyokep_max_cm + "', " +
                "`toltoanyag_min` = '" + list[0].toltoanyag_min + "', " +
                "`toltoanyag_max` = '" + list[0].toltoanyag_max + "' " +
                "WHERE `cikk`.`id` = '" + Session.CikkszamID + "'";

            db.Execute(command);
        }

        public static List<Measure> Measure_Full_Query()
        {
            string command = "SELECT * FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam WHERE cikk.id =" + Session.CikkszamID + " AND charge.charge_id = " + Session.ChargeID + " AND charge.beerk_datum = '" + Session.BedatumID + "'";
            return Measure.Get(command);
        }
    }
}
