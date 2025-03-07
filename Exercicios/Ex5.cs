
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex5
    {
        //TODO 5. Faça um TOP 5 dos funcionários com os maiores salários.
        public static void Executar()
        {
            var salarios = Program.funcionarios.OrderByDescending(f => f.Salario).Take(5);

            foreach (var f in salarios)
            {
                Console.WriteLine($"{f.Nome} - {f.Salario:c}");
            }
        }

        // João Miguel Melo - R$ 19.953,52
        // Mariane Oliveira - R$ 19.953,07
        // Nicole Silveira - R$ 19.920,30
        // Pedro Lucas Pereira - R$ 19.894,69
        // Enzo Gabriel Ferreira - R$ 19.816,03
    }
}
