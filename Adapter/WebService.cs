using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using Selia.Integrador.Utils;
using ConnectionMonitor;

namespace Selia.Integrador.Adapter
{
    public class WebService
    {
        public class Config
        {
            public Config()
            {
                Mapeamentos = new List<Util.Mapeamento.Entidade>();
            }

            public string Url { get; set; }
            public string Metodo { get; set; }
            public string ElementoSeparador { get; set; }
            public string Action { get; set; }

            public string Login { get; set; }
            public string Senha { get; set; }

            public string ExecucaoInicial { get; set; }
            public string ExecucaoFinal { get; set; }
            public string ConnectionString { get; set; }
            public DateTime DataHoraUltimaExecucao { get; set; }

            public List<Util.Mapeamento.Entidade> Mapeamentos { get; set; }
        }



        public Resultado Executar(Config objConfig, string XmlFila)
        {
            Resultado objResultado = new Resultado();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XmlFila);
                objResultado = Executar(objConfig, doc);
            }
            catch (Exception ex)
            {
                objResultado = new Resultado() { Mensagem = "XMLEntrada: \r\n" + XmlDeEntrada.ToString() + "\r\n" + ex.Message + " \r\n\r\n  " + ex.StackTrace, ParametrosEnvio = XmlDeEntradaParametros.ToString(), TipoMensagem = Resultado.Tipo.Erro };
                //ServiceLog.LogError(String.Format("Erro: Message: {0} - StackTrace: {1} - XmlEntrada: {2} \r\n\r\nINNER EXCEPTION:\r\n{3}", ex.Message, ex.StackTrace, XmlDeEntrada.ToString(), (ex.InnerException != null) ? ex.InnerException.Message : "(Sem mais informações)"));
            }
            return objResultado;
        }
        public Resultado Executar(Config objConfig, XmlDocument XmlFila = null)
        {
            Resultado objResultado = new Resultado();

            XmlDocument XmlRetorno = new XmlDocument();
            XmlDocument XmlEntrada = new XmlDocument();
            try
            {
                XmlEntrada.LoadXml(CriarSoapDeEntrada(objConfig, XmlFila == null ? null : XmlFila));

                if (!string.IsNullOrEmpty(objConfig.ExecucaoInicial))
                {
                    List<object> lst = new List<object>();
                    lst.Add(XmlEntrada);
                    lst.Add(objConfig);
                    XmlEntrada = (XmlDocument)new Integrador.Utils.Generic.Invoke().Exec(objConfig.ExecucaoInicial.Split(';')[0], objConfig.ExecucaoInicial.Split(';')[1], lst, objConfig.ConnectionString);
                    XmlDeEntradaParametros.Clear();
                    XmlDeEntradaParametros.Append(XmlEntrada.GetElementsByTagName(objConfig.Metodo)[0].InnerXml);
                }

                HttpWebRequest request = CriarWebRequest(objConfig);

                using (Stream stream = request.GetRequestStream())
                {
                    XmlEntrada.Save(stream);
                }

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            string soapResult = rd.ReadToEnd();
                            XmlRetorno.LoadXml(soapResult);
                        }
                    }
                }
                catch (WebException webEx)
                {
                    string errorText = "[Sem conteúdo de resposta]";

                    if (webEx != null && webEx.Response != null && webEx.Response.ContentLength > 0)
                    {
                        using (StreamReader rd = new StreamReader(webEx.Response.GetResponseStream()))
                        {
                            errorText = "Connection Status  **  " + Monitor.Instance.GetStatus() + "  **  Exception: **  " + webEx.Message + "  **  Content: **  " + rd.ReadToEnd() + "  **";
                        }
                    }
                    else
                    {
                        errorText = "Connection Status  **  " + Monitor.Instance.GetStatus() + "  **  Exception: **  " + webEx.Message + "  **  Content: (no content)";
                    }

                    throw new Exception(errorText);
                }
                catch (Exception e)
                {
                    throw new Exception("Connection Status  **  " + Monitor.Instance.GetStatus() + " ** Exception:  ** " +e.Message + "  ** ", e);
                }

                if (!string.IsNullOrEmpty(objConfig.ExecucaoFinal))
                {
                    List<object> lst = new List<object>();
                    lst.Add(XmlRetorno);
                    lst.Add(XmlFila);
                    XmlRetorno = (XmlDocument)new Integrador.Utils.Generic.Invoke().Exec(objConfig.ExecucaoFinal.Split(';')[0], objConfig.ExecucaoFinal.Split(';')[1], lst, objConfig.ConnectionString);
                }

                objResultado = new Resultado() { Mensagem = "WebService executado com sucesso.", ElementoSeparador = objConfig.ElementoSeparador, ParametrosEnvio = XmlDeEntradaParametros.ToString(), RespostaXmlCompleta = XmlRetorno, TipoMensagem = Resultado.Tipo.Sucesso };
            }
            catch (Exception ex)
            {
                throw new Exception("\r\n\r\nXml de Erro:\r\n" + ex.Message, ex);
            }
            return objResultado;
        }

        public StringBuilder XmlDeEntrada = new StringBuilder();
        public StringBuilder XmlDeEntradaParametros = new StringBuilder();

        private string CriarSoapDeEntrada(Config objConfig, XmlNode Node)
        {
            XmlDeEntrada = new StringBuilder();
            XmlDeEntradaParametros = new StringBuilder();

            //XmlDeEntrada.Append(@"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">");

            XmlDeEntrada.Append(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:vtex=""http://schemas.datacontract.org/2004/07/Vtex.Commerce.WebApps.AdminWcfService.Contracts"" xmlns:arr=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">");

            XmlDeEntrada.Append(@"<soapenv:Body>");
            //XmlDeEntrada.Append(@"<" + objConfig.Metodo + " xmlns=\"http://tempuri.org/\">");
            XmlDeEntrada.Append(@"<" + objConfig.Metodo + ">");

            if (objConfig.Mapeamentos.Count > 0)
            {
                XmlDeEntradaParametros.Append(new Util.Mapeamento().ExecutarMapeamentoDePara(objConfig.Mapeamentos, Node));
                XmlDeEntrada.Append(XmlDeEntradaParametros.ToString());
            }
            else if (Node != null && Node.ChildNodes.Count > 0)
            {
                XmlDeEntrada.Append(Node.InnerXml);
            }

            XmlDeEntrada.Append(@"</" + objConfig.Metodo + ">");
            XmlDeEntrada.Append(@"</soapenv:Body>");
            XmlDeEntrada.Append(@"</soapenv:Envelope>");

            return XmlDeEntrada.ToString();
        }

        private HttpWebRequest CriarWebRequest(Config objConfig)
        {
            string action = objConfig.Action;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(objConfig.Url);
            webRequest.Timeout = (60 * 1000);
            webRequest.Headers.Add(@"SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            if (!string.IsNullOrEmpty(objConfig.Login))
            {
                webRequest.Credentials = new NetworkCredential(objConfig.Login, objConfig.Senha);
            }
            return webRequest;
        }
    }
}
