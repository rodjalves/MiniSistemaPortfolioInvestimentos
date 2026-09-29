using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
{
    public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegocial
    {
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoMedioCompra { get; set; }
        public decimal PrecoMercado { get; set; }
        public decimal DividendosRecebidos { get; set; }
        public decimal DividendoPorAcao { get; set; }
        public string Periodicidade { get; set; } = string.Empty;
        public decimal VariacaoDiaria { get; set; }
        public decimal ValorInvestido => Quantidade * PrecoMedioCompra;
        public decimal ValorAtual => Quantidade * PrecoMercado;
        public decimal CalcularRentabilidade()
        {
            return ((ValorAtual + DividendosRecebidos - ValorInvestido)/ ValorInvestido) * 100m;
        }
        public decimal CalcularRendaPeriodica() => Quantidade * DividendoPorAcao;      
    }
}
