using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Application.Clientes.Cadastrar;
using ProjetoTeste.Application.Clientes.Listar;

namespace ProjetoTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IListarCliente listarCliente;
        private readonly ICadastrarCliente cadastrarCliente;

        public ClienteController(IListarCliente listarCliente, ICadastrarCliente cadastrarCliente)
        {
            this.listarCliente = listarCliente;
            this.cadastrarCliente = cadastrarCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await listarCliente.ListarAsync());
        }

        [HttpGet("FiltrarMaioresDeIdadeAsync")]
        public async Task<IActionResult> FiltrarMaioresDeIdadeAsync()
        {
            return Ok(await listarCliente.FiltrarMaioresDeIdadeAsync());
        }

        [HttpPost]
        public async Task Post([FromBody] CadastrarClienteInputModel inputModel)
        {
            await cadastrarCliente.CadastrarAsync(inputModel);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
