using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (list[1].Length > 0)
                query += " AND userActivity.username LIKE '%" + list[1] + "%'";
            if (list[2].Length > 0)
                query += " AND userActivity.activity LIKE '%" + list[2] + "%'";
            if (list[3].Length > 0)
                query += " AND userActivity.cikk LIKE '%" + list[3] + "%'";
            if (list[4].Length > 0)
                query += " AND userActivity.charge LIKE '%" + list[4] + "%'";
            if (list[5].Length > 0)
                query += " AND userActivity.beerk LIKE '%" + list[5] + "%'";
            if (list[6].Length > 0)
                query += " AND userActivity.date LIKE '%" + list[6] + "%'";

            query += " ORDER BY date DESC LIMIT 50";
            return dbE.Activity_Query_MySQL(query);
        }
    }
}
