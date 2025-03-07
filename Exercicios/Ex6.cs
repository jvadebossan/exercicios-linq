
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex6
    {
        //TODO 6. Quais são os 3 departamentos com os maiores salários médios?
        public static void Executar()
        {
            var depts = Program.funcionarios
            .GroupBy(f => f.Departamento)
            .OrderByDescending(d => d
            .Average(a => a.Salario))
            .Take(3);

            foreach (var f in depts)
            {
                Console.WriteLine($"{f.Key} - {f.Average(a => a.Salario):c}");
            }
        }
    }
}
