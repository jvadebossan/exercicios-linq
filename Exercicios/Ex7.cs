
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
                Console.WriteLine($"{item.Key} - {item.count}");
            }
        }
    }
}
