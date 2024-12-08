using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models.Usuarios;
using ProdutosAPI.Services;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuariosService.ObterTodos();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioRequest request)
        {
            try
            {
                var usuariosCadastrados = _usuariosService.Cadastrar(request);

                return Ok(usuariosCadastrados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _usuariosService.Remover(id);

                return Ok(_usuariosService.ObterTodos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(UsuarioRequest request, [FromRoute] int id)
        {
            try
            {
                _usuariosService.Atualizar(id, request.Nome, request.Email);

                return Ok(_usuariosService.ObterTodos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
