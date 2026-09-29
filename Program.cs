using MiniSistemaPortfolioInvestimentos.Generics;
using MiniSistemaPortfolioInvestimentos.Interfaces;

namespace MiniSistemaPortfolioInvestimentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            var petr4 = new Acao();
            {
                petr4.Nome = "PETR4";
                petr4.Quantidade = 100;
                petr4.PrecoMedioCompra = 30;
                petr4.PrecoMercado = 32.50m;
                petr4.DividendosRecebidos = 100.00m;
                petr4.DividendoPorAcao = 0.80m;
                petr4.Periodicidade = "Trimestral";
                petr4.VariacaoDiaria = 1.35m;
            };

            var portfolio = new Portfolio<IAtivoFinanceiro>();
            portfolio.AdicionarAtivos(petr4);
            Console.WriteLine("=== Portfólio de Investimentos ===");
            Console.WriteLine($"Valor Total:  { portfolio.ValorTotal:C}");
            Console.WriteLine($"Rentabilidade Média Ponderada: {portfolio.CalcularRentabilidadeMediaPonderada():F2}%\n");

            Console.WriteLine("=== Renda Periódica Total ===");
            Console.WriteLine(" Apenas ativos que implementam IGerador de Renda ");
            var geradoresRenda = portfolio.FiltrarPor(a => a is IGeradorDeRenda).Cast<IGeradorDeRenda>();
            decimal rendaTotal = geradoresRenda.Sum(g => g.CalcularRendaPeriodica());
            Console.WriteLine($"{rendaTotal:C}\n");
        }
    }
}
