using ProjetoTeste.Application.Commons;

namespace ProjetoTeste.Application.Clientes.Cadastrar;

public struct CadastrarClienteInputModel
{
    public string Nome { get; init; } = default!;
    public string Sobrenome { get; init; } = default!;
    public DateTime DataNascimento { get; init; }
    public StatusAtivo Ativo { get; init; }

    public CadastrarClienteInputModel()
    {
        
    }
}
