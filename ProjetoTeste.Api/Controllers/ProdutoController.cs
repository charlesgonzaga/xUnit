using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Application.Produtos.Listar;

namespace ProjetoTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IListarProduto listarProduto;

        public ProdutoController(IListarProduto listarProduto)
        {
            this.listarProduto = listarProduto;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await listarProduto.ListarAsync();
            return Ok(produtos);
        }
    }
}
