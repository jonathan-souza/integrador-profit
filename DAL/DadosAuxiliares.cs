using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.DAL
{
    public class DadosAuxiliares : DataWorker
    {
        public int InserirDadosAuxiliares(int idMillennium, int idBSeller, string descricao)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_idMillennium", idMillennium));
            lst.Add((IDbDataParameter)database.CreateParameter("p_idBSeller", idBSeller));
            lst.Add((IDbDataParameter)database.CreateParameter("p_Descricao", descricao));

            return new SQLHelper(false, "SP_BSELLER_INS_DADOS_AUX", lst).NonQuery();
        }

        public int RetornarCodigoMarcaBseller(int codMarcaMillennium)
        {
            List<IDbDataParameter> lstDataParameters = new List<IDbDataParameter>();

            lstDataParameters.Add((IDbDataParameter)database.CreateParameter("p_codMarcaMillennium", codMarcaMillennium));

            return new SQLHelper(false, "SP_BSELLER_SEL_CODIGOMARCABSELLER", lstDataParameters).NonQuery();
        }

        public DateTime? ObtemHoraDeExecucaoDoBanco(string chave)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("chave", chave));

            var dt = new SQLHelper(false, "SP_GSH_SEL_HORAEXECUCAO", lst).DataTable();

            if (dt.Rows.Count > 0)
                return (DateTime)dt.Rows[0][0];
            else
                return null;
        }

        public void SalvaHoraDeExecucaoNoBanco(string chave, DateTime data)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("chave", chave));
            lst.Add((IDbDataParameter)database.CreateParameter("data", data));

            var dt = new SQLHelper(false, "SP_GSH_INS_HORAEXECUCAO", lst).DataTable();
        }
    }
}
