namespace ProjetoTeste.Application.Produtos.Listar;

public interface IListarProduto
{
    Task<List<ProdutoEntity>> ListarAsync();
}
