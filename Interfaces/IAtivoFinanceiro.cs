using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
{
    public interface IAtivoFinanceiro
    {
        string Nome { get; }
        decimal ValorInvestido { get; }
        decimal ValorAtual { get; }
        decimal CalcularRentabilidade();

    }
}
