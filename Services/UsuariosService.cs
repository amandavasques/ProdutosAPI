using Azure.Core;
using ProdutosAPI.Data;
using ProdutosAPI.Models.Usuarios;

namespace ProdutosAPI.Services
{
    public class UsuariosService
    {
        private readonly AppDbContext _context;
        public UsuariosService(AppDbContext context)
        {
            _context = context;
        }

        public List<Usuario> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public List<Usuario> Cadastrar(UsuarioRequest request)
        {
            if (request.Nome == "" || request.Email == "" || request.Funcao == "")
            {
                throw new Exception("Favor entrar com todos os campos obrigatorios.");
            }

            Usuario usuario = new Usuario()
            {
                Nome = request.Nome,
                Email = request.Email,
                Funcao = request.Funcao
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return ObterTodos();
        }

        public void Remover(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null) throw new Exception("Usuario nao encontrado.");

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(int id, string nome, string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null) throw new Exception("Usuario nao encontrado.");

            if (nome == "" || email == "")
            {
                throw new Exception("Favor entrar com todos os campos obrigatorios.");
            }

            usuario.Nome = nome;
            usuario.Email = email;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
