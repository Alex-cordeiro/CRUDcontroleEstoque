using ControleEstoqueAPI.Models;
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

        // GET: api/<ProdutoController>
        [HttpGet]
        public IActionResult RetornaProdutos()
        {
            var produtosRetornadosService = _produtoService.FindAll();
            if(produtosRetornadosService == null)
               return NotFound();
            return Ok(produtosRetornadosService);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{idProduto}")]
        public IActionResult RetornaProdutoPorId(int idProduto)
        {
            var produtoRetornadoPorIdService = _produtoService.FindById(idProduto);
            if(produtoRetornadoPorIdService == null)
                return BadRequest("Não foi possivel encontrar o produto");
            return Ok(produtoRetornadoPorIdService);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public IActionResult InsereNovoProduto([FromBody] Produto produto)
        {
            var retornoInsert = _produtoService.Insert(produto);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<EstoqueController>/5
        [HttpPut]
        public IActionResult AlteraProduto([FromBody] Produto produto)
        {
            var produtos = produto;
            if(_produtoService.Update(produto))
                return Ok("Registro Inserido");
            return BadRequest("Não foi possivel alterar o produto selecionado!");
        }

        // DELETE api/<EstoqueController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_produtoService.Delete(id))
                return Ok("Registro Inserido");
            return BadRequest("Não foi possivel alterar o produto selecionado!");
        }
    }
}
