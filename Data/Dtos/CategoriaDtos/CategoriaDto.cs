using RestauranteNascimento.Models;

namespace RestauranteNascimento.Data.Dtos.CategoriaDtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string NomeCat { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
