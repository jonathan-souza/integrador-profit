
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils
{

    public enum HttpVerbos
    {
        GET = 1,
        POST = 2,
        PUT = 3,
        DELETE = 4
    }


    public class HttpUtil
    {
        private Dictionary<string, string> Cabecalhos { get; set; }

        public HttpVerbos httpVerbo { get; set; }

        public string Data { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string ContentytType { get; set; }

        public AutenticacaoRest.IAutenticacaoRest AutenticacaoRest { private get; set; }

        public HttpUtil()
            : this(autenticacaoRest: null)
        {
            Cabecalhos = new Dictionary<string, string>();
        }

        public HttpUtil(string Endereco, HttpVerbos httpVerbo = HttpVerbos.POST, AutenticacaoRest.IAutenticacaoRest autenticacaoRest = null)
        {
            this.httpVerbo = httpVerbo;
            this.Endereco = Endereco;
            this.AutenticacaoRest = autenticacaoRest;

            Cabecalhos = new Dictionary<string, string>();
        }


        public HttpUtil(AutenticacaoRest.IAutenticacaoRest autenticacaoRest)
            : this(string.Empty, HttpVerbos.POST, autenticacaoRest)
        {
        }


        public void InserirCabecalho(string nome, string valor)
        {
            if (!Cabecalhos.ContainsKey(nome))
            {
                Cabecalhos.Add(nome, valor);
            }
        }

        private HttpMethod ConverterHttpMethod(HttpVerbos httpVerbo)
        {
            HttpMethod ret = HttpMethod.Post;

            switch (httpVerbo)
            {
                case HttpVerbos.GET:
                    ret = HttpMethod.Get;
                    break;
                case HttpVerbos.POST:
                    ret = HttpMethod.Post;
                    break;
                case HttpVerbos.PUT:
                    ret = HttpMethod.Put;
                    break;
                case HttpVerbos.DELETE:
                    ret = HttpMethod.Delete;
                    break;
            }

            return ret;
        }

        public ResultadoHttpRest FazerRequisicao(Func<HttpResponseMessage, ResultadoHttpRest> actionHttpResponse)
        {


            ResultadoHttpRest ret = null;

            if (string.IsNullOrEmpty(Endereco))
            {
                throw new Exceptions.HttpRestException("Endereço do serviço Rest é obrigatório");
            }


            System.Net.Http.HttpClient client = null;
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Senha))
            {
                ICredentials myCredentials = new NetworkCredential(this.Login, this.Senha);
                handler.Credentials = myCredentials;
                client = new HttpClient(handler);
                
            }
            else
            {
                client = new HttpClient(handler);
            }
            
            var httpMethod = ConverterHttpMethod(httpVerbo);

            try
            {
                using (var request = new HttpRequestMessage(httpMethod, Endereco))
                {
                    if (!string.IsNullOrEmpty(Data))
                    {
                        request.Content = new StringContent(Data, Encoding.UTF8, ContentytType);
                    }
                    //Preenche os cabeçalhos se necessário
                    PreencherCabecalhoRequisicao(request);

                    //if (AutenticacaoRest != null)
                    //{
                    //    MontaAutenticacaoRest(client);
                    //}

                    using (var response = client.SendAsync(request).Result)
                    {
                        if (actionHttpResponse != null)
                        {
                            ret = actionHttpResponse(response);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                client.Dispose();

            }


            return ret;
        }

        private void MontaAutenticacaoRest(HttpClient request)
        {
            var model = new AutenticacaoRest.Autenticacao()
            {
                HttpRequest = request,
                Login = this.Login,
                Senha = this.Senha
            };

            AutenticacaoRest.CriarAutenticacao(model);


        }

        private void PreencherCabecalhoRequisicao(HttpRequestMessage request)
        {
            foreach (var cabecalho in Cabecalhos)
            {
                request.Headers.Add(cabecalho.Key, cabecalho.Value);
            }
        }


    }
}
