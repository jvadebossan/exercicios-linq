
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex2
    {
        //TODO 2. Liste os funcionários ordenados pelo nome.
        public static void Executar()
        {
            var nomes = Program.funcionarios.OrderBy(f => f.Nome);
            foreach (var n in nomes) Console.WriteLine(n.Nome);
        }

        // 5 primeiros (para correção)
        // Agatha Porto
        // Agatha Ramos
        // Alana Farias
        // Alana Oliveira
        // Alana Peixoto
    }
}
