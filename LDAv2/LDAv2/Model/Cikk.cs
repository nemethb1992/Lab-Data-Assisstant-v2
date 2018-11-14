using LDAv2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class Cikk
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

        public static void Insert(List<Cikk> list)
        {
            string command = "INSERT INTO `cikk` (`id`, `cikkszam`, `szallito`, `anyag_nev`, `anyag_tipus`, `profit_center`, `utomun_metszve`, `folyokep_homerseklet`, `utokalapacs_meret_j`, `folyokep_terheles_kg`, `suruseg`, `szin`, `szakszig_min`, `szakszig_max`, `utesallosag_min`, `utesallosag_max`, `folyokep_min_g`, `folyokep_max_g`, `folyokep_min_cm`, `folyokep_max_cm`, `toltoanyag_min`, `toltoanyag_max`) " +
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
            new Database().Execute(command);
        }

        public static bool IsExists(string item)
        {
            string command = "SELECT count(id) FROM cikk WHERE cikkszam='" + item + "'";
            return new Database().SimpleValider_MySQL(command);
        }
    }
}
