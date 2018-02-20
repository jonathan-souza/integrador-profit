using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BS;


namespace Selia.Integrador.MDias
{
    public class AcaoEnfileiramento
    {

        //public bool VerificaDuplicidade(int destinoId, string primaryKey, string secondaryKey)
        //{
        //    return new Fila().ConsultarByChavePrimaria(destinoId, primaryKey, secondaryKey).Count() > 0;
        //}

        //private void InserirSeNaoTemDuplicidade(Model.Fila novo)
        //{
        //    if (!VerificaDuplicidade(novo.IntegracaoDestino.ID, novo.ChavePrimaria, novo.ChaveSecundaria))
        //        new Fila().Inserir(novo);
        //}

        //public Model.Fila OrganizarProdutosFila(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    Model.Fila novo;
        //    int retornoParse;
        //    if (int.TryParse(fila.ChavePrimaria, out retornoParse) && retornoParse > 0)
        //    {

        //        Fila filaBS = new Fila();
        //        int[] integracoes = new int[3] { 6, 7, 17 };
        //        foreach (var integ in integracoes)
        //        {
        //            novo = new Model.Fila();
        //            novo.ChavePrimaria = fila.ChavePrimaria;
        //            novo.ChaveSecundaria = fila.ChaveSecundaria;
        //            novo.Conteudo = fila.Conteudo;
        //            novo.DataCriacao = DateTime.Now;
        //            novo.Integracao.ID = fila.Integracao.ID;
        //            novo.IntegracaoDestino.ID = integ;
        //            novo.Status = fila.Status;
        //            novo.LogIntegracaoID = fila.LogIntegracaoID;

        //            InserirSeNaoTemDuplicidade(novo);
        //        }
        //    }
        //    return null;
        //}

        //public Model.Fila GerarFilasDeModificacaoDeQuantidadeVendida(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    int helper = 0;

        //    int id = 0;
        //    int listaRef = 0;
        //    int prodCod = 0;
        //    int qtdERP = 0;
        //    int qtdVtexSite = 0;
        //    int qtdVtexExt = 0;
        //    int listaQtdVtex = 0;

        //    List<string> itensSite = new List<string>();
        //    List<string> itensExt = new List<string>();


        //    if (xml != null && xml["Item"]["ListaProd"] != null && int.TryParse(xml["Item"]["ListaProd"].InnerText, out helper))
        //    {
        //        prodCod = helper;
        //        helper = 0;
        //    }

        //    if (xml != null && xml["Item"]["ListaRef"] != null && int.TryParse(xml["Item"]["ListaRef"].InnerText, out helper))
        //    {
        //        listaRef = helper;
        //        helper = 0;
        //    }

        //    if (xml != null && xml["Item"]["ListaVend"] != null && int.TryParse(xml["Item"]["ListaVend"].InnerText, out helper))
        //    {
        //        qtdERP = helper;
        //        helper = 0;
        //    }


        //    if (xml != null && xml["Item"]["ID"] != null && int.TryParse(xml["Item"]["ID"].InnerText, out helper))
        //    {
        //        id = helper;
        //        helper = 0;
        //    }
            
        //    if (prodCod == 0 || listaRef == 0)
        //        throw new Exception("ITEM VENDA - nao foi possivel encontrar a referencia da lista ou o produto");

        //    if (xml != null && xml.GetElementsByTagName("a:GiftListStockKeepingUnitDTO").Count > 0)
        //    {
        //        var elements = xml.GetElementsByTagName("a:GiftListStockKeepingUnitDTO");

        //        foreach (XmlElement element in elements)
        //        {
        //            if(element["a:SkuId"].InnerText == prodCod.ToString())
        //            {
        //                listaQtdVtex++;
        //            }

        //            if (element["a:SkuId"].InnerText == prodCod.ToString() && !string.IsNullOrEmpty(element["a:DatePurchased"].InnerText) /*&& element["a:_IsOrderFinished"].InnerText == "true"*/)
        //            {
        //                if (string.IsNullOrEmpty(element["a:OmsOrderId"].InnerText))
        //                {
        //                    //nao tem order, veio do erp
        //                    qtdVtexExt++;
        //                    itensExt.Add(element.InnerXml);
        //                }
        //                else
        //                {
        //                    //tem order, veio da vtex
        //                    qtdVtexSite++;
        //                    itensSite.Add(element.InnerXml);
        //                }
        //            }


        //        }
        //    }


        //    if(qtdERP != (qtdVtexExt + qtdVtexSite))
        //    {
        //        if(qtdERP > (qtdVtexExt + qtdVtexSite))
        //        {
        //            //adiciona vendidos na Vtex (qtdERP - (qtdVtexExt + qtdVtexSite))
        //            //reutilizar integracao de subida de qtd vendida

        //            var incremento = qtdERP - (qtdVtexExt + qtdVtexSite);

        //            XmlDocument doc = new XmlDocument();
        //            var integrador = doc.CreateElement("Integrador");
        //            doc.AppendChild(integrador);
                    
        //            var item = doc.CreateElement("Item");
        //            item.InnerXml = "<ListaRef>" + listaRef + "</ListaRef><ListaProd>" + prodCod + "</ListaProd><Incremento>" + incremento + "</Incremento><ID>" + id + "</ID><qtdERP>" + qtdERP + "</qtdERP><qtdVtexExt>" + qtdVtexExt + "</qtdVtexExt><qtdVtexSite>" + qtdVtexSite + "</qtdVtexSite>";
        //            doc.DocumentElement.AppendChild(item);

        //            var old = doc.CreateElement("OldFila");
        //            old.InnerXml = xml.InnerXml;
        //            doc.DocumentElement.AppendChild(old);
                    
        //            fila.Conteudo = doc.InnerXml;
        //            fila.IntegracaoDestino.ID = 140;
        //        }
        //        else
        //        {
        //            //subtrai vendidos na Vtex (qtdERP - (qtdVtexExt + qtdVtexSite))
        //            //mandar para integracao que faz +1 e depois redireciona para a de subida de qtd vendida

        //            var incremento = qtdERP - (qtdVtexExt + qtdVtexSite);

        //            if (listaQtdVtex > (qtdVtexExt + qtdVtexSite))
        //                incremento = incremento - 1;

        //            XmlDocument doc = new XmlDocument();
        //            var integrador = doc.CreateElement("Integrador");
        //            doc.AppendChild(integrador);

        //            var item = doc.CreateElement("Item");
        //            item.InnerXml = "<ListaRef>" + listaRef + "</ListaRef><ListaProd>" + prodCod + "</ListaProd><Incremento>" + incremento + "</Incremento><ID>" + id + "</ID><qtdERP>" + qtdERP + "</qtdERP><qtdVtexExt>" + qtdVtexExt + "</qtdVtexExt><qtdVtexSite>" + qtdVtexSite + "</qtdVtexSite>";
        //            doc.DocumentElement.AppendChild(item);

        //            var old = doc.CreateElement("OldFila");
        //            old.InnerXml = xml.InnerXml;
        //            doc.DocumentElement.AppendChild(old);

        //            fila.Conteudo = doc.InnerXml;
        //            fila.IntegracaoDestino.ID = 150;
        //        }
        //    }
        //    else
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        var integrador = doc.CreateElement("Integrador");
        //        doc.AppendChild(integrador);

        //        var item = doc.CreateElement("Item");
        //        item.InnerXml = "<ID>" + id + "</ID><qtdERP>" + qtdERP + "</qtdERP><qtdVtexExt>" + qtdVtexExt + "</qtdVtexExt><qtdVtexSite>" + qtdVtexSite + "</qtdVtexSite>";
        //        doc.DocumentElement.AppendChild(item);

        //        var old = doc.CreateElement("OldFila");
        //        old.InnerXml = xml.InnerXml;
        //        doc.DocumentElement.AppendChild(old);

        //        fila.Conteudo = doc.InnerXml;
        //        fila.IntegracaoDestino.ID = 3;
        //    }

        //    return fila;
        //}

        //public Model.Fila FiltrarListasAntigas(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    DateTime date = DateTime.MinValue;
        //    if (xml != null && xml["EventoData"] != null && DateTime.TryParse(xml["EventoData"].InnerText, out date) && date > DateTime.Today)
        //    {
        //        return fila;
        //    }
        //    else if (xml != null && xml["ListaVtexID"] != null && !string.IsNullOrEmpty(xml["ListaVtexID"].InnerText))
        //    {
        //        return fila;
        //    }
        //    else
        //    {
        //        Fila filaBS = new Fila();
        //        Model.Fila novo = new Model.Fila();
        //        novo.ChavePrimaria = xml["ID"].InnerText;
        //        novo.ChaveSecundaria = "";
        //        novo.DataCriacao = DateTime.Now;
        //        novo.Integracao.ID = fila.Integracao.ID;
        //        novo.Status = fila.Status;
        //        novo.LogIntegracaoID = fila.LogIntegracaoID;
        //        novo.Conteudo = xml.ParentNode.InnerXml;
        //        novo.IntegracaoDestino.ID = 3;

        //        InserirSeNaoTemDuplicidade(novo);

        //        return null;
        //    }
        //}

        //public Model.Fila VerificaSePedidoPodeSerCancelado(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml != null && xml["status"] != null && xml["status"].InnerText == "payment-pending")
        //    {
        //        return fila;
        //    }

        //    Fila filaBS = new Fila();
        //    Model.Fila novo = new Model.Fila();
        //    novo.ChavePrimaria = xml["orderId"].InnerText;
        //    novo.ChaveSecundaria = "";
        //    novo.DataCriacao = DateTime.Now;
        //    novo.Integracao.ID = fila.Integracao.ID;
        //    novo.Status = fila.Status;
        //    novo.LogIntegracaoID = fila.LogIntegracaoID;
        //    novo.Conteudo = "<cancel><orderId>" + xml["orderId"].InnerText + "</orderId></cancel>";
        //    novo.IntegracaoDestino.ID = 220;

        //    InserirSeNaoTemDuplicidade(novo);

        //    return null;
        //}

        //public Model.Fila VerificaSeAlteraListaConsultaIdParticipante(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml != null && xml["Item"] != null
        //        && xml["Item"]["ListaVtexID"] != null
        //        && !string.IsNullOrEmpty(xml["Item"]["ListaVtexID"].InnerText)
        //        && xml["Item"]["ListaVtexID"].InnerText != "0")
        //    {
        //        fila.IntegracaoDestino.ID = 83;
        //        if (VerificaDuplicidade(fila.IntegracaoDestino.ID, fila.ChavePrimaria, fila.ChaveSecundaria))
        //        {
        //            return null;
        //        }
        //    }

        //    return fila;
        //}

        //public Model.Fila VerificaSeProdutoAindaTemImagem(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if(xml == null || xml.GetElementsByTagName("ImageListByStockKeepingUnitIdResult").Count == 0)
        //    {
        //        throw new Exception("Nao ha xml de resposta ou nao ha tag ImageListByStockKeepingUnitIdResult na resposta");
        //    }

        //    XmlNode node = xml.GetElementsByTagName("ImageListByStockKeepingUnitIdResult")[0];

        //    if(node.ChildNodes.Count > 0)
        //    {
        //        fila.Conteudo = fila.Conteudo.Replace("ImageListByStockKeepingUnitIdResult", "ExistemImagensAposChamarRemocao");
        //        fila.IntegracaoDestino.ID = 51;
        //    }

        //    var validations = xml.GetElementsByTagName("ExistemImagensAposChamarRemocao");

        //    if (validations != null && validations.Count > 3)
        //    {
        //        throw new Exception("Metodo de remoção de imagens ja foi chamado 3 vezes e nao funcionou.");
        //    }

        //    return fila;
        //}

        //public Model.Fila VerificaSePrecisaConsultarUserId2(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml != null && xml["Item"] != null
        //        && xml["Item"]["NoivoEmail"] != null
        //        && !string.IsNullOrEmpty(xml["Item"]["NoivoEmail"].InnerText))
        //    {
        //        fila.IntegracaoDestino.ID = 93;
        //        if (VerificaDuplicidade(fila.IntegracaoDestino.ID, fila.ChavePrimaria, fila.ChaveSecundaria))
        //        {
        //            return null;
        //        }
        //    }

        //    return fila;
        //}

        ///// <summary>
        ///// Caso a lista não esteja na tabela LogUpdate, indicando que não existe integrações de listas no sentido ERP/Vtex
        ///// pendentes, segue para o proximo passo, continuando a integração
        ///// </summary>
        ///// <param name="fila"></param>
        ///// <param name="map"></param>
        ///// <param name="xml"></param>
        ///// <returns></returns>

        //public Model.Fila ValidarDescidaLista(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml["PodeIntegrar"] != null && xml["PodeIntegrar"].InnerText == "true")
        //    {
        //        fila.IntegracaoDestino.ID = 33;
        //    }
        //    else
        //    {
        //        fila.IntegracaoDestino.ID = 84;
        //    }

        //    if (VerificaDuplicidade(fila.IntegracaoDestino.ID, fila.ChavePrimaria, fila.ChaveSecundaria))
        //    {
        //        return null;
        //    }

        //    return fila;


        //    //if (xml != null && xml["Item"] != null
        //    //    && xml["Item"]["ListaVtexID"] != null
        //    //    && !string.IsNullOrEmpty(xml["Item"]["ListaVtexID"].InnerText)
        //    //    && xml["Item"]["ListaVtexID"].InnerText != "0")
        //    //{
        //    //    fila.IntegracaoDestino.ID = 83;
        //    //    if (VerificaDuplicidade(fila.IntegracaoDestino.ID, fila.ChavePrimaria, fila.ChaveSecundaria))
        //    //    {
        //    //        return null;
        //    //    }
        //    //}

        //    //return fila;
        //}


        //public void GeraItemFilaPorVariacao(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    int variacaoTipoId = 0;

        //    if (xml != null && xml["EcommID"] != null)
        //        int.TryParse(xml["EcommID"].InnerText, out variacaoTipoId);

        //    if (variacaoTipoId == 1)
        //    {
        //        Fila filaBS = new Fila();
        //        Model.Fila novo = new Model.Fila();
        //        novo.ChavePrimaria = xml["ID"].InnerText;
        //        novo.ChaveSecundaria = "";
        //        novo.DataCriacao = DateTime.Now;
        //        novo.Integracao.ID = fila.Integracao.ID;
        //        novo.Status = fila.Status;
        //        novo.LogIntegracaoID = fila.LogIntegracaoID;
        //        novo.Conteudo = xml.ParentNode.InnerXml;
        //        novo.IntegracaoDestino.ID = 46;

        //        InserirSeNaoTemDuplicidade(novo);
        //    }

        //    xml = null;
        //}

        //public void GeraItensDeAtualizacaoDaListaVtex(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    Fila filaBS = new Fila();
        //    Model.Fila logUpdate = new Model.Fila();
        //    logUpdate.ChavePrimaria = xml["Referencias"]["LogUpdateID"].InnerText;
        //    logUpdate.ChaveSecundaria = "";
        //    logUpdate.DataCriacao = DateTime.Now;
        //    logUpdate.Integracao.ID = fila.Integracao.ID;
        //    logUpdate.Status = fila.Status;
        //    logUpdate.LogIntegracaoID = fila.LogIntegracaoID;
        //    logUpdate.Conteudo = string.Format("<Integrador><Item><ID>{0}</ID></Item></Integrador>", logUpdate.ChavePrimaria);
        //    logUpdate.IntegracaoDestino.ID = 3;

        //    InserirSeNaoTemDuplicidade(logUpdate);

        //    var diferencas = xml["Diferencas"];
        //    foreach (XmlNode node in diferencas.ChildNodes)
        //    {
        //        Model.Fila novo = new Model.Fila();
        //        novo.ChavePrimaria = node["SkuId"].InnerText;
        //        novo.ChaveSecundaria = xml["Referencias"]["VtexID"].InnerText;
        //        novo.DataCriacao = DateTime.Now;
        //        novo.Integracao.ID = fila.Integracao.ID;
        //        novo.Status = fila.Status;
        //        novo.LogIntegracaoID = fila.LogIntegracaoID;
        //        novo.Conteudo = GetConteudoItemDaLista(node, xml["Referencias"]["VtexID"].InnerText, xml["Referencias"]["ListaCod"].InnerText);


        //        if (node.Name == "genexus") //adicionar
        //        {
        //            novo.IntegracaoDestino.ID = 82;
        //        }
        //        else
        //        {
        //            //novo.IntegracaoDestino.ID = 82;
        //            novo.IntegracaoDestino.ID = 24;
        //        }

        //        InserirSeNaoTemDuplicidade(novo);
        //    }
        //}

        //public void GeraItensDeAtualizacaoDaListaGenexus(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    Fila filaBS = new Fila();
        //    var alteracoes = xml.GetElementsByTagName("alteracao-item");
        //    foreach (XmlNode node in alteracoes)
        //    {
        //        Model.Fila novo = new Model.Fila();
        //        novo.ChavePrimaria = node["VtexID"].InnerText;
        //        novo.ChaveSecundaria = node["ProdCod"].InnerText;
        //        novo.DataCriacao = DateTime.Now;
        //        novo.Integracao.ID = fila.Integracao.ID;
        //        novo.Status = fila.Status;
        //        novo.LogIntegracaoID = fila.LogIntegracaoID;
        //        novo.Conteudo = node.OuterXml;

        //        novo.IntegracaoDestino.ID = 89;

        //        InserirSeNaoTemDuplicidade(novo);
        //    }
        //}

        //private string GetConteudoItemDaLista(XmlNode node, string vtexID, string listaCod)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    var root = doc.CreateElement("ListaDePresente");
        //    doc.AppendChild(root);

        //    XmlNode idVtex = doc.CreateElement("VtexID");
        //    idVtex.InnerText = vtexID;
        //    root.AppendChild(idVtex);

        //    XmlNode nListaCod = doc.CreateElement("ListaCod");
        //    nListaCod.InnerText = listaCod;
        //    root.AppendChild(nListaCod);

        //    XmlNode prodCod = doc.CreateElement("ProdCod");
        //    prodCod.InnerText = node["SkuId"].InnerText;
        //    root.AppendChild(prodCod);

        //    XmlNode quantidade = doc.CreateElement("Quantidade");

        //    if (node["Quantidade"] == null)
        //    {
        //        quantidade.InnerText = "1";
        //    }
        //    else
        //    {
        //        quantidade.InnerText = node["Quantidade"].InnerText;// "1";// root["Quantidade"].InnerText;//"1";
        //    }
        //    root.AppendChild(quantidade);

        //    return doc.InnerXml;
        //}

        //public Model.Fila VerificaProfileId(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{

        //    if (String.IsNullOrEmpty(xml["Response"]["profileId"].InnerText))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return fila;
        //    }
        //}

        //public Model.Fila InserePedidosFila(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    Model.Fila itemFila;
        //    Fila filaBS = new Fila();
        //    #region Pedidos- Integracao 57
        //    foreach (XmlNode item in xml["listaPedidos"].ChildNodes)
        //    {
        //        itemFila = new Model.Fila();
        //        itemFila.ChavePrimaria = item["orderId"].InnerText;
        //        itemFila.ChaveSecundaria = "";
        //        itemFila.DataCriacao = DateTime.Now;
        //        itemFila.Integracao.ID = fila.Integracao.ID;
        //        itemFila.IntegracaoDestino.ID = fila.IntegracaoDestino.ID;
        //        itemFila.Status = fila.Status;
        //        itemFila.LogIntegracaoID = fila.LogIntegracaoID;
        //        itemFila.Conteudo = string.Format("<Integrador><Item>{0}</Item></Integrador>", item.InnerXml);

        //        InserirSeNaoTemDuplicidade(itemFila);
        //    }
        //    #endregion

        //    #region Buscar Lista de Pedidos VTEX - Paginação
        //    int paginaInicial = Convert.ToInt32(xml["Item"]["Page"].InnerText);
        //    int paginaAtual = paginaInicial;
        //    int paginaFinal = Convert.ToInt32(xml["Item"]["LastPage"].InnerText);
        //    while (paginaAtual < paginaFinal && paginaInicial == 1)
        //    {
        //        paginaAtual++;
        //        xml["Item"]["Page"].InnerText = paginaAtual.ToString();
        //        itemFila = new Model.Fila();
        //        itemFila.ChavePrimaria = paginaAtual.ToString();
        //        itemFila.ChaveSecundaria = "";
        //        itemFila.DataCriacao = DateTime.Now;
        //        itemFila.Integracao.ID = 55;
        //        itemFila.IntegracaoDestino.ID = fila.Integracao.ID;
        //        itemFila.Status = fila.Status;
        //        itemFila.LogIntegracaoID = fila.LogIntegracaoID;
        //        itemFila.Conteudo = string.Format("<Integrador><Item>{0}</Item></Integrador>", xml["Item"].InnerXml);
        //        InserirSeNaoTemDuplicidade(itemFila);
        //    }
        //    #endregion

        //    return null;
        //}


        //public Model.Fila SeparaItensPedidoParaFila(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    XmlNodeList list = xml.SelectNodes("//items");
        //    Model.Fila itemFila;
        //    Fila filaBS = new Fila();
        //    string IdPedidoNode = xml["pedidoResponse"].InnerXml;
        //    //int cont = 1;
        //    foreach (XmlNode item in list)
        //    {
        //        string xmlInterno = String.Format("<ItemPedido>{0}{1}</ItemPedido>", item.InnerXml, IdPedidoNode);
        //        itemFila = new Model.Fila();
        //        itemFila.ChavePrimaria = xml["orderId"].InnerText;
        //        itemFila.ChaveSecundaria = item["id"].InnerText;
        //        itemFila.DataCriacao = DateTime.Now;
        //        itemFila.Integracao.ID = fila.Integracao.ID;
        //        itemFila.IntegracaoDestino.ID = fila.IntegracaoDestino.ID;
        //        itemFila.Status = fila.Status;
        //        itemFila.Conteudo = xmlInterno;

        //        InserirSeNaoTemDuplicidade(itemFila);
        //        //cont++;
        //    }
        //    return null;

        //}

        //public Model.Fila GeraAtualizacaoDePrecoPorSalesChannel(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    Model.Fila novo;
        //    if (xml["Response"] != null
        //        && xml["Response"]["s:Envelope"] != null
        //        && xml["Response"]["s:Envelope"]["s:Body"] != null
        //        && xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"] != null
        //        && xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"]["ProductInsertUpdateResult"] != null
        //        && xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"]["ProductInsertUpdateResult"]["a:ListStoreId"] != null
        //        && xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"]["ProductInsertUpdateResult"]["a:ListStoreId"].ChildNodes != null
        //        && xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"]["ProductInsertUpdateResult"]["a:ListStoreId"].ChildNodes.Count > 0)
        //    {
        //        Fila filaBS = new Fila();
        //        List<int> salesChannels = new List<int>();

        //        var elemSalesChannels = xml["Response"]["s:Envelope"]["s:Body"]["ProductInsertUpdateResponse"]["ProductInsertUpdateResult"]["a:ListStoreId"].ChildNodes;
        //        foreach (XmlNode elem in elemSalesChannels)
        //        {
        //            salesChannels.Add(int.Parse(elem.InnerText));
        //        }

        //        foreach (var salesChannel in salesChannels)
        //        {
        //            int prodCod = int.Parse(xml["Item"]["ProdCod"].InnerText);
        //            novo = new Model.Fila();
        //            novo.ChavePrimaria = prodCod.ToString();
        //            novo.ChaveSecundaria = salesChannel.ToString();
        //            novo.Conteudo = GeraConteudoPreco(xml, salesChannel, prodCod);
        //            novo.DataCriacao = DateTime.Now;
        //            novo.Integracao.ID = fila.Integracao.ID;
        //            novo.IntegracaoDestino.ID = 8;
        //            novo.Status = fila.Status;
        //            novo.LogIntegracaoID = fila.LogIntegracaoID;

        //            InserirSeNaoTemDuplicidade(novo);
        //        }
        //    }
        //    return fila;
        //}

        //private string GeraConteudoPreco(XmlElement xml, int salesChannel, int prodCod)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    var root = doc.CreateElement("Integrador");
        //    doc.AppendChild(root);

        //    XmlNode item = doc.CreateElement("Item");
        //    root.AppendChild(item);

        //    XmlNode nProdCod = doc.CreateElement("ProdCod");
        //    nProdCod.InnerText = prodCod.ToString();
        //    item.AppendChild(nProdCod);

        //    XmlNode SalesChannel = doc.CreateElement("SalesChannel");
        //    SalesChannel.InnerText = salesChannel.ToString();
        //    item.AppendChild(SalesChannel);

        //    XmlNode ProdPromoc = doc.CreateElement("ProdPromoc");
        //    ProdPromoc.InnerText = xml["Item"]["ProdPromoc"].InnerText;
        //    item.AppendChild(ProdPromoc);

        //    XmlNode ValorVenda = doc.CreateElement("ValorVenda");
        //    ValorVenda.InnerText = xml["Item"]["ValorVenda"].InnerText;
        //    item.AppendChild(ValorVenda);

        //    XmlNode ProdValiPr = doc.CreateElement("ProdValiPr");
        //    if (xml["Item"]["ProdValiPr"] != null)
        //        ProdValiPr.InnerText = xml["Item"]["ProdValiPr"].InnerText;
        //    else
        //        ProdValiPr.InnerText = new DateTime(2200, 01, 01).ToString("yyyy/MM/ddT02:00:00");
        //    item.AppendChild(ProdValiPr);

        //    XmlNode Response = doc.CreateElement("Response");
        //    root.AppendChild(Response);

        //    XmlNode response = doc.CreateElement("response");
        //    Response.AppendChild(response);

        //    XmlNode price = doc.CreateElement("price");
        //    response.AppendChild(price);

        //    XmlNode id = doc.CreateElement("id");
        //    if (xml["Response"]["response"].ChildNodes != null)
        //    {
        //        id.InnerText = ObtemPossivelIdPreco(xml["Response"]["response"].ChildNodes, salesChannel);
        //    }
        //    price.AppendChild(id);

        //    return doc.InnerXml;
        //}

        //private string ObtemPossivelIdPreco(XmlNodeList xmlElements, int salesChannel)
        //{
        //    foreach (XmlNode node in xmlElements)
        //    {
        //        if (node["salesChannel"].InnerText == salesChannel.ToString())
        //            return node["id"].InnerText;
        //    }
        //    return null;
        //}

        //public Model.Fila RemoveItensSemValor(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml["CampoValor"].InnerText == "NAO_TEM_VALOR_CADASTRADO")
        //    {
        //        return null;
        //    }
        //    return fila;
        //}

        //public Model.Fila ValidarSeListaEstaAtiva(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml == null
        //        || xml["a:GiftListDTO"] == null
        //        || xml["a:GiftListDTO"]["a:IsActive"] == null
        //        || string.IsNullOrEmpty(xml["a:GiftListDTO"]["a:IsActive"].InnerXml)
        //        || xml["a:GiftListDTO"]["a:IsActive"].InnerXml == "false")
        //    {
        //        return null;
        //    }

        //    return fila;
        //}

        //public Model.Fila DefinirDestinoDePedidoBoletoBaseadoNoStatusAtualDaVtex(Model.Fila fila, List<Model.Mapeamento> map, XmlElement xml)
        //{
        //    if (xml == null
        //        || xml["Response"] == null
        //        || xml["Response"]["pedido"] == null
        //        || xml["Response"]["pedido"]["status"] == null
        //        || string.IsNullOrEmpty(xml["Response"]["pedido"]["status"].InnerText))
        //    {
        //        throw new Exception("Pedido não tem campo 'status'");
        //    }

        //    string status = xml["Response"]["pedido"]["status"].InnerText;

        //    if (status == "payment-pending")
        //    {
        //        fila.IntegracaoDestino.ID = 79;
        //    }
        //    else if (status == "ready-for-handling")
        //    {
        //        fila.IntegracaoDestino.ID = 69;
        //    }
        //    else if (status == "handling")
        //    {
        //        fila.IntegracaoDestino.ID = 68;
        //    }
        //    else if (status == "invoiced")
        //    {
        //        fila.IntegracaoDestino.ID = 103;
        //    }
        //    else
        //    {
        //        throw new Exception("Pedido com campo 'status' não mapeado: '" + status + "'");
        //    }

        //    return fila;
        //}
    }
}



