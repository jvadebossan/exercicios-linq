using System;
using Microsoft.VisualBasic;
using multiplicacao_linq.Models;
using NPOI.SS.UserModel;

namespace multiplicacao_linq;
class Program
{
    private static string filePath = Path.Combine(Environment.CurrentDirectory, "Funcionarios.xlsx");


    public static List<Funcionario> funcionarios = [];

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

    static void Main(string[] args)
    {
        ImportarDadosExcel();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu de Exercícios");
            Console.WriteLine("Selecione o exercício de 1 a 17 ou 0 para sair:");
            var opcao = int.Parse(Console.ReadLine());

            if (opcao == 0) break;

            Console.WriteLine("");
            Type tipo = Type.GetType($"Exercicios.Ex{opcao}");
            var metodo = tipo.GetMethod("Executar");
            metodo.Invoke(null, null);

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
