using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class MeasureShortModel
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
}
