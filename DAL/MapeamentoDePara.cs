using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selia.Integrador.DAL;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class MapeamentoDePara : DataWorker
    {

        public List<Model.Mapeamento.DePara> Consultar(int MapeamentoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_MapeamentoID", MapeamentoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_MapeamentoDePara", lst).DataTable());
        }

        public List<Model.Mapeamento.DePara> ConsultarPorIntegracao(int integracaoId)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoId", integracaoId));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_MapeamentoDeParaInt", lst).DataTable());
        }

        public List<Model.Mapeamento.DePara> Preencher(DataTable dt)
        {
            List<Model.Mapeamento.DePara> lst = new List<Model.Mapeamento.DePara>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Mapeamento.DePara ent = new Model.Mapeamento.DePara();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["De"] != DBNull.Value)
                {
                    ent.De = row["De"].ToString();
                }
                if (row["Para"] != DBNull.Value)
                {
                    ent.Para = row["Para"].ToString();
                }
                if (row["Infos_Adicionais"] != DBNull.Value)
                {
                    ent.InfosAdicionais = row["Infos_Adicionais"].ToString();
                }
                if (row["Infos_Adicionais"] != DBNull.Value)
                {
                    ent.IntegracaoId = Convert.ToInt32(row["IntegracaoId"].ToString());
                }

                lst.Add(ent);
            }
            return lst;
        }
    }
}
