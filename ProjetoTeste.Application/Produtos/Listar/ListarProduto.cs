using System.Net.Http.Json;

namespace ProjetoTeste.Application.Produtos.Listar;

public class ListarProduto : IListarProduto
{
    private readonly HttpClient _httpClient;

    public ListarProduto(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
    }

    public async Task<List<ProdutoEntity>> ListarAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProdutoEntity>>("products");

        return response!;
    }
}
