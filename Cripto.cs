using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Interfaces
{
    public class Cripto : IAtivoFinanceiro, IAtivoNegocial
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Quantidade { get; set; } 
        public decimal PrecoMedioCompra { get; set; }
        public decimal PrecoMercado { get; set; }
        public decimal VariacaoDiaria { get; set; }
        public decimal ValorInvestido => Quantidade * PrecoMedioCompra;
        public decimal ValorAtual => Quantidade * PrecoMercado;           

        public decimal CalcularRentabilidade()
        {
            return ((PrecoMercado - PrecoMedioCompra) / PrecoMedioCompra) * 100m;
        }
    }
}
