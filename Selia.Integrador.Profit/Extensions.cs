using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.MDias
{
    public static class Extensions
    {
        public static Selia.Integrador.Utils.Model.Email ToEmailUtil(this global::Model.Email email)
        {
            Selia.Integrador.Utils.Model.Email ret = new Utils.Model.Email();

            ret.Assunto = email.Assunto;
            ret.Body = email.Body;
            ret.EnableSsl = email.EnableSsl;
            ret.From = email.From;
            ret.Porta = email.Porta;
            ret.Senha = email.Senha;
            ret.Smtp = email.Smtp;
            ret.To = email.To;
            ret.Usuario = email.Usuario;

            return ret;
        }
    }
}
