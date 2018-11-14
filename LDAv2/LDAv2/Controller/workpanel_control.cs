﻿using LDAv2.Model;
using System.Collections.Generic;

namespace LDAv2.Controller
{
    class workpanel_control
    {
        Database dbE = new Database();
        Session sess = new Session();

        private static int CikkszamIDs;
        public int CikkszamID { get { return CikkszamIDs; } set { CikkszamIDs = value; } }
        private static int ChargeIDs;
        public int ChargeID { get { return ChargeIDs; } set { ChargeIDs = value; } }
        private static string BedatumIDs;
        public string BedatumID { get { return BedatumIDs; } set { BedatumIDs = value; } }
        private static List<SearchModel> SearchParams;
        public List<SearchModel> SearchParam { get { return SearchParams; } set { SearchParams = value; } }


        public List<MeasureModel> Measure_Full_Query()
        {
            string query = "SELECT * FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam WHERE cikk.id ="+ CikkszamID + " AND charge.charge_id = "+ ChargeID + " AND charge.beerk_datum = '"+ BedatumID + "'";
            return dbE.Measure_Full_Query_MySQL(query);
        }
        public List<MeasureShortModel> Measure_Compact_Query(List<string> li)
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
        public List<BeszallitoModel> Beszallitok_Query()
        {
            string query = "SELECT beszallito_id, nev FROM beszallitok ORDER BY nev DESC";
            return dbE.Beszallitok_Query_MySQL(query);
        }
        public bool Cikk_Checker(string item)
        {
            string query = "SELECT count(id) FROM cikk WHERE cikkszam='" + item + "'";
            return dbE.SimpleValider_MySQL(query);
        }
        public void Cikk_INSERT_MySQL(List<CikkModel> list)
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
        public void Charge_INSERT_MySQL(List<ChargeModel> list)
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
        public void Measure_UPDATE_MySQL(List<MeasureModel> list)
        {
            string query = "UPDATE `charge` SET " +
                "`charge_cikkszam` = '"+list[0].cikkszam+"', " +
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
                "WHERE `charge`.`charge_id` = '"+ ChargeID + "'";

            dbE.MysqlQueryExecute(query);
            string query2 = "UPDATE `cikk` " +
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
                "WHERE `cikk`.`id` = '" +CikkszamID+"'";

            dbE.MysqlQueryExecute(query2);
        }
        public void Delete_Charge(int id)
        {
            string query = "DELETE FROM `charge` WHERE `charge`.`charge_id` = " + id + ";";
            if (sess.UserData[0].admintag == 1)
            dbE.MysqlQueryExecute(query);
        }
    }
}
