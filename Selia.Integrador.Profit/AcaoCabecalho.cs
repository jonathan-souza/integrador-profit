using Model;
using Selia.Integrador.Adapter.AbstractFactory;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.AutenticacaoRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Interface.Rest;
using System.Net.Http;

namespace Selia.Integrador.MDias
{
    public class AcaoCabecalho
    {
        public List<CabecalhoHttpRest> PegaTokenNeo(string userName, string password, string storeId, string urlBase)
        {
            var ret = new List<CabecalhoHttpRest>();

            HttpUtil httpRest = null;

            IAutenticacaoRest autenticacaoRest = AutenticacaoRestAbstractFactory.ObterInstancia((Model.Interface.Rest.TipoAutenticacao)Enum.Parse(typeof(Model.Interface.Rest.TipoAutenticacao), "1"));

            string url = urlBase + "auth";            

            httpRest = new HttpUtil(url, HttpVerbos.POST, autenticacaoRest);
            
            var obj = new ReqBody();

            obj.userName = userName;
            obj.password = password;
            obj.storeID = storeId;

            httpRest.Data = Json.Serialize(obj);

            httpRest.ContentytType = Interface.Rest.ContentyType.Json.GetAtributoContentType();

            var resultadoHttpRest = httpRest.FazerRequisicao(RetornoRequisicao);

            var result = Json.Deserialize<ReqRetorno>(resultadoHttpRest.Conteudo);

            ret.Add(new CabecalhoHttpRest { Nome = "Authorization", Valor = "Bearer " + result.access_token });

            return ret;
        }

        private ResultadoHttpRest RetornoRequisicao(HttpResponseMessage actionHttpResponse)
        {
            ResultadoHttpRest ret = new ResultadoHttpRest();

            ret.Conteudo = actionHttpResponse.Content.ReadAsStringAsync().Result;

            var mediaTypeJson = Selia.Integrador.Utils.Constants.AppSettings.MediaTypeHeaderJson;

            if (actionHttpResponse.Content.Headers.ContentType == null)
            {
                ret.ConteudoJson = true;
                ret.Conteudo = "{ \"Result\" : true }";
            }
            else
            {
                ret.ConteudoJson = actionHttpResponse.Content.Headers.ContentType.MediaType.ToString().Equals(mediaTypeJson);
            }

            var listaCodeSucesso = Selia.Integrador.Utils.Constants.AppSettings.HttpStatusCode.Sucesso.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var respostaStatusCode = ((int)actionHttpResponse.StatusCode).ToString();

            if (!listaCodeSucesso.Any(a => a == respostaStatusCode))
            {
                throw new Selia.Integrador.Utils.Exceptions.HttpRestException(message: ret.Conteudo, informacaoAdicional: "STATUS: " + ret.HttpStatusCodeSucess + " " + ret.Conteudo, retornoNaoTratado: ret.Conteudo);
            }
            return ret;
        }
    }
    
    class ReqBody
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string storeID { get; set; }
    }

    class ReqRetorno
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
