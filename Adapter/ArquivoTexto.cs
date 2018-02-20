using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Selia.Integrador.Utils;

namespace Selia.Integrador.Adapter
{
    public class ArquivoTexto
    {
        public class Config
        {
            public Config()
            {
                Mapeamentos = new List<Util.Mapeamento.Entidade>();
            }
            public string FTP { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public string Url { get; set; }
            public string ElementoSeparador { get; set; }
            public string AcaoInicial { get; set; }
            public string AcaoFinal { get; set; }
            public string AcaoEnfileiramento { get; set; }
            public string NomeArquivo { get; set; }
            public string ConnectionString { get; set; }
            public string Delimitador { get; set; }
            public string Diretorio { get; set; }
            public string Encoding { get; set; }
            public List<Util.Mapeamento.Entidade> Mapeamentos { get; set; }
        }
        public Resultado Executar(Config objConfig, string XmlFila, int? integracaoId = null)
        {
            Resultado objResultado = new Resultado();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XmlFila);
                objResultado = Executar(objConfig, doc, integracaoId);
            }
            catch (Exception ex)
            {
                objResultado = new Resultado() { Mensagem = ex.Message + " <br><br>  " + ex.StackTrace, TipoMensagem = Resultado.Tipo.Erro };
            }
            return objResultado;
        }
        public Resultado Executar(Config objConfig, XmlDocument XmlFila = null, int? integracaoId = null)
        {
            Resultado entResultado = new Resultado();
            try
            {
                if (XmlFila == null)
                {
                    Dictionary<string, List<string>> Arquivos = Selia.Integrador.Utils.Ftp.ObterArquivos(objConfig.FTP, objConfig.Login, objConfig.Senha);
                    
                    XmlDocument doc = new XmlDocument();
                    string XmlCompleto = "";

                    foreach (KeyValuePair<string, List<string>> Arquivo in Arquivos.Where(c => c.Key.Contains(objConfig.Url)))
                    {
                        List<string> Lista = Arquivo.Value;
                        if (!string.IsNullOrEmpty(objConfig.AcaoInicial))
                        {
                            List<object> lst = new List<object>();
                            lst.Add(Lista);
                            Lista = (List<string>)new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoInicial.Split(';')[0], objConfig.AcaoInicial.Split(';')[1], lst, objConfig.ConnectionString);
                        }
                        
                        foreach (string line in Lista)
                        {
                            string Linha = line;
                            foreach (Adapter.Util.Mapeamento.Entidade map in objConfig.Mapeamentos)
                            {
                                if (!string.IsNullOrEmpty(objConfig.AcaoEnfileiramento))
                                {
                                    List<object> lst = new List<object>();
                                    lst.Add(line);
                                    Linha = (string)new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoEnfileiramento.Split(';')[0], objConfig.AcaoEnfileiramento.Split(';')[1], lst, objConfig.ConnectionString);
                                }
                                map.Valor = Linha.Substring(Convert.ToInt32(map.De.Split(',')[0]), Convert.ToInt32(map.De.Split(',')[1]));
                            }
                            XmlCompleto += "<Item>" + new Adapter.Util.Mapeamento().ExecutarMapeamentoDePara(objConfig.Mapeamentos, null) + "</Item>";
                        }
                        
                        if (!string.IsNullOrEmpty(objConfig.AcaoFinal))
                        {
                            List<object> lst = new List<object>();
                            lst.Add(objConfig);
                            doc = (XmlDocument)new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoEnfileiramento.Split(';')[0], objConfig.AcaoEnfileiramento.Split(';')[1], lst, objConfig.ConnectionString);
                        }

                        Ftp.MoveBackup(objConfig.FTP + "/" + Arquivo.Key, "Backup/" + Arquivo.Key, objConfig.Login, objConfig.Senha);
                    }

                    doc.LoadXml("<Itens>" + XmlCompleto + "</Itens>");
                    entResultado = new Resultado() { Mensagem = "DB executado com sucesso.", RespostaXmlCompleta = doc, RespostaXmlSeparada = Util.RetornarListaNoPrincipal(objConfig.ElementoSeparador, doc), TipoMensagem = Resultado.Tipo.Sucesso };
                }
                else
                {
                    if (string.IsNullOrEmpty(objConfig.ElementoSeparador))
                    {
                        objConfig.ElementoSeparador = "/";
                    }
                    StringBuilder sb = new StringBuilder();

                    if (!string.IsNullOrEmpty(objConfig.AcaoInicial))
                    {
                        List<object> lst = new List<object>();
                        lst.Add(XmlFila);
                        lst.Add(integracaoId);
                        sb.Append((string)new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoInicial.Split(';')[0], objConfig.AcaoInicial.Split(';')[1], lst, objConfig.ConnectionString));

                        if (sb.ToString().Length > 0 && objConfig.Mapeamentos.Count > 0)
                            sb.Append(Environment.NewLine);
                    }

                    int interador = 0;
                    string delimitador = objConfig.Delimitador;
                    int tamanhoDelimitador = 0;

                    if (!string.IsNullOrEmpty(delimitador))
                        tamanhoDelimitador = delimitador.Length;

                    foreach (XmlNode node in XmlFila.SelectNodes(objConfig.ElementoSeparador))
                    {
                        int qtdCaracteres = 0;
                        int qtdDelimitador = 0;

                        /*if (interador > 0 && sb.ToString().Length > 0 && objConfig.Mapeamentos.Count > 0)
                            sb.Append(Environment.NewLine);*/

                        interador = interador + 1;
                        bool arquivoSemPosionamento = objConfig.Mapeamentos.All(map=> String.IsNullOrEmpty(map.Para));
                        string Linha = arquivoSemPosionamento ? "" : "".PadRight(1000);

                        foreach (Adapter.Util.Mapeamento.Entidade map in objConfig.Mapeamentos.OrderBy(f => String.IsNullOrEmpty(f.Para) ? 0 : Convert.ToInt32(f.Para.Split(',')[0])))
                        {
                            map.Valor = map.Acao != null && map.Acao.IndexOf("identificador", StringComparison.OrdinalIgnoreCase) >= 0 ? new Adapter.Util.Mapeamento().ParametrosAdicionais(new List<object> { interador }).ObterValorNodeXml(map, node).Trim() : new Adapter.Util.Mapeamento().ObterValorNodeXml(map, node).Trim();
                            string valor = ""; 
                            if (String.IsNullOrEmpty(map.Para))
                            {
                                valor = map.Valor.ToString();
                                Linha += valor + delimitador;
                                qtdCaracteres = qtdCaracteres + (valor + delimitador).Length;
                            }
                            else
                            {
                                valor = map.Configuracao != null && map.Configuracao.IndexOf("Pad", StringComparison.OrdinalIgnoreCase) >= 0 ? map.Valor.ToString() : map.Valor.ToString().PadRight(Convert.ToInt32(map.Para.Split(',')[1]), ' ');
                                Linha = Linha.Insert(Convert.ToInt32(map.Para.Split(',')[0]) + qtdDelimitador, valor + delimitador);
                                qtdCaracteres = qtdCaracteres + valor.Length;
                            }
                            
                            qtdDelimitador = qtdDelimitador + tamanhoDelimitador;
                        }
                        if (!string.IsNullOrEmpty(delimitador))
                        {
                            if (Linha.TrimEnd().Length > tamanhoDelimitador)
                            {
                                Linha = Linha.TrimEnd().Substring(0, Linha.TrimEnd().Length - tamanhoDelimitador);
                            }
                        }
                        if (!string.IsNullOrEmpty(objConfig.AcaoEnfileiramento))
                        {
                            List<object> lstNodes = new List<object>();
                            lstNodes.Add(node);
                            new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoEnfileiramento.Split(';')[0], objConfig.AcaoEnfileiramento.Split(';')[1], lstNodes, objConfig.ConnectionString);
                        }

                        Linha = Linha.Substring(0, arquivoSemPosionamento && qtdCaracteres > 0 ? qtdCaracteres - 1 : qtdCaracteres);
                        
                        if (qtdCaracteres > 0 || Linha.Trim().Length > 0)
                        {
                            sb.Append(Linha + Environment.NewLine);
                        }
                    }

                    string ConteudoArquivo = sb.ToString();

                    Dictionary<XmlDocument, string> retorno = new Dictionary<XmlDocument, string>();
                    if (!string.IsNullOrEmpty(objConfig.AcaoFinal))
                    {
                        List<object> lst = new List<object>();
                        lst.Add(sb.ToString());
                        lst.Add(XmlFila);
                        lst.Add(objConfig);

                        retorno = (Dictionary<XmlDocument, string>)new Selia.Integrador.Utils.Generic.Invoke().Exec(objConfig.AcaoFinal.Split(';')[0], objConfig.AcaoFinal.Split(';')[1], lst, objConfig.ConnectionString);
                        if (retorno.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(retorno.FirstOrDefault().Value))
                            {
                                ConteudoArquivo = retorno.FirstOrDefault().Value;
                            }
                        }
                    }
                    // Upload Arquivo
                    Ftp.Upload(ConteudoArquivo, objConfig.FTP , objConfig.NomeArquivo, objConfig.Login, objConfig.Senha, objConfig.Diretorio, objConfig.Encoding.ToUpper() == "UTF-8 BOM" ? (IEncoding)(new UTF8BOM()) : (IEncoding)(new UTF8()));
                    entResultado = new Resultado() { Mensagem = "Arquivo executado com sucesso.", ElementoSeparador = objConfig.ElementoSeparador, RespostaXmlCompleta = retorno.FirstOrDefault().Key, TipoMensagem = Resultado.Tipo.Sucesso };
                }
            }
            catch (Exception ex)
            {
                entResultado = new Resultado() { Mensagem = ex.Message + " <br><br>  " + ex.StackTrace, TipoMensagem = Resultado.Tipo.Erro };
            }
            return entResultado;
        }
    }
}
