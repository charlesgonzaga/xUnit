using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Application.Clientes;
using ProjetoTeste.Application.Clientes.Cadastrar;
using ProjetoTeste.Application.Clientes.Listar;
using ProjetoTeste.Application.Commons;
using ProjetoTeste.Infrastructure;
using ProjetoTeste.Infrastructure.Repositories;

namespace xUnit.ProjetoTeste.Integration
{
    public class ClienteApplicationTest
    {
        private readonly ServiceProvider serviceProvider;

        public ClienteApplicationTest()
        {
            PopularBaseEmMemoria();
            serviceProvider = InjetarDependencias();
        }

        [Trait("Integration Test", "ClienteApplication")]
        [Fact(DisplayName = "CadastrarCliente_Sucesso")]
        public async Task CadastrarCliente_Sucesso()
        {
            // Arrange
            var inputModel = new CadastrarClienteInputModel()
            {
                Nome = "Fulaninho",
                Sobrenome = "Do Desconhecido",
                DataNascimento = DateTime.Now.AddYears(-19),
                Ativo = StatusAtivo.Sim
            };

            // Act
            var cadastrarCliente = serviceProvider.GetRequiredService<ICadastrarCliente>();
            await cadastrarCliente.CadastrarAsync(inputModel);

            var listarCliente = serviceProvider.GetRequiredService<IListarCliente>();
            var result = await listarCliente.ListarAsync();

            // Assert
            Assert.True(result.Count > 0);
        }

        #region Metodos Auxiliares

        private static ServiceProvider InjetarDependencias()
        {
            return new ServiceCollection()
                .AddSingleton<ICadastrarCliente, CadastrarCliente>()
                .AddSingleton<IListarCliente, ListarCliente>()
                .AddSingleton<IClienteRepository, ClienteRepository>()
                .AddDbContext<MyContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDB");
                })
                .BuildServiceProvider();
        }

        private static void PopularBaseEmMemoria()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryDB")
                            .Options;

            var myContext = new MyContext(options);
            PopularBase(myContext);

            static void PopularBase(MyContext myContext)
            {
                myContext.ClienteEntity.AddRange(new List<ClienteEntity>()
                    {
                        new ("João", "Da Silva", new DateOnly(1980, 1, 12), StatusAtivo.Sim),
                        new ("Maria", "Da Costa", new DateOnly(2001, 11, 15), StatusAtivo.Sim),
                        new ("Pedro", "Barbosa", new DateOnly(1993, 8, 2), StatusAtivo.Nao),
                        new ("Marta", "De Jesus", new DateOnly(2005, 3, 22), StatusAtivo.Sim)
                    });

                myContext.SaveChanges();
            }
        }

        #endregion
    }
}
