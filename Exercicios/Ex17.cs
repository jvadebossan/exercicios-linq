
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex17
    {
        //TODO 17. Qual cargo tem a maior variação salarial (máximo - mínimo)?
        public static void Executar()
        {
            var result = Program.funcionarios.GroupBy(f => f.Cargo);

            foreach (var res in result)
            {
                var salarioMin = res.MinBy(f => f.Salario).Salario;
                var salarioMax = res.MaxBy(f => f.Salario).Salario;
                Console.WriteLine($"{res.Key}: Min {salarioMin:c} - Max {salarioMax:c}");
            }

            // Consultor -  Min R$ 3.809,00 Max R$ 19.424,29
            // Analista -  Min R$ 3.002,97 Max R$ 19.953,52
            // Gerente -  Min R$ 3.287,05 Max R$ 19.920,30
            // Supervisor -  Min R$ 3.679,79 Max R$ 19.686,14
            // Técnico -  Min R$ 3.097,16 Max R$ 19.894,69
            // Desenvolvedor -  Min R$ 3.115,36 Max R$ 19.220,00
            // Coordenador -  Min R$ 3.345,93 Max R$ 19.816,03
            // Especialista -  Min R$ 3.244,53 Max R$ 19.756,24
            // Engenheiro -  Min R$ 3.033,66 Max R$ 19.953,07
        }
    }
}
