using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class Mapeamento : DataWorker
    {
        public List<Model.Mapeamento> Consultar(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_MapByIntegracaoID", lst).DataTable());
        }
        public Model.Mapeamento ConsultarPai(int MapeamentoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_filhoID", MapeamentoID));
            List<Model.Mapeamento> lstMap = Preencher(new SQLHelper(true, "SP_INT_SEL_MapByFilhoID", lst).DataTable());

            return lstMap.Count > 0 ? lstMap[0] : null;
        }
        List<Model.Mapeamento> lstItems = new List<Model.Mapeamento>();
        public List<Model.Mapeamento> Preencher(DataTable dt)
        {
            List<Model.Mapeamento> lst = new List<Model.Mapeamento>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Mapeamento ent = new Model.Mapeamento();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["De"] != DBNull.Value)
                {
                    ent.De = row["De"].ToString().Replace("OrderGetResult/", "").Trim();
                }
                if (row["Para"] != DBNull.Value)
                {
                    ent.Para = row["Para"].ToString().Trim();
                }
                if (row["Valor"] != DBNull.Value)
                {
                    ent.Valor = row["Valor"].ToString();
                }
                if (row["PaiID"] != DBNull.Value)
                {
                    ent.PaiID = Convert.ToInt32(row["PaiID"].ToString());
                }
                if (row["Multi"] != DBNull.Value)
                {
                    ent.Mult = row["Multi"].ToString() == "0" ? false : true;
                }

                if (row["Configuracao"] != DBNull.Value)
                {
                    ent.Configuracao = row["Configuracao"].ToString();
                }
                if (row["TipoValor"] != DBNull.Value)
                {
                    ent.TipoValor = row["TipoValor"].ToString();
                }
                if (row["Acao"] != DBNull.Value)
                {
                    ent.Acao = row["Acao"].ToString();
                }

                if (row["BitQueryString"] != DBNull.Value)
                {
                    ent.BitQueryString = ObtemBool(row, "BitQueryString");
                }

                if (row["BitMapRetorno"] != DBNull.Value)
                {
                    ent.BitMapRetorno = ObtemBool(row, "BitMapRetorno");
                }


                if (row["ValorDePara"] != DBNull.Value && row["ValorDePara"].ToString().Equals("1"))
                {
                    ent.ValoresDePara = new Selia.Integrador.DAL.MapeamentoDePara().Consultar(ent.ID);
                }


                if (row["BITXMLENTRADA"] != DBNull.Value)
                {
                    ent.BitXmlEntrada = ObtemBool(row, "BITXMLENTRADA");
                }

                if (row["BITEXCLUIRBRANCO"] != DBNull.Value)
                {
                    ent.BitExcluirBranco = ObtemBool(row, "BITEXCLUIRBRANCO");
                }

                if (row["ELEMENTOMULT"] != DBNull.Value)
                {
                    ent.ElementoMult = row["ELEMENTOMULT"].ToString();
                }


                lst.Add(ent);
            }
            return lst;
        }

        private bool ObtemBool(DataRow row, string p)
        {
            bool? t = row[p] as bool?;
            if (t.HasValue)
            {
                return t.Value;
            }
            else
            {
                return row[p].ToString() == "0" ? false : true;
            }
        }

        public int AtualizarValor(int id, string valor)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_ID", id));
            lst.Add((IDbDataParameter)database.CreateParameter("p_VALOR", valor));
            return new SQLHelper(false, "SP_INT_UP_MAPEAMENTOVALORRETORNO", lst).NonQuery();

        }
    }
}
