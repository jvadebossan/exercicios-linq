
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex7
    {
        //TODO 7. Quantas admissões temos mensalmente? Faça uma lista ordenada ascendente dos meses e as respectivas quantidades.
        public static void Executar()
        {
            var resultado = Program.funcionarios
            .GroupBy(f => new { f.DataAdmissao.Year, f.DataAdmissao.Month })
            .OrderBy(m => m.Key.Year).ThenBy(m => m.Key.Month)
            .Select(m => new { m.Key, count = m.Count() })
            .ToList();

            foreach (var item in resultado)
            {
                Console.WriteLine($"{item.Key.Month}/{item.Key.Year} - {item.count}");
            }
        }

        // 5 primeiros (para correção)
        // 3/2015 - 3
        // 4/2015 - 10
        // 5/2015 - 4
        // 6/2015 - 4
        // 7/2015 - 6
    }
}
