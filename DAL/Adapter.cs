using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Selia.Integrador.DAL
{
    public class Adapter
    {
        public List<Model.Adapter> Preencher(DataTable dt)
        {
            List<Model.Adapter> lst = new List<Model.Adapter>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Adapter ent = new Model.Adapter();

                if(row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["Nome"] != DBNull.Value)
                {
                    ent.Nome = row["Nome"].ToString();
                }

                lst.Add(ent);
            }
            return lst;
        }
    }
}
