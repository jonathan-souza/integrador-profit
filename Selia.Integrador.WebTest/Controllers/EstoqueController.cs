using Selia.Integrador.WebTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Selia.Integrador.WebTest.Controllers
{
    public class EstoqueController : ApiController
    {

        // GET api/values
        public IEnumerable<MilleniumResult> Get()
        {
            return new List<MilleniumResult>()
            {
                { new MilleniumResult() { Cor = "Azul", DataAtualizacao = DateTime.Now, DataCompra = DateTime.Now, Empenho = 10.1, Estampa = "Estampa", EstoqueMin = "EstoqueMin", Produto = "Produto A", ReservaNaoVitrine = 10.1, ReservaVitrine = 11.2, Saldo = 50.10, SaldoCompra = 100.10, SaldoNaoVitrine = 120.10, SaldoVitrine = 111.1, Sku = 645423, Tamanho = 10, VitrineProdutoSku = "Vitrine" } },
                { new MilleniumResult() { Cor = "Vermelho", DataAtualizacao = DateTime.Now, DataCompra = DateTime.Now, Empenho = 10.1, Estampa = "Estampa A", EstoqueMin = "EstoqueMin", Produto = "Produto B", ReservaNaoVitrine = 10.1, ReservaVitrine = 11.2, Saldo = 50.10, SaldoCompra = 100.10, SaldoNaoVitrine = 120.10, SaldoVitrine = 111.1, Sku = 654312, Tamanho = 10, VitrineProdutoSku = "Vitrine A" } }
            }.AsEnumerable();
        }

    }
}
