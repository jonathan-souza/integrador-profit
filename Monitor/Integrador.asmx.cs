using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

namespace Monitor
{
    /// <summary>
    /// Summary description for Integrador
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Integrador : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Model.Integracao> ConsultarIntegracoes()
        {
            return new BS.Integracao().ConsultarIntegracaoSimples();
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Model.LogFila> ConsultarLogFila(string IntegracaoID)
        {
            return new  Selia.Integrador.DAL.LogFila().Consultar(Convert.ToInt32(IntegracaoID));
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool AtualizarStatusParaSucesso(string FilaID)
        {
            return new BS.Fila().AtualizarStatusParaSucesso(Convert.ToInt32(FilaID));
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool DeletaFila(string FilaID)
        {
            return new BS.Fila().Deletar(Convert.ToInt32(FilaID));
        }

    }
}
