using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Interface
    {
        public object Item { get; set; }
        
        [Serializable]
        public class DB
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public Sistema Sistema { get; set; }
            public string ConnectionString { get; set; }
            public string StoredProcedure { get; set; }
            public string DataBaseNameFactory { get; set; }
            public List<ParametroDB> Parametros { get; set; }
            public class ParametroDB
            {
                public int ID { get; set; }
                public string De { get; set; }
                public string Para { get; set; }
                public string Retorno { get; set; }
                public int InterfaceWebServiceID { get; set; }
                public int PaiID { get; set; }
            }
        }
        
        [Serializable]
        public class ArquivoTexto
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public Sistema Sistema { get; set; }
            public string FTP { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public string Url { get; set; }
            public string Delimitador { get; set; }
            public string Diretorio { get; set; }
            public string Encoding { get; set; }
        }
    
        [Serializable]
        public class WebService
        {
            public WebService()
            {
                Parametros = new List<ParametroWS>();
            }
            public int ID { get; set; }
            public string Nome { get; set; }
            public Sistema Sistema { get; set; }
            public string Url { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public string Metodo { get; set; }
            public string Action { get; set; }
            public List<ParametroWS> Parametros { get; set; }
            [Serializable]
            public class ParametroWS
            {
                public int ID { get; set; }
                public string De { get; set; }
                public string Para { get; set; }
                public string Retorno { get; set; }
                public int InterfaceWebServiceID { get; set; }
                public int PaiID { get; set; }
            }
        }

        [Serializable]
        public class Rest
        {

            public enum ContentyType
            {
                [ContentTypeDescricao("")]
                Undefined=0,
                [ContentTypeDescricao("application/json")]
                Json=1,
                [ContentTypeDescricao("application/xml")]
                XML=2     
       
            }

            public enum TipoAutenticacao
            {
                Undefined = 0,
                Basic=1
            }

            public Rest()
            {
                //ParametrosRest = new List<ParametroRest>();
                CabecalhosHttpRest = new List<CabecalhoHttpRest>();
            }
            public int Id { get;set; }
            public string Nome { get; set; }
            public Sistema Sistema { get; set; }
            public string Url { get; set; }

            public string Login { get; set; }
            public string Senha { get; set; }

            //public string ContentType { get; set; }

            public ContentyType ContentType { get; set; }

            public int VerboHttp { get; set; }

            public int? TipoAutenticacaoId { get; set; }

            public TipoAutenticacao Autenticacao
            {
                get {
                    Rest.TipoAutenticacao ret =  Rest.TipoAutenticacao.Undefined;

                    if (TipoAutenticacaoId.HasValue && TipoAutenticacaoId.Value > 0)
                    {
                        ret = (Model.Interface.Rest.TipoAutenticacao)Enum.Parse(typeof(Model.Interface.Rest.TipoAutenticacao), TipoAutenticacaoId.Value.ToString());
                    }

                    return ret;
                }
            }

            public string ReturnRootElementPai { get; set; }
            public string ReturnRootElementLista { get; set; }

            //public List<ParametroRest> ParametrosRest { get; set; }
            public List<CabecalhoHttpRest> CabecalhosHttpRest { get; set; }

            public class ParametroRest
            {
                public int Id { get; set; }
                public int InterfaceRestId { get; set; }
                public string De { get; set; }
                public string Para { get; set; }
                public bool isXML { get; set; }
                public bool isQueryString { get; set; }
            }

            public class CabecalhoHttpRest
            {
                public int Id { get; set; }
                public int InterfaceRestId { get; set; }
                public string Nome { get; set; }
                public string Valor { get; set; }
            }

         
        }
    }
}
