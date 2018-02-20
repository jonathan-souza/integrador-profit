using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils.Model
{
    public class Email
    {

        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Smtp { get; set; }
        public int Porta { get; set; }


        public Nullable<bool> EnableSsl { get; set; }

        public string Body { get; set; }
        public string Assunto { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
