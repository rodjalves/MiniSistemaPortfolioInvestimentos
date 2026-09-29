using MiniSistemaPortfolioInvestimentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Generics
{
    public class Portfolio<T> where T : IAtivoFinanceiro
    {
        private readonly List<T> _ativos = new List<T>();
        public void AdicionarAtivos(T ativo)
        {
            _ativos.Add(ativo);
        }
        public decimal ValorTotal => _ativos.Sum(a => a.ValorAtual);
        public decimal CalcularRentabilidadeMediaPonderada()
        {
            var valorTotal = ValorTotal;
            if (valorTotal == 0) return 0;
            
            return _ativos.Sum(a => a.CalcularRentabilidade() * a.ValorAtual) / valorTotal;                 
        }
        public IEnumerable<T> FiltrarPor(Func<T, bool> predicado)
        {
            return _ativos.Where(predicado);
        }
        public IEnumerable<T> ObterTodosAtivos() => _ativos; 
    }
}
