
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex14
    {
        //TODO 14. Qual é a média salarial de cada estado?
        public static void Executar()
        {
            var result = Program.funcionarios.GroupBy(f => f.Estado);

            foreach (var res in result)
            {
                var media = res.Average(f => f.Salario);
                Console.WriteLine($"{res.Key} - {media:c}");
            }

            // MG - R$ 10.627,84
            // BA - R$ 11.978,86
            // PE - R$ 9.609,85
            // RJ - R$ 11.205,60
            // DF - R$ 11.722,20
            // SC - R$ 12.432,70
            // PR - R$ 10.820,51
            // CE - R$ 11.086,62
            // SP - R$ 10.925,90
            // RS - R$ 11.632,38
        }
    }
}
