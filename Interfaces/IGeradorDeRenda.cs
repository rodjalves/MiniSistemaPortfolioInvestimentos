using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
{
    public interface IGeradorDeRenda
    {
        decimal CalcularRendaPeriodica();
        string Periodicidade { get; }   
    }
}
