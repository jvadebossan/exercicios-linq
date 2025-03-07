
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex11
    {
        //TODO 11. Quantos funcionários existem em cada estado?
        public static void Executar()
        {
            var result = Program.funcionarios
            .GroupBy(f => f.Estado)
            .OrderByDescending(f => f.Count());

            foreach (var res in result)
            {
                Console.WriteLine($"{res.Key} tem {res.Count()} funcionários");
            }
            // SP tem 67 funcionários
            // RJ tem 63 funcionários
            // SC tem 55 funcionários
            // RS tem 55 funcionários
            // PR tem 50 funcionários
            // BA tem 47 funcionários
            // DF tem 45 funcionários
            // CE tem 43 funcionários
            // PE tem 41 funcionários
            // MG tem 34 funcionários
        }
    }
}
