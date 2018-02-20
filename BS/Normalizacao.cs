using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Selia.Integrador.Utils;

namespace BS
{
    public class Normalizacao
    {
        public void Executar()
        {
            var logIntegracao = new Selia.Integrador.DAL.LogIntegracao().ConsultaQtdMaiorZero(1);

            foreach (var item in logIntegracao)
            {
                var parametro = new List<object>();

                if (!string.IsNullOrEmpty(ValidaXml(item.Conteudo, item.ID)))
                {
                    var xml = new XmlDocument();
                    xml.LoadXml(item.Conteudo);
                    parametro.Add(xml);

                    new Selia.Integrador.Utils.Generic.Invoke().Exec("Coop.Integrador.Normalizacao, Coop.Integrador", "Salvar", parametro);
                }
            }
        }

        private string ValidaXml(string p, int id)
        {
            try
            {
                XDocument.Parse(p, LoadOptions.None);
            }
            catch(XmlException ex)
            {
                //ServiceLog.LogError(string.Format("Erro ao processar robo normalização. ID:{1}. Erro:{0}", ex.ToString(), id));
                return string.Empty;
            }

            return "ok";
        }
    }
}