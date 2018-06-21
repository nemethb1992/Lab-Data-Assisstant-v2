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
            query += " ORDER BY beerk_datum DESC";
            return dbE.Measure_Compact_Query_MySQL(query);
        }
        public List<Beszallitok_Struct> Beszallitok_Query()
        {
            string query = "SELECT cikk.id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam ";
            return dbE.Beszallitok_Query_MySQL(query);
        }
    }
}
