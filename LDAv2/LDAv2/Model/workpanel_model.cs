using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    class workpanel_model
    {
        public class Measure_Full_Struct
        {
            public int    id { get; set; }
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
            public int    charge_id { get; set; }
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
        }
        public class Measure_Compact_Struct
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
        }
        public class Beszallitok_Struct
        {
            public int beszallito_id { get; set; }
            public string nev { get; set; }
        }
        public class Cikk_Struct
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
        }
        public class Charge_Struct
        {
            public int charge_id { get; set; }
            public string charge_cikkszam { get; set; }
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
        }
    }
}
