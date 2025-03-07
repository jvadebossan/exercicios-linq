
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex15
    {
        //TODO 15. Liste os funcionários admitidos antes de 2015 (mudei pra 2016).
        public static void Executar()
        {
            var result = Program.funcionarios.Where(f => f.DataAdmissao.Year < 2016);

            Console.WriteLine($"Total de {result.Count()} funcionarios");
            foreach (var res in result)
            {
                Console.WriteLine($"Nome: {res.Nome}");
            }

            // Total de 51 funcionarios (mostrei apenas os 4 primeiros para correção)
            // Nome: Diego Souza
            // Nome: Maitê da Cunha
            // Nome: Ana Clara Jesus
            // Nome: Antônio da Mata
        }
    }
}
