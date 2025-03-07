
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex10
    {
        //TODO 10. Qual é o tempo médio de empresa dos funcionários (em anos)?
        public static void Executar()
        {
            var hj = DateTime.Today;
            var result = Program.funcionarios
            .Select(f => new { AnosEmpresa = (hj - f.DataAdmissao).TotalDays / 365 })
            .Average(f => f.AnosEmpresa);

            Console.WriteLine($"A média de anos na empresa é: {result:F2}");
            //A média de anos na empresa é: 5,21
        }
    }
}
