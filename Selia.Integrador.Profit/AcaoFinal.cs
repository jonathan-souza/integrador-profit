using BS;
using Selia.Integrador.Adapter;
using Selia.Integrador.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Selia.Integrador.Adapter.Rest;

namespace Selia.Integrador.MDias
{
    public class AcaoFinal
    {
        public XmlDocument RemoveNodesNaoUtilizados(XmlDocument respostaCompleta, XmlDocument fila, Config entConfig = null)
        {
            if (entConfig != null)
            {
                var nodes = entConfig.NodesNaoUtilizados.Split(';');

                foreach(var nomeNode in nodes)
                {
                    XmlNode node = respostaCompleta.SelectSingleNode(nomeNode);
                    node.ParentNode.RemoveChild(node);
                }
            }

            return respostaCompleta;
        }
        //public XmlDocument PreencheDadosDaFilaAposRetornoVtex(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    XmlDocument complete = new XmlDocument();

        //    complete.AppendChild(complete.CreateElement("Integrador"));
        //    XmlNode response;
        //    if (fila["Integrador"] != null && fila["Integrador"]["Response"] != null)
        //    {
        //        response = complete.ImportNode(fila["Integrador"]["Response"].Clone(), true);
        //        response.InnerXml += respostaCompleta.InnerXml;
        //        //complete.AppendChild(fila["Integrador"]["Response"]);
        //    }
        //    else
        //    {
        //        response = complete.CreateElement("Response");
        //        response.InnerXml = respostaCompleta.InnerXml;

        //    }
        //    complete.DocumentElement.AppendChild(response);






        //    //complete.ImportNode(respostaCompleta["response"], true);
        //    var item = complete.CreateElement("Item");
        //    if (fila["Item"] != null)
        //    {
        //        item.InnerXml = fila["Item"].InnerXml;
        //    }
        //    else if (fila["Integrador"]["Item"] != null)
        //    {
        //        item.InnerXml = fila["Integrador"]["Item"].InnerXml;
        //    }
        //    complete.DocumentElement.AppendChild(item);
        //    return complete;

        //}

        //public XmlDocument MontarNoClienteEEndFatura(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    fila.DocumentElement.AppendChild(fila.CreateElement("clientDataFromPayments"));

        //    if (respostaCompleta != null && respostaCompleta.GetElementsByTagName("fields").Count > 0)
        //        foreach (XmlNode node in respostaCompleta.GetElementsByTagName("fields"))
        //            if (node["name"].InnerText == "clientProfileData")
        //            {
        //                var valueJson = Json.DeserializeXmlNode("{ parent: " + node["value"].InnerText + " }");
        //                fila.DocumentElement["clientDataFromPayments"].InnerXml = valueJson["parent"].InnerXml;
        //            }

        //    return fila;
        //}

        //public XmlDocument PreencheDadosDoMembroNoiva(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    return PreencheDadosDoMembro(respostaCompleta, fila, "MembroNoiva");
        //}

        //public XmlDocument PreencheDadosDoMembroNoivo(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    return PreencheDadosDoMembro(respostaCompleta, fila, "MembroNoivo");
        //}

        //public XmlDocument PreencheDadosDoMembro(XmlDocument respostaCompleta, XmlDocument fila, string membro)
        //{
        //    if (respostaCompleta != null && respostaCompleta.DocumentElement != null && respostaCompleta.DocumentElement.ChildNodes.Count > 0)
        //    {
        //        fila.DocumentElement[membro]["CPF"].InnerText = respostaCompleta.DocumentElement["document"].InnerText;
        //        fila.DocumentElement[membro]["Telefone"].InnerText = respostaCompleta.DocumentElement["homePhone"].InnerText;
        //        fila.DocumentElement[membro]["Celular"].InnerText = respostaCompleta.DocumentElement["cellPhone"].InnerText;
        //    }
        //    return fila;
        //}

        //public XmlDocument ValidarDescidaLista(XmlDocument resultadoAtual, XmlDocument fila)
        //{
        //    bool listaConstaNaLogUpdate = false; 
        //    foreach (XmlNode ItemLogUpdate in resultadoAtual["Integrador"].ChildNodes)
        //    {
        //        if (ItemLogUpdate["ListaRef"].InnerText == fila["Vtex"]["a:GiftListDTO"]["a:GiftListId"].InnerText)
        //        {
        //            listaConstaNaLogUpdate = true;
        //            break;
        //        }
        //    }

        //    if (listaConstaNaLogUpdate)
        //    {
        //        if (fila["Vtex"]["PodeIntegrar"] == null)
        //        {
        //            XmlNode end = fila.CreateElement("PodeIntegrar");
        //            fila.DocumentElement.AppendChild(end);
        //            end.InnerText = "false";
        //        }
        //        else
        //        {
        //            fila["Vtex"]["PodeIntegrar"].InnerText = "false";
        //        }

        //        //return fila;
        //    }
        //    else
        //    {
        //        if (fila["Vtex"]["PodeIntegrar"] == null)
        //        {
        //            XmlNode end = fila.CreateElement("PodeIntegrar");
        //            fila.DocumentElement.AppendChild(end);
        //            end.InnerText = "true";
        //        }
        //        else
        //        {
        //            fila["Vtex"]["PodeIntegrar"].InnerText = "true";
        //        }
        //        //string conteudo = fila.InnerXml.ToString();
        //        //resultadoAtual.InnerXml = conteudo;
        //        //return resultadoAtual;
        //    }

        //    return fila;
        //}

        //public XmlDocument PreencheEnderecoCompletoLista(XmlDocument resultadoAtual, XmlDocument fila)
        //{
        //    XmlNode end = fila.CreateElement("EnderecoLista");
        //    fila.DocumentElement.AppendChild(end);

        //    XmlNode noivosNome = fila.CreateElement("NoivosNome");
        //    end.AppendChild(noivosNome);
        //    XmlNode noivosEndereco = fila.CreateElement("NoivosEnd");
        //    end.AppendChild(noivosEndereco);
        //    XmlNode noivosBairro = fila.CreateElement("NoivosBairro");
        //    end.AppendChild(noivosBairro);
        //    XmlNode noivosCidade = fila.CreateElement("NoivosCidade");
        //    end.AppendChild(noivosCidade);
        //    XmlNode noivosEstado = fila.CreateElement("NoivosEstado");
        //    end.AppendChild(noivosEstado);
        //    XmlNode noivosCep = fila.CreateElement("NoivosCep");
        //    end.AppendChild(noivosCep);


        //    var currAdId = fila["Vtex"]["a:GiftListDTO"]["a:ProfileSystemUserAddressName"].InnerText.Replace("-", "_x002D_");

        //    if (resultadoAtual["enderecoCompleto"] != null && resultadoAtual["enderecoCompleto"][currAdId] != null)
        //    {
        //        var addressNode = resultadoAtual["enderecoCompleto"][currAdId].InnerXml;
        //        dynamic jsonAddress = Json.Deserialize(addressNode);
        //        //var jsonAddress = new { street = "", number = "", complement = "", city = "", neighborhood = "", state = "", postalCode = "" };
        //        //jsonAddress = Json.DeserializeDynamic<jsonAddress.GetType()>(addressNode, jsonAddress);

        //        if (fila != null
        //            && fila.DocumentElement != null
        //            && fila.DocumentElement["MembroNoiva"] != null
        //            && fila.DocumentElement["MembroNoiva"]["Nome"] != null)
        //        {
        //            noivosNome.InnerText = fila.DocumentElement["MembroNoiva"]["Nome"].InnerText;
        //            if (!string.IsNullOrEmpty(fila.DocumentElement["MembroNoivo"]["Nome"].InnerText))
        //                noivosNome.InnerText += " e " + fila.DocumentElement["MembroNoivo"]["Nome"].InnerText;
        //        }

        //        noivosEndereco.InnerText = string.Format("{0} {1} {2}", (jsonAddress.street == null) ? "(sem endereço)" : jsonAddress.street, (jsonAddress.number == null) ? "(sem numero)" : jsonAddress.number, (jsonAddress.complement == null) ? "(sem compl)" : jsonAddress.complement);
        //        noivosCidade.InnerText = jsonAddress.city;
        //        noivosBairro.InnerText = jsonAddress.neighborhood;
        //        noivosEstado.InnerText = jsonAddress.state;
        //        noivosCep.InnerText = jsonAddress.postalCode;
        //    }


        //    #region endereco da noiva
        //    XmlNode enderecoNoiva = fila.CreateElement("EnderecoNoiva");
        //    fila.DocumentElement.AppendChild(enderecoNoiva);


        //    XmlNode noivaEndereco = fila.CreateElement("NoivaEnd");
        //    enderecoNoiva.AppendChild(noivaEndereco);

        //    #region campos novos para o endereco

        //    XmlNode noivaNumero = fila.CreateElement("NoivaNumero");
        //    enderecoNoiva.AppendChild(noivaNumero);

        //    XmlNode noivaComplemento = fila.CreateElement("NoivaComplemento");
        //    enderecoNoiva.AppendChild(noivaComplemento);

        //    #endregion

        //    XmlNode noivaBairro = fila.CreateElement("NoivaBairro");
        //    enderecoNoiva.AppendChild(noivaBairro);
        //    XmlNode noivaCidade = fila.CreateElement("NoivaCidade");
        //    enderecoNoiva.AppendChild(noivaCidade);
        //    XmlNode noivaEstado = fila.CreateElement("NoivaEstado");
        //    enderecoNoiva.AppendChild(noivaEstado);
        //    XmlNode noivaCep = fila.CreateElement("NoivaCep");
        //    enderecoNoiva.AppendChild(noivaCep);



        //    //var currAdId = fila["Vtex"]["a:GiftListDTO"]["a:ProfileSystemUserAddressName"].InnerText;

        //    if (resultadoAtual["enderecoCompleto"] != null && resultadoAtual["enderecoCompleto"][currAdId] != null)
        //    {
        //        var addressNode = resultadoAtual["enderecoCompleto"][currAdId].InnerXml;
        //        dynamic jsonAddress = Json.Deserialize(addressNode);
        //        //var jsonAddress = new { street = "", number = "", complement = "", city = "", neighborhood = "", state = "", postalCode = "" };
        //        //jsonAddress = Json.DeserializeDynamic<jsonAddress.GetType()>(addressNode, jsonAddress);

        //        noivaEndereco.InnerText = (jsonAddress.street == null) ? "(sem endereço)" : jsonAddress.street;
        //        noivaNumero.InnerText = (jsonAddress.number == null) ? "(sem numero)" : jsonAddress.number;
        //        noivaComplemento.InnerText = (jsonAddress.complement == null) ? "(sem compl)" : jsonAddress.complement;
        //        noivaCidade.InnerText = jsonAddress.city;
        //        noivaBairro.InnerText = jsonAddress.neighborhood;
        //        noivaEstado.InnerText = jsonAddress.state;
        //        noivaCep.InnerText = jsonAddress.postalCode;

        //    }

        //    #endregion

        //    return fila;
        //}

        //public XmlDocument ReuneMasterDataCliente(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    if (respostaCompleta != null && respostaCompleta.GetElementsByTagName("ccs").Count > 0)
        //    {
        //        XmlNode masterData = fila.CreateElement("MasterData");
        //        fila.DocumentElement.AppendChild(masterData);

        //        masterData.InnerXml = respostaCompleta.GetElementsByTagName("ccs")[0].InnerXml;
        //    }

        //    return fila;
        //}

        //public XmlDocument ReuneDadosDeListaECliente(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    XmlNode email = fila.CreateElement("EmailPrincipal");
        //    fila.DocumentElement.AppendChild(email);

        //    if (respostaCompleta["cliente"] != null && respostaCompleta["cliente"]["email"] != null)
        //        email.InnerXml = respostaCompleta["cliente"]["email"].InnerXml;

        //    GeraNosMembros(respostaCompleta, fila);

        //    return fila;
        //}


        //public XmlDocument ReuneDadosGiftListMemberId(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    //XmlNode GiftListMemberId = fila.CreateElement("GiftListMemberId");
        //    //fila.DocumentElement.AppendChild(GiftListMemberId);

        //    foreach (XmlNode cliente in fila["Integrador"]["Response"].ChildNodes)
        //    {
        //        string profileId = cliente["profileId"].InnerText;

        //        if (respostaCompleta["response"]["giftListMembers"] != null)
        //        {

        //            foreach (XmlNode item in respostaCompleta["response"].ChildNodes)
        //            {

        //                if (item["giftListMemberId"] != null)
        //                {
        //                    if (item["giftListMemberId"] != null && item["userId"] != null && item["userId"].InnerText.ToUpper() == profileId.ToUpper())
        //                    {
        //                        //encontrou o giftListMemberId do cliente, precisa inserir um só com está informação
        //                        XmlNode GiftListMemberId = fila.CreateElement("GiftListMemberId");
        //                        cliente.AppendChild(GiftListMemberId);

        //                        GiftListMemberId.InnerXml = item["giftListMemberId"].InnerText;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    //foreach (XmlNode item in respostaCompleta["response"].ChildNodes)
        //    //{
        //    //    if (item["giftListMemberId"] != null)
        //    //    {
        //    //        if (item["giftListMemberId"] != null && item["userId"] != null && item["userId"].InnerText != "593af683-fa0a-4d17-855b-3d73f6d3a3e0")
        //    //        {
        //    //            XmlNode GiftListMemberId = fila.CreateElement("GiftListMemberId1");
        //    //            fila.DocumentElement["Item"].AppendChild(GiftListMemberId);

        //    //            GiftListMemberId.InnerXml = item["giftListMemberId"].InnerText;
        //    //        }
        //    //        else if(item["giftListMemberId"] != null)
        //    //        {
        //    //            XmlNode GiftListMemberId = fila.CreateElement("GiftListMemberId2");
        //    //            fila.DocumentElement["Item"].AppendChild(GiftListMemberId);

        //    //            GiftListMemberId.InnerXml = item["giftListMemberId"].InnerText;
        //    //        }
        //    //    }
        //    //}

        //    return fila;
        //}

        //private void GeraNosMembros(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    bool noivaok = false;
        //    foreach (XmlNode member in fila.DocumentElement["a:GiftListDTO"]["a:GiftListMembers"].ChildNodes)
        //    {
        //        XmlNode memberNode = fila.CreateElement((noivaok) ? "MembroNoivo" : "MembroNoiva");
        //        fila.DocumentElement.AppendChild(memberNode);

        //        XmlNode nNome = fila.CreateElement("Nome");
        //        XmlNode nTelefone = fila.CreateElement("Telefone");
        //        XmlNode nCelular = fila.CreateElement("Celular");
        //        XmlNode nEmail = fila.CreateElement("Email");
        //        XmlNode nCpf = fila.CreateElement("CPF");
        //        XmlNode nUserId = fila.CreateElement("ProfileUserId");

        //        memberNode.AppendChild(nNome);
        //        memberNode.AppendChild(nTelefone);
        //        memberNode.AppendChild(nCelular);
        //        memberNode.AppendChild(nEmail);
        //        memberNode.AppendChild(nCpf);
        //        memberNode.AppendChild(nUserId);

        //        var valorId = "-1";
        //        var valorNome = "";
        //        var valorEmail = "";

        //        if (!string.IsNullOrEmpty(member["a:ProfileSystemUserId"].InnerText))
        //        {
        //            valorId = member["a:ProfileSystemUserId"].InnerText;
        //            noivaok = true;
        //        }

        //        valorNome = member["a:Name"].InnerText + " " + member["a:Surname"].InnerText;
        //        valorEmail = member["a:Mail"].InnerText;

        //        nUserId.InnerText = valorId;
        //        nNome.InnerText = valorNome;
        //        nEmail.InnerText = valorEmail;
        //    }

        //    if (fila.DocumentElement["a:GiftListDTO"]["a:GiftListMembers"].ChildNodes.Count == 1)
        //    {
        //        XmlNode memberNode = fila.CreateElement("MembroNoivo");
        //        fila.DocumentElement.AppendChild(memberNode);

        //        XmlNode nNome = fila.CreateElement("Nome");
        //        XmlNode nTelefone = fila.CreateElement("Telefone");
        //        XmlNode nCelular = fila.CreateElement("Celular");
        //        XmlNode nEmail = fila.CreateElement("Email");
        //        XmlNode nCpf = fila.CreateElement("CPF");
        //        XmlNode nUserId = fila.CreateElement("ProfileUserId");

        //        memberNode.AppendChild(nNome);
        //        memberNode.AppendChild(nTelefone);
        //        memberNode.AppendChild(nCelular);
        //        memberNode.AppendChild(nEmail);
        //        memberNode.AppendChild(nCpf);
        //        memberNode.AppendChild(nUserId);

        //        var valorId = "-1";
        //        var valorNome = "";
        //        var valorEmail = "";

        //        nUserId.InnerText = valorId;
        //        nNome.InnerText = valorNome;
        //        nEmail.InnerText = valorEmail;
        //    }
        //}

        //public XmlDocument PreencheFilaAposRetornoListaVtex(XmlDocument resultadoAtual, XmlDocument fila)
        //{
        //    XmlDocument listaFinal = new XmlDocument();
        //    listaFinal.AppendChild(listaFinal.CreateElement("ListaDePresente"));

        //    if (resultadoAtual["s:Envelope"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListGetAllFromModifiedDateAndIdResponse"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListGetAllFromModifiedDateAndIdResponse"]["GiftListGetAllFromModifiedDateAndIdResult"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListGetAllFromModifiedDateAndIdResponse"]["GiftListGetAllFromModifiedDateAndIdResult"].ChildNodes != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListGetAllFromModifiedDateAndIdResponse"]["GiftListGetAllFromModifiedDateAndIdResult"].ChildNodes.Count > 0)
        //    {
        //        var nodes = resultadoAtual["s:Envelope"]["s:Body"]["GiftListGetAllFromModifiedDateAndIdResponse"]["GiftListGetAllFromModifiedDateAndIdResult"].ChildNodes;
        //        foreach (XmlNode node in nodes)
        //        {
        //            XmlNode vtex = listaFinal.CreateElement("Vtex");
        //            listaFinal.DocumentElement.AppendChild(vtex);
        //            var nodeToBeAdded = listaFinal.ImportNode(node.Clone(), true);
        //            vtex.AppendChild(nodeToBeAdded);

        //            DateTime modified = DateTime.Parse(node["a:DateModified"].InnerText);
        //            new DAL.DadosAuxiliares().SalvaHoraDeExecucaoNoBanco("Selia.Integrador.SantaHelena.AcaoInicial, Selia.Integrador.SantaHelena;SubstituiChavesPadrao", modified);
        //        }
        //    }

        //    return listaFinal;
        //}




        //public XmlDocument ReuneItensDaListaDePresenteGenexus(XmlDocument resultadoAtual, XmlDocument fila)
        //{
        //    XmlDocument final = new XmlDocument();

        //    XmlNode root = final.CreateElement("ListaDePresente");
        //    final.AppendChild(root);

        //    XmlNode referencias = final.CreateElement("Referencias");
        //    root.AppendChild(referencias);

        //    XmlNode genexus = final.CreateElement("Genexus");
        //    root.AppendChild(genexus);

        //    XmlNode vtex = final.CreateElement("Vtex");
        //    root.AppendChild(vtex);

        //    XmlNode idLogUpdate = final.CreateElement("LogUpdateID");
        //    idLogUpdate.InnerText = fila["Integrador"]["Item"]["ID"].InnerText;
        //    referencias.AppendChild(idLogUpdate);

        //    XmlNode idListaCod = final.CreateElement("ListaCod");
        //    idListaCod.InnerText = fila["Integrador"]["Item"]["ListaCod"].InnerText;
        //    referencias.AppendChild(idListaCod);

        //    XmlNode idVtex = final.CreateElement("VtexID");
        //    if (fila["Integrador"]["Item"]["ListaRef"] != null)
        //    {
        //        idVtex.InnerText = fila["Integrador"]["Item"]["ListaRef"].InnerText;
        //    }
        //    referencias.AppendChild(idVtex);

        //    foreach (XmlNode node in resultadoAtual["Integrador"].ChildNodes)
        //    {
        //        var nodeToBeAdded = final.ImportNode(node.Clone(), true);
        //        genexus.AppendChild(nodeToBeAdded);
        //    }



        //    return final;
        //}


        //public XmlDocument ReuneItensDaListaDePresenteVtex(XmlDocument resultadoAtual, XmlDocument fila)
        //{
        //    if (resultadoAtual["s:Envelope"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListSkuGetResponse"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListSkuGetResponse"]["GiftListSkuGetResult"] != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListSkuGetResponse"]["GiftListSkuGetResult"].ChildNodes != null
        //        && resultadoAtual["s:Envelope"]["s:Body"]["GiftListSkuGetResponse"]["GiftListSkuGetResult"].ChildNodes.Count > 0)
        //    {
        //        var nodes = resultadoAtual["s:Envelope"]["s:Body"]["GiftListSkuGetResponse"]["GiftListSkuGetResult"].ChildNodes;
        //        var vtexNode = fila["ListaDePresente"]["Vtex"];

        //        foreach (XmlNode node in nodes)
        //        {

        //            int quantidadeItem = 1;
        //            foreach (XmlNode item in vtexNode)
        //            {
        //                if (item["a:SkuId"].InnerText == node["a:SkuId"].InnerText)
        //                {
        //                    quantidadeItem += Convert.ToInt32(item["Quantidade"].InnerText);
        //                    item["Quantidade"].InnerText = quantidadeItem.ToString();
        //                    break;
        //                }
        //            }

        //            if (quantidadeItem == 1)
        //            {
        //                var nodeToBeAdded = fila.ImportNode(node.Clone(), true);
        //                XmlNode quantidade = fila.CreateElement("Quantidade");
        //                nodeToBeAdded.AppendChild(quantidade);
        //                quantidade.InnerText = quantidadeItem.ToString();
        //                vtexNode.AppendChild(nodeToBeAdded);
        //            }



        //        }
        //    }

        //    CriarNoItensAdicionarERemover(fila);

        //    return fila;
        //}

        //public class _AlteracaoItem
        //{
        //    public int vtexId { get; set; }
        //    public int prodCod { get; set; }
        //    public int quantidade { get; set; }
        //    public string acao { get; set; }
        //}

        //private void CriarNoItensAdicionarERemover(XmlDocument fila)
        //{
        //    var diferencas = fila.CreateElement("Diferencas");
        //    fila.DocumentElement.AppendChild(diferencas);

        //    var itensVtex = fila["ListaDePresente"]["Vtex"];
        //    var itensGenexus = fila["ListaDePresente"]["Genexus"];

        //    var alteracoes = new List<_AlteracaoItem>();
        //    foreach(XmlNode node in itensGenexus)
        //        alteracoes.Add(new _AlteracaoItem {
        //            vtexId = int.Parse(fila["ListaDePresente"]["Referencias"]["VtexID"].InnerText),
        //            prodCod = int.Parse(node["ProdCod"].InnerText),
        //            quantidade = int.Parse(node["Quantidade"].InnerText),
        //            acao = "D"
        //        });

        //    foreach (XmlNode node in itensVtex)
        //    {
        //        _AlteracaoItem item = new _AlteracaoItem();
        //        item.vtexId = int.Parse(fila["ListaDePresente"]["Referencias"]["VtexID"].InnerText);
        //        item.prodCod = int.Parse(node["a:SkuId"].InnerText);
        //        item.quantidade = int.Parse(node["Quantidade"].InnerText);

        //        if (alteracoes.Any(x => x.prodCod == item.prodCod))
        //        {
        //            var existente = alteracoes.First(x => x.prodCod == item.prodCod);

        //            if(item.quantidade == existente.quantidade)
        //            {
        //                alteracoes.Remove(existente);
        //            }
        //            else
        //            {
        //                existente.quantidade = item.quantidade;
        //                existente.acao = "U";
        //            }
        //        }
        //        else
        //        {
        //            item.acao = "I";
        //            alteracoes.Add(item);
        //        }
        //    }

        //    foreach (var item in alteracoes)
        //    {
        //        var alt = fila.CreateElement("alteracao-item");
        //        diferencas.AppendChild(alt);

        //        XmlNode prodcod = fila.CreateElement("ProdCod");
        //        alt.AppendChild(prodcod);
        //        prodcod.InnerText = item.prodCod.ToString();

        //        XmlNode listacod = fila.CreateElement("VtexID");
        //        alt.AppendChild(listacod);
        //        listacod.InnerText = item.vtexId.ToString();

        //        XmlNode quantidade = fila.CreateElement("Quantidade");
        //        alt.AppendChild(quantidade);
        //        quantidade.InnerText = item.quantidade.ToString();

        //        XmlNode acao = fila.CreateElement("Acao");
        //        alt.AppendChild(acao);
        //        acao.InnerText = item.acao;
        //    }
        //}


        //public XmlDocument TransformaXmlEnderecoCliente(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    var node = respostaCompleta.ChildNodes[0].ChildNodes[0];
        //    string innerXmlResposta = new Rest().ConverterParaXML(true, node.InnerText, "endereco", null).InnerXml;

        //    XmlDocument respostaXml = new XmlDocument();
        //    respostaXml.LoadXml(innerXmlResposta);

        //    return PreencheDadosDaFilaAposRetornoVtex(respostaXml, fila);

        //}

        //public XmlDocument PreencheFilaListaPedidos(XmlDocument respostaCompleta, XmlDocument fila)
        //{

        //    if (fila["Integrador"]["listaPedidos"] == null)
        //        fila["Integrador"].AppendChild(fila.CreateElement("listaPedidos"));

        //    foreach (XmlNode item in respostaCompleta["listaPedidos"].ChildNodes)
        //    {
        //        if (item.Name.ToUpper() == "LIST")
        //        {
        //            var node = fila.ImportNode(item, true);
        //            fila["Integrador"]["listaPedidos"].AppendChild(node);
        //        }
        //    }

        //    fila["Integrador"]["Item"].AppendChild(fila.CreateElement("LastPage"));
        //    fila["Integrador"]["Item"]["LastPage"].InnerXml = respostaCompleta["listaPedidos"]["paging"]["pages"].InnerXml;

        //    return fila;
        //}

        //public XmlDocument GeraItemSePedidoNaoExiste(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    if (respostaCompleta != null && respostaCompleta["Integrador"] != null && respostaCompleta["Integrador"].ChildNodes.Count > 0)
        //    {
        //        return null;
        //    }
        //    return fila;
        //}

        //public XmlDocument IncluiDadosClienteNoPedido(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    var clientResponse = fila.CreateElement("clientProfileResponse");
        //    clientResponse.InnerXml = respostaCompleta["cliente"].InnerXml;
        //    fila.DocumentElement.AppendChild(clientResponse);
        //    return fila;
        //}

        //public XmlDocument IncluiEnderecoClienteNoPedido(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    var node = respostaCompleta.ChildNodes[0].ChildNodes[0];

        //    if (node != null)
        //    {
        //        string innerXmlResposta = new Rest().ConverterParaXML(true, node.InnerText, "endereco", null).InnerXml;

        //        XmlDocument respostaXml = new XmlDocument();
        //        respostaXml.LoadXml(innerXmlResposta);

        //        var clientResponse = fila.CreateElement("addressProfileResponse");
        //        clientResponse.InnerXml = respostaXml["endereco"].InnerXml;
        //        fila.DocumentElement.AppendChild(clientResponse);
        //    }

        //    return fila;
        //}


        //public XmlDocument MantemFilaAnteriorParaProximaIntegracao(XmlDocument respostaCompleta, XmlDocument fila)
        //{
        //    return fila;
        //}

        //public XmlDocument InsereIdPedidoFila(XmlDocument doc, XmlDocument fila)
        //{
        //    var pedidoResponse = fila.CreateElement("pedidoResponse");
        //    pedidoResponse.InnerXml = doc["Integrador"]["Item"].InnerXml;
        //    fila["pedido"].AppendChild(pedidoResponse);

        //    return fila;
        //}

        //public XmlDocument PreencheProdutoTipo(XmlDocument doc, XmlDocument fila)
        //{
        //    var pedidoResponse = fila.CreateElement("pedidoResponse");
        //    pedidoResponse.InnerXml = doc["Integrador"]["Item"].InnerXml;
        //    fila["pedido"].AppendChild(pedidoResponse);

        //    return fila;
        //}
    }
}
