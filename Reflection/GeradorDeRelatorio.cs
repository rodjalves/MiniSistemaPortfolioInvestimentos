using MiniSistemaPortfolioInvestimentos.Generics;
using MiniSistemaPortfolioInvestimentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistemaPortfolioInvestimentos.Reflection
{
    public static class GeradorDeRelatorio
    {
        public static void Gerar<T>(Portfolio<T> portfolio) where T : IAtivoFinanceiro
        {
            var interfacesEspecificas = new[]
            {
                nameof(IAtivoComVencimento),
                nameof(IGeradorDeRenda),
                nameof(IAtivoNegocial)
            };
            foreach (var ativo in portfolio.ObterTodosAtivos())
            {
                Type type = ativo.GetType();
                Console.WriteLine($"Tipo: {type.Name}");

                PropertyInfo[] propriedades = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in propriedades)
                {
                    var valor = prop.GetValue(ativo);
                    if (valor is decimal decVal)
                    {
                        if (prop.Name.Contains("Taxa") || prop.Name.Contains("Variação"))
                            Console.WriteLine($" {prop.Name}: {decVal:F2}%");
                        else
                            Console.WriteLine($" {prop.Name}: {decVal:N2}");

                    }
                    else if (valor is DateTime dtVal)
                    {
                        Console.WriteLine($" {prop.Name}: {dtVal:dd/MM/yyyy}");
                    }
                    else
                    {
                        Console.WriteLine($" {prop.Name}: {valor}");
                    }
                }
                Console.WriteLine($" Rentabilidade: {ativo.CalcularRentabilidade():F2}%");

                var interfacesImplementadas = type.GetInterfaces()
                                                .Select(i => i.Name)
                                                .Intersect(interfacesEspecificas)
                                                .ToList();
                if (interfacesImplementadas.Any())
                {
                    Console.WriteLine($" -> Implementa: {string.Join(", ", interfacesImplementadas)}");
                }
                Console.WriteLine();
            }
        }
    }
}
