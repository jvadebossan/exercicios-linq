
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
    }
}
