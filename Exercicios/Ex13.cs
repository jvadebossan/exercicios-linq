
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex13
    {
        //TODO 13. Qual funcionário recebe o maior salário dentro de cada departamento?
        public static void Executar()
        {
            var result = Program.funcionarios
            .GroupBy(f => f.Departamento);

            foreach (var res in result)
            {
                var maiorSalario = res.MaxBy(f => f.Salario);
                Console.WriteLine($"{res.Key} - {maiorSalario.Salario:c}");
            }
            // Produção - R$ 19.756,24
            // Comercial - R$ 19.894,69
            // Marketing - R$ 19.920,30
            // Produção - R$ 19.756,24
            // Financeiro - R$ 19.624,53
            // Logística - R$ 19.953,52
            // TI - R$ 19.953,07
            // Recursos Humanos - R$ 19.613,94
            // Jurídico - R$ 19.619,63
        }
    }
}
