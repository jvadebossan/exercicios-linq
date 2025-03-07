
using System;
using System.Linq;
using multiplicacao_linq;

namespace Exercicios
{
    public static class Ex16
    {
        //TODO 16. Quem é o funcionário mais recente da empresa?
        public static void Executar()
        {
            var res = Program.funcionarios.OrderByDescending(f => f.DataAdmissao)
            .Take(1)
            .FirstOrDefault();
            //! .ToList()[0]; usei to list para que eu possa acessar o único item

            Console.WriteLine($"O funcionário mais recente é o {res.Nome} que entrou em {res.DataAdmissao.ToString("dd/MM/yyyy")}");

            //O funcionário mais recente é o Theo Cardoso que entrou em 14/02/2025
        }
    }
}