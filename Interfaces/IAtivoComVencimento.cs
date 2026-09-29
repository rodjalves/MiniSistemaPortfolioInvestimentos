using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
// Interface específica: ativos que possuem data de vencimento
{
    public interface IAtivoComVencimento
    {
        DateTime DataVencimento { get; }
        int DiasParaVencimento();
    }
}
