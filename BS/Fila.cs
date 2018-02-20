using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using Selia.Integrador.Adapter;

namespace BS
{
    public class Fila
    {

        public List<Model.Fila> Consultar(int IntegracaoID)
        {
            return new Selia.Integrador.DAL.Fila().Consultar(IntegracaoID);
        }

        public List<Model.Fila> ConsultarByStatus(int IntegracaoID, int status)
        {
            return new Selia.Integrador.DAL.Fila().ConsultarByStatus(IntegracaoID, status);
        }

        public List<Model.Fila> ConsultarByChavePrimaria(int IntegracaoID, string chavePrimaria, string secondaryKey)
        {
            return new Selia.Integrador.DAL.Fila().ConsultarByChavePrimaria(IntegracaoID, chavePrimaria, secondaryKey);
        }
        public int Inserir(Model.Fila entFila)
        {
            return new Selia.Integrador.DAL.Fila().Inserir(entFila);
        }
        public int Excluir(int FilaID)
        {
            return new Selia.Integrador.DAL.Fila().Excluir(FilaID);
        }
        public int AtualizarStatus(Model.Fila.TipoStatus StatusID, int FilaID)
        {
            return new Selia.Integrador.DAL.Fila().AtualizarStatus((int)StatusID, FilaID);
        }

        public int AtualizarDestino(int DestinoID, int FilaID) {
            return new Selia.Integrador.DAL.Fila().AtualizarDestino(DestinoID, FilaID);
        }

        public bool AtualizarStatusParaSucesso(int FilaID)
        {
            return new Selia.Integrador.DAL.Fila().AtualizarStatusParaSucesso(FilaID);
        }
        public bool Deletar(int FilaID)
        {
            return new Selia.Integrador.DAL.Fila().Excluir(FilaID) > -1;
        }
        public void ProcessarFila(Selia.Integrador.Adapter.Resultado objResult, Model.Integracao ent, List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> Mapeamentos)
        {
            
            List<XmlElement> lste = new List<XmlElement>();
            foreach (XmlElement xmle in objResult.RespostaXmlSeparada)
            {
                Selia.Integrador.Adapter.Util.Mapeamento web = new Selia.Integrador.Adapter.Util.Mapeamento();
                XmlNode root = xmle;

                web.ExecutarMapeamentoDePara(Mapeamentos, root);
                XmlDocument doc = new XmlDocument();
                if (!string.IsNullOrEmpty(web.XmlDeEntrada.ToString()))
                {
                    doc.LoadXml(web.XmlDeEntrada.ToString());
                }
                lste.Add((XmlElement)doc.DocumentElement);
            }
            objResult.RespostaXmlSeparada = lste;

            Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
            entLogIntegracao.Conteudo = objResult.RespostaXmlCompleta.InnerXml;
            entLogIntegracao.QtdRegistros = objResult.RespostaXmlSeparada.Count;
            entLogIntegracao.Integracao = ent;
            int LogIntegracaoID = new BS.LogIntegracao().Inserir(entLogIntegracao);

            if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
            {
                if (ent.Destino != null)
                {
                    BS.Fila filaBS = new BS.Fila();
                    foreach (XmlElement xmle in objResult.RespostaXmlSeparada)
                    {
                        string primaryKey = filaBS.ConsultaPrimaryKey(ent, xmle);
                        string secondaryKey = filaBS.ConsultaSecondaryKey(ent, xmle);

                        if (!filaBS.VerificaDuplicidade(ent, primaryKey, secondaryKey))
                        {
                            Model.Fila entFila = new Model.Fila();
                            entFila.Conteudo = (xmle).ParentNode.InnerXml;
                            entFila.Integracao.ID = ent.ID;
                            entFila.DataCriacao = DateTime.Now;
                            entFila.Status = Model.Fila.TipoStatus.Sucesso;
                            entFila.LogIntegracaoID = LogIntegracaoID;
                            entFila.IntegracaoDestino.ID = ent.Destino.ID;
                            entFila.ChavePrimaria = primaryKey;
                            entFila.ChaveSecundaria = secondaryKey;

                            if (!string.IsNullOrEmpty(ent.AcaoEnfileiramento))
                            {
                                List<object> lst = new List<object>();
                                lst.Add(entFila);
                                lst.Add(ent.Mapeamento);
                                lst.Add(xmle);
                                entFila = (Model.Fila)new Selia.Integrador.Utils.Generic.Invoke().Exec(ent.AcaoEnfileiramento.Split(';')[0], ent.AcaoEnfileiramento.Split(';')[1], lst, ent.ConnectionString);
                            }

                            if (entFila != null)
                                filaBS.Inserir(entFila);

                        }
                    }


                    //Pega o ultimo elemento da fila para o mapeamento de retorno
                    if (objResult.RespostaXmlSeparada != null && objResult.RespostaXmlSeparada.Count > 0)
                    {
                        if (ent.MapeamentoRetorno != null && ent.MapeamentoRetorno.Count > 0)
                        {
                            var ultimoElementoFila = objResult.RespostaXmlSeparada.Last();

                            foreach (var mapeamentoRetorno in ent.MapeamentoRetorno)
                            {
                                var mapeamento = new Util.Mapeamento.Entidade()
                                {
                                    De = mapeamentoRetorno.De,
                                    Valor = mapeamentoRetorno.Valor,
                                    Acao = mapeamentoRetorno.Acao,
                                    Para = mapeamentoRetorno.Para
                                };
                                var valor = new Util.Mapeamento().ObterValorNodeXml(mapeamento, ultimoElementoFila);

                                //atualiza o valor do pai
                                new Selia.Integrador.DAL.Mapeamento().AtualizarValor(mapeamentoRetorno.PaiID, valor);
                            }
                        }
                    }


                }
            }
        }

        public string ConsultaKey(XmlElement xml, string keyName, bool secondary = false)
        {
            try
            {
                if (!string.IsNullOrEmpty(xml.InnerXml))
                {

                    if (!String.IsNullOrEmpty(keyName))
                    {
                        if (keyName.Contains("/"))
                        {
                            return xml.SelectSingleNode(keyName).InnerText.Trim();
                        }
                        else
                        {
                            return xml.GetElementsByTagName(keyName)[0].InnerText.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (secondary)
                    return null;
                else
                    throw new Exception(string.Format("Não foi possível consultar a Chave cadastrada. {0}", ex.StackTrace.ToString()));
            }

            return string.Empty;
        }

        public string ConsultaPrimaryKey(Model.Integracao ent, XmlElement xml)
        {
            return ConsultaKey(xml, ent.PKPrimaria, false);
        }

        public string ConsultaSecondaryKey(Model.Integracao ent, XmlElement xml)
        {
            return ConsultaKey(xml, ent.PKSecundaria, true);
        }

        public bool VerificaDuplicidade(Model.Integracao ent, string primaryKey, string secondaryKey)
        {
            return this.ConsultarByChavePrimaria(ent.Destino.ID, primaryKey, secondaryKey).Count() > 0;
        }
    }
}