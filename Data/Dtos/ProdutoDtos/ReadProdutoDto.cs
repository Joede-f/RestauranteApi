using RestauranteNascimento.Models;

namespace RestauranteNascimento.Data.Dtos.ProdutoDtos
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
