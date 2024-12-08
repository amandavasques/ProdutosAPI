namespace ProdutosAPI.Models.Produtos
{
    public class ProdutoRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } 
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
