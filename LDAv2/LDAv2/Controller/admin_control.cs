using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.admin_model;

namespace LDAv2.Controller
{
    class admin_control
    {
        dbEntities dbE = new dbEntities();
        public List<Activity_Struct> Aktivitas_List(List<string> list)
        {
            string query = "SELECT * FROM userActivity WHERE allapot = "+list[0]+" ";
            //if (list[1].Length > 0)
            //    query += " AND ";
            //if (list[2].Length > 0)
            //    query += " AND ";
            //if (list[3].Length > 0)
            //    query += " AND ";
            //if (list[4].Length > 0)
            //    query += " AND ";
            //if (list[5].Length > 0)
            //    query += " AND ";
            //if (list[6].Length > 0)
            //    query += " AND ";

            query += " ORDER BY date ASC LIMIT 50";
            return dbE.Activity_Query_MySQL(query);
        }
    }
}
