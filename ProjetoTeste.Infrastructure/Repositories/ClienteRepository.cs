using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Application.Clientes;
using ProjetoTeste.Application.Clientes.Cadastrar;

namespace ProjetoTeste.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly MyContext myContext;

    public ClienteRepository(MyContext myContext)
    {
        this.myContext = myContext;
    }

    public async Task CadastrarAsync(CadastrarClienteInputModel inputModel)
    {
        await myContext.AddAsync((ClienteEntity)inputModel);
        myContext.SaveChanges();
    }

    public async Task<bool> Inativar()
    {
        return await Task.FromResult(true);
    }

    public async Task<List<ClienteEntity>> ListarAsync()
    {
        return await myContext.ClienteEntity.ToListAsync();
    }

    public async Task<List<ClienteEntity>> FiltrarMaioresDeIdadeAsync()
    {
        var dataLimite = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));

        return await myContext.ClienteEntity
                .Where(w => w.DataNascimento.CompareTo(dataLimite) <= 0)
                .ToListAsync();
    }

    public async Task<bool> Reativar()
    {
        return await Task.FromResult(true);
    }
}
