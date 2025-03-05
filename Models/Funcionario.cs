using System;

namespace multiplicacao_linq.Models;

public class Funcionario
{
    public string Id { get; protected set; }
    public string Nome { get; protected set; }
    public string Cargo { get; protected set; }
    public string Departamento { get; protected set; }
    public DateTime DataAdmissao { get; protected set; }
    public decimal Salario { get; protected set; }
    public string Cidade { get; protected set; }
    public string Estado { get; protected set; }

    public Funcionario(string id, string nome, string cargo, string departamento, DateTime dataAdmissao, decimal salario, string cidade, string estado)
    {
        SetId(id);
        SetNome(nome);
        SetCargo(cargo);
        SetDepartamento(departamento);
        SetDataAdmissao(dataAdmissao);
        SetSalario(salario);
        SetCidade(cidade);
        SetEstado(estado);
    }

    public void SetId(string id)
    {
        Id = id;
    }
    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome deve ser preenchido");
        if (nome.Length > 255)
            throw new Exception("O nome pode ter no máximo 255 caracteres.");

        Nome = nome;
    }

    public void SetCargo(string cargo)
    {
        if (string.IsNullOrWhiteSpace(cargo))
            throw new Exception("O cargo deve ser preenchido");
        if (cargo.Length > 255)
            throw new Exception("O cargo pode ter no máximo 255 caracteres.");

        Cargo = cargo;
    }

    public void SetDepartamento(string departamento)
    {
        if (string.IsNullOrWhiteSpace(departamento))
            throw new Exception("O departamento deve ser preenchido");
        if (departamento.Length > 255)
            throw new Exception("O departamento pode ter no máximo 255 caracteres.");

        Departamento = departamento;
    }

    public void SetDataAdmissao(DateTime dataAdmissao)
    {
        if (dataAdmissao == DateTime.MinValue)
            throw new Exception("Data inválida");
        if (dataAdmissao > DateTime.Now)
            throw new Exception("A data não pode estar no futuro");
        DataAdmissao = dataAdmissao;
    }

    public void SetSalario(decimal salario)
    {
        if (salario <= 0)
            throw new Exception("O salario deve ser maior que 0");

        Salario = salario;
    }

    public void SetCidade(string cidade)
    {
        if (string.IsNullOrWhiteSpace(cidade))
            throw new Exception("O cidade deve ser preenchido");
        if (cidade.Length > 255)
            throw new Exception("O cidade pode ter no máximo 255 caracteres.");

        Cidade = cidade;
    }

    public void SetEstado(string estado)
    {
        if (string.IsNullOrWhiteSpace(estado))
            throw new Exception("O estado deve ser preenchido");
        if (estado.Length > 255)
            throw new Exception("O estado pode ter no máximo 255 caracteres.");

        Estado = estado;
    }


}
