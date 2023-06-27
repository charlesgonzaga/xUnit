namespace ProjetoTeste.Application.Clientes.Listar;

public class ListarCliente : IListarCliente
{
    private readonly IClienteRepository clienteRepository;

    public ListarCliente(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task<List<ClienteEntity>> ListarAsync()
    {
        // logica ...

        return await clienteRepository.ListarAsync();
    }

    public async Task<List<ClienteEntity>> FiltrarMaioresDeIdadeAsync()
    {
        // logica ...

        return await clienteRepository.FiltrarMaioresDeIdadeAsync();
    }
}
