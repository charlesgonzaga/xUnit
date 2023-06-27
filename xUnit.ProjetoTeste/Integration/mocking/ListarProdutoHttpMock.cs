using ProjetoTeste.Application.Produtos;
using ProjetoTeste.Application.Produtos.Listar;
using static ProjetoTeste.Application.Produtos.ProdutoEntity;

namespace xUnit.ProjetoTeste.Integration.mocking;

internal class ListarProdutoHttpMock : IListarProduto
{
    public Task<List<ProdutoEntity>> ListarAsync()
    {
        var listageFake = new List<ProdutoEntity>()
        {
            new()
            {
                Id = 1,
                Title = "Produto Mock 1",
                Price = 39.99M,
                Description = "Teste de mock para produto 1.",
                Category = "Esporte",
                Image = "url da imagem aqui",
                Rating = new RatingEntity() {
                    Rate = 3.8,
                    Count = 679
                }
            },
            new()
            {
                Id = 2,
                Title = "Produto Mock 2",
                Price = 39.99M,
                Description = "Teste de mock para produto 2.",
                Category = "Esporte",
                Image = "url da imagem aqui",
                Rating = new RatingEntity() {
                    Rate = 3.8,
                    Count = 679
                }
            },
        };

        return Task.FromResult(listageFake);
    }
}