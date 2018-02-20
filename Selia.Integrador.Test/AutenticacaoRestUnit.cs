using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.AutenticacaoRest;
using Model;
using System.Net.Http;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class AutenticacaoRestUnit
    {
        [TestMethod]
        public void Basic()
        {
            var endereco = "https://Seliaamara.bseller.com.br/commerce-api/api/stock";
            var verbo = HttpVerbos.GET;
            var autenticacao = new AutenticacaoRestBasic();
            var login = "api";
            var senha = "api123";


            var http = new Selia.Integrador.Utils.HttpUtil(endereco, verbo, null);
            http.Login = login;
            http.Senha = senha;

            http.FazerRequisicao(RetornoRequisicao);
        }

         [TestMethod]
        public void NTML()
        {
            var endereco = "http://millennium.iwise.com.br:888/api/millenium_eco/VITRINE.Lista_Status";
            var verbo = HttpVerbos.GET;
            var autenticacao = new AutenticacaoRestBasic();
            var login = "api";
            var senha = "api123";


            var http = new Selia.Integrador.Utils.HttpUtil(endereco, verbo, null);
            http.Login = login;
            http.Senha = senha;

            http.FazerRequisicao(RetornoRequisicao);
        }

        public ResultadoHttpRest RetornoRequisicao(HttpResponseMessage actionHttpResponse)
        {
            var conteudo = actionHttpResponse.Content.ReadAsStringAsync().Result;

            return null;
        }

    }
}
