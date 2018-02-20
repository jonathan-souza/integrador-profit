using Selia.Integrador.Adapter;
using Selia.Integrador.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class RestUnit
    {
        [TestMethod]
        public void PegarQueryString()
        { 
            var queryString = "https://api-Seliaamara.bseller.com.br/commerce-api/api/product?offset=10";

            var indexOff = queryString.IndexOf("offset=");

            var valor = queryString.Remove(0, indexOff + 7);
        }
        [TestMethod]
        public void Verificar_Geracao_De_Json()
        {
            var model = new List<Util.Mapeamento.Entidade>()
            {
                { new Util.Mapeamento.Entidade(){ ID = 1, Para = "vitrine", Valor = 0, Mult = false, TemPai = false } },   
                { new Util.Mapeamento.Entidade(){ ID = 2, Para = "status_pedidos", Mult = true, TemPai = false } },
                { new Util.Mapeamento.Entidade(){ ID = 3, Para = "cod_pedidov", Valor = 1, Mult = false, PaiID = 2, TemPai = true } },
                { new Util.Mapeamento.Entidade(){ ID = 4, Para = "status", Valor = 1, Mult = false, PaiID = 2, TemPai = true } },
                { new Util.Mapeamento.Entidade(){ ID = 5, Para = "status_teste", Valor = "teste", Mult = false, PaiID = 2, TemPai = true } }
            };

            var json = new Rest().MontarJson(model);
        }


        [TestMethod]
        public void MontarJsonParaXML()
        {
            //var model = new List<Util.Mapeamento.Entidade>()
            //{
            //    { new Util.Mapeamento.Entidade(){ ID = 1, Para = "?xml", Valor = 0, Mult = true, TemPai = false } },   
            //    { new Util.Mapeamento.Entidade(){ ID = 2, Para = "@version", Valor="1.0", Mult = false, TemPai = true, PaiID=1 } },
            //    { new Util.Mapeamento.Entidade(){ ID = 3, Para = "@encoding", Valor = "UTF-8", Mult = false, PaiID = 1, TemPai = true } },

            //    { new Util.Mapeamento.Entidade(){ ID = 4, Para = "stock", Valor = 0, Mult = true, TemPai = false } },   
            //    { new Util.Mapeamento.Entidade(){ ID = 5, Para = "@xmlns", Valor="http://kanlo.com.br/stock", Mult = false, TemPai = true, PaiID=4 } },
                
            //    { new Util.Mapeamento.Entidade(){ ID = 6, Para = "sku", Valor = 0, Mult = true, TemPai = true, PaiID=4 } },   
            //    { new Util.Mapeamento.Entidade(){ ID = 7, Para = "id", Valor="28101", Mult = false, TemPai = true, PaiID=6 } },
            //    { new Util.Mapeamento.Entidade(){ ID = 8, Para = "quantity", Valor = "10", Mult = false, PaiID = 6, TemPai = true } },
            //    { new Util.Mapeamento.Entidade(){ ID = 8, Para = "leadTime", Valor = "1", Mult = false, PaiID = 6, TemPai = true } },
            //};

            //var model = new List<Model.Mapeamento>()
            //{
            //    { new Model.Mapeamento(){ ID = 1, Para = "?xml", Valor = "0", Mult = true,  TemPai = false } },   
            //    { new Model.Mapeamento(){ ID = 2, Para = "@version", Valor="1.0", Mult = false, TemPai = true, PaiID=1 } },
            //    { new Model.Mapeamento(){ ID = 3, Para = "@encoding", Valor = "UTF-8", Mult = false, PaiID = 1, TemPai = true } },
            //    { new Model.Mapeamento(){ ID = 4, Para = "stock", Valor = "0", Mult = true, TemPai = false } },   
            //    { new Model.Mapeamento(){ ID = 5, Para = "@xmlns", Valor="http://kanlo.com.br/stock", Mult = false, TemPai = true, PaiID=4 } },                
            //    { new Model.Mapeamento(){ ID = 6, Para = "sku", Valor = "0", Mult = true, TemPai = true, PaiID=4 } },   
            //    { new Model.Mapeamento(){ ID = 7, Para = "id", Valor="28101", Mult = false, TemPai = true, PaiID=6 } },
            //    { new Model.Mapeamento(){ ID = 8, Para = "quantity", Valor = "10", Mult = false, PaiID = 6, TemPai = true } },
            //    { new Model.Mapeamento(){ ID = 8, Para = "leadTime", Valor = "1", Mult = false, PaiID = 6, TemPai = true } },
            //};

            //var map = MapearParaAdapter(model);


            //var json = new Rest().MontarJson(map);

            var xml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode("{\"?xml\":[{\"@version\":\"1.0\",\"@enconding\":\"UTF-8\"}],\"stock\":[{\"@xmln\":\"http://kanlo.com.br/stock\",\"sku\":[{\"id\":\"28101\",\"quantity\":\"10\",\"leadTime\":\"1\"}]}]}");
        }

        public List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapearParaAdapter(List<Model.Mapeamento> lstMapeamento)
        {
            List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRootAll = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
            List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRoot = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
            foreach (Model.Mapeamento Map in lstMapeamento)
            {
                lstRootAll.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade() { ID = Map.ID, De = Map.De, Para = Map.Para, Mult = Map.Mult, PaiID = Map.PaiID, Valor = Map.Valor, TipoValor = Map.TipoValor, Acao = Map.Acao });
            }

            var paisId = lstRoot.Where(w => w.PaiID != 0).Select(s => s.PaiID).Distinct(); 

            foreach (var id in paisId)
            {
                var pai = lstRootAll.Where(w => w.ID == id).First();
                var filhosDoPai = lstRootAll.Where(w => w.PaiID == pai.ID).ToList();

                pai.Filhos = filhosDoPai;

                if (pai.PaiID == 0)
                {
                    lstRoot.Add(pai);
                }
            }


            return lstRoot;
        }

        [TestMethod]
        public void ConverterJsonParaXML()
        {
            var json = "{\"stock\": {\"-xmlns\": \"http://kanlo.com.br/stock\",\"sku\": {\"id\": \"28101\",\"quantity\": \"10\",\"leadTime\": \"1\"}}}";

            var xml22 = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><stock xmlns=\"http://kanlo.com.br/stock\"><sku><id>28101</id><quantity>10</quantity><leadTime>1</leadTime></sku></stock>";

            var json333 = "{\"?xml\":{\"@version\":\"1.0\",\"@encoding\":\"UTF-8\"},\"stock\":{\"@xmlns\":\"http://kanlo.com.br/stock\",\"sku\":{\"id\":\"28101\",\"quantity\":\"10\",\"leadTime\":\"1\"}}}";

            var json888 = "{\"?xml\":[{\"@version\":\"1.0\",\"@encoding\":\"UTF-8\"}],\"stock\":[{\"@xmlns\":\"http://kanlo.com.br/stock\"}],\"sku\":[{\"id\":\"28101\",\"quantity\":\"10\",\"leadTime\":\"1\"}]}";

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xml22);


            var xml444 = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json888);

            var json2 = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xml);

            //var xml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json,"stoke", true);


            var xml2 = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json, "stoke", false);

            //var xml3 = JsonToXml(json);


        }

        private static string XmlToJSON(XmlDocument xmlDoc)
        {
            StringBuilder sbJSON = new StringBuilder();
            sbJSON.Append("{ ");
            XmlToJSONnode(sbJSON, xmlDoc.DocumentElement, true);
            sbJSON.Append("}");
            return sbJSON.ToString();
        }

        private static void XmlToJSONnode(StringBuilder sbJSON, XmlElement node, bool showNodeName)
        {
            if (showNodeName)
                sbJSON.Append("\"" + SafeJSON(node.Name) + "\": ");
            sbJSON.Append("{");
            // Build a sorted list of key-value pairs
            //  where   key is case-sensitive nodeName
            //          value is an ArrayList of string or XmlElement
            //  so that we know whether the nodeName is an array or not.
            SortedList childNodeNames = new SortedList();

            //  Add in all node attributes
            if (node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                    StoreChildNode(childNodeNames, attr.Name, attr.InnerText);

            //  Add in all nodes
            foreach (XmlNode cnode in node.ChildNodes)
            {
                if (cnode is XmlText)
                    StoreChildNode(childNodeNames, "value", cnode.InnerText);
                else if (cnode is XmlElement)
                    StoreChildNode(childNodeNames, cnode.Name, cnode);
            }

            // Now output all stored info
            foreach (string childname in childNodeNames.Keys)
            {
                ArrayList alChild = (ArrayList)childNodeNames[childname];
                if (alChild.Count == 1)
                    OutputNode(childname, alChild[0], sbJSON, true);
                else
                {
                    sbJSON.Append(" \"" + SafeJSON(childname) + "\": [ ");
                    foreach (object Child in alChild)
                        OutputNode(childname, Child, sbJSON, false);
                    sbJSON.Remove(sbJSON.Length - 2, 2);
                    sbJSON.Append(" ], ");
                }
            }
            sbJSON.Remove(sbJSON.Length - 2, 2);
            sbJSON.Append(" }");
        }

        private static void StoreChildNode(SortedList childNodeNames, string nodeName, object nodeValue)
        {
            // Pre-process contraction of XmlElement-s
            if (nodeValue is XmlElement)
            {
                // Convert  <aa></aa> into "aa":null
                //          <aa>xx</aa> into "aa":"xx"
                XmlNode cnode = (XmlNode)nodeValue;
                if (cnode.Attributes.Count == 0)
                {
                    XmlNodeList children = cnode.ChildNodes;
                    if (children.Count == 0)
                        nodeValue = null;
                    else if (children.Count == 1 && (children[0] is XmlText))
                        nodeValue = ((XmlText)(children[0])).InnerText;
                }
            }
            // Add nodeValue to ArrayList associated with each nodeName
            // If nodeName doesn't exist then add it
            object oValuesAL = childNodeNames[nodeName];
            ArrayList ValuesAL;
            if (oValuesAL == null)
            {
                ValuesAL = new ArrayList();
                childNodeNames[nodeName] = ValuesAL;
            }
            else
                ValuesAL = (ArrayList)oValuesAL;
            ValuesAL.Add(nodeValue);
        }

        private static void OutputNode(string childname, object alChild, StringBuilder sbJSON, bool showNodeName)
        {
            if (alChild == null)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                sbJSON.Append("null");
            }
            else if (alChild is string)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                string sChild = (string)alChild;
                sChild = sChild.Trim();
                sbJSON.Append("\"" + SafeJSON(sChild) + "\"");
            }
            else
                XmlToJSONnode(sbJSON, (XmlElement)alChild, showNodeName);
            sbJSON.Append(", ");
        }

        // Make a string safe for JSON
        private static string SafeJSON(string sIn)
        {
            StringBuilder sbOut = new StringBuilder(sIn.Length);
            foreach (char ch in sIn)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    int ich = (int)ch;
                    sbOut.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                else if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    sbOut.Append('\\');
                }
                sbOut.Append(ch);
            }
            return sbOut.ToString();
        }
    }
}

