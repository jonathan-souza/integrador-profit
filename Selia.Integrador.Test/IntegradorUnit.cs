using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using BS;
using ConnectionMonitor;
using System.Collections.Generic;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class IntegradorUnit
    {
        [TestMethod]
        [TestCategory("Integração DB")]
        public void Dado_ID_Retornar_uma_integracao()
        {
            Model.Integracao model = new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoID(2);
        }

        [TestMethod]
        [TestCategory("Integração DB")]
        public void Dados_Integracao()
        {
            new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoParaExecucao(false);
        }


        [TestMethod]
        [TestCategory("Integração DB")]
        public void Dado_Id_Retornar_uma_interface_rest()
        {
            var model = new Selia.Integrador.DAL.Interface.Rest().Consultar(1);
        }

        [TestMethod]
        public void Roda_Executor_Integracao()
        {
            var integracao = new Integracao();
            integracao.Executar(9);
        }

        [TestMethod]
        [TestCategory("Integração DB")]
        public void Busca_itens_de_estoque()
        {
                try
                {
                    new Integracao().Executar(1, true);
                }
                catch
                {

                }
        }

        [TestMethod]
        [TestCategory("Integração DB")]
        public void Consulta_Produto()
        {
            for (var i = 0; i < 10; i++)
                try
                {
                    new Integracao().Executar(5, true);
                }
                catch
                {

                }
        }

        [TestMethod]
        public void Consulta_Categoria()
        {
            new Integracao().Executar(14);
        }

        [TestMethod]
        public void Consulta_Categoria_2()
        {
            new Integracao().Executar(85);
        }

        [TestMethod]
        public void Insere_Produto()
        {
            Monitor.Instance.Start();
            new Integracao().Executar(6);
        }

        [TestMethod]
        public void Insere_SKU_VTEX()
        {
            new Integracao().Executar(7);
        }

        [TestMethod]
        public void Roda_Consumidor_Integracao()
        {
            var integracao = new Integracao();
            integracao.Executar(5);
        }

        [TestMethod]
        public void Roda_Fluxo_Estoque()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null, 1);
            integracao.Executar(5);
            //integracao.Executar(true, null, 3);
        }

        [TestMethod]
        public void Roda_Fluxo_Categoria()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null, 45);
            //integracao.Executar(true, null, 46);
            integracao.Executar(3);
        }

        [TestMethod]
        public void Roda_Fluxo_Produto_Sku_Preco_Caracteristica()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null   , 4 );
            //integracao.Executar(true, null      , 6 );
            //integracao.Executar(true, null    , 7 );
            //integracao.Executar(true, null    , 17);
            integracao.Executar(8);
            //integracao.Executar(true, null    , 66);
            //integracao.Executar(true, null    , 65);
            //integracao.Executar(true, null    , 3 );
        }

        [TestMethod]
        public void Roda_Fluxo_Lista_Origem_Vtex()
        {
            var integracao = new Integracao();
            integracao.Executar(28, true);

            //integracao.Executar(84);
            //integracao.Executar(true,   null, 33);
            //integracao.Executar(true, null, 47);
            //integracao.Executar(true, null, 48);
            //integracao.Executar(73);
            //integracao.Executar(true, null, 31);
            //integracao.Executar(true, null, 37);
            //integracao.Executar(true, null, 36); // SOAP
            //integracao.Executar(true, null  , 42);
            //integracao.Executar(true, null  , 41);
        }

        [TestMethod]
        public void Roda_Fluxo_Lista_Origem_ERP()
        {
            var integracao = new Integracao();

            //integracao.Executar(false, null, 15);
            integracao.Executar(16, true);
            //integracao.Executar(true, null, 49);
            ////integracao.Executar(true, null, 18); // SOAP


            //integracao.Executar(true, null, 83); //INTEGRACAO REST - CONSULTA LISTA POR ID

            //integracao.Executar(81); // REST - SUBSTITUTA DA 18
            //integracao.Executar(true, null, 19);
            //integracao.Executar(true, null, 21);
            //integracao.Executar(true, null, 22); // SOAP

            //integracao.Executar(true, null, 82);

            //integracao.Executar(true, null  , 3);
        }

        [TestMethod]
        public void Testa_Integracao_Estoque_Reservado()
        {
            var integracao = new Integracao();
            integracao.Executar(999, true);
            //integracao.Executar(998, true);
        }

        [TestMethod]
        public void Roda_Fluxo_Lista_Origem_ERP_So_Capa()
        {
            var integracao = new Integracao();
            integracao.Executar(15);
            //integracao.Executar(true, null, 16);
            //integracao.Executar(true, null, 49);
            //integracao.Executar(true, null, 83);
            //integracao.Executar(true, null, 81);
            //integracao.Executar(true, null, 19);
            //integracao.Executar(true, null, 3);

            //integracao.Executar(true, null, 82);
        }

        [TestMethod]
        public void Roda_Fluxo_Imagens_Produto()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null, 50);
            //integracao.Executar(51);
            integracao.Executar(180);
            //integracao.Executar(true, null, 53);
            //integracao.Executar(true, null, 52);
            //integracao.Executar(true, null, 54);
            //integracao.Executar(true, null, 64);
        }

        [TestMethod]
        public void Roda_Fluxo_Descida_Pedido()
        {
            var integracao = new Integracao();
            //integracao.Executar(55);
            integracao.Executar(56);
        }

        [TestMethod]
        public void Roda_Fluxo_Descida_Pedido_Boleto()
        {
            var integracao = new Integracao();
            //integracao.Executar(77);
            //integracao.Executar(true, null, 76);
            //integracao.Executar(true, null, 57);
            //integracao.Executar(true, null, 58);
            //integracao.Executar(true, null, 59);
            integracao.Executar(60);
            //integracao.Executar(true, null, 63);
            //integracao.Executar(true, null, 52);
            //integracao.Executar(true, null, 54);
            //integracao.Executar(true, null, 79);
        }

        [TestMethod]
        public void Consultar_Lancamento()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null, 70);
            integracao.Executar(71);
        }

        [TestMethod]
        public void email()
        {
            var integracao = new Integracao();
            //integracao.Executar(false, null, 70);
            integracao.Executar(75);
        }

        [TestMethod]
        public void Consultar_Produto_E_Nome_Categoria()
        {
            var integracao = new Integracao();
            integracao.Executar(25);
        }

        [TestMethod]
        public void Atualiza_Promocao_VTex()
        {
            new Integracao().Executar(17);
        }

        [TestMethod]
        public void Integracao_cliente_CRM()
        {
            //new Integracao().Executar(101, true);
            new Integracao().Executar(102, true);
        }

        [TestMethod]
        public void Integracao_cancelamento_de_pedido()
        {
            new Integracao().Executar(190, true);
            new Integracao().Executar(200, true);
            //new Integracao().Executar(220, true);
        }

        [TestMethod]
        public void Integracao_nova_de_item_vendido()
        {
            new Integracao().Executar(120, true);
            new Integracao().Executar(130, true);
            new Integracao().Executar(150, true);

            //var fila = new Model.Fila();
            //fila.Conteudo = "<Integrador><Response><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><GiftListSkuGetResponse xmlns=\"http://tempuri.org/\"><GiftListSkuGetResult xmlns:a=\"http://schemas.datacontract.org/2004/07/Vtex.Commerce.WebApps.AdminWcfService.Contracts\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:06:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286586</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>63870</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:17:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286589</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>80178</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:22:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286590</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>87726</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:24:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286591</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>84551</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286596</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>75452</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:29:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286599</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>75857</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:30:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286602</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>70401</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:35:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286605</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>10626</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:44:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286622</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>82826</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:46:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286623</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>74346</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:02:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286638</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88650</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:52:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286639</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88533</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286640</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88532</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:56:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286641</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>49136</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:57:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286642</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>86902</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:57:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286643</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>82738</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:58:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286644</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>41600</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:08:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286645</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>87089</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:41:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286646</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>71899</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286647</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>34205</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286648</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>84503</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T02:38:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286649</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>90159</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286705</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39168</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286706</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39168</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286707</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39169</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:56:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286708</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88641</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO></GiftListSkuGetResult></GiftListSkuGetResponse></s:Body></s:Envelope></Response><Item><ID>2988432</ID><ListaCod>960331</ListaCod><ListaProd>84552</ListaProd><ListaQtd>1</ListaQtd><ListaVend>2</ListaVend><ListaRef>2043</ListaRef></Item></Integrador>";
            //var maps = new List<Model.Mapeamento>();
            //var xml = new XmlDocument();
            //xml.LoadXml("<Integrador><Response><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><GiftListSkuGetResponse xmlns=\"http://tempuri.org/\"><GiftListSkuGetResult xmlns:a=\"http://schemas.datacontract.org/2004/07/Vtex.Commerce.WebApps.AdminWcfService.Contracts\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:06:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286586</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>63870</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:17:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286589</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>80178</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:22:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286590</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>87726</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:24:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286591</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>84551</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286596</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>75452</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:29:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286599</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>75857</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:30:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286602</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>70401</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:35:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286605</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>10626</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:44:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286622</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>82826</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-01T23:46:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286623</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>74346</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:02:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286638</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88650</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:52:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286639</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88533</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286640</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88532</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:56:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286641</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>49136</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:57:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286642</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>86902</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:57:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286643</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>82738</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T00:58:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286644</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>41600</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:08:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286645</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>87089</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:41:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286646</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>71899</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286647</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>34205</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T01:53:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286648</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>84503</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-02T02:38:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286649</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>90159</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286705</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39168</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286706</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39168</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:28:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286707</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>39169</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO><a:GiftListStockKeepingUnitDTO><a:DateCreated>2016-11-03T01:56:00</a:DateCreated><a:DatePurchased i:nil=\"true\" /><a:FreightAndServicesValue i:nil=\"true\" /><a:GiftListId>2043</a:GiftListId><a:GiftListSkuId>286708</a:GiftListSkuId><a:InsertedByClientId>0</a:InsertedByClientId><a:InsertedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:InsertedByProfileSystemUserId><a:ItemValue i:nil=\"true\" /><a:OmsOrderId i:nil=\"true\" /><a:OrderId i:nil=\"true\" /><a:OrderMessage i:nil=\"true\" /><a:OrderMessageFrom i:nil=\"true\" /><a:OrderMessageTo i:nil=\"true\" /><a:OrderResponseMessage i:nil=\"true\" /><a:SkuId>88641</a:SkuId><a:WishedByClientId i:nil=\"true\" /><a:WishedByProfileSystemUserId>9c004f53-f643-470c-b189-9187ef77ebde</a:WishedByProfileSystemUserId><a:_IsOrderFinished i:nil=\"true\" /></a:GiftListStockKeepingUnitDTO></GiftListSkuGetResult></GiftListSkuGetResponse></s:Body></s:Envelope></Response><Item><ID>2988432</ID><ListaCod>960331</ListaCod><ListaProd>84552</ListaProd><ListaQtd>1</ListaQtd><ListaVend>2</ListaVend><ListaRef>2043</ListaRef></Item></Integrador>");

            //new SantaHelena.AcaoEnfileiramento().GerarFilasDeModificacaoDeQuantidadeVendida(fila, maps, xml.DocumentElement);

        }

        [TestMethod]
        public void Integracao_nova_remocao_estoque_logupdate()
        {
            new Integracao().Executar(1005, true);
        }

        [TestMethod]
        public void Testar_Roteamento_De_Status_De_Pedido_Boleto()
        {
            new Integracao().Executar(78, true);
            new Integracao().Executar(80, true);
        }
    }
}
