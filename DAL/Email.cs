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
    public class Email : DataWorker
    {
        public Model.Email ObterDadosEmail()
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            return Preencher(new SQLHelper(true, "SP_INT_SEL_EMAIL_DADOS", lst).DataTable());

        }

        private Model.Email Preencher(DataTable dt)
        {
            Model.Email email = new Model.Email();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                email.Porta = DataHelper.ToGenericValue<int>(dr, "PORTA");
                email.Smtp = DataHelper.ToGenericValue<string>(dr, "SMTP");
                email.Usuario = DataHelper.ToGenericValue<string>(dr, "USUARIO");
                email.Senha = DataHelper.ToGenericValue<string>(dr, "SENHA");
                email.Assunto = DataHelper.ToGenericValue<string>(dr, "ASSUNTO");
                email.From = DataHelper.ToGenericValue<string>(dr, "FROM");
                email.To = DataHelper.ToGenericValue<string>(dr, "TO");
                email.EnableSsl = DataHelper.ToGenericValue<bool>(dr, "enableSsl");
            }

            return email;
        }
    }
}
