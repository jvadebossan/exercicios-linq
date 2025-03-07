using System;
using Microsoft.VisualBasic;
using multiplicacao_linq.Models;
using NPOI.SS.UserModel;

namespace Program;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ImportarDadosExcel();
        //Ex1();
        //Ex2();
        //Ex3();
        //Ex4();
        //Ex5();
        //Ex6();
        //Ex7();
        //Ex8();
        //Ex9();
        //Ex10();
        //Ex11();
        //Ex12();
        //Ex13();
        //Ex14();
        //Ex15();
        Ex16();
        //Ex7();
    }

    private static string filePath = Path.Combine(Environment.CurrentDirectory, "Funcionarios.xlsx");


    private static List<Funcionario> funcionarios = [];

    private static void ImportarDadosExcel()
    {
        try
        {
            //* IWorkbook abstração de pasta de trabalho no excel
            //* WorkbookFactory implementação pra fabricar objetos para Iworkbook (.xls e .xlsx)
            IWorkbook wd = WorkbookFactory.Create(filePath);

            ISheet planilha = wd.GetSheetAt(0);

            for (int i = 1; i < planilha.PhysicalNumberOfRows; i++)
            {
                IRow linha = planilha.GetRow(i);

                string id = linha.GetCell(0).StringCellValue;
                string nome = linha.GetCell(1).StringCellValue;
                string cargo = linha.GetCell(2).StringCellValue;
                string departamento = linha.GetCell(3).StringCellValue;
                DateTime dataAdmissao = linha.GetCell(4).DateCellValue ?? DateTime.Now;
                decimal salario = (decimal)linha.GetCell(5).NumericCellValue;
                string cidade = linha.GetCell(6).StringCellValue;
                string estado = linha.GetCell(7).StringCellValue;

                Funcionario funcionario = new Funcionario(id, nome, cargo, departamento, dataAdmissao, salario, cidade, estado);

                funcionarios.Add(funcionario);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    //TODO 1. Quantos funcionários com nomes distintos existem na empresa?
    private static void Ex1()
    {
        var nomes = funcionarios.Select(f => f.Nome);

        var quant = nomes.Distinct().Count();
        Console.WriteLine($"{quant} funcionarios com nomes distintos.");
    }

    //TODO 2. Liste os funcionários ordenados pelo nome.
    private static void Ex2()
    {
        var nomes = funcionarios.OrderBy(f => f.Nome);

        foreach (var n in nomes)
        {
            Console.WriteLine(n.Nome);
        }
    }

    //TODO 3. Quantos funcionários existem em cada departamento
    //TODO EXEMPLO -> o Recursos Humanos – 10 funcionários
    private static void Ex3()
    {
        var depts = funcionarios.GroupBy(f => f.Departamento);

        Console.WriteLine("Lista de funcionários por departamento:\n");
        foreach (var groups in depts)
        {
            Console.WriteLine($"{groups.Key} - {groups.Count()} funcionários");

        }
    }

    //TODO 4. Qual é o salário médio da empresa?
    private static void Ex4()
    {
        var salarios = funcionarios.Select(f => f.Salario)
        .Average();

        Console.WriteLine($"A média salarial é: R${salarios:F2}");
    }

    //TODO 5. Faça um TOP 5 dos funcionários com os maiores salários.
    private static void Ex5()
    {
        var salarios = funcionarios
        .OrderByDescending(f => f.Salario).Take(5);

        foreach (var f in salarios)
        {
            Console.WriteLine($"{f.Nome} - {f.Salario:c}");
        }
    }

    //TODO 6. Quais são os 3 departamentos com os maiores salários médios?
    private static void Ex6()
    {
        var depts = funcionarios
        .GroupBy(f => f.Departamento)
        .OrderByDescending(d => d
        .Average(a => a.Salario))
        .Take(3);

        foreach (var f in depts)
        {
            Console.WriteLine($"{f.Key} - {f.Average(a => a.Salario):c}");
        }
    }

    //TODO 7. Quantas admissões temos mensalmente? Faça uma lista ordenada ascendente dos meses e as respectivas quantidades.
    private static void Ex7()
    {
        var resultado = funcionarios
        .GroupBy(f => new { f.DataAdmissao.Year, f.DataAdmissao.Month })
        .OrderBy(m => m.Key.Year).ThenBy(m => m.Key.Month)
        .Select(m => new { m.Key, count = m.Count() })
        .ToList();

        foreach (var item in resultado)
        {
            Console.WriteLine($"{item.Key} - {item.count}");
        }
    }

    //TODO 8. Quantos funcionários foram admitidos nos últimos 12 meses?
    static void Ex8()
    {
        //! forma não otimizada
        // var resultado = funcionarios
        // .GroupBy(f => new { f.DataAdmissao.Year, f.DataAdmissao.Month })
        // .OrderByDescending(m => m.Key.Year).ThenByDescending(m => m.Key.Month)
        // .Take(12)
        // .ToList();

        // var total = 0;

        // foreach (var item in resultado)
        // {   
        //     Console.WriteLine(item.Count());
        //     total += item.Count();
        // }

        // Console.WriteLine($"Total: {total}");

        //? Forma Otimizada
        var dataLimite = DateTime.Today.AddYears(-1);

        var result = funcionarios
        .Count(f => f.DataAdmissao >= dataLimite);

        Console.WriteLine($"Total: {result}");
        //Total: 48
    }

    //TODO 9. Quem são os 3 funcionários mais antigos na empresa?
    static void Ex9()
    {
        var result = funcionarios
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

    //TODO 10. Qual é o tempo médio de empresa dos funcionários (em anos)?
    static void Ex10()
    {
        var hj = DateTime.Today;
        var result = funcionarios
        .Select(f => new { AnosEmpresa = (hj - f.DataAdmissao).TotalDays / 365 })
        .Average(f => f.AnosEmpresa);

        Console.WriteLine($"A média de anos na empresa é: {result:F2}");
        //A média de anos na empresa é: 5,21
    }

    //TODO 11. Quantos funcionários existem em cada estado?
    static void Ex11()
    {
        var result = funcionarios
        .GroupBy(f => f.Estado)
        .OrderByDescending(f => f.Count());

        foreach (var res in result)
        {
            Console.WriteLine($"{res.Key} tem {res.Count()} funcionários");
        }
        // SP tem 67 funcionários
        // RJ tem 63 funcionários
        // SC tem 55 funcionários
        // RS tem 55 funcionários
        // PR tem 50 funcionários
        // BA tem 47 funcionários
        // DF tem 45 funcionários
        // CE tem 43 funcionários
        // PE tem 41 funcionários
        // MG tem 34 funcionários
    }

    //TODO 12. Liste os 3 cargos mais comuns na empresa.
    static void Ex12()
    {
        var result = funcionarios
        .GroupBy(f => f.Cargo)
        .OrderByDescending(f => f.Count())
        .Take(3);

        foreach (var res in result)
        {
            Console.WriteLine($"{res.Key} - {res.Count()}");
        }
        //Resultado
        //Técnico - 67
        // Analista - 60
        // Supervisor - 60
    }

    //TODO 13. Qual funcionário recebe o maior salário dentro de cada departamento?
    static void Ex13()
    {
        var result = funcionarios
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

    //TODO 14. Qual é a média salarial de cada estado?
    static void Ex14()
    {
        var result = funcionarios.GroupBy(f => f.Estado);

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

    //TODO 15. Liste os funcionários admitidos antes de 2015 (mudei pra 2016).
    static void Ex15()
    {
        var result = funcionarios.Where(f => f.DataAdmissao.Year < 2016);

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

    //TODO 16. Quem é o funcionário mais recente da empresa?
    static void Ex16()
    {
        var res = funcionarios.OrderByDescending(f => f.DataAdmissao)
        .Take(1).ToList()[0]; //usei to list para que eu possa acessar o único item

        Console.WriteLine($"O funcionário mais recente é o {res.Nome} que entrou em {res.DataAdmissao.ToString("dd/MM/yyyy")}");

        //O funcionário mais recente é o Theo Cardoso que entrou em 14/02/2025
    }

    //TODO 17. Qual cargo tem a maior variação salarial (máximo - mínimo)?
    static void Ex17() { }
}
