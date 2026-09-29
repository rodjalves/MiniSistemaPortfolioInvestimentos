using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
{
    public interface IAtivoNegocial
    {
        decimal PrecoMercado { get; }
        decimal VariacaoDiaria { get; } // percentual de variacao do dia
    }
}
