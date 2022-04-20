using ControleEstoqueAPI.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        // GET: api/<EstoqueController>
        [HttpGet]
        public IActionResult RetornaProdutos()
        {
            var produtosRetornadosService = _produtoService.FindAll();
            if(produtosRetornadosService == null)
               return NotFound();
            return Ok(produtosRetornadosService);
        }

        // GET api/<EstoqueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstoqueController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EstoqueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstoqueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
