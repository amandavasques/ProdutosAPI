using Azure.Core;
using ProdutosAPI.Data;
using ProdutosAPI.Models.Produtos;

namespace ProdutosAPI.Services
{
    public class ProdutosService
    {
        private readonly AppDbContext _context;
        public ProdutosService(AppDbContext context)
        {
            _context = context;
        }

        // Método para obter todos os produtos
        public List<Produto> ObterTodos()
        {

            return _context.Produtos.ToList();

        }

        // Método para obter todos os produtos
        public List<Produto> ObterTodos(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return _context.Produtos.ToList();
            }

            return _context.Produtos.Where(x => x.Status == status).ToList();
        }

        // Método para cadastrar um novo produto
        public List<Produto> Cadastrar(ProdutoRequest request)
        {

            if (request.Nome == "")
            {
                throw new Exception("O nome do produto não pode estar em branco.");
            }

            if (request.Status != "Em estoque" && request.Status != "Indisponivel")
            {
                throw new Exception("Status invalido.");
            }

            var produto = new Produto()
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Status = request.Status,
                Preco = request.Preco,
                QuantidadeEstoque = request.QuantidadeEstoque
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return ObterTodos();
        }

        // Método para remover um produto
        public void Remover(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        // Método para atualizar um produto
        public void Atualizar(int id, string nome, string descricao, string status, decimal preço, int quantidadeEstoque)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            if (nome == "")
            {
                throw new Exception("O nome do produto não pode estar em branco.");
            }

            if (status != "Em estoque" && status != "Indisponivel")
            {
                throw new Exception("Status invalido.");
            }


            produto.Nome = nome;
            produto.Descricao = descricao;
            produto.Status = status;
            produto.Preco = preço;
            produto.QuantidadeEstoque = quantidadeEstoque;

            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
    }
}
