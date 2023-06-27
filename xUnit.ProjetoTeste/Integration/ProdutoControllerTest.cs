using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Application.Produtos.Listar;
using xUnit.ProjetoTeste.Integration.mocking;

namespace xUnit.ProjetoTeste.Integration
{
    public class ProdutoControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public ProdutoControllerTest()
        {
            var factory = CriarWebApplicationFactory();
            httpClient = factory.CreateClient();
        }

        [Trait("Integration Test", "ProdutoController")]
        [Fact(DisplayName = "BuscaTodos_Sucesso")]
        public async Task BuscaTodos_Sucesso()
        {
            // Act
            var response = await httpClient.GetAsync("api/Produto");

            // Assert
            if (!response.IsSuccessStatusCode)
                Assert.Fail(response.StatusCode.ToString());

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #region Metodos Auxiliares

        private static WebApplicationFactory<Program> CriarWebApplicationFactory()
        {
            return new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureTestServices(services =>
                    {
                        services.AddScoped<IListarProduto, ListarProdutoHttpMock>();
                    });
                });
        }

        #endregion
    }
}
