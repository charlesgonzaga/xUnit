using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProjetoTeste.Application.Clientes;
using ProjetoTeste.Application.Commons;
using ProjetoTeste.Infrastructure;
using System.Text;

namespace xUnit.ProjetoTeste.Integration
{
    public class ClienteControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;
        private readonly MyContext myContext;

        public ClienteControllerTest()
        {
            var factory = CriarWebApplicationFactory();
            httpClient = factory.CreateClient();

            var scope = factory.Services.GetService<IServiceScopeFactory>()!.CreateScope();
            myContext = scope.ServiceProvider.GetService<MyContext>()!;

            PopularBaseEmMemoria();
        }

        [Trait("Integration Test", "ClienteController")]
        [Fact(DisplayName = "BuscaTodos_Sucesso")]
        public async Task BuscaTodos_Sucesso()
        {
            // Act
            var response = await httpClient.GetAsync("api/Cliente");

            // Assert
            if (!response.IsSuccessStatusCode)
                Assert.Fail(response.StatusCode.ToString());

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Trait("Integration Test", "ClienteController")]
        [Fact(DisplayName = "FiltrarMaioresDeIdadeAsync_Sucesso")]
        public async Task FiltrarMaioresDeIdadeAsync_Sucesso()
        {
            // Act
            var response = await httpClient.GetAsync("api/Cliente/FiltrarMaioresDeIdadeAsync");

            if (!response.IsSuccessStatusCode)
                Assert.Fail(response.StatusCode.ToString());

            var jsonString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<ClienteEntity>>(jsonString);

            // Assert
            Assert.IsAssignableFrom<List<ClienteEntity>>(result);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Trait("Integration Test", "ClienteController")]
        [Fact(DisplayName = "Cadastrar_Sucesso")]
        public async Task Cadastrar_Sucesso()
        {
            // Act 
            var httpContent = new StringContent(JsonConvert.SerializeObject(new
            {
                Nome = "John",
                Sobrenome = "Doe",
                DataNascimento = DateTime.Now.AddYears(-13),
                Ativo = StatusAtivo.Sim
            }), Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync("api/Cliente", httpContent);

            if (!response.IsSuccessStatusCode)
                Assert.Fail(response.StatusCode.ToString());

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #region Metodos Auxiliares

        private static WebApplicationFactory<Program> CriarWebApplicationFactory()
        {
            return new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MyContext>));
                        services.Remove(descriptor!);

                        services.AddDbContext<MyContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDB");
                        });
                    });
                });
        }

        private void PopularBaseEmMemoria()
        {
            myContext.ClienteEntity.AddRange(new List<ClienteEntity>()
            {
                new ("João", "Da Silva", new DateOnly(1980, 1, 12), StatusAtivo.Sim),
                new ("Pedro", "Barbosa", new DateOnly(1993, 8, 2), StatusAtivo.Nao),
                new ("Marta", "De Jesus", DateOnly.FromDateTime(DateTime.Now.AddYears(-16)), StatusAtivo.Sim),
                new ("Maria", "Da Costa", new DateOnly(2001, 11, 15), StatusAtivo.Sim)
            });

            myContext.SaveChanges();
        }

        #endregion
    }
}
