using MiniSistemaPortfolioInvestimentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos
{
    public class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
    {
        public string Nome { get; set; } = string.Empty;
        public decimal ValorInvestido { get; set; }
        public decimal TaxaAnual { get; set; }
        public DateTime DataAplicacao { get; }
        public DateTime DataVencimento { get; }
        public int DiasDecorridos => (DateTime.Now.Date - DataAplicacao).Days;

        public decimal CalcularRentabilidade()
        {
            return TaxaAnual * (DiasDecorridos / 365m);
        }
        public decimal ValorAtual => ValorInvestido * (1m + (CalcularRentabilidade()/ 100m));
        public int DiasParaVencimento() {

            return (DataVencimento - DateTime.Now.Date).Days;
        }
    }
}
