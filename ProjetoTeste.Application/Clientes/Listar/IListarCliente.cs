namespace ProjetoTeste.Application.Clientes.Listar;

public interface IListarCliente
{
    Task<List<ClienteEntity>> FiltrarMaioresDeIdadeAsync();
    Task<List<ClienteEntity>> ListarAsync();
}
