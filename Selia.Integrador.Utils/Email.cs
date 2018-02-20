using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils
{
    public static class Email
    {
        public static void SendMail(Model.Email email)
        {
            try
            {
                MailMessage mailmessage = new MailMessage();

                mailmessage.Subject = email.Assunto;

                mailmessage.Body = email.Body;
                mailmessage.From = new MailAddress(email.From);
                mailmessage.To.Add(new MailAddress(email.To));

                AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(email.Body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(email.Body, null, "text/html");

                mailmessage.AlternateViews.Add(plainView);
                mailmessage.AlternateViews.Add(htmlView);
                mailmessage.IsBodyHtml = true;
                mailmessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailmessage.SubjectEncoding = System.Text.Encoding.UTF8;

                using (SmtpClient smtp = new SmtpClient())
                {

                    var usuario = email.Usuario;
                    var senha = email.Senha;
                    var host = email.Smtp;

                    System.Net.NetworkCredential autenticacao = new System.Net.NetworkCredential(usuario, senha);

                    smtp.Credentials = autenticacao;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.UseDefaultCredentials = true;
                    smtp.Host = host;
                    smtp.Port = email.Porta;
                    smtp.EnableSsl = email.EnableSsl.HasValue ? email.EnableSsl.Value : false; ;

                    smtp.Send(mailmessage);
                }
                mailmessage.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
