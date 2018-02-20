using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.WebTest.Models
{
    public class MilleniumResult
    {
        public double Saldo { get; set; }

        public double Empenho { get; set; }

        public string Produto { get; set; }

        public string Cor { get; set; }

        public string Estampa { get; set; }

        public int Tamanho { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public int Sku { get; set; }

        public string VitrineProdutoSku { get; set; }

        public double ReservaVitrine { get; set; }

        public double ReservaNaoVitrine { get; set; }

        public double SaldoVitrine { get; set; }

        public double SaldoNaoVitrine { get; set; }

        public DateTime DataCompra { get; set; }

        public double SaldoCompra { get; set; }

        public string EstoqueMin { get; set; }
    }
}
