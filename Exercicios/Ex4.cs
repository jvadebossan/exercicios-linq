
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex4
    {
        //TODO 4. Qual é o salário médio da empresa?
        public static void Executar()
        {
            var salarios = Program.funcionarios.Select(f => f.Salario).Average();

            Console.WriteLine($"A média salarial é: R${salarios:F2}");
        }

        //A média salarial é: R$11250,35
    }
}
