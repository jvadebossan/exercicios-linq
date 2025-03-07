
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex12
    {
        //TODO 12. Liste os 3 cargos mais comuns na empresa.
        public static void Executar()
        {
            var result = Program.funcionarios
            .GroupBy(f => f.Cargo)
            .OrderByDescending(f => f.Count())
            .Take(3);

            foreach (var res in result)
            {
                Console.WriteLine($"{res.Key} - {res.Count()}");
            }
            //Resultado
            //Técnico - 67
            // Analista - 60
            // Supervisor - 60
        }
    }
}
