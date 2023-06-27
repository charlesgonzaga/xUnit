using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Application.Clientes;

namespace ProjetoTeste.Infrastructure;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public DbSet<ClienteEntity> ClienteEntity { get; set; } = default!;
}
