namespace ProjetoTeste.Application.Clientes.Cadastrar
{
    public interface ICadastrarCliente
    {
        Task CadastrarAsync(CadastrarClienteInputModel inputModel);
    }
}