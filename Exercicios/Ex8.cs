
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex8
    {
        //TODO 8. Quantos funcionários foram admitidos nos últimos 12 meses?
        public static void Executar()
        {
            //! forma não otimizada
            // var resultado = Program.funcionarios
            // .GroupBy(f => new { f.DataAdmissao.Year, f.DataAdmissao.Month })
            // .OrderByDescending(m => m.Key.Year).ThenByDescending(m => m.Key.Month)
            // .Take(12)
            // .ToList();

            // var total = 0;

            // foreach (var item in resultado)
            // {   
            //     Console.WriteLine(item.Count());
            //     total += item.Count();
            // }

            // Console.WriteLine($"Total: {total}");

            //? Forma Otimizada
            var dataLimite = DateTime.Today.AddYears(-1);

            var result = Program.funcionarios
            .Count(f => f.DataAdmissao >= dataLimite);

            Console.WriteLine($"Total: {result}");
            
            //Total: 48
        }
    }
}
