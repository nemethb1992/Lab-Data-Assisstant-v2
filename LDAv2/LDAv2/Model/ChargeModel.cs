using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class ChargeModel
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
