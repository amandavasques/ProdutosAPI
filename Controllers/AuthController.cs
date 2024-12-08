using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models.Usuarios;
using ProdutosAPI.Services;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            try
            {
                var token = _authService.GerarTokenJWT(login.UserName, login.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
