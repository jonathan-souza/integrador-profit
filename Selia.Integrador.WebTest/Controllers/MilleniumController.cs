using Selia.Integrador.WebTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Selia.Integrador.WebTest.Controllers
{
    public class MilleniumController : ApiController
    {
        // GET api/values/5
        public MilleniumResponse Get(int id)
        {
            var lst = new List<MilleniumResponse>()
            {
                { new MilleniumResponse() { Cor = "Verde", DataAtualizacao = DateTime.Now, DataCompra = DateTime.Now.AddDays(-10), Empenho = 10.4, Estampa = "Estampa A", EstoqueMinimo = "10", Produto = "Produto A", ReservaNaoVitrine = 10.4, ReservaVitrine = 10.4, Saldo = 100.40, SaldoCompra = 10000.00, Sku = 645423, Tamanho = 10, VitrineSku = 10 } },
                { new MilleniumResponse() { Cor = "Verde", DataAtualizacao = DateTime.Now, DataCompra = DateTime.Now.AddDays(-10), Empenho = 10.4, Estampa = "Estampa B", EstoqueMinimo = "10", Produto = "Produto B", ReservaNaoVitrine = 10.4, ReservaVitrine = 10.4, Saldo = 100.40, SaldoCompra = 10000.00, Sku = 654312, Tamanho = 10, VitrineSku = 10 } }
            };

            return lst.FirstOrDefault(x => x.Sku == id);
        }
    }
}
