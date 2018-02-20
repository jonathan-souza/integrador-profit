using ConnectionMonitor;
using Selia.Integrador.Adapter.AbstractFactory;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.AutenticacaoRest;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Selia.Integrador.Adapter
{
    public class Rest
    {
        public class Config
        {
            public Model.Interface.Rest Rest { get; set; }

            private List<Util.Mapeamento.Entidade> mapeamentos;
            public List<Util.Mapeamento.Entidade> Mapeamentos
            {
                get
                {
                    TirarMapeamentosNaoObrigatorios(mapeamentos);

                    return mapeamentos;
                }

                set
                {

                    mapeamentos = value;
                }
            }

            public List<Util.Mapeamento.Entidade> MapeamentosQueryString { get; set; }

            public List<Util.Mapeamento.Entidade> MapeamentoRetorno { get; set; }


            public string AcaoFinal { get; set; }
            public string AcaoInicial { get; set; }
            public string AcaoCabecalho { get; set; }

            public string ElementoSeparador { get; set; }

            public string NodesNaoUtilizados { get; set; }

            private void TirarMapeamentosNaoObrigatorios(List<Util.Mapeamento.Entidade> mapeamentos)
            {

                List<int> idsExluir = new List<int>();

                foreach (var mapeamento in mapeamentos)
                {
                    if (mapeamento.Filhos.Count > 0)
                    {
                        TirarMapeamentosNaoObrigatorios(mapeamento.Filhos);
                    }

                    if (mapeamento.BitExcluirBranco == true && mapeamento.Valor.ToString().Equals(string.Empty))
                    {
                        if (mapeamento.Filhos.Count == 0)
                        {
                            idsExluir.Add(mapeamento.ID);
                        }
                    }
                }

                if (idsExluir.Count > 0)
                {
                    mapeamentos.RemoveAll(r => idsExluir.Contains(r.ID));
                }
            }
        }

        public Resultado Executar(Config entConfig, XmlDocument xmlFila = null)
        {
            Resultado ret = new Resultado();
            HttpUtil httpRest = null;

            try
            {

                if (xmlFila != null)
                    ObterValorNodeXML(entConfig.Mapeamentos, xmlFila, false);

                var url = ConfigurarURL(entConfig.Rest.Url, entConfig.MapeamentosQueryString, xmlFila);
                var httpVerbo = (HttpVerbos)Enum.Parse(typeof(HttpVerbos), entConfig.Rest.VerboHttp.ToString());

                IAutenticacaoRest autenticacaoRest = AutenticacaoRestAbstractFactory.ObterInstancia(entConfig.Rest.Autenticacao);

                httpRest = new HttpUtil(url, httpVerbo, autenticacaoRest);


                if (!string.IsNullOrEmpty(entConfig.AcaoInicial))
                {
                    //List<object> lst = new List<object>();
                    //lst.Add("bWRpYXNfYWRtcHJvZHV0bw==");
                    //lst.Add("YWRtcHJvbWRpYXMyQDE3");
                    //lst.Add("MTAwMDAxNQ==");                    
                    //httpRest.Data = new Integrador.Utils.Generic.Invoke().Exec(entConfig.AcaoInicial.Split(';')[0], entConfig.AcaoInicial.Split(';')[1], lst).ToString();
                }
                else
                {
                    if (httpVerbo == HttpVerbos.POST || httpVerbo == HttpVerbos.PUT)
                        httpRest.Data = ObterConteudo(entConfig.Mapeamentos, entConfig.Rest.ContentType, xmlFila);
                }

                httpRest.ContentytType = entConfig.Rest.ContentType.GetAtributoContentType();
                httpRest.Login = entConfig.Rest.Login;
                httpRest.Senha = entConfig.Rest.Senha;

                if (httpVerbo == HttpVerbos.POST || httpVerbo == HttpVerbos.PUT)
                    ret.ParametrosEnvio = httpRest.Data;

                if (!string.IsNullOrEmpty(entConfig.AcaoCabecalho))
                {
                    List<object> lst = new List<object>();
                    entConfig.Rest.CabecalhosHttpRest = (List<Interface.Rest.CabecalhoHttpRest>)new Integrador.Utils.Generic.Invoke().Exec(entConfig.AcaoCabecalho.Split(';')[0], entConfig.AcaoCabecalho.Split(';')[1], lst);
                }

                foreach (var cabecalho in entConfig.Rest.CabecalhosHttpRest)
                {
                    httpRest.InserirCabecalho(cabecalho.Nome, cabecalho.Valor);
                }

                var resultadoHttpRest = httpRest.FazerRequisicao(RetornoRequisicao);

                ret.RespostaXmlCompleta = ConverterParaXML(resultadoHttpRest.ConteudoJson, resultadoHttpRest.Conteudo, entConfig.Rest.ReturnRootElementPai, entConfig.Rest.ReturnRootElementLista);

                if (!string.IsNullOrEmpty(entConfig.AcaoFinal))
                {
                    List<object> lst = new List<object>();
                    lst.Add(ret.RespostaXmlCompleta);
                    lst.Add(xmlFila);
                    lst.Add(entConfig);
                    try
                    {
                        ret.RespostaXmlCompleta = (XmlDocument)new Integrador.Utils.Generic.Invoke().Exec(entConfig.AcaoFinal.Split(';')[0], entConfig.AcaoFinal.Split(';')[1], lst);
                    }
                    catch (Exception e)
                    {
                        throw new Selia.Integrador.Utils.Exceptions.HttpRestRetornoException(
                            message: e.Message,
                            inner: e,
                            conteudoFila: xmlFila.InnerXml,
                            retornoNaoTratado: "Connection: " + Monitor.Instance.GetStatus() + "  **  " + "STATUS: ** " + resultadoHttpRest.HttpStatusCodeSucess + " ** CONTENT: ** " + resultadoHttpRest.Conteudo + " **",
                            retornoTratado: e.Message + "  <br /><br />\r\n\r\n  " + e.StackTrace
                        );
                    }
                }

                ret = new Resultado
                {
                    Mensagem = "Rest executado com sucesso.",
                    ElementoSeparador = entConfig.ElementoSeparador,
                    RespostaXmlCompleta = ret.RespostaXmlCompleta,
                    TipoMensagem = Resultado.Tipo.Sucesso,
                    ParametrosEnvio = httpRest.Data,
                    RespostaSemTratamento = resultadoHttpRest.Conteudo
                };

            }
            catch (Selia.Integrador.Utils.Exceptions.HttpRestRetornoException exIntegradoRetorno)
            {
                if (httpRest != null)
                {
                    exIntegradoRetorno.InformacaoAdicional = httpRest.Data;
                    exIntegradoRetorno.ParamentroEnvio = httpRest.Data;
                }

                if (xmlFila != null)
                    exIntegradoRetorno.ConteudoFila = xmlFila.InnerXml;

                throw exIntegradoRetorno;
            }
            catch (Selia.Integrador.Utils.Exceptions.HttpRestException exIntegrador)
            {
                if (httpRest != null)
                {
                    exIntegrador.InformacaoAdicional = httpRest.Data;
                    exIntegrador.ParamentroEnvio = httpRest.Data;
                }

                if (xmlFila != null)
                    exIntegrador.ConteudoFila = xmlFila.InnerXml;

                throw exIntegrador;
            }
            catch (Exception ex)
            {
                ret = new Resultado
                {
                    Mensagem = ex.Message + " <br><br>  " + ex.StackTrace,
                    TipoMensagem = Resultado.Tipo.Erro,
                    ElementoSeparador = entConfig.ElementoSeparador,

                    ParametrosEnvio = (httpRest != null) ? httpRest.Data : "(empty)",
                    RespostaSemTratamento = ex.Message + " <br><br>\r\n\r\n  " + ex.StackTrace,
                };
                //ServiceLog.LogError(String.Format("Erro: Message: {0} - StackTrace: {1}", ex.Message, ex.ToString()));
            }
            return ret;
        }

        //private void ObterValorNodeXML(List<Util.Mapeamento.Entidade> entidades, XmlDocument xmlfila)
        //{
        //    foreach (var entidade in entidades)
        //    {
        //        entidade.Valor = new Adapter.Util.Mapeamento().ObterValorNodeXml(entidade, xmlfila);

        //        if (entidade.Filhos.Count() > 0)
        //        {
        //            ObterValorNodeXML(entidade.Filhos, xmlfila);
        //        }
        //    }
        //}

        private void ObterValorNodeXML(List<Util.Mapeamento.Entidade> entidades, XmlDocument xmlfila, bool mult)
        {
            foreach (var entidade in entidades)
            {
                if (!mult || entidade.ElementoMult == null)
                {
                    entidade.Valor = new Adapter.Util.Mapeamento().ObterValorNodeXml(entidade, xmlfila);

                    if (entidade.Filhos.Count() > 0)
                    {
                        ObterValorNodeXML(entidade.Filhos, xmlfila, entidade.Mult);
                    }
                }
                else
                {
                    XmlDocument clone = new XmlDocument();
                    clone.LoadXml(xmlfila.InnerXml);
                    entidade.ValoresMult = new List<object>();

                    var collection = clone.GetElementsByTagName("value");
                    while (collection.Count > 0)
                    {
                        XmlNode node = collection[0];
                        entidade.ValoresMult.Add(new Adapter.Util.Mapeamento().ObterValorNodeXml(entidade, clone));

                        node.ParentNode.RemoveChild(node);
                    }
                }
            }
        }

        public string ObterConteudo(List<Util.Mapeamento.Entidade> mapeamentos, Interface.Rest.ContentyType contentType, XmlDocument xmlFila)
        {
            var conteudo = string.Empty;

            if (mapeamentos != null && mapeamentos.Count > 0)
            {
                conteudo = MontarJson(mapeamentos);

                if (contentType == Interface.Rest.ContentyType.XML)
                {
                    conteudo = conteudo.DeserializeXmlNode().InnerXml;
                }
            }

            return conteudo;
        }

        private string ConfigurarURL(string url, List<Util.Mapeamento.Entidade> parametrosQueryString, XmlDocument XmlFila)
        {
            if (parametrosQueryString != null)
            {
                //Somente parametros que o valor não está em branco
                parametrosQueryString.Where(w => !w.Valor.ToString().Equals(string.Empty)).ToList().ForEach(f => url = url.Replace(f.Para, f.Valor.ToString()));

                //Somente parametros que não é querystring e o valor  é xml
                var valor = string.Empty;
                parametrosQueryString.Where(w => w.Valor.ToString().Equals(string.Empty)).ToList().ForEach(f =>
                 {
                     valor = new Util.Mapeamento().ObterValorNodeXml(new Util.Mapeamento.Entidade() { De = f.De }, XmlFila);
                     var para = f.Para;

                     if (f.Para.Contains("|") && string.IsNullOrEmpty(valor))
                     {
                         valor = f.Para.Split('|')[1];
                         para = f.Para.Split('|')[0];
                     }
                     else if (f.Para.Contains("|"))
                         para = f.Para.Split('|')[0];

                     if (f.ValoresDePara != null && f.ValoresDePara.Count > 0)
                         valor = f.ValoresDePara.Where(x => x.De == valor).Select(x => x.Para).FirstOrDefault();

                     url = url.Replace(para, valor);
                 });

            }

            return url;
        }

        public XmlDocument ConverterParaXML(bool conteudoJson, string conteudo, string returnRootElementPai, string returnRootElementLista)
        {
            XmlDocument xml = null;

            if (conteudoJson)
            {
                var jsonParaXML = CompletaAMontangemDoJsonParaTransformarEmXML(conteudo, returnRootElementPai, returnRootElementLista);
                xml = jsonParaXML.DeserializeXmlNode();
            }
            else
            {
                xml = new XmlDocument();
                xml.LoadXml(conteudo);

                if (!string.IsNullOrEmpty(returnRootElementPai))
                {

                    XmlDocument newXmlDocumento = new XmlDocument();
                    XmlDeclaration xmlDeclaracao = newXmlDocumento.CreateXmlDeclaration("1.0", "UTF-8", null);
                    newXmlDocumento.AppendChild(xmlDeclaracao);

                    XmlElement root = newXmlDocumento.CreateElement(returnRootElementPai);
                    newXmlDocumento.AppendChild(root);

                    XmlNode node = newXmlDocumento.ImportNode(xml.DocumentElement, true);
                    newXmlDocumento.DocumentElement.AppendChild(node);

                    return newXmlDocumento;
                }


            }

            return xml;

        }

        private string CompletaAMontangemDoJsonParaTransformarEmXML(string json, string returnRootElementPai, string returnRootElementLista)
        {

            if (!string.IsNullOrEmpty(returnRootElementLista))
            {
                json = string.Format("\"{0}\":{1}", returnRootElementLista, json);
            }

            if (!string.IsNullOrEmpty(returnRootElementPai))
            {
                if (!string.IsNullOrEmpty(returnRootElementLista))
                {
                    json = string.Format("{0}\"{1}\":{2}{3}{4}", "{", returnRootElementPai, "{", json, "}}");
                }
                else
                {
                    json = string.Format("{0}\"{1}\":{2}{3}", "{", returnRootElementPai, json, "}");
                }
            }

            return json;

        }

        public ResultadoHttpRest RetornoRequisicao(HttpResponseMessage actionHttpResponse)
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

        private dynamic MontarEntidade(List<Util.Mapeamento.Entidade> mapeamentos)
        {
            dynamic dinamicMap = new DynamicObj();

            foreach (var mapeamento in mapeamentos)
            {
                if (mapeamento.Filhos.Count() == 0)
                {
                    dinamicMap.AddProperty(mapeamento.Para, mapeamento.Valor);
                }
                else
                {
                    dynamic lista = null;

                    if (mapeamento.Mult)
                    {
                        lista = new List<DynamicObj>();
                        dinamicMap.AddProperty(mapeamento.Para, lista);

                        if (mapeamento.Filhos[0].ValoresMult != null)
                        {
                            for (int i = 0; i < mapeamento.Filhos[0].ValoresMult.Count; i++)
                            {
                                var filhos = new List<Util.Mapeamento.Entidade>();

                                foreach (Util.Mapeamento.Entidade ent in mapeamento.Filhos)
                                {
                                    filhos.Add(new Util.Mapeamento.Entidade
                                    {
                                        Acao = ent.Acao,
                                        BitExcluirBranco = ent.BitExcluirBranco,
                                        Configuracao = ent.Configuracao,
                                        De = ent.De,
                                        ElementoMult = ent.ElementoMult,
                                        Filhos = ent.Filhos,
                                        ID = ent.ID,
                                        isXmlEntrada = ent.isXmlEntrada,
                                        Mult = ent.Mult,
                                        PaiID = ent.PaiID,
                                        Para = ent.Para,
                                        TemPai = ent.TemPai,
                                        TipoValor = ent.TipoValor,
                                        ValoresDePara = ent.ValoresDePara,
                                        Valor = ent.ValoresMult[i]
                                    });
                                }

                                lista.Add(MontarEntidade(filhos));
                            }
                        }
                        else
                        {
                            lista.Add(MontarEntidade(mapeamento.Filhos));
                        }
                    }
                    else
                    {
                        lista = new DynamicObj();

                        dinamicMap.AddProperty(mapeamento.Para, lista);
                        var maps = MontarEntidade(mapeamento.Filhos);

                        foreach (KeyValuePair<string, object> item in maps.properties)
                        {
                            lista.AddProperty(item.Key, item.Value);
                        }

                    }


                }
            }

            return dinamicMap;
        }

        public string MontarJson(List<Util.Mapeamento.Entidade> mapeamentos)
        {
            dynamic entidade = MontarEntidade(mapeamentos);

            return Json.Serialize(entidade);
        }

        private string MontarXML(List<Util.Mapeamento.Entidade> mapeamentos, XmlDocument xmlFila)
        {
            var xmlRetorno = string.Empty;

            if (mapeamentos.Count > 0)
            {
                xmlRetorno = new Util.Mapeamento().ExecutarMapeamentoDePara(mapeamentos, xmlFila);
            }
            else if (xmlFila != null && xmlFila.ChildNodes.Count > 0)
            {
                xmlRetorno = xmlFila.InnerXml;
            }

            return xmlRetorno;
        }

    }
}
