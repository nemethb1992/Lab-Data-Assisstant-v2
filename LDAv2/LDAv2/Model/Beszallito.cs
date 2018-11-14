using LDAv2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Model
{
    public class Beszallito
    {
        public int beszallito_id { get; set; }
        public string nev { get; set; }

        public static List<Beszallito> Get()
        {
            string command = "SELECT beszallito_id, nev FROM beszallitok ORDER BY nev DESC";
            return new Database().Beszallitok_Query_MySQL(command);
        }
    }
}
