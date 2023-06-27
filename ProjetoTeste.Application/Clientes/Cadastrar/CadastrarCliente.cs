namespace ProjetoTeste.Application.Clientes.Cadastrar;

public class CadastrarCliente : ICadastrarCliente
{
    private readonly IClienteRepository clienteRepository;

    public CadastrarCliente(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task CadastrarAsync(CadastrarClienteInputModel inputModel)
    {
        // logica...

        await clienteRepository.CadastrarAsync(inputModel);

        // logica...
    }
}
