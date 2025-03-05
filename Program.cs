using System;
using multiplicacao_linq.Models;
using NPOI.SS.UserModel;

namespace Program;
class Program
{
    static void Main(string[] args)
    {
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
        Ex11();
        //Ex12();
        //Ex13();
        //Ex14();
        //Ex15();
        //Ex16();
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
        var salarios = funcionarios.Select(f => f.Salario).Average();

        Console.WriteLine($"A média salarial é: R${salarios:F2}");
    }

    //TODO 5. Faça um TOP 5 dos funcionários com os maiores salários.
    private static void Ex5()
    {
        var salarios = funcionarios.OrderByDescending(f => f.Salario).Take(5);

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
        var result = funcionarios.Count(f => f.DataAdmissao >= dataLimite);

        Console.WriteLine($"Total: {result}");
    }

    //TODO 9. Quem são os 3 funcionários mais antigos na empresa?
    static void Ex9()
    {
        var result = funcionarios.OrderBy(f => f.DataAdmissao)
        .Take(3);

        foreach (var f in result)
        {
            Console.WriteLine($"{f.Nome} - {f.DataAdmissao.ToString("dd/MM/yyyy")}");
        }
    }

    //TODO 10. Qual é o tempo médio de empresa dos funcionários (em anos)?
    static void Ex10()
    {
        var hj = DateTime.Today;
        var result = funcionarios.Select(f => new { f.Nome, AnosEmpresa = (hj - f.DataAdmissao).TotalDays / 365 })
        .Average(f => f.AnosEmpresa);

        Console.WriteLine($"A média de anos na empresa é: {result:F2}");

    }

    //TODO 11. Quantos funcionários existem em cada estado?
    static void Ex11() { 
            
    }
}