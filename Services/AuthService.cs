using Azure.Identity;
using Microsoft.IdentityModel.Tokens;
using ProdutosAPI.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProdutosAPI.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public string GerarTokenJWT(string username, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.UserName == username);
            if (usuario == null) throw new Exception("Usuario nao encontrado.");

            if (usuario.Password != password)
            {
                throw new Exception("Password Incorreto.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,usuario.Nome), //Nome do Usuario
                new Claim(ClaimTypes.Role,usuario.Funcao) // Papel do usuario
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("93f8207bc2281eebd070f337f907984bfb4ef2d3f1b08689e2e7e16030c8c5e9"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: "api-autenticacao",
                audience: "api-cadastro",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
