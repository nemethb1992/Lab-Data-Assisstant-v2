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

        public List<Measure_Full_Struct> Measure_Full_Query()
        {
            string query = "SELECT * FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam";
            return dbE.Measure_Full_Query_MySQL(query);
        }
        public List<Measure_Compact_Struct> Measure_Compact_Query()
        {
            string query = "SELECT cikk.id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam ";
            return dbE.Measure_Compact_Query_MySQL(query);
        }
        public List<Beszallitok_Struct> Beszallitok_Query()
        {
            string query = "SELECT cikk.id, cikk.cikkszam,charge.charge,szallito,anyag_nev,anyag_tipus,kw,beerk_datum,allapot FROM charge LEFT JOIN cikk ON charge.charge_cikkszam = cikk.cikkszam ";
            return dbE.Beszallitok_Query_MySQL(query);
        }
    }
}
