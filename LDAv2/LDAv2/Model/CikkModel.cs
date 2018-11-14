using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class CikkModel
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
}
