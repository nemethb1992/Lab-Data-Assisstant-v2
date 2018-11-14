using LDAv2.Controller;
using System.Collections.Generic;

namespace LDAv2.Model
{
    public class Charge
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

        public static void PartialInsert(List<Charge> list)
        {
            string command = "INSERT INTO `charge` (`charge_id`, `charge_cikkszam`, `charge`, `beerk_datum`, `ut_meres_datum`, `kw`, `megjegyzes`) " +
            "VALUES (NULL, " +
            "'" + list[0].charge_cikkszam + "', " +
            "'" + list[0].charge + "', " +
            "'" + list[0].beerk_datum + "', " +
            "'" + list[0].ut_meres_datum + "', " +
            "'" + list[0].kw + "', " +
            "'" + list[0].megjegyzes + "');";

            new Database().Execute(command);
        }

        public static void Delete(int id)
        {
            string command = "DELETE FROM `charge` WHERE `charge`.`charge_id` = " + id + ";";
            if (Session.UserData[0].admintag == 1)
                new Database().Execute(command);
        }
    }
}
