
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex3
    {
        //TODO 3. Quantos funcionários existem em cada departamento
        //TODO EXEMPLO -> o Recursos Humanos – 10 funcionários
        public static void Executar()
        {
            var depts = Program.funcionarios.GroupBy(f => f.Departamento);

            Console.WriteLine("Lista de funcionários por departamento:\n");
            foreach (var groups in depts)
            {
                Console.WriteLine($"{groups.Key} - {groups.Count()} funcionários");
            }
        }

        // Comercial - 73 funcionários
        // Marketing - 66 funcionários
        // Produção - 54 funcionários
        // Financeiro - 65 funcionários
        // Logística - 63 funcionários
        // TI - 57 funcionários
        // Recursos Humanos - 56 funcionários
        // Jurídico - 66 funcionários
    }
}
