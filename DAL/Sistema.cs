using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Selia.Integrador.DAL
{
    public class Sistema
    {
        public List<Model.Sistema> Preencher(DataTable dt)
        {
            List<Model.Sistema> lst = new List<Model.Sistema>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Sistema ent = new Model.Sistema();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                else if (row["Nome"] != DBNull.Value)
                {
                    ent.Nome = row["Nome"].ToString();
                }

                lst.Add(ent);
            }
            return lst;
        }
    }
}
