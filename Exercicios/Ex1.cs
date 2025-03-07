
using System;
using System.Linq;
using multiplicacao_linq;


namespace Exercicios
{
    public static class Ex1
    {

        //TODO 1. Quantos funcionários com nomes distintos existem na empresa?
        public static void Executar()
        {
            var nomes = Program.funcionarios.Select(f => f.Nome);

            var quant = nomes.Distinct().Count();
            Console.WriteLine($"{quant} funcionarios com nomes distintos.");
        }

        //494 funcionarios com nomes distintos.
    }
}
