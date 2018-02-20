using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Selia.Integrador.Adapter
{
    public class Util
    {
        public class Mapeamento
        {
            private List<object> Parametros { get; set; }

            public class Entidade
            {
                public Entidade()
                {
                    Filhos = new List<Mapeamento.Entidade>();
                    ValoresDePara = new List<DePara>();
                    MetodoConfig = new Metodo();
                }
                public string ElementoMult { get; set; }
                public int ID { get; set; }
                public string De { get; set; }
                public string Para { get; set; }
                public string Acao { get; set; }
                public List<object> ValoresMult { get; set; }
                object valor = "";
                public object Valor
                {
                    get
                    {
                        if (valor == null || string.IsNullOrEmpty(valor.ToString()))
                            return string.Empty;

                        object ValorPrincipal = valor;
                        if (!string.IsNullOrEmpty(TipoValor))
                        {
                            if (Type.GetType(TipoValor) != ValorPrincipal.GetType())
                            {
                                ValorPrincipal = Selia.Integrador.Utils.Generic.Parse.Invoke(Type.GetType(TipoValor), ValorPrincipal);
                                MetodoConfig.Valor = ValorPrincipal;
                            }
                        }

                        if (!string.IsNullOrEmpty(MetodoConfig.Configuracao))
                        {
                            ValorPrincipal = MetodoConfig.Retorno;
                        }


                        return ValorPrincipal;
                    }
                    set
                    {
                        object ValorPrincipal = value;
                        if (ValoresDePara.Exists(c => c.De == value.ToString()))
                        {
                            ValorPrincipal = ValoresDePara.Single(c => c.De == value.ToString()).Para;
                        }

                        MetodoConfig.Valor = ValorPrincipal;
                        valor = ValorPrincipal;
                    }
                }
                public bool Mult { get; set; }
                public int PaiID { get; set; }
                public List<Mapeamento.Entidade> Filhos { get; set; }
                private Metodo MetodoConfig { get; set; }
                public string Configuracao
                {
                    set
                    {
                        MetodoConfig.Configuracao = value;
                    }
                    get
                    {
                        return string.IsNullOrEmpty(MetodoConfig.Configuracao) ? string.Empty : MetodoConfig.Configuracao;
                    }
                }
                public string TipoValor { get; set; }
                public bool TemPai { get; set; }
                public bool isXmlEntrada { get; set; }

                public bool BitExcluirBranco { get; set; }

                internal class Metodo
                {
                    internal string Configuracao { get; set; }
                    private string Nome
                    {
                        get
                        {
                            return Configuracao.Split(';')[0];
                        }
                    }
                    internal object Valor { get; set; }
                    internal string Retorno
                    {
                        get
                        {
                            return Valor.GetType().GetMethod(Nome, TipoEntrada).Invoke(Valor, Parametros).ToString();
                        }
                    }
                    private Type[] tipoEntrada = null;
                    private Type[] TipoEntrada
                    {
                        get
                        {
                            if (tipoEntrada == null)
                            {
                                List<Type> lstTipoEntrada = new List<Type>();
                                foreach (string o in Configuracao.Split(';')[1].Split(','))
                                {
                                    lstTipoEntrada.Add(Type.GetType(o));
                                }
                                tipoEntrada = lstTipoEntrada.ToArray();
                            }
                            return tipoEntrada.Length == 0 ? null : tipoEntrada;
                        }
                        set
                        {
                            tipoEntrada = value;
                        }
                    }

                    object[] parametros = null;
                    private object[] Parametros
                    {
                        get
                        {
                            if (parametros == null)
                            {
                                List<object> lstParametrosDB = new List<object>();
                                foreach (object param in Configuracao.Split(';')[2].Split(','))
                                {
                                    lstParametrosDB.Add(param);
                                }

                                System.Reflection.MethodInfo objMethodInfo = Valor.GetType().GetMethod(Nome, TipoEntrada);
                                List<System.Reflection.ParameterInfo> lstParameters = objMethodInfo.GetParameters().ToList();
                                List<object> lstParametrosConvertidos = new List<object>();
                                for (int i = 0; i < lstParameters.Count; i++)
                                {
                                    lstParametrosConvertidos.Add(Integrador.Utils.Generic.Parse.Invoke(lstParameters[i].ParameterType, lstParametrosDB[i]));
                                }
                                parametros = lstParametrosConvertidos.ToArray();
                            }
                            return parametros;
                        }
                        set
                        {
                            parametros = value;
                        }
                    }
                }
                public List<DePara> ValoresDePara { get; set; }
                public class DePara
                {
                    public int ID { get; set; }
                    public string De { get; set; }
                    public string Para { get; set; }
                    public string InfosAdicionais { get; set; }
                }
            }

            public StringBuilder XmlDeEntrada = new StringBuilder();
            private XmlNode XmlPrincipal { get; set; }
            public string ExecutarMapeamentoDePara(List<Util.Mapeamento.Entidade> Maps, XmlNode Node)
            {
                if (Maps == null || Maps.Count <= 0 || Maps.Any(x => x.isXmlEntrada != null && !x.isXmlEntrada))
                {
                    if (Node == null)
                    {
                        var ret = Maps.Select(x => string.Format("<{0}>{1}</{0}>", x.Valor, x.Para)).Aggregate((a, b) => a + b);
                        return ret;
                    }

                    XmlDeEntrada.Append(Node.OuterXml);
                    return XmlDeEntrada.ToString();
                }
                XmlDeEntrada = new StringBuilder();
                if (Node != null)
                {
                    XmlPrincipal = Node.Clone();
                }
                return Inicio(Maps, Node);
            }
            private string Inicio(List<Util.Mapeamento.Entidade> Maps, XmlNode Node)
            {
                foreach (Util.Mapeamento.Entidade Map in Maps)
                {
                    XmlNode No = null;
                    if (Node != null)
                    {
                        No = Node.Clone();
                    }
                    MontarParametrosXml(Map, No);
                }
                return XmlDeEntrada.ToString();
            }


            public Mapeamento ParametrosAdicionais(List<object> parametros)
            {
                this.Parametros = parametros;
                return this;
            }

            private void MontarParametrosXml(Util.Mapeamento.Entidade Map, XmlNode Node)
            {
                if ("PRODUTO" == Map.Para)
                {
                }
                if (Map.Filhos.Count == 0)
                {
                    MontarItemParametroXml(Map, Node);
                }
                else
                {
                    if (Map.Mult && Map.De != null)
                    {
                        XmlNode NodeClone = Node.Clone();
                        foreach (string Nome in Map.De.Split('/'))
                        {
                            NodeClone = NodeClone[Nome];
                            if (NodeClone == null)
                            {
                                NodeClone = Node.Clone();
                            }
                        }

                        List<XmlNode> NodeList = new List<XmlNode>();
                        if (NodeClone.Name == Map.De)
                        {
                            NodeList.Add(NodeClone);
                        }
                        else
                        {
                            if (NodeClone.ParentNode != null)
                            {
                                NodeList.AddRange(NodeClone.ParentNode.ChildNodes.Cast<XmlNode>());
                            }
                        }

                        foreach (XmlNode no in NodeList)
                        {
                            XmlDeEntrada.Append(@"<" + Map.Para.Trim() + ">");
                            Inicio(Map.Filhos, no);
                            XmlDeEntrada.Append(@"</" + Map.Para.Trim() + ">");
                        }

                    }
                    else
                    {
                        XmlDeEntrada.Append(@"<" + Map.Para.Trim() + ">");
                        foreach (Util.Mapeamento.Entidade ObjetoMapeamento in Map.Filhos)
                        {
                            MontarParametrosXml(ObjetoMapeamento, Node);
                        }
                        XmlDeEntrada.Append(@"</" + Map.Para.Trim() + ">");
                    }

                }

            }
            private void MontarItemParametroXml(Util.Mapeamento.Entidade Map, XmlNode Node)
            {
                string Valor = Map.Valor.ToString();
                if (Node != null)
                {
                    if (string.IsNullOrEmpty(Map.Valor.ToString()))
                    {
                        Valor = ObterValorNodeXml(Map, Node);
                    }
                }

                if (!Map.BitExcluirBranco || (Map.BitExcluirBranco && !string.IsNullOrWhiteSpace(Valor)))
                {
                    XmlDeEntrada.Append(@"<" + Map.Para.Trim() + ">");
                    XmlDeEntrada.Append(Valor.Trim());
                    XmlDeEntrada.Append(@"</" + Map.Para.Trim() + ">");
                }

            }
            public string ObterValorNodeXml(Util.Mapeamento.Entidade Map, XmlNode Node)
            {
                string Valor = "";
                try
                {
                    if (!string.IsNullOrEmpty(Map.De))
                    {
                        bool Exists = true;
                        XmlNode NodeClone = Node.Clone();
                        foreach (string Nome in Map.De.Split('/'))
                        {
                            NodeClone = NodeClone[Nome];
                            if (NodeClone == null)
                            {
                                NodeClone = Node.Clone();
                                Exists = false;
                            }
                            else
                            {
                                Exists = true;
                            }
                        }

                        if(Map.TipoValor == "System.DateTime")
                            Valor = Exists ? DateTime.Parse(NodeClone.InnerText).ToString("yyyy-MM-ddThh:mm:ss.000") : "";
                        else 
                            Valor = Exists ? NodeClone.InnerText : "";
                    }
                    else if (!string.IsNullOrEmpty(Map.Valor.ToString()))
                    {
                        Valor = Map.Valor.ToString();
                    }

                    if (Map.ValoresDePara != null && Map.ValoresDePara.Count > 0)
                    {
                        if (Map.ValoresDePara.Exists(c => c.De == (Valor == "" ? " " : Valor)))
                        {
                            Valor = Map.ValoresDePara.Single(c => c.De == (Valor == "" ? " " : Valor)).Para;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("O nó de mapeamento De:'" + Map.De + "' Para:'" + Map.Para + "' não foi encontrado!");
                }
                try
                {
                    if (!string.IsNullOrEmpty(Map.Acao))
                    {
                        List<object> lstParametros = new List<object>();

                        if (this.Parametros != null)
                            lstParametros.AddRange(this.Parametros);
                        else
                        {
                            lstParametros.Add(Valor);
                            lstParametros.Add(XmlPrincipal == null ? Node : XmlPrincipal);

                            if (!String.IsNullOrEmpty(Map.Para))
                                lstParametros.Add(Map.Para);
                        }
                        Valor = new Selia.Integrador.Utils.Generic.Invoke().Exec(Map.Acao.Split(';')[0], Map.Acao.Split(';')[1], lstParametros, "").ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                return Valor.Replace("&", "&amp;");
            }

        }

        public static List<XmlElement> RetornarListaNoPrincipal(string ElementoSeparador, XmlDocument Xml)
        {
            if (string.IsNullOrEmpty(ElementoSeparador))
            {
                return (Xml).ChildNodes.Cast<XmlElement>().ToList();
            }
            else
            {
                XmlNode No = Xml;
                if (Xml != null)
                {
                    foreach (string Nome in ElementoSeparador.Split('/'))
                    {
                        if (Nome.Trim() != "")
                        {
                            No = No[Nome.Trim()];
                        }
                    }
                }
                return (No).ChildNodes.Cast<XmlElement>().ToList();
            }
        }
    }
}
