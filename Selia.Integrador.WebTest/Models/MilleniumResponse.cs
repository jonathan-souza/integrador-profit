using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.WebTest.Models
{
    public class MilleniumResponse
    {
        public double Saldo { get; set; }

        public double Empenho { get; set; }

        public string Produto { get; set; }

        public string Cor { get; set; }

        public string Estampa { get; set; }

        public int Tamanho { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public int Sku { get; set; }

        public int VitrineSku { get; set; }

        public double ReservaVitrine { get; set; }

        public double ReservaNaoVitrine { get; set; }

        public DateTime DataCompra { get; set; }

        public double SaldoCompra { get; set; }

        public string EstoqueMinimo { get; set; }
    }
}
