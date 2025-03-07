
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex9
    {
        //TODO 9. Quem são os 3 funcionários mais antigos na empresa?
        public static void Executar()
        {
            var result = Program.funcionarios
            .OrderBy(f => f.DataAdmissao)
            .Take(3);

            foreach (var f in result)
            {
                Console.WriteLine($"{f.Nome} - {f.DataAdmissao.ToString("dd/MM/yyyy")}");
            }

            //Maitê da Cunha - 07/03/2015
            // Carlos Eduardo Ribeiro - 20/03/2015
            // Davi da Mata - 22/03/2015        
        }
    }
}
