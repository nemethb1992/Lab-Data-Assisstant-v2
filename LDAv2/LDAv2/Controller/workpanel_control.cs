using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.workpanel_model;

namespace LDAv2.Controller
{
    class workpanel_control
    {
        dbEntities dbE = new dbEntities();


        private static int CikkszamIDs;
        public int CikkszamID { get { return CikkszamIDs; } set { CikkszamIDs = value; } }
        private static int ChargeIDs;
        public int ChargeID { get { return ChargeIDs; } set { ChargeIDs = value; } }
        private static string BedatumIDs;
        public string BedatumID { get { return BedatumIDs; } set { BedatumIDs = value; } }

        public struct Search_Params
        {
            public string cikkszam;
            public string charge;
            public string szallito;
            public string anyagnev;
            public string beerk_datum;
            public bool allapot;
        }
        private static List<Search_Params> SearchParams;
            public List<Search_Params> SearchParam { get { return SearchParams; } set { SearchParams = value; } }


            public List<Measure_Full_Struct> Measure_Full_Query()
        {
            string query = "SELECT * FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam WHERE cikk.id ="+ CikkszamID + " AND charge.charge_id = "+ ChargeID + " AND charge.beerk_datum = '"+ BedatumID + "'";
            return dbE.Measure_Full_Query_MySQL(query);
        }
        public List<Measure_Compact_Struct> Measure_Compact_Query(List<string> li)
        {
            string query = "SELECT cikk.id, charge.charge_id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam WHERE id IS NOT NULL AND allapot = "+li[5]+" ";
            if(li[0] != "")
            {
                query += " AND cikk.cikkszam LIKE '%"+li[0]+"%'";
            }
            if (li[1] != "")
            {
                query += " AND charge.charge LIKE '%" + li[1] + "%'";
            }
            if (li[2] != "")
            {
                query += " AND szallito LIKE '%" + li[2] + "%'";
            }
            if (li[3] != "")
            {
                query += " AND anyag_nev LIKE '%" + li[3] + "%'";
            }
            if (li[4] != "")
            {
                query += " AND beerk_datum LIKE '%" + li[4] + "%'";
            }
            query += " ORDER BY beerk_datum DESC LIMIT 25";
            return dbE.Measure_Compact_Query_MySQL(query);
        }
        public List<Beszallitok_Struct> Beszallitok_Query()
        {
            string query = "SELECT cikk.id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam ";
            return dbE.Beszallitok_Query_MySQL(query);
        }
        public bool Cikk_Checker(string item)
        {
            string query = "SELECT count(id) FROM cikk WHERE cikkszam='" + item + "'";
            return dbE.SimpleValider_MySQL(query);
        }
        public void Cikk_INSERT_MySQL(List<Cikk_Struct> list)
        {
            string query = "INSERT INTO `cikk` (`id`, `cikkszam`, `szallito`, `anyag_nev`, `anyag_tipus`, `profit_center`, `utomun_metszve`, `folyokep_homerseklet`, `utokalapacs_meret_j`, `folyokep_terheles_kg`, `suruseg`, `szin`, `szakszig_min`, `szakszig_max`, `utesallosag_min`, `utesallosag_max`, `folyokep_min_g`, `folyokep_max_g`, `folyokep_min_cm`, `folyokep_max_cm`, `toltoanyag_min`, `toltoanyag_max`) " +
            "VALUES(NULL, " +
            "'" + list[0].cikkszam + "', " +
            "'" + list[0].szallito + "', " +
            "'" + list[0].anyag_nev + "', " +
            "'" + list[0].anyag_tipus + "', " +
            "'" + list[0].profit_center + "', " +
            "'" + list[0].utomun_metszve + "', " +
            "'" + list[0].folyokep_homerseklet + "', " +
            "'" + list[0].utokalapacs_meret_j + "', " +
            "'" + list[0].folyokep_terheles_kg + "', " +
            "'" + list[0].suruseg + "', " +
            "'" + list[0].szin + "', " +
            "'" + list[0].szakszig_min + "', " +
            "'" + list[0].szakszig_max + "', " +
            "'" + list[0].utesallosag_min + "', " +
            "'" + list[0].utesallosag_max + "', " +
            "'" + list[0].folyokep_min_g + "', " +
            "'" + list[0].folyokep_max_g + "', " +
            "'" + list[0].folyokep_min_cm + "', " +
            "'" + list[0].folyokep_max_cm + "', " +
            "'" + list[0].toltoanyag_min + "', " +
            "'" + list[0].toltoanyag_max + "');";
            dbE.MysqlQueryExecute(query);
        }
        public void Charge_INSERT_MySQL(List<Charge_Struct> list)
        {
            string query = "INSERT INTO `charge` (`charge_id`, `charge_cikkszam`, `charge`, `beerk_datum`, `ut_meres_datum`, `kw`, `megjegyzes`) " +
            "VALUES (NULL, " +
            "'" + list[0].charge_cikkszam + "', " +
            "'" + list[0].charge + "', " +
            "'" + list[0].beerk_datum + "', " +
            "'" + list[0].ut_meres_datum + "', " +
            "'" + list[0].kw + "', " +
            "'" + list[0].megjegyzes + "');";

            dbE.MysqlQueryExecute(query);
        }
        public void Measure_UPDATE_MySQL(List<Charge_Struct> list)
        {
            string query = "UPDATE `charge` SET " +
                "`charge_cikkszam` = 'cikkszam', " +
                "`charge` = 'charge.', " +
                "`beerk_datum` = '2018.06.28..', " +
                "`ut_meres_datum` = '2018.06.28..', " +
                "`kw` = '30.', " +
                "`allapot` = '1', " +
                "`viztartalom` = '1', " +
                "`szakszig` = '1', " +
                "`szakszig_gy` = '1', " +
                "`utesallosag` = '1', " +
                "`utesallosag_gy` = '1', " +
                "`folyokep_g` = '1', " +
                "`folyokep_g_gy` = '1', " +
                "`folyokep_cm` = '1', " +
                "`folyokep_cm_gy` = '1', " +
                "`toltoanyag` = '1', " +
                "`toltoanyag_gy` = '1', " +
                "`megjegyzes` = 'megjegyzes1' " +
                "WHERE `charge`.`charge_id` = 399;";

            dbE.MysqlQueryExecute(query);
        }
    }
}
