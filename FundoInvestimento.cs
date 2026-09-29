using MiniSistemaPortfolioInvestimentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos
{
    public class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
    {
        public string Nome { get; set; } = string.Empty;
        public decimal QuantidadeCotas { get; set; }
        public decimal ValorCotaCompra { get; set; }
        public decimal ValorCotaAtual { get; set; }
        public decimal TaxaAdministracao { get; set; }
        public decimal RendimentoPorCota { get; set; }
        public string Periodicidade { get; set; } = string.Empty;
        public decimal ValorInvestido => QuantidadeCotas * ValorCotaCompra;
        public decimal ValorAtual => QuantidadeCotas * ValorCotaAtual;
        public decimal CalcularRendaPeriodica()
        {
            return QuantidadeCotas * RendimentoPorCota; 
        }
        public decimal CalcularRentabilidade()
        {
            return ((ValorCotaAtual - ValorCotaCompra) / ValorCotaCompra * 100m);
        }
    }
}
