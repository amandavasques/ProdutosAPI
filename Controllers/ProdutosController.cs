using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models.Produtos;
using ProdutosAPI.Services;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly ProdutosService _produtosService;

        public ProdutosController(ProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        // Método GET para obter todos os produtos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtosService.ObterTodos();
                return Ok(produtos);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }

        // Método GET para obter todos os produtos em estoque
        [HttpGet]
        [Route("EmEstoque")]
        public IActionResult GetEmEstoque()
        {
            try
            {
                var produtos = _produtosService.ObterTodos("Em estoque");
                return Ok(produtos);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }

        // Método POST para cadastrar um novo produto
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            try
            {
                var produtosCadastrados = _produtosService.Cadastrar(request);
                return Ok(produtosCadastrados);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }

        }

        // Método DELETE para remover um produto por ID
        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _produtosService.Remover(id);
                return Ok(_produtosService.ObterTodos());
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }

        }

        // Método PUT para atualizar as informações de um produto
        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, Funcionario")]
        public IActionResult Atualizar(ProdutoRequest request, [FromRoute] int id)
        {
            try
            {
                _produtosService.Atualizar(id, request.Nome, request.Descricao, request.Status, request.Preco, request.QuantidadeEstoque);
                return Ok(_produtosService.ObterTodos());
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }

        }
    }
}
