
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex17
    {
        //TODO 17. Qual cargo tem a maior variação salarial (máximo - mínimo)?
        public static void Executar()
        {
            var result = Program.funcionarios.GroupBy(f => f.Cargo)
            .Select(f => new { f.Key, variacao = f.MaxBy(f => f.Salario).Salario - f.MinBy(f => f.Salario).Salario })
            .OrderByDescending(f => f.variacao)
            .Take(1).FirstOrDefault();

            Console.WriteLine($"A maior variação é do cargo {result.Key} com {result.variacao:c} de diferença salarial");

            // A maior variação é do cargo Analista com R$ 16.950,55 de diferença salarial
        }
    }
}
