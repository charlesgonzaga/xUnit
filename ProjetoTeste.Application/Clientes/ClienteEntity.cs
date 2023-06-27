using ProjetoTeste.Application.Clientes.Cadastrar;
using ProjetoTeste.Application.Commons;

namespace ProjetoTeste.Application.Clientes;

public record ClienteEntity
{
    public int Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Sobrenome { get; init; } = default!;
    public DateOnly DataNascimento { get; init; }
    public StatusAtivo Ativo { get; init; }

    public ClienteEntity()
    {
    }

    public ClienteEntity(string nome, string sobrenome, DateOnly dataNascimento, StatusAtivo status)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        DataNascimento = dataNascimento;
        Ativo = status;
    }

    public bool EhMaiorDeIdade()
    {
        var dataLimite = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
        var data = DataNascimento.CompareTo(dataLimite);

        // Menor que zero > DataNascimento é anterior a data de comparação
        // Zero > DataNascimento é igual a data de comparação
        // Maior que zero > DataNascimento é posterior a data de comparação
        return data <= 0;
    }

    public static explicit operator ClienteEntity(CadastrarClienteInputModel inputModel)
    {
        return new ClienteEntity(
            inputModel.Nome, 
            inputModel.Sobrenome,
            DateOnly.FromDateTime(inputModel.DataNascimento), 
            inputModel.Ativo);
    }
}
