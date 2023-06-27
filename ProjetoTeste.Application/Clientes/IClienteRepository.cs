using ProjetoTeste.Application.Clientes.Cadastrar;

namespace ProjetoTeste.Application.Clientes;

public interface IClienteRepository
{
    Task CadastrarAsync(CadastrarClienteInputModel inputModel);
    Task<List<ClienteEntity>> ListarAsync();
    Task<List<ClienteEntity>> FiltrarMaioresDeIdadeAsync();
}
